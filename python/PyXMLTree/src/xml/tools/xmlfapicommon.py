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

import string


ELEM_EMBED = 0
ELEM_SEPAR = 1

ELEM_ENUM = 10
ELEM_STRUCT = 11
ELEM_SEL_UNION = 12
ELEM_VECTOR = 13
ELEM_FIELD = 14
ELEM_OPTIONAL = 15
ELEM_OEM = 16
ELEM_SECTION = 17

COMMENT_BLOCK = 1
COMMENT_SIDE = 2

cmntHeadLine  = "/*******************************************************************************\n"
cmntFootLine  = "*******************************************************************************/\n"

def isInt(str):
   """ Is the given string an integer?"""
   try:
      num = int(str)
      return 1
   except ValueError:
      try:
         num = string.atoi(str, 16)
         return 1
      except ValueError:
         return 0
      return 0

def isAttrNotEmpty(node, tag):
   if node.hasAttribute(tag) and node.getAttribute(tag) != "":
      return 1
   else:
      return 0
   pass

def makeSpace(len):
   space = ""
   for i in range(len):
      space = space + " "
      pass
   return space



##############################################################################
## XML Reader                                                                #
##############################################################################
def getText(tag):
   rc = ""
   nodelist = tag.childNodes
   for node in nodelist:
      if node.nodeType == node.TEXT_NODE:
         rc = rc + node.data
   return rc
   
class FapiXmlReader:
    def __init__(self, fapiDefinition):
        self.fapiDef = fapiDefinition
        pass
    
    def __getText(self, nodelist):
        rc = ""
        for node in nodelist:
            if node.nodeType == node.TEXT_NODE:
                rc = rc + node.data
        return string.strip(rc)

    def getPreamble(self):
        return self.__getText(self.fapiDef.getElementsByTagName("preamble")[0].childNodes)

    def getFapiName(self):
        return self.fapiDef.getElementsByTagName("fapiheader")[0].getAttribute("name")

    def getMainComment(self):
        return self.__getText(self.fapiDef.getElementsByTagName("main_comment")[0].childNodes)

    def getComment(self, tag):
        comment_tags = tag.getElementsByTagName("comment")
        if (len(comment_tags) > 0):
            comment = string.strip(self.__getText(comment_tags[0].childNodes))
        else:
            comment = ""
        return comment

    def getValue(self, tag):
        return self.__getText(tag.getElementsByTagName("value")[0].childNodes)

    def getInclude(self, tag):
        return self.__getText(tag.childNodes)

    def getUnion(self, tag):
        return tag.getElementsByTagName("union")[0]

    def hasUnion(self, tag):
        if (tag.hasAttribute("union")):
            if (tag.getAttribute("union") == "yes"):
                return 1
        return 0

    def getReturn(self, tag):
        return self.__getText(tag.getElementsByTagName("return")[0].childNodes)

    def isArray(self, tag):
        if (tag.hasAttribute("array")):
            if (tag.getAttribute("array") == "yes"):
                return 1
        return 0

    def isNotXdrArg(self, tag):
        if (tag.hasAttribute("xdr")):
            if (tag.getAttribute("xdr") == "no"):
                return 1
        return 0

    def isVendor(self, tag):
        if (tag.hasAttribute("vendor")):
            if (tag.getAttribute("vendor") == "yes"):
                return 1
        return 0

    def isNotXdrFunc(self, tag):
        if (tag.hasAttribute("xdr")):
            if (tag.getAttribute("xdr") == "no"):
                return 1
        return 0

