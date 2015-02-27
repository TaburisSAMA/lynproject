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
## Generator                                                                 #
##############################################################################
class Generator:

    def __init__(self, fapiDefinition):
        self.fapiDef = fapiDefinition
        self.reader = FapiXmlReader(self.fapiDef)
        pass
        
    def generate(self, fout):
        fout.write(self.printElemsChain())
        pass

    def printElemsChain(self):
        api = self.fapiDef.getElementsByTagName("api")[0]

        text = ""
        indent = ""
        for n in api.childNodes:
            if n.nodeType != n.ELEMENT_NODE:
                continue
            
            if n.nodeName in ["StructBegin", "EnumBegin", "UnionBegin"]:
                indent = indent + "    "
            elif n.nodeName in ["StructEnd", "EnumEnd", "UnionEnd"]:
                indent = indent[:-4]
                pass
            
            if not self.__class__.__dict__.has_key("write"+n.nodeName):
                raise Exception("Unimplemented node name: "+n.nodeName)
            
            text = text + self.__class__.__dict__["write"+n.nodeName](self, n, indent)
            pass
        
        return text

