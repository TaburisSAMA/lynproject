#include <stdlib.h>
#include <sys/msg.h>
#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <string.h>
#include "Constants.h"
#include "Ipc.h"
#include "Utilities.h"

s32  fS32_getPermission(s32  vS32Fp_readPerm, s32  vS32Fp_writePerm)
{
	s32  vS32_tempPermission = 0;
	s32  vS32_permission = 0;

	vS32_tempPermission = vS32_tempPermission | vS32Fp_readPerm;
	vS32_tempPermission = vS32_tempPermission << 1;
	vS32_tempPermission = vS32_tempPermission | vS32Fp_writePerm;
	vS32_tempPermission = vS32_tempPermission << 1;

	vS32_permission = vS32_tempPermission;
	vS32_permission = vS32_permission << 3;
	vS32_permission = vS32_permission | vS32_tempPermission;
	vS32_permission = vS32_permission << 3;
	vS32_permission = vS32_permission | vS32_tempPermission;

	return vS32_permission;
}

s32  fS32_getMsgQID(s8 *pvS8Fp_path, s32  vS32Fp_readPerm, s32  vS32Fp_writePerm){

	s32  vS32_permission;
	key_t vSt_key;
	s32  vS32_msgQID;

	vS32_permission = fS32_getPermission(vS32Fp_readPerm, vS32Fp_writePerm);
	vSt_key = ftok(pvS8Fp_path, 'b');
	if(vSt_key==-1){
		fV_print("Key generation failed");
		return vSt_key;
	}

	vS32_msgQID = msgget(vSt_key, vS32_permission | IPC_CREAT);
    if(vS32_msgQID==-1){
    	fV_print("Failed to create Message Queue ID");
    }
	return vS32_msgQID;
}

s32  fS32_createQueue(s8 *pvS8Fp_path, s32  vS32Fp_readPerm, s32  vS32Fp_writePerm)
{
	return fS32_getMsgQID(pvS8Fp_path, vS32Fp_readPerm, vS32Fp_writePerm);
}

s32  fS32_enqueue(s32  vS32Fp_msgQID, long vLFp_messageType,void *pvVFp_message, u16 vU16Fp_messageLength)
{
	struct struct_message vSt_msgBuffer;
	vSt_msgBuffer.vL_messageType = vLFp_messageType;

	fS32_copyMemory(vSt_msgBuffer.aS8_message,pvVFp_message,vU16Fp_messageLength);

	return msgsnd(vS32Fp_msgQID, (void *)&vSt_msgBuffer, (size_t) vU16Fp_messageLength, 0);
}

s32  fS32_dequeue(s32  vS32Fp_msgQID, long vLFp_msgType, void *pvVFp_msgBuffer, boolean vBFp_wait)
{
	if(vBFp_wait==FALSE)
	return msgrcv(vS32Fp_msgQID, pvVFp_msgBuffer,
			               (size_t) PACKET_SIZE, vLFp_msgType, IPC_NOWAIT);

	else
	return msgrcv(vS32Fp_msgQID, pvVFp_msgBuffer,
			               (size_t) PACKET_SIZE, vLFp_msgType, 0);
}

void fV_destroyQueue(s32  vS32Fp_msgQID)
{
	if (msgctl(vS32Fp_msgQID, IPC_RMID, 0) == -1) {
		fV_print("msgctl(IPC_RMID) failed");
		fV_exitProgram(EXIT_FAILURE);
	}
	return;
}

s32 fS32_getSharedMemory(s8 *pvS8Fp_path, s32 vS32Fp_size, s32  vS32Fp_readPerm, s32  vS32Fp_writePerm){

	s32  vS32_permission;
	key_t vSt_key;
	s32  vS32_sharedMemoryID;

	vS32_permission = fS32_getPermission(vS32Fp_readPerm, vS32Fp_writePerm);
	vSt_key = ftok(pvS8Fp_path, 's');
	if(vSt_key==-1){
		fV_print("Key generation failed");
		return vSt_key;
	}

	vS32_sharedMemoryID = shmget(vSt_key, vS32Fp_size, vS32_permission);

	if(vS32_sharedMemoryID == -1)
	    fV_print("Failed to allocate Shared Memory");

	return vS32_sharedMemoryID;
}

void *fV_attachSharedMemory(s32 vS32Fp_sharedMemoryId){

	void *pvV_sharedMemory = shmat(vS32Fp_sharedMemoryId, NULL, 0);
	if (pvV_sharedMemory == (void *)-1)
		fV_print("Failed to attach Shared Memory");

	return pvV_sharedMemory;
}

s32 fS32_detachSharedMemory(void *pvVFp_sharedMemory){

	s32 vS32_status = shmdt(pvVFp_sharedMemory);
	if (vS32_status == -1)
		fV_print("Failed to detach Shared Memory");
	return vS32_status;
}

