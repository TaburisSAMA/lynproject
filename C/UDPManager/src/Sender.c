#include "Sender.h"
#include "Ipc.h"
#include "InitTransport.h"
#include "Utilities.h"



s32 fS32_receiveFromSenderMsgQ(s32 vS32Fp_msgQID, struct struct_message *pvStFp_msgBuffer){

	 return fS32_dequeue(vS32Fp_msgQID,0, pvStFp_msgBuffer,0);
}

void fV_send(struct struct_messageQID *pvStFp_messageQID){


	s32 vS32_numOfBytes;
	s8 *pvS8_buffer;
	struct struct_message vSt_message;
	s32 vS32_messageLen;

	while(1){

		if ((vS32_messageLen = fS32_receiveFromSenderMsgQ(pvStFp_messageQID->vS32_msgQIDRW, &vSt_message)) != -1){
			pvS8_buffer = (char *)vSt_message.aS8_message;
			fV_print("this message are send%s",pvS8_buffer);
			fV_print("msg len %d dfd",vS32_messageLen);
			fV_print("Sending ...\n");
			vS32_numOfBytes = sendto(vS32G_socketDescriptor, pvS8_buffer, vS32_messageLen,
						             0, (struct sockaddr*)&vStG_address, sizeof (vStG_address));

			if (vS32_numOfBytes < 0){
				fV_print("Sending Failed\n");
			}
			else
			{
				printf("Sending successful");
			}

		}

	}
	fS32_closeSocket(vS32G_socketDescriptor);

	return;
}
