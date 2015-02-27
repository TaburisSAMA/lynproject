#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <netdb.h>
#include "Constants.h"
#include "Utilities.h"
#include "Receiver.h"
#include "InitTransport.h"
#include "Ipc.h"
#include "Packet.h"
#include <stdio.h>
#include "unistd.h"
#include "ThreadWrapper.h"




s32 fS32_sendPacketToParser(s32 vS32Fp_msgQID, s8 * pvS8Fp_completePacket, u16 vU16Fp_packetLength){

	return fS32_enqueue(vS32Fp_msgQID, 1, pvS8Fp_completePacket,vU16Fp_packetLength);
}

s32 fS32_sendToReassembler(s32 vS32Fp_msgQID, s8 * pvS8Fp_message,u16 vU16Fp_packetLength){

	return fS32_enqueue(vS32Fp_msgQID,1, pvS8Fp_message,vU16Fp_packetLength);
}

void fV_showGateWayHeader(u8*pvU8Fp_gatewayMsg)
{
	printf("Version:-   %d\n",pvU8Fp_gatewayMsg[0]);
	printf("Flags:-     %d\n",(u8)pvU8Fp_gatewayMsg[1]);
	//u16 functype=0;
	//functype=msg[3];
	//functype=functype<<8;
	//functype=functype|msg[2];
	printf("FunctionType:-  %d\n",(u8)pvU8Fp_gatewayMsg[2]);
	u8 opidmtype=(u8)pvU8Fp_gatewayMsg[3];
	printf("OPid:%d\n",opidmtype>>3);
	printf("MessageType:- %d\n",opidmtype&7);
	u16 length=0;
	length=pvU8Fp_gatewayMsg[5];
	length=length<<8;
	length=length|pvU8Fp_gatewayMsg[4];
	printf("Message Length:- %d\n",length);
	printf("MSID: %d %d %d %d %d %d\n",pvU8Fp_gatewayMsg[6],pvU8Fp_gatewayMsg[7],pvU8Fp_gatewayMsg[8],pvU8Fp_gatewayMsg[9],pvU8Fp_gatewayMsg[10],pvU8Fp_gatewayMsg[11]);
	u32 reserved=pvU8Fp_gatewayMsg[15];
	reserved<<=8;
	reserved=reserved|pvU8Fp_gatewayMsg[14];
	reserved<<=8;
	reserved=reserved|pvU8Fp_gatewayMsg[13];
	reserved<<=8;
	reserved=reserved|pvU8Fp_gatewayMsg[12];
	printf("First Reserved:-  %d\n",(u32)reserved);
	u16 transectionId=pvU8Fp_gatewayMsg[17];
	transectionId<<=8;
	transectionId=transectionId|pvU8Fp_gatewayMsg[16];
	printf("TID:-   %d\n",(u16)transectionId);
	u16 reserved1=pvU8Fp_gatewayMsg[19];
	reserved1<<=8;
	reserved1|=pvU8Fp_gatewayMsg[18];
	printf("SecondReserved:-  %d\n",reserved1);
	u16 sourceIdType=pvU8Fp_gatewayMsg[21];
	sourceIdType<<=8;
	sourceIdType|=pvU8Fp_gatewayMsg[20];
	printf("SourceIdTYpe:- %d\n",sourceIdType);

	u16 sourceIdLen=pvU8Fp_gatewayMsg[23];
	sourceIdLen<<=8;
	sourceIdLen|=pvU8Fp_gatewayMsg[22];
	printf("SourceIdLen:- %d\n",sourceIdLen);

	printf("Source-- IP4thOct %d IP3rdOct %d IP2ndOct %d IP1stOct %d\n",(u8)pvU8Fp_gatewayMsg[27],pvU8Fp_gatewayMsg[26],pvU8Fp_gatewayMsg[25],pvU8Fp_gatewayMsg[24]);

	u16 destIdType=pvU8Fp_gatewayMsg[29];
	destIdType<<=8;
	destIdType|=pvU8Fp_gatewayMsg[28];
	printf("destIdType:-  %d\n",destIdType);
	u16 destIdLen=pvU8Fp_gatewayMsg[31];
	destIdLen<<=8;
	destIdLen|=pvU8Fp_gatewayMsg[30];
	printf("destIdLen:- %d\n",destIdLen);

	printf("Dest--4thOct %d IP3rdOct %d IP2ndOct %d IP1stOct %d\n",pvU8Fp_gatewayMsg[35],pvU8Fp_gatewayMsg[34],pvU8Fp_gatewayMsg[33],pvU8Fp_gatewayMsg[32]);

}
void fV_getIPInNetworkByteOrder(u8* pvU8Fp_networkMsg,u32 *pvU32Fp_IpNetworkByteOrder){

   u32 IpNetworkByteOrder=0;
//   printf(" Source-- IP4thOct %d IP3rdOct %d IP2ndOct %d IP1stOct %d\n",
//		   pvU8Fp_networkMsg[0],pvU8Fp_networkMsg[1],pvU8Fp_networkMsg[2],pvU8Fp_networkMsg[3]);
   IpNetworkByteOrder=pvU8Fp_networkMsg[0];
   IpNetworkByteOrder<<=8;
   //printf("After Shift%d\n",IpNetworkByteOrder);
   IpNetworkByteOrder|=pvU8Fp_networkMsg[1];
   //printf("After Or%d\n",IpNetworkByteOrder);
   IpNetworkByteOrder<<=8;
   //printf("After shiftAgain%d\n",IpNetworkByteOrder);
   IpNetworkByteOrder|=pvU8Fp_networkMsg[2];
   IpNetworkByteOrder<<=8;
   IpNetworkByteOrder|=pvU8Fp_networkMsg[3];
   *pvU32Fp_IpNetworkByteOrder=IpNetworkByteOrder;
   //printf("IpNetworkByteOrder%d\n",IpNetworkByteOrder);



}

