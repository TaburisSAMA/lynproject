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
import array
import xml.dom.minidom
from xmlfapicommon import *


##############################################################################
## FAPI Debug Header Generator                                               #
##############################################################################

class FapiDebugHGenerator:

    def __init__(self, fapiDefinition, oem):
        self.fapiDef = fapiDefinition
        self.oem = oem
        self.funcs = []
        self.structs = []
        self.enums = []
        pass
        
    def generate(self, fout):
        fout.write(self.handleApi())
        pass

    def handleApi(self):
        includes = ""
        sections = ""
        api = self.fapiDef.getElementsByTagName("api")[0]
        self.apiName = api.getAttribute("name")
        for node in api.childNodes:
            if node.nodeType == node.ELEMENT_NODE:
                if (node.nodeName == "preamble"):
                    preamble = self.handlePreamble(node)
                elif (node.nodeName == "section"):
                    sections = sections + self.handleSection(node)
                elif node.nodeName == "optional":
                    sections = sections + self.handleOptionalTop(node)
                elif node.nodeName == "oem":
                    sections = sections + self.handleOemTop(node)
                else:
                    sections = sections + self.handleElem(node, ELEM_SEPAR)
                    pass
                pass
            pass
        result = preamble + "\n"
        result = result + includes + "\n"
        result = result + self.declarationsFront() + "\n"
        result = result + sections + "\n"
        result = result + self.declarationsBack() + "\n"
        result = result + self.generateOptionalFuncsDecls()
        return result

    def declarationsFront(self):
        decls = ""
        decls = decls + "/*****************************************************/\n"
        decls = decls + "/*   DO NOT TOUCH                                    */\n"
        decls = decls + "/*   THIS FILE IS AUTOMAGICALLY GENERATED            */\n"
        decls = decls + "/*****************************************************/\n"
        decls = decls + "\n"
        decls = decls + "#ifndef __%s_debug_h__\n" % self.apiName
        decls = decls + "#define __%s_debug_h__\n\n" % self.apiName
        decls = decls + "#include \"fapi/%s.h\"\n" % self.apiName
        decls = decls + "#include \"../include/npfdebug.h\"\n\n\n"
        decls = decls + "#ifdef __cplusplus\nextern \"C\" {\n#endif\n\n"
        return decls

    def declarationsBack(self):
        decls = ""
        decls = decls + "\n#ifdef __cplusplus\n}//extern \"C\"\n#endif\n\n"
        return decls

    def handlePreamble(self, node):
        preamble = cmntHeadLine
        preamble = preamble + getText(node) + "\n\n";
        preamble = preamble + cmntFootLine
        return preamble

    def handleSection(self, node):
        section = ""
        for n in node.childNodes:
            if n.nodeType == n.ELEMENT_NODE:
                if (n.nodeName == "section"):
                    section = section + self.handleSection(n)
                elif node.nodeName == "optional":
                    section = section + self.handleOptionalTop(n)
                elif node.nodeName == "oem":
                    section = section + self.handleOemTop(n)
                else:
                    section = section + self.handleElem(n, ELEM_SEPAR)
                    pass
                pass
            pass
        return section
            

    def handleElem(self, node, embed):
        elem = ""
        if node.nodeType == node.ELEMENT_NODE:
            if (node.nodeName == "func"):
                elem = self.handleFunc(node)
            elif (node.nodeName == "functype"):
                elem = self.handleFuncType(node)
            elif node.nodeName == "section":
                elem = self.handleSection(node)
            elif node.nodeName == "optional":
                elem = self.handleOptionlTop(node)
            elif (node.nodeName == "struct"):
                self.structs = self.structs + [node]
            elif (node.nodeName == "enum"):
                self.enums = self.enums + [node]
            elif node.nodeName == "oem":
                elem = self.handleOemTop(node)
                pass
            pass
        return elem


    def handleOptionalTop(self, node):
        name = node.getAttribute("name")
        sections = "#ifdef %s" % name
        for n in node.childNodes:
            if n.nodeType == n.ELEMENT_NODE:
                if (n.nodeName == "section"):
                    sections = sections + self.handleSection(n)
                else:
                    sections = sections + self.handleElem(n, ELEM_SEPAR)
                    pass
                pass
            pass

        endif = "#endif /* %s */" % name 
        return sections + endif

    def handleOemTop(self, node):
        if string.find(node.getAttribute("name"), self.oem) == -1:
            return ""

        sections = ""
        for n in node.childNodes:
            if n.nodeType == n.ELEMENT_NODE:
                if (n.nodeName == "section"):
                    sections = sections + self.handleSection(n)
                else:
                    sections = sections + self.handleElem(n, ELEM_SEPAR)
                    pass
                pass
            pass
        return sections

    def handleFunc(self, node):
        if node.hasAttribute("impl") and node.getAttribute("impl") == "no":
            return ""

        name = node.getAttribute("name")
        result = self.handleFuncGeneral(node, name, "NPF_DEBUG_PROTOTYPE(" + name + ")")
        self.funcs = self.funcs + [name]
        return result

    def handleFuncType(self, node):
        if node.hasAttribute("impl") and node.getAttribute("impl") == "no":
            return ""

        name = node.getAttribute("name")[:-2] + "_Debug"
        result = self.handleFuncGeneral(node, name, name)
        return result

    def handleFuncGeneral(self, node, name, funcName):
        
        type = node.getAttribute("type")
        if type == "string":
            type = "NPF_char8_t*"
            pass

        fDeclar = type
        fDeclar = fDeclar + " %s (\n" % funcName
        
        i = 0
        
        for param in node.getElementsByTagName("param"):
            paramType = param.getAttribute("type")
            if paramType == "string":
                paramType = "NPF_char8_t*"
                pass
            
            paramName = param.getAttribute("name")

            io = param.getAttribute("io")
            if io == "in":
                prefix = "NPF_IN"
            elif io == "out":
                prefix = "NPF_OUT"
            else:
                prefix = "NPF_IN_OUT"
                pass

            if i != 0:
                fDeclar = fDeclar + ",\n"
                pass

            if param.hasAttribute("class") and param.getAttribute("class") == "vector":
                length = param.getElementsByTagName("length")[0]
                lenType = length.getAttribute("type")
                lenName = length.getAttribute("name")
                fDeclar = fDeclar + "    " + prefix + " %s %s,\n" % (lenType, lenName)
                fDeclar = fDeclar + "    " + prefix + " %s *%s" % (paramType, paramName)
            else:
                fDeclar = fDeclar + "    " + prefix + " " + paramType + " " + paramName
                pass
            
            i = i + 1
        
            pass

        fDeclar = fDeclar + ");\n\n" 

        return fDeclar 

    def generateOptionalFuncsDecls(self):

        result = "#if NPF_DEBUG_FLAG\n"
    
        for f in self.funcs:
            result = result + "#define %s      NPF_DEBUG_PROTOTYPE(%s)\n" % (f,f)
            pass
        
        result = result + "#endif\n\n#ifdef __cplusplus\n\n"
        
        for s in self.structs:
            type = s.getAttribute("type")
            paramName = string.replace(string.strip(type), "NPF_F_umts", "", 1); 
            paramName = string.replace(paramName, "NPF_F_", "", 1); 
            paramName = string.replace(paramName, "_t", "", 1); 

            arrayS = array.array('c')
            arrayS.fromstring(paramName)
            paramName = arrayS[0]
            arrayS = arrayS[1:]
            paramName = string.lower(paramName) + arrayS.tostring() 
            result = result + "void npfdump(const char* name, const %s &%s);\n" % (type, paramName)
            pass

        for e in self.enums:
            type = e.getAttribute("type")
            result = result + "void npfdump(const char* name, const %s type);\n" % type
            pass
        
        result = result + "\n#endif /* __cplusplus */\n\n"
        
        result = result + "#endif /* __%s_debug_h__ */\n\n\n" % self.apiName

        return result



