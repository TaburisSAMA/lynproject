class FAPINodeGenerator:

    def __init__(self, fapiDefinition, oem, tree):
        self.fapiDef = fapiDefinition
        self.oem = oem
        self.funcs = []
        self.structs = []
        self.enums = []
        self.treestore = tree
        pass
        
    def generate(self):
        self.handleApi()
        pass

    def handleApi(self):
        includes = ""
        sections = ""
        #Get first "api" node
        api = self.fapiDef.getElementsByTagName("api")[0]
        self.apiName = api.getAttribute("name")
        present = self.treestore.append(None, [self.apiName])
        #now create the nodes
        for node in api.childNodes:
            if node.nodeType == node.ELEMENT_NODE:
                if (node.nodeName == "preamble"):
                    pass
                elif (node.nodeName == "section"):
                    children = self.treestore.append(present, [node.nodeName])
                    self.handleSection(node, children)
                elif node.nodeName == "optional":
                    children = self.treestore.append(present, [node.nodeName])
                    self.handleOptionalTop(node, children)
                elif node.nodeName == "oem":
                    children = self.treestore.append(present, [node.nodeName])
                    self.handleOemTop(node, children)
                else:
                    children = self.treestore.append(present, [node.nodeName])
                    self.handleElem(node, ":", children)
                    pass
                pass
            pass

    def handleSection(self, node, present):
        section = ""
        for n in node.childNodes:
            if n.nodeType == n.ELEMENT_NODE:
                if (n.nodeName == "section"):
                    children = self.treestore.append(present, [n.nodeName])
                    self.handleSection(n, children)
                elif node.nodeName == "optional":
                    children = self.treestore.append(present, [n.nodeName])
                    self.handleOptionalTop(n, children)
                elif node.nodeName == "oem":
                    children = self.treestore.append(present, [n.nodeName])
                    self.handleOemTop(n, children)
                else:
                    children = self.treestore.append(present, [n.nodeName])
                    self.handleElem(n, "", children)
                    pass
                pass
            pass
        return section
            

    def handleElem(self, node, embed, present):
        elem = ""
        if node.nodeType == node.ELEMENT_NODE:
            if (node.nodeName == "func"):
                self.handleFunc(node, present)
            elif (node.nodeName == "functype"):
                self.handleFuncType(node, present)
            elif node.nodeName == "section":
                self.handleSection(node, present)
            elif node.nodeName == "optional":
                self.handleOptionlTop(node, present)
            elif (node.nodeName == "struct"):
                self.structs = self.structs + [node]
            elif (node.nodeName == "enum"):
                self.enums = self.enums + [node]
            elif node.nodeName == "oem":
                elem = self.handleOemTop(node, present)
                pass
            pass
        return elem


    def handleOptionalTop(self, node, present):
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

    def handleOemTop(self, node, present):
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

    def handleFunc(self, node, present):
        if node.hasAttribute("impl") and node.getAttribute("impl") == "no":
            return ""

        name = node.getAttribute("name")
        result = self.handleFuncGeneral(node, name, "NPF_DEBUG_PROTOTYPE(" + name + ")", None)
        self.funcs = self.funcs + [name]
        return result

    def handleFuncType(self, node, present):
        if node.hasAttribute("impl") and node.getAttribute("impl") == "no":
            return ""

        name = node.getAttribute("name")[:-2] + "_Debug"
        result = self.handleFuncGeneral(node, name, name, present)
        return result

    def handleFuncGeneral(self, node, name, funcName, present):
        
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

    def generateOptionalFuncsDecls(self, present):

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
        
        #result = result + "\n#endif /* __cplusplus */\n\n"
        
        #result = result + "#endif /* __%s_debug_h__ */\n\n\n" % self.apiName

        return result



