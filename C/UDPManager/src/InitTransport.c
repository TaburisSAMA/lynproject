#include "InitTransport.h"
#include "Constants.h"
#include "Utilities.h"
#include <arpa/inet.h>
#include <string.h>
//#include "Dispatcher.h"
//#include <npf_f_wmax_bscp_bsn.h>
//#include <pthread.h>


//struct protoent * pvStG_protocol;




boolean fB_openClientSocket(){

	/**
	 * Socket Creation.
	 */
	vS32G_socketDescriptor = socket(SOCKET_DOMAIN, SOCKET_TYPE, 0);
	if (vS32G_socketDescriptor < 0)
	{
		fV_print("Socket Creation Failed\n");
		return FALSE;
	}
	return TRUE;
}


boolean fB_initClient(){

//	fS32_setMemory((s8 *)&vStG_address, 0, sizeof(vStG_address));
//	if (gethostbyname(ASN_GATEWAY_IP) == 0){
//	    fV_print("Error resolving local host\n");
//	    return FALSE;
//	}
//	vStG_address.sin_addr.s_addr = inet_addr(ASN_GATEWAY_IP);
//	vStG_address.sin_family = SOCKET_DOMAIN;
//	vStG_address.sin_port = htons((u_short)WIMAX_PORT_NUMBER);
//	pvStG_protocol = getprotobyname(SOCKET_PROTOCOL);
//	vS32G_addressLen = sizeof (vStG_address);
//
//	return fB_openClientSocket();
	return TRUE;


}

boolean fB_openServerSocket(){

	/**
	 * Socket Creation.
	 */
//	vS32G_socketDescriptor = socket(SOCKET_DOMAIN, SOCKET_TYPE, pvStG_protocol->p_proto);
//	if (vS32G_socketDescriptor < 0)
//	{
//		fV_print("Socket Creation Failed\n");
//		fV_exitProgram(1);
//	}
//	/**
//	 * Socket Binding.
//	 */
//	if (bind(vS32G_socketDescriptor, (struct sockaddr*)&vStG_address, sizeof(vStG_address))<0)
//	{
//		fV_print("Socket Binding Failed\n");
//		fV_exitProgram(1);
//	}

	return TRUE;
}



boolean fB_initServer(){

	//fS32_setMemory((s8 *)&vStG_address, 0, sizeof(vStG_address));
//	vStG_address.sin_addr.s_addr = INADDR_ANY;
//	vStG_address.sin_family = SOCKET_DOMAIN;
//	vStG_address.sin_port = htons((u_short)WIMAX_PORT_NUMBER);
//	pvStG_protocol = getprotobyname(SOCKET_PROTOCOL);
//	vS32G_addressLen = sizeof (vStG_address);
//
//	return fB_openServerSocket();
	if ( (sockid = socket(AF_INET, SOCK_DGRAM, 0)) < 0)
	{
		fV_print("Server: socket error: %d\n",errno);
		fV_exitProgram(1);
	}
	fV_print("Socket Id after Creation%d...  ",sockid);

	fV_print("Server: binding my local socket\n");
   bzero((char *)&vStG_myaddress, sizeof(vStG_myaddress));
   vStG_myaddress.sin_family = AF_INET;
   vStG_myaddress.sin_addr.s_addr = htons(INADDR_ANY);

   //vStG_myaddress.sin_addr.s_addr = inet_addr(ASN_GATEWAY_IP);
   //vStG_myaddress.sin_port = htons(WIMAX_PORT_NUMBER);
   //vStG_myaddress.sin_addr.s_addr = inet_addr(ASN_GATEWAY_IP);

   if(ASNGW_RELAY==TRUE)
   {
	   vStG_myaddress.sin_port = htons(WIMAX_PORT_NUMBER);

   }
   else
   {
	   vStG_myaddress.sin_port = htons(WIMAX_PORT_NUMBER+1);
   }
	if ( (bind(sockid, (struct sockaddr *) &vStG_myaddress,
	      sizeof(vStG_myaddress)) < 0) )
	      { fV_print("Server: bind fail: %d\n",errno); fV_exitProgram(0);}

	   return TRUE;
}