void fV_processGateMsg(void*pVS8_gatewayMsg)
{
	int p=1;
	printf("Inside Msg Process Thread...........\n");
	u8* msg=(u8*)pVS8_gatewayMsg;
	fV_showGateWayHeader(msg);
	u32 vU32_sourceIPNetworkOrder;
	u32 vU32_DestIPNetworkOrder;

	u8 vU8_msgFlag=msg[1];

	if((vU8_msgFlag&2)>0)
	{
		printf("T flag set.Source Dest Tlv Included.Msg will be relayed to destination\n");
		u16 vU16_msgLength=0;
		vU16_msgLength=msg[5];
		vU16_msgLength=vU16_msgLength<<8;
		vU16_msgLength=vU16_msgLength|msg[4];
		printf("Message Length before sending%d\n",vU16_msgLength);
		fV_getIPInNetworkByteOrder(msg+24,&vU32_sourceIPNetworkOrder);
		fV_getIPInNetworkByteOrder(msg+32,&vU32_DestIPNetworkOrder);
		s32 vS32_sockid, retcode;
		struct sockaddr_in  server_addr;

		/*printf("Client: creating socket\n");
		if ( (vS32_sockid = socket(AF_INET, SOCK_DGRAM, 0)) < 0)
		{
			fV_print("Client: socket failed: %d\n",errno);
			fV_exitProgram(1);
		}*/
	    printf("Client: creating addr structure for server\n");
	    bzero((char *) &server_addr, sizeof(server_addr));
	    server_addr.sin_family = AF_INET;
	    //server_addr.sin_addr.s_addr = inet_addr(ASN_GATEWAY_IP);
	    server_addr.sin_addr.s_addr =vU32_DestIPNetworkOrder;

		server_addr.sin_port = htons(WIMAX_PORT_NUMBER);

	    printf("Client: initializing message and sending\n");
	   /*retcode = sendto(vS32_sockid,pVS8_gatewayMsg,14,0,(struct sockaddr *) &server_addr,
				 sizeof(server_addr));*/
	    retcode = sendto(sockid,pVS8_gatewayMsg,vU16_msgLength,0,(struct sockaddr *) &server_addr,
					 sizeof(server_addr));
		if (retcode <= -1)
		{
			printf("client: send to failed: %d\n",errno);
			exit(0);
		}
		else
		{
			fV_print("Udp packet sent to client %d  successfuuly\n",vU32_DestIPNetworkOrder);
		}
		fV_freeMemory(pVS8_gatewayMsg);

		  /* close socket */
		//close(vS32_sockid);
	}
}

