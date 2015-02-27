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
## FAPI CPP source Debug Generator                                           #
##############################################################################

class FapiDebugCppGenerator:

    def __init__(self, fapiDefinition, oem):
        self.fapiDef = fapiDefinition
        self.oem = oem
        self.funcs = []
        self.default = 0
        self.funcTypeNames = []
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
                elif (node.nodeName == "imports"):
                    sections = sections + self.handleImports(node)
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
        return result

    def declarationsFront(self):
        decls = ""
        decls = decls + "/*****************************************************/\n"
        decls = decls + "/*   DO NOT TOUCH                                    */\n"
        decls = decls + "/*   THIS FILE IS AUTOMAGICALLY GENERATED            */\n"
        decls = decls + "/*****************************************************/\n"
        decls = decls + "\n"
        decls = decls + "#include \"%s_debug.h\"\n" % self.apiName
        decls = decls + "#include \"npfdump.h\"\n"
        return decls


    def handlePreamble(self, node):
        preamble = cmntHeadLine
        preamble = preamble + getText(node) + "\n";
        preamble = preamble + cmntFootLine
        return preamble

    def handleImports(self, node):
        result =""
        
        for element in node.childNodes:
            if element.nodeType == element.ELEMENT_NODE:
                if (element.nodeName == "import"):
                    result = result + self.handleImport(element)
                elif element.nodeName == "optional":
                    result = result + self.handleOptionalImports(element)
                elif element.nodeName == "oem":
                    result = result + self.handleOemImports(node)
                    pass
                pass
            pass
        
        return result + "\n"
        

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
            elif (node.nodeName == "struct"):
                elem = self.handleStruct(node)
            elif (node.nodeName == "enum"):
                elem = self.handleEnum(node)
            elif node.nodeName == "section":
                elem = elem + self.handleSection(node)
            elif node.nodeName == "optional":
                elem = elem + self.handleOptionalTop(node)
            elif node.nodeName == "oem":
                elem = elem + self.handleOemTop(node)
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

    def handleOptionalImports(self, node):
        name = node.getAttribute("name")
        sections = "#ifdef %s" % name
        for n in node.childNodes:
            if n.nodeType == n.ELEMENT_NODE:
                if (n.nodeName == "import"):
                    sections = sections + self.handleImport(n)
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

    def handleOemImports(self, node):
        if string.find(node.getAttribute("name"), self.oem) == -1:
            return ""

        sections = ""
        for n in node.childNodes:
            if n.nodeType == n.ELEMENT_NODE:
                if (n.nodeName == "import"):
                    sections = sections + self.handleImport(n)
                    pass
                pass
            pass
        return sections

    def handleImport(self, node):
        name = string.strip(getText(node))
        if name == "npf":
            return ""
        
        result = "#include \"%s_debug.h\"\n" % name
        return result

    def handleFunc(self, node):

        if node.hasAttribute("impl") and node.getAttribute("impl") == "no":
            return ""

        name = node.getAttribute("name")
        type = node.getAttribute("type")
        if type == "string":
            type = "NPF_char8_t*"
            pass
        
        result = self.handleFuncGeneral(node, name, "NPF_DEBUG_PROC(" + name + ")")

        if( type == "void" ):
            result = result + "    NPF_DEBUG_IMPL(%s) (" % name
        else:
            result = result + "    return NPF_DEBUG_IMPL(%s) (" % name
            pass

        i = 0

        for param in node.getElementsByTagName("param"):
            paramName = param.getAttribute("name")
            
            if i != 0:
                result = result + ", "
                pass
            
            if param.hasAttribute("class") and param.getAttribute("class") == "vector":
                length = param.getElementsByTagName("length")[0]
                lenName = length.getAttribute("name")
                result = result + lenName + ", "
                pass
            
            result = result + paramName
            i= i + 1
            pass
        

        result = result + ");\n}\n"
        
        return result

    def handleFuncType(self, node):
        name = node.getAttribute("name")
        self.funcTypeNames = self.funcTypeNames + [name]
        
        if node.hasAttribute("impl") and node.getAttribute("impl") == "no":
            return ""
           
        funcName = name[:-2] + "_Debug"
        result = self.handleFuncGeneral(node, funcName, funcName) + "}\n"
        return result

    def handleFuncGeneral(self, node, name, funcName):
        type = node.getAttribute("type")
        if type == "string":
            type = "NPF_char8_t*"
            pass
        
        fDeclar = "\nextern \"C\" " + type + " " + funcName + " (\n"
        
        i = 0
        
        for param in node.getElementsByTagName("param"):
            paramType = param.getAttribute("type")
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

        fDeclar = fDeclar + ")\n{\n"
        fDeclar = fDeclar + "    NPFDUMPINIT(\"%s()\");\n" % name

        for param in node.getElementsByTagName("param"):
            paramName = param.getAttribute("name")
            paramType = param.getAttribute("type")
            done = 0
            
            for ft in self.funcTypeNames:
                if ft == paramType:
                    fDeclar = fDeclar + "    NPFDUMP((void*)%s);\n" % paramName
                    done = 1
                    pass
                pass
            
            if done == 0:
                if param.hasAttribute("class") and param.getAttribute("class") == "vector":
                    length = param.getElementsByTagName("length")[0]
                    lenName = length.getAttribute("name")
                    fDeclar = fDeclar + "    NPFDUMP_ARR2(%s, %s);\n" % (paramName, lenName)
                elif (string.find(paramType, "*") == -1) and (string.find(paramName, "*") == -1) :
                    fDeclar = fDeclar + "    NPFDUMP(%s);\n" % paramName
                else:
                    fDeclar = fDeclar + "    NPFDUMP_PTR(%s);\n" % paramName
                    pass
            
                pass
            pass

        fDeclar = fDeclar + "    NPFDUMPDONE();\n"

        return fDeclar 



    def handleStruct(self, node):
        type = node.getAttribute("type")
        paramName = string.replace(string.strip(type), "NPF_F_umts", "", 1); 
        paramName = string.replace(paramName, "NPF_F_", "", 1); 
        paramName = string.replace(paramName, "_t", "", 1); 

        arrayS = array.array('c')
        arrayS.fromstring(paramName)
        paramName = arrayS[0]
        arrayS = arrayS[1:]
        paramName = string.lower(paramName) + arrayS.tostring() 

      
        result = "void npfdump(const char* name, const %s &%s)\n{\n" % (type, paramName)
        result = result +"     NPFDUMPINIT2(name, \"%s\");\n" % type

        for element in node.childNodes:
            if element.nodeType == element.ELEMENT_NODE:
                if (element.nodeName == "field"):
                    result = result + self.handleStructField(element, paramName)
                elif (element.nodeName == "vector"):
                    result = result + self.handleVector(element, paramName)
                elif element.nodeName == "selectunion":
                    result = result + self.handleUnion(element, paramName)
                elif element.nodeName == "optional":
                    result = result + self.handleOptionalStruct(element, paramName)
                elif element.nodeName == "oem":
                    result = result + self.handleOemStruct(element, paramName)
                    pass
                pass
            pass

        result = result + "     NPFDUMPDONE();\n}\n\n"
        
        return result


    def handleStructField(self, node, paramName):            
        name = paramName + "." + node.getAttribute("name")
        result = self.handleFieldGeneral(node, name)
        return result
    
    def handleVector(self, node, paramName):            
        name =  paramName + "." + node.getAttribute("name")
        length = node.getElementsByTagName("length")[0]
        lenName = paramName + "." + length.getAttribute("name")
        result = "     NPFDUMP_ARR2(%s, %s);\n" % (name, lenName)
        return result

    def handleUnion(self, node, paramName):
        name = paramName + "." + node.getAttribute("name")

        self.default = 0
        
        selectField = node.getElementsByTagName("selectfield")[0]
        selectFieldName = paramName + "." + selectField.getAttribute("name")
        
        result = "     NPFDUMP(%s);\n" % selectFieldName
        result = result + "     switch (%s)\n     {\n" % selectFieldName

        for element in node.childNodes:
            if element.nodeType == element.ELEMENT_NODE:
                if (element.nodeName == "field"):
                    result = result + self.handleUnionField(element, name)
                elif element.nodeName == "oem":
                    result = result + self.handleOemUnion(element, name) 
                elif element.nodeName == "optional":
                    result = result + self.handleOptionalUnion(element, name) 
                    pass
                pass
            pass
        
        if self.default == 0:
            result = result + "     default:\n"
            result = result + "         NPFDUMPHEX(%s)\n" % name
            result = result + "         break;\n"
   
        result = result + "     }\n"

        return result


    def handleUnionField(self, node, unionName):
        selectors = node.getElementsByTagName("selector")
        name = unionName + "." + node.getAttribute("name")

        if selectors[0].hasAttribute("default") and selectors[0].getAttribute("default") == "yes":
            result = "     default:\n"
            result = result + "     " + self.handleFieldGeneral(node, name)
            result = result + "          break;\n"
            self.default = 1
        else:
            result = ""
            for sel in selectors:
                result = result + "     case %s:\n" % string.strip(getText(sel))
                pass
            result = result + "     " + self.handleFieldGeneral(node, name)
            result = result + "          break;\n"
            pass
        pass
        return result

    def handleFieldGeneral( self, node, name):
        type = node.getAttribute("type")            
        if type == "string":
            type = "NPF_char8_t*"
            pass

        if(node.hasAttribute("size")):
            if string.find(type, "NPF_uint8_t") != -1:
               result = "     NPFDUMPHEX(%s);\n" % name
            else:
               size = node.getAttribute("size")
               result = "     NPFDUMP_ARR(%s, %s);\n" % (name, size)
               pass
        elif(string.find( type, "*") == -1) and (string.find( name, "*") == -1):
            result = "     NPFDUMP(%s);\n" % name
        else:
            result = "     NPFDUMP_PTR(%s);\n" % name
            pass
        return result

        
    def handleOemStruct(self, node, paramName):
        if string.find(node.getAttribute("name"), self.oem) == -1:
            return ""

        result = ""
        for element in node.childNodes:
            if element.nodeType == element.ELEMENT_NODE:
                if (element.nodeName == "field"):
                    result = result + self.handleStructField(element, paramName)
                elif (element.nodeName == "vector"):
                    result = result + self.handleVector(element, paramName)
                elif element.nodeName == "selectunion":
                    result = result + self.handleUnion(element, paramName)
                    pass
                pass
            pass

        return result


    def handleOptionalStruct(self, node, paramName):
        name = node.getAttribute("name")
        result = "\n#ifdef %s\n\n" % name

        for element in node.childNodes:
            if element.nodeType == element.ELEMENT_NODE:
                if (element.nodeName == "field"):
                    result = result + self.handleStructField(element, paramName)
                elif (element.nodeName == "vector"):
                    result = result + self.handleVector(element, paramName)
                elif element.nodeName == "selectunion":
                    result = result + self.handleUnion(element, paramName)
                    pass
                pass
            pass

        endifString = "\n#endif /* %s */\n" % name

        result = result + endifString

        return result



    def handleOemUnion(self, node, unionName):

        if string.find(node.getAttribute("name"), self.oem) == -1:
            return ""

        result = ""
        for element in node.childNodes:
           if (element.nodeType == element.ELEMENT_NODE)and (element.nodeName == "field"):
                result = result + self.handleUnionField(element, unionName)
           
        return result


    def handleOptionalUnion(self, node, unionName):
        name = node.getAttribute("name")
        result = "\n#ifdef %s\n\n" % name
        for element in node.childNodes:
            if element.nodeType == element.ELEMENT_NODE and element.nodeName == "field":
               result = result + self.handleUnionField(element, unionName)
            pass

        endifString = "\n#endif /* %s */\n" % name

        result = result + endifString

        return result


    def handleEnum(self, node):
        type = node.getAttribute("type")

        result = "void npfdump(const char* name, const %s type)\n{\n" % type

        result = result + "    ALIAS_BEGIN(type)\n"

        for element in node.childNodes:
            if element.nodeType == element.ELEMENT_NODE:
                if (element.nodeName == "field"):
                    result = result + self.handleOemField(element)
                elif element.nodeName == "oem":
                    result = result + self.handleOemEnum(element)
                elif element.nodeName == "optional":
                    result = result + self.handleOptionalEnum(element)
                    pass
                pass
            pass

        result = result + "    ALIAS_END(name)\n"
        result = result + "}\n\n"

        return result
   
    def handleOemEnum(self, node):

        if string.find(node.getAttribute("name"), self.oem) == -1:
            return ""

        result = ""
        for element in node.childNodes:
           if (element.nodeType == element.ELEMENT_NODE)and (element.nodeName == "field"):
                result = result + self.handleOemField(element, unionName)
           
        return result

    def handleOptionalEnum(self, node):
        name = node.getAttribute("name")
        result = "\n#ifdef %s\n\n" % name
        for element in node.childNodes:
            if element.nodeType == element.ELEMENT_NODE and element.nodeName == "field":
               result = result + self.handleEnumField(element, unionName)
            pass

        endifString = "\n#endif /* %s */\n" % name

        result = result + endifString

        return result


    def handleOemField(self, node):
        name = node.getAttribute("name")
        result ="    ALIAS_CASE(%s);\n" % name
        return result 





