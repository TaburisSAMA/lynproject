/*
 * snmp_agent.h
 *
 *  Created on: Dec 18, 2008
 *      Author: Maksud
 */

#ifndef SNMP_AGENT_H_
#define SNMP_AGENT_H_

typedef enum
{
	SNMP_INT, SNMP_CHAR
} SNMPDataType;

typedef enum
{
	SNMP_GET, SNMP_SET
} SNMPRequestType;

typedef struct SnmpDataReq
{
	int correlator;
	SNMPRequestType reqType;
	char name[128];
	int index;
	SNMPDataType dataType;
	int length;
	void* data;
} WimaxSnmpDataReq;

#endif /* SNMP_AGENT_H_ */
