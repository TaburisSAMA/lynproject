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
import xml.dom.minidom
from xmlfapicommon import *
from generator import *

##############################################################################
## XDR Generator                                                             #
##############################################################################
class FapiXdrGenerator(Generator):
    def writePreamble(self, node, indent):
        preamble = cmntHeadLine
        preamble = preamble + getText(node) + "\n\n";
        preamble = preamble + cmntFootLine + "\n"
        preamble = preamble + "/*****************************************************/\n"
        preamble = preamble + "/*   DO NOT TOUCH                                    */\n"
        preamble = preamble + "/*   THIS FILE IS AUTOMAGICALLY GENERATED            */\n"
        preamble = preamble + "/*****************************************************/\n\n"
        return preamble

    def writeImports(self, node, indent):
        parent = node
        while parent.nodeName != "api":
            parent = parent.parentNode
            pass
        fapiName = string.upper(parent.getAttribute("name"))
        imports = ""
        for n in node.getElementsByTagName("import"):
            imports = imports + "%#include \"x_" + string.strip(getText(n))+".h\"\n"
            pass
        return imports + "\n"

    def writeOptBegin(self, node, indent):
        name = node.getAttribute("name")
        return "#ifdef " + name + "\n"

    def writeOptEnd(self, node, indent):
        name = node.getAttribute("name")
        return "#endif /* " + name + " */\n"

    def writeTypedef(self, node, indent):
        return "typedef X_" + node.getAttribute("type") + " X_" + node.getAttribute("name") + ";\n\n"

    def writeStructBegin(self, node, indent):
        return "struct X_%s {\n" % node.getAttribute("type")

    def writeStructEnd(self, node, indent):
        return "};\n\n"

    def writeStructField(self, node, indent):
        type = node.getAttribute("type")
        name = node.getAttribute("name")
        if type[-1] == "*":
            type = type[:-1]
            name = "*" + name
            pass
        if node.hasAttribute("size"):
            size = node.getAttribute("size")
            if isInt(size) == 0:
                field = "X_" + type + " " + name + "[X_" + size + "];"
            else:
                field = "X_" + type + " " + name + "[" + size + "];"
                pass
        else:
            field = "X_" + type + " " + name + ";"
            pass
        return indent + field + "\n"
    pass

    def writeEnumBegin(self, node, indent):
        return "enum X_%s {\n" % node.getAttribute("type")

    def writeEnumEnd(self, node, indent):
        return "};\n\n"

    def writeEnumField(self, node, indent):
        name = node.getAttribute("name")
        if node.hasAttribute("value") and node.getAttribute("value") != "":
            value = string.strip(node.getAttribute("value"))
            if isInt(value):
                value = " = " + value
            else:
                value = " = X_" + value
                pass
            pass
        else:
            value = ""
            pass

        if node.getAttribute("last") == "yes":
            line = "    X_%s%s" % (name, value)
        else:
            line = "    X_%s%s," % (name, value)
            pass
        return line + "\n"

    def writeUnionBegin(self, node, indent):
        type = node.getAttribute("type")
        selectorType = node.getAttribute("selecttype")
        selectorName = node.getAttribute("selectname")
        return "union X_%s switch (X_%s %s) {\n" % (type, selectorType, selectorName)

    def writeUnionEnd(self, node, indent):
        return "};\n\n"

    def writeUnionField(self, node, indent):
        selectors = ""
        for selector in node.getElementsByTagName("selector"):
            if selector.hasAttribute("default") and selector.getAttribute("default") == "yes":
                selectors = "    default:\n"
            else:                
                selectors = selectors + "    case X_" + string.strip(getText(selector)) + ":\n"
                pass
        return selectors + "        " + self.writeStructField(node, indent[:-4])
    
    def writeFuncBegin(self, node, indent):
        name = node.getAttribute("name")
        next = node.nextSibling
        while next.nodeName == "#text":
            next = next.nextSibling
        if next.nodeName == "FuncEnd":
            return ""
        return "struct X_" + name + "_args {\n"

    def writeFuncEnd(self, node, indent):
        prev = node.previousSibling
        while prev.nodeName == "#text":
            prev = prev.previousSibling
        if prev.nodeName == "FuncBegin":
            return ""
        return "};\n\n"

    def writeParam(self, node, indent):
        paramType = node.getAttribute("type")
        paramName = node.getAttribute("name")

        l = node.getElementsByTagName("length")
        if len(l) > 0:
            return "    X_" + paramType + " " + paramName + "<>;\n"
        else:
            return "    X_" + paramType + " " + paramName + ";\n"
        pass

    def writeDefines(self, node, indent):
        defines = ""
        for n in node.getElementsByTagName("field"):
            value = string.strip(getText(n.getElementsByTagName("value")[0]))
            for s in n.getElementsByTagName("depends"):
                symbol = getText(s)
                value = string.replace(value, symbol, "X_"+symbol)
            defines = defines + "%#define X_" + n.getAttribute("name") + " " + value + "\n"
        return defines + "\n"

    def writeApiEnd(self, node, indent):
        return ""

    def writeXdrIds(self, node, indent):
        parent = node
        while parent.nodeName != "api":
            parent = parent.parentNode
            pass
        fapiName = string.capitalize(parent.getAttribute("name")[6:])
        rpcNumbers = "enum Rpc_%s_Fapi_Numbers_t {\n" % fapiName
        list = node.getElementsByTagName("xdrid")
        numList = ""
        for n in list:
            name = n.getAttribute("name")
            if n == list[-1]:
                numList = numList + "  " + name + "\n"
            else:
                numList = numList + "  " + name + ",\n"
                pass
            pass
        if numList == "":
            return ""
        rpcNumbers = rpcNumbers + numList +"};\n\n"
        return rpcNumbers
