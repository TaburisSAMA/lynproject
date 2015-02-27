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


##############################################################################
## CP Wrapper Generator                                                      #
##############################################################################
class Callbacks:
    pass

class FapiCpWrapperGenerator:

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
                if (node.nodeName == "preamble"):
                    preamble = self.handlePreamble(node)
                elif (node.nodeName == "import"):
                    includes = includes + self.handleImport(node)
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
        result = result + self.declarations() + "\n"
        result = result + sections + "\n"
        if self.cbacks.events:
            result = result + self.eventXdrFunc() + "\n"
            result = result + self.handleEvent() + "\n"
            result = result + self.handleEventReg() + "\n"
            result = result + self.handleEventDereg() + "\n"
            pass
        return result

    def declarations(self):
        decls = ""
        decls = decls + "/*****************************************************/\n"
        decls = decls + "/*   DO NOT TOUCH                                    */\n"
        decls = decls + "/*   THIS FILE IS AUTOMAGICALLY GENERATED            */\n"
        decls = decls + "/*****************************************************/\n"
        decls = decls + "\n"
        decls = decls + "#include <unistd.h>\n"
        decls = decls + "#include <%s_debug.h>\n" % self.apiName
        decls = decls + "#include <fapi/%s.h>\n" % self.apiName
        decls = decls + "#include <x_%s.h>\n" % self.apiName
        decls = decls + "#include <rpc_api.h>\n"
        decls = decls + "#include <rpc_numbers.h>\n"
        decls = decls + "#include <ix_bff_cp_fapi_support.h>\n\n"
        decls = decls + "static\n"
        decls = decls + "ix_bff_callback_list cbList = NULL;\n\n"
        decls = decls + "static\n"
        decls = decls + "ix_bff_event_list eventList = NULL;\n\n"
        decls = decls + "static rpc_result_t\n"
        decls = decls + "RPC_CP_Callback(u_long correlator, XDR *pXdrs);\n\n"
        decls = decls + "struct %sEventParams\n" % self.apiName[6:]
        decls = decls + "{\n"
        decls = decls + "    NPF_FEHandle_t feHandle;          /* address of DP */\n"
        decls = decls + "    NPF_callbackHandle_t remoteEventHandle; /* event handle aquired from DP */\n"
        decls = decls + "    pthread_mutex_t mutex;\n"
        decls = decls + "    NPF_userContext_t userContext;    /* original user context */\n"
        decls = decls + "};\n"
        return decls

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

    def handleIncludes(self, reader):
        for include in self.fapiDef.getElementsByTagName("include"):
            print '#include "' + reader.getInclude(include) + '"'
            pass
        print ""
        print ""
        pass
        
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

    def handleFunc(self, node):
        if node.hasAttribute("class"):
            klass = node.getAttribute("class")
            if klass in ["event_register", "event_deregister", "cback_register", "cback_deregister"]:
                return self.handleReg(node)
        
        type = node.getAttribute("type")
        name = node.getAttribute("name")
       
        if not node.hasAttribute("xdrid"):
            return ""
        if node.hasAttribute("impl") and node.getAttribute("impl") == "no":
            return ""
        xdrid = node.getAttribute("xdrid")

        params = node.getElementsByTagName("param")
        if params[0].getAttribute("type") == "NPF_callbackHandle_t":
            asyncFunc = 1
        else:
            asyncFunc = 0
            pass

        fHead = ""
        fDecls = ""
        fSetParams = ""
        fCall1 = ""
        fCall2 = ""
        
        fHead = fHead + "NPF_error_t\n"
        fHead = fHead + "%s(\n" % name
        fDecls = fDecls + ")\n{\n"
        fDecls = fDecls + "    rpc_procedure_t rpcProc;\n"
        fDecls = fDecls + "    ix_bff_call_params params;\n"

        fSetParams = fSetParams + "    /* store call params on CP side in param structure */\n"
        if asyncFunc:
            fSetParams = fSetParams + "    params.callbackHandle = %s;\n" % params[0].getAttribute("name")
            fSetParams = fSetParams + "    params.correlator = correlator;\n"
            fSetParams = fSetParams + "    params.errorReporting = errorReporting;\n\n"
        else:
            fSetParams = fSetParams + "    params.callbackHandle = 0;\n"
            fSetParams = fSetParams + "    params.correlator = 0;\n"
            fSetParams = fSetParams + "    params.errorReporting = 0;\n\n"
            pass

        fCall1 = fCall1 + "\n    /* set all required arguments for RPC service */\n"
        fCall1 = fCall1 + "    rpcProc.group      = RPC_GROUP_%s;\n" % string.upper(self.apiName[6:])
        fCall1 = fCall1 + "    rpcProc.proc       = %s;\n" % xdrid
        fCall1 = fCall1 + "    rpcProc.corelator  = ix_bff_get_call_correlator(&params);\n"
        if asyncFunc:
            fCall1 = fCall1 + "    rpcProc.callback   = RPC_CP_Callback;\n"
        else:
            fCall1 = fCall1 + "    rpcProc.callback   = NULL;\n"
        fCall1 = fCall1 + "    rpcProc.flags      = 0;\n"

        # check if there is any arguments to transport
        noArgs = 1
        for param in params:
            if (not param.hasAttribute("xdr")) or (param.hasAttribute("xdr") and param.getAttribute("xdr") == "yes"):
                noArgs = 0
                pass
            pass
        if noArgs == 1:
            fCall1 = fCall1 + "    rpcProc.argFunc    = (xdrproc_t)xdr_void;\n"
        else:
            fCall1 = fCall1 + "    rpcProc.argFunc    = (xdrproc_t)xdr_X_%s_args;\n" % name
            pass

        if asyncFunc:
            feHandle = params[3].getAttribute("name")
        else:
            feHandle = params[0].getAttribute("name")
            pass
        fCall2 = fCall2 + "    /* send FAPI request to DP over RPC */\n"
        fCall2 = fCall2 + "    if (Rpc_CallAsync(%s, &rpcProc) != RPC_CC_SUCCESS)\n" % feHandle
        fCall2 = fCall2 + "    {\n"
        fCall2 = fCall2 + "        return NPF_E_UNKNOWN;\n"
        fCall2 = fCall2 + "    }\n\n"
        fCall2 = fCall2 + "    return NPF_NO_ERROR;\n"
        fCall2 = fCall2 + "}\n\n"
        
        argsDefs = ""
        copyArgs = ""
        for param in params:
            paramType = param.getAttribute("type")
            paramName = param.getAttribute("name")

            if param.hasAttribute("class") and param.getAttribute("class") == "vector":
                length = param.getElementsByTagName("length")[0]
                lenType = length.getAttribute("type")
                lenName = length.getAttribute("name")
                argsDefs = argsDefs + "    %s %s,\n" % (lenType, lenName)
                argsDefs = argsDefs + "    %s *%s,\n" % (paramType, paramName)
                if param.hasAttribute("xdr") and param.getAttribute("xdr") == "no":
                    continue
                copyArgs = copyArgs + "    rpcArgs.%s.%s_len = %s;\n" % (paramName, paramName, lenName)
                copyArgs = copyArgs + "    rpcArgs.%s.%s_val = (X_%s*)%s;\n" % (paramName, paramName, paramType,paramName)
            else:
                argsDefs = argsDefs + "    " + paramType + " " + paramName + ",\n"
                if param.hasAttribute("xdr") and param.getAttribute("xdr") == "no":
                    continue
                if paramType[-1] == "*":
                    copyArgs = copyArgs + "    rpcArgs.%s = (X_%s)%s;\n" % (paramName, paramType, paramName)
                else:
                    copyArgs = copyArgs + "    rpcArgs.%s = *(X_%s *)&%s;\n" % (paramName, paramType, paramName)
                pass
            pass

        if copyArgs == "":
            fRpcArgs = "    rpcProc.procArgs   = NULL;\n\n"
            result = fHead + argsDefs[:-2] + fDecls + fSetParams + fCall1 + fRpcArgs + fCall2
        else:
            fDecls = fDecls + "    X_%s_args rpcArgs;\n\n" % name
            fCmt1 = "    /* set call args */\n"
            fRpcArgs = "    rpcProc.procArgs   = (caddr_t)&rpcArgs;\n\n"
            result = fHead + argsDefs[:-2] + fDecls + fSetParams + fCmt1 + copyArgs + fCall1 + fRpcArgs + fCall2
        
        return result

    def handleFunctype(self, node):
        if not node.hasAttribute("class"):
            return ""
        klass = node.getAttribute("class")
        if klass == "event":
            self.cbacks.eventNode = node
            return ""

        if klass != "callback":
            return ""

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
        fHead = fHead + "static rpc_result_t\n"
        fHead = fHead + "RPC_CP_Callback(u_long correlator, XDR *pXdrs)\n"
        fHead = fHead + "{\n"
        fHead = fHead + "    X_%s cbkData;\n" % dataType
        fHead = fHead + "    %s respData;\n" % dataType
        fHead = fHead + "    ix_bff_call_params *params;\n"
        fHead = fHead + "    ix_bff_callback *cb;\n"
        fHead = fHead + "    %s  cbf;\n\n" % name
        fHead = fHead + "    if(pXdrs == NULL)\n"
        fHead = fHead + "    {\n"
        fHead = fHead + "        printf(\"%s CP RPC Callback: NULL Xdrs\\n\");\n" % string.upper(self.apiName[6:])
        fHead = fHead + "        return RPC_CC_UNKNOWN_ERROR;\n"
        fHead = fHead + "    }\n\n"
        fHead = fHead + "    /* all pointers in cbkData must be initialized ! */\n"
        fHead = fHead + "    memset(&cbkData, 0, sizeof(cbkData));\n\n"
        fHead = fHead + "    /* unmarshal response data from the stream */\n"
        fHead = fHead + "    if (xdr_X_%s(pXdrs, &cbkData) == FALSE)\n" % dataType
        fHead = fHead + "    {\n"
        fHead = fHead + "        printf(\"CPW: %s could not unmarshall response data\\n\", __FUNCTION__);\n"
        fHead = fHead + "        return RPC_CC_UNKNOWN_ERROR;\n"
        fHead = fHead + "    }\n\n"
        fHead = fHead + "    /* set response data */\n"
        fHead = fHead + "    respData = *(%s *)&(cbkData);\n\n" % dataType
        fHead = fHead + "    /* get call parameters - retrive original call params using\n"
        fHead = fHead + "     \"fake\" correlator - see corresponding FAPI function */\n"
        fHead = fHead + "    params = ix_bff_get_call_params(correlator);\n\n"
        fHead = fHead + "    /* call user callback if appropriate */\n"
        fHead = fHead + "    if (params != NULL)\n"
        fHead = fHead + "    {\n"
        fHead = fHead + "        if (params->errorReporting == NPF_REPORT_ALL)\n"
        fHead = fHead + "        {\n"
        fHead = fHead + "            cb = ix_bff_get_callback(cbList, params->callbackHandle);\n"
        fHead = fHead + "            if (cb != NULL)\n"
        fHead = fHead + "            {\n"
        fHead = fHead + "                /* call cbk function */\n"
        fHead = fHead + "                cbf = (%s) cb->function;\n" % name
        fHead = fHead + "                cbf(cb->context,\n"
        fHead = fHead + "                    params->correlator,\n"
        fHead = fHead + "                    respData);\n"
        fHead = fHead + "            }\n"
        fHead = fHead + "        }\n"
        fHead = fHead + "    }\n"
        fHead = fHead + "    /* free correlator */\n"
        fHead = fHead + "    ix_bff_free_call_correlator(correlator);\n"
        fHead = fHead + "    /* release memory allocated by XDR filters after data is no\n"
        fHead = fHead + "       longer needed */\n"
        fHead = fHead + "    xdr_free((xdrproc_t)xdr_X_%s, (char *)&cbkData);\n\n" % dataType
        fHead = fHead + "    return RPC_CC_SUCCESS;\n"
        fHead = fHead + "}\n"

        return fHead + "\n"

    def handleReg(self, node):
        type = node.getAttribute("type")
        name = node.getAttribute("name")
        klass = node.getAttribute("class")

        reg = ""
        if klass == "cback_register":
            callbackFunc = node.getElementsByTagName("param")[1].getAttribute("type")
            reg = reg + "NPF_error_t\n"
            reg = reg + "%s(\n" % name
            reg = reg + "    NPF_userContext_t userContext,\n"
            reg = reg + "    %s callbackFunc,\n" % callbackFunc
            reg = reg + "    NPF_callbackHandle_t *callbackHandle)\n"
            reg = reg + "{\n"
            reg = reg + "    if (cbList == NULL)\n"
            reg = reg + "    {\n"
            reg = reg + "        // initialization deferred\n"
            reg = reg + "        cbList = ix_bff_cb_list_create();\n"
            reg = reg + "    }\n"
            reg = reg + "    return ix_bff_register_callback(cbList, userContext, callbackFunc, callbackHandle);\n"
            reg = reg + "}\n\n"
        elif klass == "cback_deregister":
            reg = reg + "NPF_error_t\n"
            reg = reg + "%s(\n" % name
            reg = reg + "    NPF_callbackHandle_t callbackHandle)\n"
            reg = reg + "{\n"
            reg = reg + "    if (ix_bff_unregister_callback(cbList, callbackHandle) != NPF_TRUE)\n"
            reg = reg + "    {\n"
            reg = reg + "        return NPF_E_BAD_CALLBACK_HANDLE;\n"
            reg = reg + "    }\n"
            reg = reg + "    return NPF_NO_ERROR;\n"
            reg = reg + "}\n\n"
        elif klass == "event_register":
            self.cbacks.events = 1
            self.cbacks.eventRegNode = node
        elif klass == "event_deregister":
            self.cbacks.eventDeregNode = node
            pass
        return reg


    def handleEventReg(self):
        node = self.cbacks.eventRegNode
        params = node.getElementsByTagName("param")
        evFuncType = params[2].getAttribute("type")
        xdrid = node.getAttribute("xdrid")
        
        func = ""
        func = func + "NPF_error_t %s(\n" % node.getAttribute("name")
        func = func + "    NPF_IN NPF_FEHandle_t feHandle,\n"
        func = func + "    NPF_IN NPF_userContext_t userContext,\n"
        func = func + "    NPF_IN %s eventCallFunc,\n" % evFuncType
        func = func + "    NPF_OUT NPF_callbackHandle_t *eventHandle)\n"
        func = func + "{\n"
        func = func + "    rpc_procedure_t rpcProc;\n"
        func = func + "    ix_bff_call_params params;\n"
        func = func + "    struct %sEventParams *eventParams;\n" % self.apiName[6:]
        func = func + "    NPF_error_t error_code = NPF_NO_ERROR;\n\n"
        func = func + "    eventParams = malloc(sizeof(struct %sEventParams));\n" % self.apiName[6:]
        func = func + "    if (eventParams == NULL)\n"
        func = func + "    {\n"
        func = func + "        return NPF_E_UNKNOWN;\n"
        func = func + "    }\n"
        func = func + "    eventParams->userContext = userContext;\n"
        func = func + "    eventParams->feHandle = feHandle;\n"
        func = func + "    eventParams->remoteEventHandle = 0;\n"
        func = func + "#ifndef ASYNC_EVENT_REGISTER\n"
        func = func + "    pthread_mutex_init(&eventParams->mutex, NULL);\n"
        func = func + "    pthread_mutex_lock(&eventParams->mutex);\n\n"
        func = func + "#endif\n"
        func = func + "    if (eventList == NULL)\n"
        func = func + "    {\n"
        func = func + "        /* initialization deferred */\n"
        func = func + "        if ((eventList = ix_bff_event_list_create()) == NULL)\n"
        func = func + "        {\n"
        func = func + "            return NPF_E_UNKNOWN;\n"
        func = func + "        }\n"
        func = func + "    }\n\n"
        func = func + "    if (ix_bff_register_event(eventList,\n"
        func = func + "                              (NPF_userContext_t)eventParams,\n"
        func = func + "                              eventCallFunc,\n"
        func = func + "                              eventHandle) != NPF_NO_ERROR)\n"
        func = func + "    {\n"
        func = func + "        return NPF_E_UNKNOWN;\n"
        func = func + "    }\n\n"
        func = func + "    /* store call params on CP side in param structure */\n"
        func = func + "    params.callbackHandle = *eventHandle;\n"
        func = func + "    params.correlator = 0;\n"
        func = func + "    params.errorReporting = 0;\n\n"
        func = func + "    rpcProc.group      = RPC_GROUP_%s;\n" % string.upper(self.apiName[6:])
        func = func + "    rpcProc.proc       = %s;\n" % xdrid
        func = func + "    rpcProc.corelator = ix_bff_get_call_correlator(&params);\n"
        func = func + "    rpcProc.callback  = RPC_CP_Event;\n"
        func = func + "    rpcProc.argFunc   = (xdrproc_t)xdr_void;\n"
        func = func + "    rpcProc.flags     = F_RPC_PROCEDURE_EVENT_REG;\n"
        func = func + "    rpcProc.procArgs  = (caddr_t)NULL;\n\n"
        func = func + "    if (Rpc_CallAsync(feHandle, &rpcProc) != RPC_CC_SUCCESS)\n"
        func = func + "    {\n"
        func = func + "        /* Call failed, so clean up */\n"
        func = func + "        ix_bff_unregister_event(eventList, *eventHandle);\n"
        func = func + "#ifndef ASYNC_EVENT_REGISTER\n"
        func = func + "        pthread_mutex_unlock(&eventParams->mutex);\n"
        func = func + "        pthread_mutex_destroy(&eventParams->mutex);\n"
        func = func + "#endif\n"
        func = func + "        free(eventParams);\n\n"
        func = func + "        return NPF_E_UNKNOWN;\n"
        func = func + "    }\n\n"
        func = func + "#ifndef ASYNC_EVENT_REGISTER\n"
        func = func + "    /* wait on mutex; check stored data in eventParams; */\n"
        func = func + "    pthread_mutex_lock(&eventParams->mutex);\n"
        func = func + "    pthread_mutex_unlock(&eventParams->mutex);\n\n"
        func = func + "    if (eventParams->remoteEventHandle == -1) {\n"
        func = func + "        error_code = NPF_E_UNKNOWN;\n"
        func = func + "        ix_bff_unregister_event(eventList, *eventHandle);\n"
        func = func + "        pthread_mutex_destroy(&eventParams->mutex);\n"
        func = func + "        free(eventParams);\n"
        func = func + "        printf(\"CPW: %s Warning: Unable to register event\\n\", __FUNCTION__);\n"
        func = func + "    }\n\n"    
        func = func + "    return error_code;\n"
        func = func + "#else\n"
        func = func + "    return NPF_NO_ERROR;\n"
        func = func + "#endif\n"
        func = func + "}\n"
        return func


    def handleEventDereg(self):
        node = self.cbacks.eventDeregNode
        xdrid = node.getAttribute("xdrid")
        
        func = ""
        func = func + "NPF_error_t %s(\n" % node.getAttribute("name")
        func = func + "    NPF_IN NPF_callbackHandle_t eventHandle)\n"
        func = func + "{\n"
        func = func + "    X_NPF_callbackHandle_t rpcArgs;\n"
        func = func + "    rpc_procedure_t rpcProc;\n"
        func = func + "    ix_bff_call_params params;\n"
        func = func + "    struct %sEventParams *eventParams;\n\n" % self.apiName[6:]
        func = func + "    ix_bff_callback *cb;\n\n"
        func = func + "    cb = ix_bff_get_callback(eventList, eventHandle);\n"
        func = func + "    eventParams = (struct %sEventParams *)cb->context;\n" % self.apiName[6:]
        func = func + "    if (eventParams == 0) {\n"
        func = func + "        return NPF_E_UNKNOWN;\n"
        func = func + "    }\n\n"
        func = func + "    params.callbackHandle = eventHandle;\n"
        func = func + "    params.correlator = 0;\n"
        func = func + "    params.errorReporting = 0;\n\n"
        func = func + "    rpcArgs = eventParams->remoteEventHandle;\n\n"    
        func = func + "    rpcProc.group      = RPC_GROUP_%s;\n" % string.upper(self.apiName[6:])
        func = func + "    rpcProc.proc       = %s;\n" % xdrid
        func = func + "    rpcProc.corelator = ix_bff_get_call_correlator(&params);\n"
        func = func + "    rpcProc.callback  = RPC_CP_Event;\n"
        func = func + "    rpcProc.argFunc   = (xdrproc_t)xdr_X_NPF_callbackHandle_t;\n"
        func = func + "    rpcProc.flags     = 0;\n"
        func = func + "    rpcProc.procArgs  = (caddr_t)&rpcArgs;\n\n"
        func = func + "    if (Rpc_CallAsync(eventParams->feHandle, &rpcProc) != RPC_CC_SUCCESS)\n"
        func = func + "    {\n"
        func = func + "        return NPF_E_UNKNOWN;\n"
        func = func + "    }\n\n"    
        func = func + "    /* wait on mutex; check stored data in eventParams; */\n"
        func = func + "#ifndef ASYNC_EVENT_REGISTER\n"
        func = func + "    pthread_mutex_lock(&eventParams->mutex);\n"
        func = func + "    pthread_mutex_unlock(&eventParams->mutex);\n"
        func = func + "    pthread_mutex_destroy(&eventParams->mutex);\n"
        func = func + "#endif\n"
        func = func + "    free(eventParams);\n"
        func = func + "    return NPF_NO_ERROR;\n"
        func = func + "}\n"
        return func


    def handleEvent(self):
        node = self.cbacks.eventNode
        params = node.getElementsByTagName("param")
        eventDataType = params[1].getAttribute("type")
        
        node = self.cbacks.eventRegNode
        params = node.getElementsByTagName("param")
        eventFuncType = params[2].getAttribute("type")
        
        func = ""
        func = func + "static rpc_result_t\n"
        func = func + "RPC_CP_Event(u_long correlator, XDR *pXdrs)\n"
        func = func + "{\n"
        func = func + "    NPF_genericEventHandlerHandle_t evH;\n"
        func = func + "    X_%sEventData_t args;\n" % self.apiName[6:]
        func = func + "    %s        eventArray;\n" % eventDataType
        func = func + "    struct %sEventParams *eventParams;\n" % self.apiName[6:]
        func = func + "    ix_bff_call_params *params;\n"
        func = func + "    ix_bff_callback *cb;\n"
        func = func + "    %s cbf;\n\n" % eventFuncType
        func = func + "    params = ix_bff_get_call_params(correlator);\n"
        func = func + "    cb = ix_bff_get_callback(eventList, params->callbackHandle);\n"
        func = func + "    cbf = (%s) cb->function;\n" % eventFuncType
        func = func + "    eventParams = (struct %sEventParams *)cb->context;\n\n" % self.apiName[6:]
        func = func + "    if (pXdrs == NULL)\n"
        func = func + "    {\n"
        func = func + "        printf(\"%s CP RPC Event handler: NULL Xdrs\\n\");\n" % string.upper(self.apiName[6:])
        func = func + "        eventParams->remoteEventHandle = -1;\n"
        func = func + "#ifndef ASYNC_EVENT_REGISTER\n"
        func = func + "        pthread_mutex_unlock(&eventParams->mutex);\n"
        func = func + "#endif\n"
        func = func + "        return RPC_CC_UNKNOWN_ERROR;\n"
        func = func + "    }\n\n"
        func = func + "    /* all pointers in cbkData must be initialized ! */\n"
        func = func + "    memset(&args, 0, sizeof(args));\n\n"
        func = func + "    /* unmarshal response data from the stream */\n"
        func = func + "    if (xdr_X_%sEventData_t(pXdrs, &args) == FALSE)\n" % self.apiName[6:]
        func = func + "    {\n"
        func = func + "        printf(\"CPW: %s could not unmarshall response data\\n\", __FUNCTION__);\n"
        func = func + "        return RPC_CC_UNKNOWN_ERROR;\n"
        func = func + "    }\n\n"
        func = func + "    if (args.type == 1)\n"
        func = func + "    {\n"
        func = func + "        eventParams->remoteEventHandle = args.u.eventHandle;\n"
        func = func + "#ifndef ASYNC_EVENT_REGISTER\n"
        func = func + "        pthread_mutex_unlock(&eventParams->mutex);\n"
        func = func + "#endif\n"
        func = func + "    }\n"
        func = func + "    else if (args.type == 0)\n"
        func = func + "    {\n"
        func = func + "        eventArray = *(%s*)&args.u.eventData;\n\n" % eventDataType
        func = func + "	       cbf(eventParams->userContext,\n"
        func = func + "	           eventArray);\n"
        func = func + "    }\n"
        func = func + "    else if (args.type == 2)\n"
        func = func + "    {\n"
        func = func + "        ix_bff_unregister_callback(eventList, params->callbackHandle);\n"
        func = func + "#ifndef ASYNC_EVENT_REGISTER\n"
        func = func + "        pthread_mutex_unlock(&eventParams->mutex);\n"
        func = func + "#endif\n"
        func = func + "    }\n\n"    
        func = func + "    /* release memory allocated by XDR filters after data is no\n"
        func = func + "       longer needed */\n"
        func = func + "    xdr_free((xdrproc_t)xdr_X_%sEventData_t, (char *)&args);\n\n" % self.apiName[6:]
        func = func + "    return RPC_CC_SUCCESS;\n"
        func = func + "}\n"
        return func

    def eventXdrFunc(self):
        node = self.cbacks.eventNode
        params = node.getElementsByTagName("param")
        eventDataType = params[1].getAttribute("type")
        
        func = ""
        func = func +"typedef struct {\n"
        func = func +"    X_NPF_uint32_t type;\n"
        func = func +"	union {\n"
        func = func +"        X_%s eventData;\n" % eventDataType
        func = func +"        X_NPF_callbackHandle_t eventHandle;\n"
        func = func +"	} u;\n"
        func = func +"} X_%sEventData_t;\n\n" % self.apiName[6:]
        func = func +"static bool_t\n"
        func = func +"xdr_X_%sEventData_t (XDR *xdrs, X_%sEventData_t *objp)\n" % (self.apiName[6:], self.apiName[6:])
        func = func +"{\n"
        func = func +"	register int32_t *buf;\n\n"
        func = func +"	 if (!xdr_X_NPF_uint32_t (xdrs, &objp->type))\n"
        func = func +"		 return FALSE;\n"
        func = func +"	switch (objp->type) {\n"
        func = func +"	case 0:\n"
        func = func +"		 if (!xdr_X_%s (xdrs, &objp->u.eventData))\n" % eventDataType
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