void fV_startProcessThread(s8 *pVS8_gatewayMsg)
{
	 printf("Thread is going to be started\n");
	 fB_msgProcessThreadStart((void*)fV_processGateMsg,pVS8_gatewayMsg,"msgProcess");
	 printf("Thread Started Successfully\n");
	 if(ASNGW_RELAY==TRUE)
	 {
		 printf("Msg received at Gateway1: %s\n",pVS8_gatewayMsg);
	 }
	 else
	 {
		 printf("Msg received at Gateway2: %s\n",pVS8_gatewayMsg);
	 }
}
void fV_receiver(struct struct_messageQID *pvStFp_messageQID){

	s32 vS32_numOfBytes = -1;
	s8 aS8_buffer[RECEIVER_BUFFER_SIZE];
	s8 *pvS8_buffer;
	struct struct_message vSt_message;

	while(1){

		fV_print("Waiting for something to receive");
		/*vS32_numOfBytes = recvfrom (vS32G_socketDescriptor, aS8_buffer, RECEIVER_BUFFER_SIZE,
						            0, (struct sockaddr*)&vStG_address, &vS32G_addressLen);*/

		fV_print("Soket Id%d",sockid);
		if(ASNGW_RELAY)fV_print("ASNGATEWAY1 is waiting to receive something");
		else fV_print("ASNGATEWAY2 is waiting to receive something");
		vS32_numOfBytes=recvfrom(sockid,aS8_buffer,RECEIVER_BUFFER_SIZE,0,
		                 (struct sockaddr *)&vStG_address,&vS32G_addressLen);


		if(vS32_numOfBytes>0){
			pvS8_buffer=(s8*)fV_allocateMemory(vS32_numOfBytes*sizeof(s8));
			printf("Client IP Port found.....%d\n",ntohs(vStG_address.sin_port));
			fV_print("Something got");
			//strcpy(pvS8_buffer,aS8_buffer);
			fS32_copyMemory(pvS8_buffer,aS8_buffer,vS32_numOfBytes);
			fV_startProcessThread(pvS8_buffer);
		}
		else
		{
			fV_print("Invalid packet received");
		}
		//		if(vS32_numOfBytes >= PACKET_HEADER_LENGTH){
//			if (fU16_getPacketLength(aS8_buffer) != vS32_numOfBytes){
//				fV_print("Receiver: Distorted Packet!!!\n");
//				continue;
//			}
//			//pvS8_buffer= (s8 *)fV_allocateMemory(vS32_numOfBytes);
//			//fS32_copyMemory(pvS8_buffer,aS8_buffer,vS32_numOfBytes);
//
//			if(ASNGW_RELAY==TRUE)
//			{
//
//			}
//			else
//			{
//
//
//				if(fU16_getTransactionID(aS8_buffer)!=0){
//
//					if(fB_isCompletePacket(aS8_buffer)){
//					  fS32_sendPacketToParser(pvStFp_messageQID->vS32_msgQIDW, aS8_buffer, vS32_numOfBytes);
//					}
//					else
//					  fS32_sendToReassembler(pvStFp_messageQID->vS32_msgQIDRW, aS8_buffer,vS32_numOfBytes);
//				}
//				else
//					fV_print("Transaction ID 0. Packet Dropped");
//
//				//fV_freeMemory(pvS8_buffer);
//			}
//		}
		//sleep(3);
	}
	//fS32_closeSocket(vS32G_socketDescriptor);
	close(sockid);

	return;
}

