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
import string
import xml.dom.minidom
from xmlfapicommon import *


##############################################################################
## DP Wrapper Generator                                                      #
##############################################################################

class Callbacks:
    def __init__(self):
        self.cback_reg = None
    pass

class FapiDpWrapperGenerator:

    def __init__(self, fapiDefinition, oem):
        self.fapiDef = fapiDefinition
        self.oem = oem
        self.reader = FapiXmlReader(self.fapiDef)
        self.xdrFuncs = []
        self.cbacks = Callbacks()
        self.cbacks.events = 0
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
                if node.nodeName == "preamble":
                    preamble = self.handlePreamble(node)
                elif node.nodeName == "import":
                    includes = includes + self.handleImport(node)
                elif node.nodeName == "section":
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
        result = result + self.declarations() + "\n"
        result = result + sections + "\n"
        if self.cbacks.events:
            result = result + self.eventXdrFunc() + "\n"
            result = result + self.handleEvent() + "\n"
            result = result + self.handleEventReg() + "\n"
            result = result + self.handleEventDereg() + "\n"
            pass
        result = result + self.registerFuncs() + "\n"
        return result

    def handleOptionalTop(self, node):
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

    def declarations(self):
        decls = ""
        decls = decls + "/*****************************************************/\n"
        decls = decls + "/*   DO NOT TOUCH                                    */\n"
        decls = decls + "/*   THIS FILE IS AUTOMAGICALLY GENERATED            */\n"
        decls = decls + "/*****************************************************/\n"
        decls = decls + "\n"
        decls = decls + "#include <unistd.h>\n"
        decls = decls + "#include <sys/socket.h>\n"
        decls = decls + "#include <netinet/in.h>\n"
        decls = decls + "#include <arpa/inet.h>\n"
        decls = decls + "#include <rpc/rpc.h>\n"
        decls = decls + "#include <ix_types.h>\n"
        decls = decls + "#include <ix_error.h>\n"
        decls = decls + "#include <ix_cc_error.h>\n"
        decls = decls + "#include <x_%s.h>\n" % self.apiName
        decls = decls + "#include <fapi/%s.h>\n" % self.apiName
        decls = decls + "#include <rpc_api.h>\n"
        decls = decls + "#include <fapi_macros.h>\n\n"       
        decls = decls + "static\n"
        decls = decls + "NPF_callbackHandle_t callbackHandle; /* DP callback handle */\n"
        decls = decls + "static\n"
        decls = decls + "NPF_userContext_t    dpContext; /* some arbitrary context created \n"
        decls = decls + "                                      by the DP wrapper for itself */\n\n"
        decls = decls + "struct %sDPEventParams\n" % self.apiName
        decls = decls + "{\n"
        decls = decls + "    struct %sDPEventParams *next;\n" % self.apiName
        decls = decls + "    NPF_callbackHandle_t eventHandle; /* event handle aquired from DP */\n"
        decls = decls + "    NPF_correlator_t correlator;\n"
        decls = decls + "};\n"
        decls = decls + "static struct %sDPEventParams listHead;\n" % self.apiName
        return decls

    def registerFuncs(self):
        reg = ""
        reg = reg + "ix_error\n"
        reg = reg + "ix_cc_register_rpc_%s_fapi_callers(void);\n" % self.apiName[6:]
        reg = reg + "ix_error\n"
        reg = reg + "ix_cc_register_rpc_%s_fapi_callers(void)\n" % self.apiName[6:]
        reg = reg + "{\n"
        reg = reg + "    listHead.next = NULL;\n\n"

        for f in self.xdrFuncs:
            reg = reg + "    if (Rpc_RegisterProc(RPC_GROUP_%s,\n" % string.upper(self.apiName[6:])
            reg = reg + "                         %s,\n" % f[1]
            reg = reg + "                         RPC_DP_Request_%s) != RPC_CC_SUCCESS)\n" % f[0]
            reg = reg + "    {\n"
            reg = reg + "        return IX_ERROR_WARNING(IX_CC_ERROR_INTERNAL,\n"
            reg = reg + "                                (\"FAPI registration in RPC server failed\"));\n"
            reg = reg + "    }\n"
            pass
        reg = reg + "\n    /* register FAPI callback */\n"
        reg = reg + "    dpContext = 1;\n"
        if self.cbacks.cback_reg != None:
            reg = reg + "    if (%s(dpContext, RPC_DP_Callback, " % (self.cbacks.cback_reg)
            reg = reg + "&callbackHandle) != NPF_NO_ERROR)\n"
            reg = reg + "    {\n"
            reg = reg + "        return IX_ERROR_WARNING(IX_CC_ERROR_INTERNAL,\n"
            reg = reg + "                                (\"FAPI callback registration failed\"));\n"
            reg = reg + "    }\n\n"
            pass

        reg = reg + "    FAPI_LOG_INFO(\"%s DP RPC wrapper initialized\\n\");\n" % string.upper(self.apiName[6:])
        reg = reg + "    return IX_SUCCESS;\n"
        reg = reg + "}\n\n"

        reg = reg + "ix_error\n"
        reg = reg + "ix_cc_deregister_rpc_%s_fapi_callers(void);\n" % self.apiName[6:]
        reg = reg + "ix_error\n"
        reg = reg + "ix_cc_deregister_rpc_%s_fapi_callers(void)\n" % self.apiName[6:]
        reg = reg + "{\n"
        reg = reg + "    /* unregister Fapi functions from RPC CC */\n"
        reg = reg + "    return IX_SUCCESS;\n"
        reg = reg + "}\n\n"
        return reg
        

    def handlePreamble(self, node):
        preamble = cmntHeadLine
        preamble = preamble + getText(node) + "\n\n";
        preamble = preamble + cmntFootLine
        return preamble

    def handleImport(self, node):
        include = string.strip(getText(node))
        return "#include <fapi/"+include+".h>\n"

    def handleSection(self, node):
        section = ""
        for n in node.childNodes:
            if n.nodeType == n.ELEMENT_NODE:
                if n.nodeName == "section":
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
            if node.nodeName == "func":
                elem = self.handleFunc(node)
            elif node.nodeName == "functype":
                elem = self.handleFunctype(node)
            elif node.nodeName == "section":
                elem = elem + self.handleSection(node)
            elif node.nodeName == "optional":
                elem = elem + self.handleOptionalTop(node)
            elif node.nodeName == "oem":
                elem = elem + self.handleOemTop(node)
                pass
            pass
        return elem

    def handleFunc(self, node):
        type = node.getAttribute("type")
        name = node.getAttribute("name")
        if node.hasAttribute("class"):
            klass = node.getAttribute("class")
            if klass in ["event_register", "event_deregister", "cback_register", "cback_deregister"]:
                self.handleReg(node)
                return ""
            pass
        
        if not node.hasAttribute("xdrid"):
            return ""
        if node.hasAttribute("impl") and node.getAttribute("impl") == "no":
            return ""
        self.xdrFuncs = self.xdrFuncs + [[node.getAttribute("name"), node.getAttribute("xdrid")]]

        fHead = ""
        fUpk = ""
        fCall1 = ""
        fCall2 = ""
        fFreeArgs = ""
        fCallEnd = ""
        
        fHead = fHead + "rpc_result_t\n"
        fHead = fHead + "RPC_DP_Request_%s(\n" % name
        fHead = fHead + "    u_long correlator,\n"
        fHead = fHead + "    XDR *pXdr);\n"
        fHead = fHead + "rpc_result_t\n"
        fHead = fHead + "RPC_DP_Request_%s(\n" % name
        fHead = fHead + "    u_long correlator,\n"
        fHead = fHead + "    XDR *pXdr)\n"
        fHead = fHead + "{\n"
        fHead = fHead + "    rpc_result_t rpcErr = RPC_CC_SUCCESS;\n"

        fUpk= fUpk+ "\n    memset(&args, 0, sizeof(args));\n"
        fUpk= fUpk+ "    if (!xdr_X_%s_args(pXdr, &args))\n" % name
        fUpk= fUpk+ "    {\n"
        fUpk= fUpk+ "        FAPI_LOG_ERROR(\"RPC_DP_Request_%s error: cannot unpack data\\n\");\n" % name
        fUpk= fUpk+ "        return RPC_CC_INVALID_ARGS;\n"
        fUpk= fUpk+ "    }\n\n"

        if node.getElementsByTagName("param")[0].getAttribute("type") == "NPF_callbackHandle_t":
            fCall1 = fCall1 + "\n    if (%s(callbackHandle,\n" % (name)
            fCall1 = fCall1 + "        "+makeSpace(len(name)+1)+"correlator,\n"
            fCall1 = fCall1 + "        "+makeSpace(len(name)+1)+"NPF_REPORT_ALL,\n"
            fCall1 = fCall1 + "        "+makeSpace(len(name)+1)+"0"
        else:
            fCall1 = fCall1 + "\n    (void)correlator; /* avoid warning */\n"
            fCall1 = fCall1 + "    if (%s(0" % (name)
            pass
        fCall2 = fCall2 + ") != NPF_NO_ERROR)\n"
        fCall2 = fCall2 + "    {\n"
        fCall2 = fCall2 + "        rpcErr = RPC_CC_UNKNOWN_ERROR;\n"
        fCall2 = fCall2 + "    }\n\n"
        
        fFreeArgs = fFreeArgs + "    /* release RPC resources */\n"
        fFreeArgs = fFreeArgs + "    xdr_free((xdrproc_t)xdr_X_%s_args, (char *)&args);\n" % name
        fFreeArgs = fFreeArgs + "    if (rpcErr == RPC_CC_SUCCESS)\n"
        fFreeArgs = fFreeArgs + "    {\n"
        fFreeArgs = fFreeArgs + "        FAPI_LOG_DEBUG(\"RPC_DP_Request_%s suceed\\n\");\n" % name
        fFreeArgs = fFreeArgs + "    }\n"
        fFreeArgs = fFreeArgs + "    else\n"
        fFreeArgs = fFreeArgs + "    {\n"
        fFreeArgs = fFreeArgs + "        FAPI_LOG_DEBUG(\"RPC_DP_Request_%s failed\\n\");\n" % name
        fFreeArgs = fFreeArgs + "    }\n"

        fCallEnd = fCallEnd + "    return rpcErr;\n"
        fCallEnd = fCallEnd + "}\n\n"

        funcFoot = ""
        argsDefs = "    X_%s_args args;\n" % name
        copyArgs = ""
        callArgs = ""
        for param in node.getElementsByTagName("param"):
            if param.hasAttribute("xdr") and param.getAttribute("xdr") == "no":
                continue
            paramType = param.getAttribute("type")
            paramName = param.getAttribute("name")

            if param.hasAttribute("class") and param.getAttribute("class") == "vector":
                length = param.getElementsByTagName("length")[0]
                lenType = length.getAttribute("type")
                lenName = length.getAttribute("name")
                argsDefs = argsDefs + "    %s %s;\n" % (lenType, lenName)
                argsDefs = argsDefs + "    %s *%s;\n" % (paramType, paramName)
                copyArgs = copyArgs + "    %s = args.%s.%s_len;\n" % (lenName, paramName, paramName)
                copyArgs = copyArgs + "    %s = (%s*)args.%s.%s_val;\n" % (paramName, paramType, paramName,paramName)
                callArgs = callArgs + "        %s,\n" % (makeSpace(len(name)+1)+lenName)
                callArgs = callArgs + "        %s,\n" % (makeSpace(len(name)+1)+paramName)
            else:
                argsDefs = argsDefs + "    " + paramType + " " + paramName + ";\n"
                if paramType[-1] == "*":
                    copyArgs = copyArgs + "    %s = (%s)args.%s;\n" % (paramName, paramType, paramName)
                else:
                    copyArgs = copyArgs + "    %s = *(%s *)&args.%s;\n" % (paramName, paramType, paramName)
                callArgs = callArgs + "        %s,\n" % (makeSpace(len(name)+1)+paramName)
                pass
            pass
        if callArgs == "":
            fHead = fHead + "    (void)pXdr; /* avoid warning */\n"
            result = fHead + fCall1 + fCall2 + fCallEnd
        else:
            callArgs2 = ",\n" + callArgs[:-2]
            result = fHead + argsDefs + fUpk + copyArgs + fCall1 + callArgs2 + fCall2 + fFreeArgs + fCallEnd
        return result

    def handleFunctype(self, node):
        if not node.hasAttribute("class"):
            return ""
        if node.getAttribute("class") == "callback":
            return self.handleCallback(node)
        if node.getAttribute("class") == "event":
            params = node.getElementsByTagName("param")
            self.cbacks.eventDataType = params[1].getAttribute("type")
            self.cbacks.eventNode = node
            return ""

    def handleReg(self, node):
        type = node.getAttribute("type")
        name = node.getAttribute("name")
        klass = node.getAttribute("class")

        if klass == "event_register":
            self.cbacks.events = 1
            self.cbacks.event_reg = name
            self.cbacks.eventRegNode = node
            self.xdrFuncs = self.xdrFuncs + [[name, node.getAttribute("xdrid")]]
        elif klass == "event_deregister":
            self.cbacks.event_dereg = name
            self.cbacks.eventDeregNode = node
            self.xdrFuncs = self.xdrFuncs + [[name, node.getAttribute("xdrid")]]
        elif klass == "cback_register":
            self.cbacks.cback_reg = name
        elif klass == "cback_deregister":
            self.cbacks.cback_dereg = name
            pass
        pass       

    def handleCallback(self, node):
        type = node.getAttribute("type")
        name = node.getAttribute("name")
        params = node.getElementsByTagName("param")
        contextType = params[0].getAttribute("type")
        contextName = params[0].getAttribute("name")
        correlatorType = params[1].getAttribute("type")
        correlatorName = params[1].getAttribute("name")
        dataType = params[2].getAttribute("type")
        dataName = params[2].getAttribute("name")

        fHead = ""
        
        fHead = fHead + "static void\n"
        fHead = fHead + "RPC_DP_Callback(\n"
        for p in params:
            fHead = fHead + "    " + p.getAttribute("type") + " " + p.getAttribute("name") + ",\n"
            pass
      
        fHead = fHead[:-2] + ")\n{\n"

        fHead = fHead + "    X_%s rpcArgs;\n" % dataType
        fHead = fHead + "    rpc_result_t err;\n"
        ctx = params[0].getAttribute("name")
        fHead = fHead + "    (void)%s; /* avoid warning */ \n" % ctx
        fHead = fHead + "    rpcArgs = *(X_%s *)&(%s);\n" % (dataType, dataName)

        fHead = fHead + "    if ((err = Rpc_SendReply(%s, (caddr_t)&rpcArgs, (xdrproc_t)xdr_X_%s))\n" % (correlatorName, dataType)
        fHead = fHead + "        != RPC_CC_SUCCESS)\n"
        fHead = fHead + "    {\n"
        fHead = fHead + "        FAPI_LOG_ERROR(\""+string.upper(self.apiName[6:])+" RPC error: callback cannot send reply (err=%d)\\n\", err);\n"
        fHead = fHead + "        return;\n"
        fHead = fHead + "    }\n"
        fHead = fHead + "}\n"

        return fHead + "\n"

    def handleEvent(self):
        node = self.cbacks.eventNode

        #type = node.getAttribute("type")
        #name = node.getAttribute("name")
        #params = node.getElementsByTagName("param")
        #contextType = params[0].getAttribute("type")
        #contextName = params[0].getAttribute("name")
        #dataType = params[1].getAttribute("type")
        #dataName = params[1].getAttribute("name")

        func = ""
        func = func + "static void\n"
        func = func + "RPC_DP_Event(\n"
        func = func + "    NPF_IN NPF_userContext_t userContext,\n"
        func = func + "    NPF_IN %s eventArray)\n" % self.cbacks.eventDataType
        func = func + "{\n"
        func = func + "    X_%sEventData_t rpcArgs;\n" % self.apiName[6:]
        func = func + "    rpc_result_t err;\n"
        func = func + "    NPF_correlator_t correlator;\n"
        func = func + "    struct %sDPEventParams *eventParams;\n\n" % self.apiName
        func = func + "    eventParams = (struct %sDPEventParams*)userContext;\n" % self.apiName
        func = func + "    correlator = eventParams->correlator;\n\n"
        func = func + "    rpcArgs.type = 0;\n"
        func = func + "    rpcArgs.u.eventData = *(X_%s *)&eventArray;\n" % self.cbacks.eventDataType
        func = func + "    /* send FAPI request to CP over RPC */\n"
        func = func + "    if ((err = Rpc_SendReply(correlator, (caddr_t)&rpcArgs,\n"
        func = func + "                         (xdrproc_t)xdr_X_%sEventData_t))\n" % self.apiName[6:]
        func = func + "        != RPC_CC_SUCCESS)\n"
        func = func + "    {\n"
        func = func + "        if ((err == RPC_CC_NO_SERVER) || (err == RPC_CC_CANTSEND))\n"
        func = func + "        {\n"
        func = func + "            struct npf_f_%sDPEventParams *prev, *next;\n" % self.apiName[6:]
        func = func + "            %s(eventParams->eventHandle);\n" % self.cbacks.event_dereg
        func = func + "            prev = &listHead;\n"
        func = func + "            while ((next = prev->next) != NULL) {\n"
        func = func + "                if (next->eventHandle == eventParams->eventHandle)\n"
        func = func + "                {\n"
        func = func + "                    prev->next = next->next;\n"
        func = func + "                    ix_ossl_free(next);\n"
        func = func + "                }\n"
        func = func + "                else\n"
        func = func + "                {\n"
        func = func + "                    prev = prev->next;\n"
        func = func + "                }\n"
        func = func + "            }\n"
        func = func + "        }\n"
        func = func + "        FAPI_LOG_ERROR(\"%s RPC error: event cannot send reply (err=%%d)\\n\", err);\n" % string.upper(self.apiName[6:])
        func = func + "    }\n"
        func = func + "    return;\n"
        func = func + "}\n"
        return func + "\n"

    def handleEventReg(self):
        node = self.cbacks.eventRegNode
        func = ""
        func = func +"rpc_result_t\n"
        func = func +"RPC_DP_Request_%s(\n" % self.cbacks.event_reg
        func = func +"    u_long correlator,\n"
        func = func +"    XDR *pXdr);\n"
        func = func +"rpc_result_t\n"
        func = func +"RPC_DP_Request_%s(\n" % self.cbacks.event_reg
        func = func +"    u_long correlator,\n"
        func = func +"    XDR *pXdr)\n"
        func = func +"{\n"
        func = func +"    NPF_callbackHandle_t eventHandle;\n"
        func = func +"    X_%sEventData_t rpcArgs;\n" % self.apiName[6:]
        func = func +"    rpc_result_t err = RPC_CC_SUCCESS;\n"
        func = func +"    struct %sDPEventParams *eventParams = ix_ossl_malloc(sizeof(struct %sDPEventParams));\n" % (self.apiName, self.apiName)
        func = func +"    (void)pXdr; /* avoid warning */\n"
        func = func +"    eventParams->eventHandle = 0;\n"
        func = func +"    eventParams->correlator = correlator;\n"
    
        func = func +"    if (%s(0, /* feHandle */\n" % self.cbacks.event_reg
        func = func +"                              (NPF_userContext_t)eventParams,\n"
        func = func +"                              RPC_DP_Event,\n"
        func = func +"                              &eventHandle) != NPF_NO_ERROR)\n"
        func = func +"    {\n"
        func = func +"        FAPI_LOG_INFO(\"%s DP RPC wrapper: Cannot register event\\n\");\n" % string.upper(self.apiName[6:])
        func = func +"        return NPF_E_UNKNOWN;\n"
        func = func +"    }\n"
        func = func +"    eventParams->eventHandle = eventHandle;\n"
        func = func +"    eventParams->next = listHead.next;\n"
        func = func +"    listHead.next = eventParams;\n"

        func = func +"    rpcArgs.type = 1;\n"
        func = func +"    rpcArgs.u.eventHandle = *(X_NPF_callbackHandle_t *)&(eventHandle);\n"

        func = func +"    if ((err = Rpc_SendReply(correlator, (caddr_t)&rpcArgs, (xdrproc_t)xdr_X_%sEventData_t))\n" % self.apiName[6:]
        func = func +"        != RPC_CC_SUCCESS)\n"
        func = func +"    {\n"
        func = func +"        FAPI_LOG_ERROR(\"%s RPC error: callback cannot send reply (err=%%d)\\n\", err);\n" % string.upper(self.apiName[6:])
        func = func +"    }\n\n"
        func = func +"    return err;\n"
        func = func +"}\n"
        return func

    def handleEventDereg(self):
        node = self.cbacks.eventDeregNode
        func = ""
        func = func +"rpc_result_t\n"
        func = func +"RPC_DP_Request_%s(\n" % self.cbacks.event_dereg
        func = func +"    u_long correlator,\n"
        func = func +"    XDR *pXdr);\n"
        func = func +"rpc_result_t\n"
        func = func +"RPC_DP_Request_%s(\n" % self.cbacks.event_dereg
        func = func +"    u_long correlator,\n"
        func = func +"    XDR *pXdr)\n"
        func = func +"{\n"
        func = func +"    NPF_callbackHandle_t eventHandle;\n"
        func = func +"    X_%sEventData_t rpcArgs;\n" % self.apiName[6:]
        func = func +"    X_NPF_callbackHandle_t args;\n"
        func = func +"    struct %sDPEventParams *prev, *next;\n" % self.apiName
        func = func +"    NPF_correlator_t eventCorrelator = 0;\n"
        func = func +"    rpc_result_t err = RPC_CC_SUCCESS;\n"
        func = func +"    int eventFound = 0;\n\n"
        func = func +"    (void)correlator; /* avoid warning */\n"
        func = func +"    if (pXdr == NULL)\n"
        func = func +"    {\n"
        func = func +"        FAPI_LOG_ERROR(\"%s DP RPC Event Deregister:NULL Xdrs\\n\");\n" % string.upper(self.apiName[6:])
        func = func +"        return RPC_CC_INVALID_ARGS;\n"
        func = func +"    }\n\n"
        func = func +"    /* all pointers in cbkData must be initialized ! */\n"
        func = func +"    memset(&args, 0, sizeof(args));\n"

        func = func +"    /* unmarshal response data from the stream */\n"
        func = func +"    if (xdr_X_NPF_callbackHandle_t(pXdr, &args) == FALSE)\n"
        func = func +"    {\n"
        func = func +"        FAPI_LOG_ERROR(\"DPW: %s could not unmarshall DeregisterEvent data\\n\", __FUNCTION__);\n"
        func = func +"        return RPC_CC_INVALID_ARGS;\n"
        func = func +"    }\n"
        func = func +"    eventHandle = (NPF_callbackHandle_t) args;\n"
        func = func +"    %s(eventHandle);\n\n" % self.cbacks.event_dereg
        func = func +"    eventFound = 0;\n"
        func = func +"    prev = &listHead;\n"
        func = func +"    while ((next = prev->next) != NULL) {\n"
        func = func +"        if (next->eventHandle == eventHandle)\n"
        func = func +"        {\n"
        func = func +"            eventCorrelator = next->correlator;\n"
        func = func +"            eventFound = 1;\n"
        func = func +"            prev->next = next->next;\n"
        func = func +"            ix_ossl_free(next);\n"
        func = func +"        }\n"
        func = func +"        else\n"
        func = func +"        {\n"
        func = func +"            prev = prev->next;\n"
        func = func +"        }\n"
        func = func +"    }\n"
        func = func +"    if (eventFound)\n"
        func = func +"    {\n"
        func = func +"        rpcArgs.type = 2;\n"
        func = func +"        if ((err = Rpc_SendReply(eventCorrelator, (caddr_t)&rpcArgs, (xdrproc_t)xdr_X_%sEventData_t))\n" % self.apiName[6:]
        func = func +"	          != RPC_CC_SUCCESS)\n"
        func = func +"	      {\n"
        func = func +"	          FAPI_LOG_ERROR(\"%s RPC error: callback cannot send reply (err=%%d)\\n\", err);\n" % string.upper(self.apiName[6:])
        func = func +"	      }\n\n"
        func = func +"        Rpc_UnregisterEvent(eventCorrelator);\n"
        func = func +"    }\n\n"
        func = func +"    return err;\n"
        func = func +"}\n"
        return func

    def eventXdrFunc(self):
        func = ""
        func = func +"typedef struct {\n"
        func = func +"    X_NPF_uint32_t type;\n"
        func = func +"	union {\n"
        func = func +"        X_%s eventData;\n" % self.cbacks.eventDataType
        func = func +"        X_NPF_callbackHandle_t eventHandle;\n"
        func = func +"	} u;\n"
        func = func +"} X_%sEventData_t;\n\n" % self.apiName[6:]
        func = func +"static bool_t\n"
        func = func +"xdr_X_%sEventData_t (XDR *xdrs, X_%sEventData_t *objp)\n" % (self.apiName[6:], self.apiName[6:])
        func = func +"{\n"
        func = func +"	 if (!xdr_X_NPF_uint32_t (xdrs, &objp->type))\n"
        func = func +"		 return FALSE;\n"
        func = func +"	switch (objp->type) {\n"
        func = func +"	case 0:\n"
        func = func +"		 if (!xdr_X_%s (xdrs, &objp->u.eventData))\n" % self.cbacks.eventDataType
        func = func +"			 return FALSE;\n"
        func = func +"		break;\n"
        func = func +"	case 1:\n"
        func = func +"		 if (!xdr_X_NPF_callbackHandle_t (xdrs, &objp->u.eventHandle))\n"
        func = func +"			 return FALSE;\n"
        func = func +"		break;\n"
        func = func +"	case 2:\n"
        func = func +"        return TRUE;\n"
        func = func +"	default:\n"
        func = func +"		return FALSE;\n"
        func = func +"	}\n"
        func = func +"	return TRUE;\n"
        func = func +"}\n"
        return func
