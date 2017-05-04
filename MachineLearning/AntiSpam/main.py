import antispam
import email.parser
import os, sys, stat
import shutil
import html2text
import locale
import codecs

locale.getpreferredencoding(False)
d = antispam.Detector("my_model.dat")

def ExtractSubPayload (filename: object) -> object:
	''' Extract the subject and payload from the .eml file.

	'''
	if not os.path.exists(filename): # dest path doesnot exist
		print("ERROR: input file does not exist:", filename)
		os.exit(1)

	fp = codecs.open(filename, encoding="utf8")

	msg = email.message_from_file(fp)
	payload = msg.get_payload()

	if type(payload) == type(list()) :
		payload = payload[0] # only use t,he first part of payload

	sub = msg.get('subject')
	sub = str(sub)

	if type(payload) != type('') :
		try:
			payload = payload.get_payload()

			if type(payload) == type(list()) :
				payload = payload[0] # only use t,he first part of payload
				payload = payload.get_payload()

			payload = html2text.html2text(payload)
		except:
			pass

	return sub + payload

def ExtractBodyFromDir (srcdir):
    files = os.listdir(srcdir)

    for file in files:
        srcpath = os.path.join(srcdir, file)
        body = ExtractSubPayload(srcpath)

        print(body)

ExtractBodyFromDir ('C:\\Users\\sercanakmaz\\Downloads\\CSDMC2010_SPAM\\TRAINING')

