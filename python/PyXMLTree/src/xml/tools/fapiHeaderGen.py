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

#
# Comments
#
cmnt1HeadLine = "/* ==================================================================================\n"
cmnt1FootLine = "\n * ================================================================================== */\n"

cmnt2HeadLine = "/* ----------------------------------------------------------------------------------\n"
cmnt2FootLine = "\n * ---------------------------------------------------------------------------------- */\n"

cmnt3HeadLine = "/* ---------------------------------\n"
cmnt3FootLine = "\n * ------------------- */\n"

cmnt4HeadLine = "/**\n"
cmnt4FootLine = "\n */\n"

class Comments:
    def getSpace(self, str):
        if len(str) < 40:
            width = 40
        else:
            width = len(str) + 1
        return width + 5, makeSpace(width - len(str))

    def putIoType(self, arg):
        argType = arg.getAttribute("io")
        if argType == "in":
            return " IN "
        elif argType == "out":
            return " OUT "
        elif argType == "inout":
            return " INOUT "
        pass

    def wrapComment(self, comment, startCol, endCol, linePrefix, linePrefix2=""):
        lineTab = []
        lineTab = lineTab + [linePrefix + makeSpace(startCol)]
        i = 0
        for word in string.split(comment):
            # estimate line prefix length
            if i == 0:
                linePrefixLen = len(linePrefix)
            else:
                linePrefixLen = len(linePrefix + linePrefix2)
                pass

            # add next word
            if (len(lineTab[i] + " " + word) <= endCol - linePrefixLen): # to current line
                lineTab[i] = lineTab[i] + word + " "
            else:                                                        # to new line
                lineTab[i] = lineTab[i][:-1] # cut last space
                newLine = linePrefix + linePrefix2 + makeSpace(startCol) + word + " "
                lineTab = lineTab + [newLine]                
                i = i + 1
                pass
            pass
        lineTab[-1] = lineTab[-1][:-1] # cut last space in last line
        wrappedLines = ""
        for l in lineTab:
            wrappedLines = wrappedLines + l + "\n"
            pass
        return wrappedLines[startCol:-1]
        
    def handleBlockComments(self, node, head, tail):
        startCol = 0
        endCol = 90
        startPrefix = head
        linePrefix = " * "
        endSuffix = tail
        cmnt = ""

        if isAttrNotEmpty(node, "brief"):
            br = node.getAttribute("brief")
            if br[-1] != ".":
                br = br + "."
            cmnt = cmnt + self.wrapComment(br, startCol, endCol, linePrefix) + "\n"
            pass

        prefix = makeSpace(startCol) + linePrefix
        
        for n in node.childNodes:
            if n.nodeType == n.ELEMENT_NODE:
                if n.nodeName == "descr":
                    if cmnt == "":
                        txt = getText(n)
                        i = string.find(txt, ".") + 1
                        if i != -1:
                            firstSntc = string.strip(txt[:i])
                            rest = string.strip(txt[i:])
                        else:
                            firstSntc = txt
                            rest = ""
                            pass
                        if firstSntc != "":
                            cmnt = cmnt + self.wrapComment(firstSntc, startCol, endCol, linePrefix) + "\n"
                        if rest != "":
                            cmnt = cmnt + self.wrapComment(rest, startCol, endCol, linePrefix) + "\n"
                    else:
                        cmnt = cmnt + self.wrapComment(getText(n), startCol, endCol, linePrefix) + "\n"
                elif n.nodeName == "range":
                    txt = "Range: " + string.strip(getText(n))
                    cmnt = cmnt + self.wrapComment(txt, startCol, endCol, linePrefix) + "\n"
                elif n.nodeName == "default":
                    txt = "Default value: " + string.strip(getText(n)) + "\n"
                    cmnt = cmnt + self.wrapComment(txt, startCol, endCol, linePrefix) + "\n"
                elif n.nodeName == "see":
                    txt = "@see " + string.strip(getText(n)) + "\n"
                    cmnt = cmnt + self.wrapComment(txt, startCol, endCol, linePrefix) + "\n"
                elif n.nodeName == "ref":
                    txt = "@ref " + string.strip(getText(n)) + "\n"
                    cmnt = cmnt + self.wrapComment(txt, startCol, endCol, linePrefix) + "\n"
                elif n.nodeName == "param":
                    param_cmnt = ""
                    if n.hasAttribute("class") and n.getAttribute("class") == "vector":
                        length = n.getElementsByTagName("length")[0]
                        param_cmnt = ""
                        if length.hasAttribute("brief"):
                            param_cmnt = length.getAttribute("brief")
                        if len(length.getElementsByTagName("descr")) > 0:
                            param_cmnt = param_cmnt + getText(length.getElementsByTagName("descr")[0])
                        p = "@param " + length.getAttribute("name") + " - " + " IN " + string.strip(param_cmnt)
                        cmnt = cmnt + self.wrapComment(p, 0, 90, linePrefix, "       ") + "\n"
                        pass
                    pass
                    param_cmnt = ""
                    if isAttrNotEmpty(n, "brief"):
                        param_cmnt = n.getAttribute("brief")
                    if len(n.getElementsByTagName("descr")) > 0:
                        param_cmnt = param_cmnt + getText(n.getElementsByTagName("descr")[0])
                    p = "@param " + n.getAttribute("name") + " - " + self.putIoType(n) + string.strip(param_cmnt)
                    cmnt = cmnt + self.wrapComment(p, 0, 90, linePrefix, "       ") + "\n"
                elif n.nodeName == "return" or n.nodeName == "callback":
                    p = "@" + n.nodeName + " " + getText(n.getElementsByTagName("descr")[0])
                    cmnt = cmnt + self.wrapComment(p, 0, 90, linePrefix) + "\n"
                    for retval in n.childNodes:
                        if retval.nodeType == retval.ELEMENT_NODE and retval.nodeName == "retval":
                            br = ""
                            if isAttrNotEmpty(retval, "brief"):
                                br = retval.getAttribute("brief")
                            d = retval.getElementsByTagName("descr")
                            if len(d) > 0:
                                ret = " - " + retval.getAttribute("name") + " - " + br + getText(d[0])
                            else:
                                ret = " - " + retval.getAttribute("name") + " - " + br
                                pass
                            cmnt = cmnt + self.wrapComment(ret, 0, 90, linePrefix, "       ") + "\n"
                    pass
                pass
            pass

        if cmnt == "":
            return "\n"
        else:
            return startPrefix + cmnt[:-1] + endSuffix
        pass

    def handleSideComments(self, node, start_column):
        val_range = ""
        see = ""
        ref = ""
        param = ""
        ret = ""
        callback = ""
        end_column = 90
        start_prefix, line_prefix, end_suffix = "/*!< ", "", " */\n"

        if isAttrNotEmpty(node, "brief"):
            brief = self.wrapComment(node.getAttribute("brief"), start_column, end_column, line_prefix) + "\n"
        else:
            brief = ""
            pass
        descr = brief

        prefix = makeSpace(start_column) + line_prefix
        
        for n in node.childNodes:
            if n.nodeType == n.ELEMENT_NODE:
                if n.nodeName == "descr":
                    if descr != "":
                        descr = descr + prefix
                        pass
                    descr = descr + self.wrapComment(getText(n), start_column, end_column, line_prefix) + "\n"
                elif n.nodeName == "range":
                    val_range = prefix + "Range: " + string.strip(getText(n)) + "\n"
                elif n.nodeName == "default":
                    default = prefix + "Default value: " + string.strip(getText(n)) + "\n"
                elif n.nodeName == "see":
                    see = prefix + "@see " + string.strip(getText(n)) + "\n"
                elif n.nodeName == "ref":
                    ref = prefix + "@ref " + string.strip(getText(n)) + "\n"
                    pass
                pass
            pass
        comm = descr + val_range + see + ref + param + ret + callback
        if comm == "":
            return "\n"
        else:
            return start_prefix + comm[:-1] + end_suffix
        pass

