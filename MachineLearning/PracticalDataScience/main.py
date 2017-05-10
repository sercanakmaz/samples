import matplotlib.pyplot as plt
import csv
from textblob import TextBlob
import pandas
import sklearn
import pickle
import numpy as np
from sklearn.feature_extraction.text import CountVectorizer, TfidfTransformer
from sklearn.naive_bayes import MultinomialNB
from sklearn.svm import SVC, LinearSVC
from sklearn.metrics import classification_report, f1_score, accuracy_score, confusion_matrix
from sklearn.pipeline import Pipeline
from sklearn.grid_search import GridSearchCV
from sklearn.cross_validation import StratifiedKFold, cross_val_score, train_test_split
from sklearn.tree import DecisionTreeClassifier
from sklearn.learning_curve import learning_curve


messages = pandas.read_csv('F:\\Repos\\srjohn.git\\samples\\MachineLearning\\PracticalDataScience\\data\\SMSSpamCollection',
                           sep='\t', quoting=csv.QUOTE_NONE,
                           names=["label", "message"])

messages['length'] = messages['message'].map(lambda text: len(text))

def split_into_tokens(message):
    message = message
    return TextBlob(message).words
def split_into_lemmas(message):
    message = message.lower()
    words = TextBlob(message).words
    # for each word, take its "base form" = lemma
    return [word.lemma for word in words]

messages.message.head().apply(split_into_tokens)
messages.message.head().apply(split_into_lemmas)

message4 = messages['message'][14]

bow_transformer = CountVectorizer(analyzer=split_into_lemmas).fit(messages['message'])
bow4 = bow_transformer.transform([message4])
messages_bow = bow_transformer.transform(messages['message'])

tfidf_transformer = TfidfTransformer().fit(messages_bow)
tfidf4 = tfidf_transformer.transform(bow4)
messages_tfidf = tfidf_transformer.transform(messages_bow)

spam_detector = MultinomialNB().fit(messages_tfidf, messages['label'])

print(spam_detector.predict(tfidf4)[0])
