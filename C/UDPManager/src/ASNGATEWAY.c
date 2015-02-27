/*
 ============================================================================
 Name        : ASNGATEWAY.c
 Author      : Parvez Mahmud
 Version     :
 Copyright   : pmtamal@2008,all right reserved
 Description : Hello World in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include "InitTransport.h"
#include "Receiver.h"
#include "Packet.h"
#include "Constants.h"
#include "Utilities.h"
#include "DataTypes.h"
#include "Ipc.h"

void fV_threadtest(char*msg)
{
	printf("message Printing %s ",msg);
	printf("Thread Exiting");

}

void fV_Start()
{


	fB_initServer();
	//fB_initClient();

	s32 vS32_threadResult;

	pthread_t vSt_receiverThread;
	void * pvV_receiverThreadStatus;

	struct struct_messageQID *pvSt_msgQIDForReceiver;
	pvSt_msgQIDForReceiver = (struct struct_messageQID *)fV_allocateMemory(sizeof(struct struct_messageQID));
	pvSt_msgQIDForReceiver->vS32_msgQIDRW = fS32_createQueue(MSGQ_PATH_FOR_REASSEMBLER, 0, 1);
	pvSt_msgQIDForReceiver->vS32_msgQIDW = fS32_createQueue(MSGQ_PATH_FOR_PARSER, 0, 1);

	vS32_threadResult = pthread_create(&vSt_receiverThread, NULL,
										  (void*)fV_receiver, (void *) pvSt_msgQIDForReceiver);


	if (vS32_threadResult != 0) {
		fV_print("Receiver thread creation failed\n");
		fV_exitProgram(0);
	}

	fV_print("Receiver thread created\n");
	pthread_join(vSt_receiverThread, &pvV_receiverThreadStatus);

}
int main(void) {
	//puts("Hello World!!!"); /* prints Hello World!!! */
	pthread_t vSt_testThread;
	void * pvV_testThreadStatus;
	int vS32_threadResult;
	char msg[]="Hello world";
	fV_Start();
	/*int byteOrder=10;
	s8* p=&byteOrder;
	printf("MSB addres: %X\nLSB address: %X\n",(int)&p[3],(int)&p[0]);
	printf("value at lsb%d",p[0]);*/

	/*vS32_threadResult = pthread_create(&vSt_testThread, NULL,
				                              fV_threadtest, (void *)msg);*/
	//pthread_join(vSt_testThread, &pvV_testThreadStatus);



	return 1;
}
