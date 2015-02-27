#ifndef IPC_H_
#define IPC_H_

#include "DataTypes.h"
#include "Utilities.h"

#define MSGQ_PATH_FOR_WIMAX_SNMP_AGENT "/bin/agent_wimax"
#define PACKET_SIZE 1024

struct struct_messageQID *pvSt_msgQIdForSNMP;

struct struct_message
{
	long vL_messageType;
	s8 aS8_message[PACKET_SIZE];
};

s32 fS32_getPermission(s32 vS32Fp_readPerm, s32 vS32Fp_writePerm);
s32 fS32_getMsgQID(s8 *pvS8Fp_path, s32 vS32Fp_readPerm, s32 vS32Fp_writePerm);
s32 fS32_createQueue(s8 *pvS8Fp_path, s32 vS32Fp_readPerm, s32 vS32Fp_writePerm);
s32 fS32_enqueue(s32 vS32Fp_msgQID, long vLFp_messageType, void *pvVFp_message, u16 vU16Fp_messageLength);
s32 fS32_dequeue(s32 vS32Fp_msgQID, long vLFp_messageType, void *pvVFp_msgBuffer, boolean vBFp_wait);
void fV_destroyQueue();

s32 fS32_getSharedMemory(s8 *pvS8Fp_path, s32 vS32Fp_size, s32 vS32Fp_readPerm, s32 vS32Fp_writePerm);
void *fV_attachSharedMemory(s32 vS32Fp_sharedMemoryId);
s32 fS32_detachSharedMemory(void *pvVFp_sharedMemory);

#endif /*IPC_H_*/
