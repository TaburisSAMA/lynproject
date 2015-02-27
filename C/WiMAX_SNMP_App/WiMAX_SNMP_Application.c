/*
 ============================================================================
 Name        : WiMAX_SNMP_Application.c
 Author      : Maksudul Alam
 Version     :
 Copyright   : maksud@commlinkinfotech.com,all right reserved
 Description : SNMP Agent Demo Application
 ============================================================================
 */
#include "util/DataTypes.h"
#include "util/Utilities.h"
#include "util/Ipc.h"
#include <stdio.h>

#define MSGQ_PATH_FOR_SNMP_AGENT "/bin/agent_wimax"

#define MSGQ_DEF_REQ_TYPE	1

struct struct_messageQID *pvSt_msgQIdForSNMPReq;

int main()
{

	pvSt_msgQIdForSNMPReq = (struct struct_messageQID *) fV_allocateMemory(sizeof(struct struct_messageQID));
	pvSt_msgQIdForSNMPReq->vS32_msgQIDRW = fS32_createQueue(MSGQ_PATH_FOR_SNMP_AGENT, 1, 1);

	return 0;
}
b