##############################################################################
## Fapi Header Generator                                                     #
##############################################################################
class FapiHeaderGenerator(Generator, Comments):
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
        imports = "#ifndef %s_H\n#define %s_H\n\n" % (fapiName, fapiName)
        for n in node.getElementsByTagName("import"):
            imports = imports + "#include \"" + string.strip(getText(n))+".h\"\n"
            pass
        imports = imports + "\n\n#ifdef __cplusplus\nextern \"C\" {\n#endif\n\n\n"
        return imports

    def writeOptBegin(self, node, indent):
        name = node.getAttribute("name")
        comments = self.handleSideComments(node, len(name))
        return "#ifdef " + name + "\n    " + comments

    def writeOptEnd(self, node, indent):
        name = node.getAttribute("name")
        return "#endif /* " + name + " */\n"

    def writeSection(self, node, indent):
        #name = node.getAttribute("name")
        level = node.getAttribute("level")
        if level == "1":
            head, tail = cmnt1HeadLine, cmnt1FootLine
        elif level == "2":
            head, tail = cmnt2HeadLine, cmnt2FootLine
        else:
            head, tail = cmnt3HeadLine, cmnt3FootLine
            pass
        return self.handleBlockComments(node, head, tail) + "\n"

    def writeBlockComment(self, node, indent):
        return self.handleBlockComments(node, cmnt4HeadLine, cmnt4FootLine)

    def writeTypedef(self, node, indent):
        return "typedef " + node.getAttribute("type") + " " + node.getAttribute("name") + ";\n\n"

    def writeStructBegin(self, node, indent):
        return "typedef struct {\n"

    def writeStructEnd(self, node, indent):
        return "} %s;\n\n" % node.getAttribute("type")

    def __writeField(self, node, indent):
        type = node.getAttribute("type")
        name = node.getAttribute("name")
        if type[-1] == "*":
            type = type[:-1]
            name = "*" + name
            pass
        if isAttrNotEmpty(node, "size"):
            size = node.getAttribute("size")
            field = indent + type + " " + name + "[" + size + "];"
        else:
            field = indent + type + " " + name + ";"
            pass
        width, space = self.getSpace(field)
        return field + space + self.handleSideComments(node, width)

    def writeStructField(self, node, indent):
        return self.__writeField(node, indent)

    def writeUnionField(self, node, indent):
        return self.__writeField(node, indent)

    def writeEnumBegin(self, node, indent):
        return "typedef enum {\n"

    def writeEnumEnd(self, node, indent):
        return "} %s;\n\n" % node.getAttribute("type")

    def writeEnumField(self, node, indent):
        name = node.getAttribute("name")
        if node.hasAttribute("value") and node.getAttribute("value") != "":
            value = " = " + string.strip(node.getAttribute("value"))
        else:
            value = ""
            pass

        if node.getAttribute("last") == "yes":
            line = "    %s%s" % (name, value)
        else:
            line = "    %s%s," % (name, value)
            pass
        width, space = self.getSpace(line)
        return line + space + self.handleSideComments(node, width)

    def writeUnionBegin(self, node, indent):
        return "    union {\n"

    def writeUnionEnd(self, node, indent):
        foot = "    } " + node.getAttribute("name") + "; "
        width, space = self.getSpace(foot)
        return foot + space + self.handleSideComments(node, width)

    def writeFunctypeBegin(self, node, indent):
        return "typedef " + node.getAttribute("type") + "(* " + node.getAttribute("name") + ")(\n"

    def writeFunctypeEnd(self, node, indent):
        return ");\n\n"

    def writeFuncBegin(self, node, indent):
        return node.getAttribute("type") + " " + node.getAttribute("name") + "(\n"

    def writeFuncEnd(self, node, indent):
        return ");\n\n"

    def writeParam(self, node, indent):
        io = node.getAttribute("io")
        if io == "in":
            argType = "NPF_IN"
        elif io == "out":
            argType = "NPF_OUT"
        elif io == "inout":
            argType = "NPF_IN_OUT"
            pass        

        paramType = node.getAttribute("type")
        paramName = node.getAttribute("name")
        if paramType[-1] == "*":
            paramType = paramType[:-1]
            paramName = "*" + paramName
            pass

        if isAttrNotEmpty(node, "class") and node.getAttribute("class") == "vector":
            length = node.getElementsByTagName("length")[0]
            lenType = length.getAttribute("type")
            lenName = length.getAttribute("name")
            param = "    " + argType + " " + lenType + " " + lenName + ",\n"
            param = param + "    " + argType + " " + paramType + " *" + paramName + ",\n"
        else:
            param = "    " + argType + " " + paramType + " " + paramName + ",\n"
            pass
        if node.getAttribute("last") == "yes":
            param = param[:-2]
        return param

    def writeDefines(self, node, indent):
        names = []
        midMaxWidth = 0
        maxWidth = 0
        for n in node.getElementsByTagName("field"):
            name = "#define " + n.getAttribute("name")
            names = names + [[n, name]]
            if midMaxWidth < len(name):
                midMaxWidth = len(name)
                pass
            pass
        midMaxWidth = midMaxWidth + 1 
        defines = []
        for d in names:
            val = string.strip(getText(d[0].getElementsByTagName("value")[0]))
            name = d[1] + makeSpace(midMaxWidth - len(d[1])) + val
            defines = defines + [[d[0], name]]
            if maxWidth < len(name):
                maxWidth = len(name)
                pass
            pass

        defs = ""
        for d in defines:
            space = makeSpace(maxWidth - len(name) + 1)
            cmnt = self.handleSideComments(d[0], maxWidth+6)
            if cmnt != "\n":
                defs = defs + d[1] + space + cmnt
            else:
                defs = defs + d[1] + " \n"
                pass
            pass
        return defs + "\n"

    def writeApiEnd(self, node, indent):
        parent = node
        while parent.nodeName != "api":
            parent = parent.parentNode
            pass
        fapiName = string.upper(parent.getAttribute("name"))
        ending = "\n\n#ifdef __cplusplus\n}\n#endif\n\n\n"
        ending = ending + "#endif /* %s_H */\n\n" % fapiName
        return ending
