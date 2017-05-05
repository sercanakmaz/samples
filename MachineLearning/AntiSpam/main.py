import antispam
import email.parser
import os, sys, stat
import shutil
import html2text
import locale
import codecs
import re

myDetector = antispam.Detector("my_model.dat")

def readFile(filePath):
    fp = codecs.open(filePath, encoding="utf8", errors='replace')
    fileText = fp.read()

    fileText = fileText.replace("Subject", "")
    fileText = fileText.replace("subject", "")
    fileText = fileText.replace("to", "")
    fileText = fileText.replace("cc", "")
    fileText = fileText.replace("bcc", "")
    fileText = fileText.replace("from", "")

    fileText = re.sub('[^0-9a-zA-Z-\ ]+', '', fileText)

    return fileText

def train():
    spamFolderPath = 'C:\\Users\\sercanakmaz\\Downloads\\enron3\\spam'
    hamFolderPath = 'C:\\Users\\sercanakmaz\\Downloads\\enron3\\ham'

    spamFiles = os.listdir(spamFolderPath)
    hamFiles = os.listdir(hamFolderPath)

    for file in spamFiles:
        filePath = os.path.join(spamFolderPath, file)

        fileText = readFile(filePath)

        myDetector.train(fileText, True)

    for file in hamFiles:
        filePath = os.path.join(hamFolderPath, file)

        fileText = readFile(filePath)

        myDetector.train(fileText, False)

    myDetector.save()


train()

testFileText = readFile("C:\\Users\\sercanakmaz\\Downloads\\enron1\\spam\\0061.2003-12-21.GP.spam.txt")

print(myDetector.score(testFileText))
print(myDetector.is_spam(testFileText))
