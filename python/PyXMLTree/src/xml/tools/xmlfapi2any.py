#!/usr/bin/python
###############################################################################
# INTEL CONFIDENTIAL
#
# Copyright 2001 - 2003 Intel Corporation All Rights Reserved.
#
# The source code contained or described herein and all documents related to
# the source code ("Material") are owned by Intel Corporation or its suppliers
# or licensors.
#
# Title to the Material remains with Intel Corporation or its suppliers and
# licensors. The Material contains trade secrets and proprietary and
# confidential information of Intel or its suppliers and licensors.
# The Material is protected by worldwide copyright and trade secret laws and
# treaty provisions. No part of the Material may be used, copied, reproduced,
# modified, published, uploaded, posted, transmitted, distributed, or disclosed 
# in any way without Intel's prior express written permission.
#
# No license under any patent, copyright, trade secret or other intellectual
# property right is granted to or conferred upon you by disclosure or delivery
# of the Materials, either expressly, by implication, inducement, estoppel or
# otherwise. Any license under such intellectual property rights must be
# express and approved by Intel in writing.
#
###############################################################################

import sys
import os
import string
import getopt

# XML parser
import xml.dom.minidom

# validation for DTD
from xml.parsers.xmlproc import xmlproc
from xml.parsers.xmlproc import xmlval
from xml.parsers.xmlproc import xmldtd

# generators
from fapiHeaderGen import *
from fapiXdrGen import *
from fapiDpWrapperGen import *
from fapiCpWrapperGen import *
from fapiDebugHGen import *
from fapiDebugCppGen import *

##############################################################################
## DTD Validator                                                             #
##############################################################################
class XmlFapiValidator(xmlproc.Application):
  def handle_start_tag(self,name,attrs):
    pass
  def handle_end_tag(self,name):
    pass
  def handle_data(self,data,start,end):
    pass
  def handle_comment(self,data):
    pass

def validate(file):
    print "validating..."
    d = xmldtd.load_dtd(sys.path[0] + "/xmlfapi.dtd")
    p = xmlval.XMLValidator()
    p.set_application(XmlFapiValidator())
    try:
        p.parse_resource(file)
    except:
        sys.stderr.write("Cannot validate XML source\n")
        pass
    pass


##############################################################################
## Main                                                                      #
##############################################################################

DO_VALIDATE_ONLY = 1
DO_GENERATE_HEADER = 2
DO_GENERATE_XDR = 3
DO_GENERATE_DPW = 4
DO_GENERATE_CPW = 5
DO_GENERATE_FAPI_DEBUG_H = 6
DO_GENERATE_FAPI_DEBUG_CPP = 7

def usage():
    sys.stderr.write("FAPI Converter to C header file or XDR file\n")
    sys.stderr.write("Usage: xmlfapi2any.py [-v] -h|-x|-c|-d fapifile.xml [-o outputfile]\n")
    sys.stderr.write("   -v     Validate only\n")
    sys.stderr.write("   -h     Generate header\n")
    sys.stderr.write("   -x     Generate XDR\n")
    sys.stderr.write("   -d     Generate DP wrapper\n")
    sys.stderr.write("   -c     Generate CP wrapper\n")
    sys.stderr.write("   -e     Generate FAPI Debug header\n")
    sys.stderr.write("   -g     Generate FAPI Debug CPP source\n")
    sys.stderr.write("   -o     output filename\n")
    pass


def parseFile(input):
    try:
        fapi = xml.dom.minidom.parse(input)
    except Exception, detail:
        sys.stderr.write("Exception during parsing: " + str(detail) + " \n")
        sys.exit(1)
        pass
    return fapi

def parseString(input):
    try:
        fapi = xml.dom.minidom.parseString(input)
    except Exception, detail:
        sys.stderr.write("Exception during parsing: " + str(detail) + " \n")
        sys.exit(1)
        pass
    return fapi

def checkFapiElem(node):
    for n in node.childNodes:
        if n.nodeType == n.ELEMENT_NODE:
            if ((n.nodeName == "vector")) or (n.hasAttribute("class") and n.getAttribute("class") == "vector"):
                length = n.getElementsByTagName("length")[0]
                #vector length type should be always NPF_uint32_t
                if (length.getAttribute("type") != "NPF_uint32_t"):
                  sys.stderr.write("Wrong vector (" + n.getAttribute("name") + " in " + node.getAttribute("name") + ") length type -> \"" + length.getAttribute("type") + "\" (should be \"NPF_uint32_t\")\n")
                  return 1
            else:
                if (checkFapiElem(n) != 0):
                    return 1
    return 0

def verifyXmlFapiFile(fapiDefinition):
    api = fapiDefinition.getElementsByTagName("api")[0]
    return checkFapiElem(api)

try:
    opts, args = getopt.getopt(sys.argv[1:], "v:h:x:c:d:e:g:o:D:")
except:
    usage()
    sys.exit(2)

action = DO_VALIDATE_ONLY
output = ""
input = ""
oem = "generic"
for o, a in opts:
    if o == "-h":
        action = DO_GENERATE_HEADER
        input = a
    elif o == "-x":
        action = DO_GENERATE_XDR
        input = a
    elif o == "-d":
        action = DO_GENERATE_DPW
        input = a
    elif o == "-c":
        action = DO_GENERATE_CPW
        input = a
    elif o == "-e":
        action = DO_GENERATE_FAPI_DEBUG_H
        input = a
    elif o == "-g":
        action = DO_GENERATE_FAPI_DEBUG_CPP
        input = a
    elif o == "-v":
        action = DO_VALIDATE_ONLY
        input = a
    elif o == "-o":
        output = a
    elif o == "-D":
        oem = a
        pass

if input == "":
    usage()
    sys.exit(2)

if output == "":
    fout = sys.stdout
else:
    fout = open(output, "w")
    pass

#validate(input)

if (verifyXmlFapiFile(parseFile(input)) != 0):
    sys.exit(1)

if action == DO_VALIDATE_ONLY:
    validate(input)
    sys.exit(0)
elif action == DO_GENERATE_HEADER:
    cmd = "xsltproc --novalid --path "+sys.path[0]+" --param output \"\'header\'\" --param oem \"\'" + oem + "\'\" "+sys.path[0]+"/preprocess.xsl " + input
    #print cmd
    hXml = os.popen(cmd).read()
    fapiGen = FapiHeaderGenerator(parseString(hXml))
elif action == DO_GENERATE_XDR:
    cmd = "xsltproc --novalid --param output \"\'xdr\'\" --param oem \"\'" + oem + "\'\" "+sys.path[0]+"/preprocess.xsl " + input
    #print cmd
    xXml = os.popen(cmd).read()
    fapiGen = FapiXdrGenerator(parseString(xXml))
elif action == DO_GENERATE_DPW:
    fapiGen = FapiDpWrapperGenerator(parseFile(input), oem)
elif action == DO_GENERATE_CPW:
    fapiGen = FapiCpWrapperGenerator(parseFile(input), oem)
elif action == DO_GENERATE_FAPI_DEBUG_H:
    fapiGen = FapiDebugHGenerator(parseFile(input), oem)
elif action == DO_GENERATE_FAPI_DEBUG_CPP:
    fapiGen = FapiDebugCppGenerator(parseFile(input), oem)
    pass

fapiGen.generate(fout)
fout.close()
sys.exit(0)

