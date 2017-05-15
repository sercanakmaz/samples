from sklearn.feature_extraction.text import TfidfVectorizer
import pandas
from sklearn import preprocessing
from sklearn import tree
from sklearn.naive_bayes import MultinomialNB

nameFilePath = "C:\\Users\\sercanakmaz\\Desktop\\NameList.csv"

nameList = pandas.read_csv(nameFilePath,
                             sep=";",
                             names=["İsim","Durum"])

label_encoder = preprocessing.LabelEncoder()
vectorizer = TfidfVectorizer(analyzer='char')
tree_model = tree.DecisionTreeClassifier()

# create feature vectors

encodedState = label_encoder.fit_transform(nameList["Durum"][1:])
nameVectors = vectorizer.fit_transform(nameList["İsim"][1:])

# create model

myModel = MultinomialNB().fit(nameVectors, encodedState)

#tree_model.fit(X=nameVectors, y = encodedState)

# create test data

testData = pandas.DataFrame([{ "İsim": "Sercan"}])
testVector = vectorizer.transform(testData["İsim"]);

prediction = myModel.predict(X=testVector)

print(prediction)
