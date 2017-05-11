# Article: http://hamelg.blogspot.com.tr/2015/11/python-for-data-analysis-part-29.html

import numpy as np
import pandas as pd
import os
from sklearn import tree
from sklearn import preprocessing
from IPython.display import Image
from sklearn.cross_validation import train_test_split

titanic_train = pd.read_csv("train.csv")    # Read the data

# Impute median Age for NA Age values
new_age_var = np.where(titanic_train["Age"].isnull(), # Logical check
                       28,                       # Value if check is true
                       titanic_train["Age"])     # Value if check is false

titanic_train["Age"] = new_age_var

# Initialize label encoder
label_encoder = preprocessing.LabelEncoder()

# Convert Sex variable to numeric
encoded_sex = label_encoder.fit_transform(titanic_train["Sex"])

# Initialize model
tree_model = tree.DecisionTreeClassifier()

# Train the model
tree_model.fit(X = pd.DataFrame(encoded_sex),
               y = titanic_train["Survived"])


# Save tree as dot file

with open("tree1.dot", 'w') as f:
    f = tree.export_graphviz(tree_model,
                             feature_names=["Sex"],
                             out_file=f)

preds = tree_model.predict_proba(X = pd.DataFrame(encoded_sex))

print(pd.crosstab(preds[:,0], titanic_train["Sex"]))

# Make data frame of predictors
predictors = pd.DataFrame([encoded_sex, titanic_train["Pclass"]]).T

# Train the model
tree_model.fit(X=predictors,
               y=titanic_train["Survived"])

with open("tree2.dot", "w") as f:
    f = tree.export_graphviz(tree_model,
                             feature_names=["Sex", "Class"],
                             out_file=f)

# Get survival probability
preds = tree_model.predict_proba(X = predictors)

# Create a table of predictions by sex and class
print(pd.crosstab(preds[:,0], columns=[titanic_train["Pclass"],
                                 titanic_train["Sex"]]))


predictors = pd.DataFrame([encoded_sex,
                          titanic_train["Pclass"],
                          titanic_train["Age"],
                          titanic_train["Fare"]]).T

# Initialize model with maximum tree depth set to 8

tree_model = tree.DecisionTreeClassifier(max_depth=8)

tree_model.fit(X = predictors,
               y = titanic_train["Survived"])

with open("tree3.dot", "w") as f:
    f = tree.export_graphviz(tree_model,
                             feature_names=["Sex", "Class", "Age", "Fare"],
                             out_file=f)

print(tree_model.score(X = predictors,
                 y = titanic_train["Survived"]))

# Read and prepare test data
titanic_test = pd.read_csv("test.csv")

# Impute median Age for NA Age values

new_age_var = np.where(titanic_test["Age"].isnull(),
                       28,
                       titanic_test["Age"])

new_fare_var = np.where(titanic_test["Fare"].isnull(),
                        0,
                        titanic_test["Fare"])

titanic_test["Age"] = new_age_var
titanic_test["Fare"] = new_fare_var

# Convert test variables to match model features
encoded_sex_test = label_encoder.fit_transform(titanic_test["Sex"])

test_features = pd.DataFrame([encoded_sex_test,
                              titanic_test["Pclass"],
                              titanic_test["Age"],
                              titanic_test["Fare"]])

test_features.fillna(0)

# Make test set predictions
test_preds = tree_model.predict(X=test_features.T)

# Create a submission for Kaggle
submission = pd.DataFrame({"PassengerId": titanic_test["PassengerId"],
                           "Survived": test_preds})

# Save submission to CSV

submission.to_csv("tutorial_dectree_submission.csv", index=False)

v_train, v_test = train_test_split(titanic_train,
                                   test_size=0.25,
                                   random_state=1,
                                   stratify=titanic_train["Survived"])

# Training set size for validation
print(v_train.shape)
# Test set size for validation
print(v_test.shape)

from sklearn.cross_validation import KFold

cv = KFold(n=len(titanic_train),    # Number of elements
           n_folds=10,              # Desired number of cv folds
           random_state=12)         # Set a random seed

fold_accuracy = []

titanic_train["Sex"] = encoded_sex

for train_fold, valid_fold in cv:
    train = titanic_train[train_fold] # Extract train data with cv indices
    valid = titanic_train[valid_fold] # Extract valid data with cv indices

    model = tree_model.fit(X=train[["Sex", "Pclass", "Age", "Fare"]],
                           y= train["Survived"])
    valid_acc = model.score(X = valid[["Sex", "Pclass", "Age", "Fare"]],
                            y = valid["Survived"])
    fold_accuracy.append(valid_acc)

print("Accuracy per fold: ", fold_accuracy, "\n")
print("Average accuracy: ", sum(fold_accuracy)/len(fold_accuracy))

from sklearn.cross_validation import cross_val_score

scores = cross_val_score(estimator= tree_model,     # Model to test
                X= titanic_train[["Sex","Pclass",   # Train Data
                                  "Age","Fare"]],
                y = titanic_train["Survived"],      # Target variable
                scoring = "accuracy",               # Scoring metric
                cv=10)                              # Cross validation folds

print("Accuracy per fold: ")
print(scores)
print("Average accuracy: ", scores.mean())
