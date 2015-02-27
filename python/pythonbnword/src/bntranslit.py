#!/usr/bin/env python
import codecs
import re
import anydbm
"""
The main dictionary path
"""
bndictpath = "bn-phonetic.dict"

def createDictionary(pathin):
    filein = codecs.open(pathin, "r", "utf-8")
    text = filein.read()	# Read its contents as one large Unicode string.

    # Stripe any front [ or white char or ending ]
    text = text.strip()
    text = text.strip("[")
    text = text.strip("]")

    pat = r'\]\s*,\s*\['	#find pattern ],[
    r = re.compile(pat)
    a = r.split(text);

    i=0
    for b in a:
        a[i] = b.replace("\s", "").strip().split("\",\"") #strip off any whitespace
        a[i][0] = a[i][0].replace("\"", "")
        a[i][1] = a[i][1].replace("\"", "")
        i = i+1

    # c is the dict
    c = {}
    for b in a:
        c[b[0]]=b[1]	# create Dictionary
    filein.close()	# Close the file.
    return c

def createOutputFile(pathin, pathout):
    """
    create a file containing the replacements
    """
    filein = codecs.open(pathin, "r", "utf-8")
    fileout = codecs.open(pathout, "w", "utf-8")

    text = filein.read()	# Read File

    text = text.strip()
    text = text.strip("[")
    text = text.strip("]")

    pat = r'\]\s*,\s*\['	# Pattern
    r = re.compile(pat)		# Create RE
    a = r.split(text);

    i=0
    for b in a:
        a[i] = b.replace("\s", "").strip().split("\",\"") #strip off any whitespace
        a[i][0] = a[i][0].replace("\"", "")
        a[i][1] = a[i][1].replace("\"", "")
        i = i+1
    for b in a:
        fileout.write(b[0] + "\t" + b[1] + "\n")	
    filein.close()
    fileout.close()
    return

def translit(c):
    """
    A state machine translator. Each time takes a character
    and convert it according to database.
    """
    global fin, fin_s, unfin, unfin_s, bndict, mode, tstr
    if c==" " or c=="\t" or c=="\n":
        tstr = tstr + fin_s + unfin_s + c
        unfin = ""
        unfin_s = ""
        fin = ""
        fin_s = ""
        return

    res = bndict.get(fin + unfin + c, None)
    if res !=None:
        unfin = fin + unfin + c
        unfin_s = res
        fin = ""
        fin_s = ""
    else:
        res = bndict.get(unfin + c, None)
        if res !=None:
            unfin = unfin + c
            unfin_s = res
        else:
            fin = fin + unfin
            fin_s = fin_s + unfin_s
            unfin = c
            unfin_s = bndict.get(c, c)
	return

def createBnDict():
    """
    Initialize the translator engine
    """
    global fin, fin_s, unfin, unfin_s, bndict, mode, tstr
    bndict = createDictionary(bndictpath)
    unfin = ""
    unfin_s = ""
    fin = ""
    fin_s = ""
    tstr = ""

def createRawBnDB():
    """
    Create a new persistent database from the raw inputs
    only use when you need a fresh databse
    """
    db = anydbm.open('bntranslit', 'n')
    mydict = createDictionary(bndictpath)
    for d in mydict.keys():
        db[d.encode('utf-8')] = mydict[d].encode('utf-8')
    db.close()

def dbToBnDict():
    """
    from persistent db create memory dictionary
    """
    global bndict
    try:
        db = anydbm.open('bntranslit', 'w')
    except:
        createRawBnDB()
        db = anydbm.open('bntranslit', 'w')
    #mydict = createDictionary(bndictpath)
    bndict = {}     #Clear
    for d in db.keys():
        bndict[d] = db[d]
    db.close()

def initBnTranslit():
    """
    Initialize Bn translator
    """
    dbToBnDict()
    global fin, fin_s, unfin, unfin_s, bndict, mode, tstr
    unfin = ""
    unfin_s = ""
    fin = ""
    fin_s = ""
    tstr = ""

def convertString(text):
    """
    Convert a string into bangla
    """
    global fin, fin_s, unfin, unfin_s, bndict, mode, tstr
    unfin = ""
    unfin_s = ""
    fin = ""
    fin_s = ""
    tstr = ""
    for c in text:
        translit(c)
    return tstr + fin_s + unfin_s
    
def reset():
    global fin, fin_s, unfin, unfin_s, bndict, mode, tstr
    bnword = tstr + fin_s + unfin_s
    unfin = ""
    unfin_s = ""
    fin = ""
    fin_s = ""
    tstr = ""
    return bnword
