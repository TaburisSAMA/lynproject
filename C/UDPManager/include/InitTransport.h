#ifndef INITIALIZATION_H_
#define INITIALIZATION_H_

#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <netdb.h>
#include <DataTypes.h>
#include <errno.h>

struct sockaddr_in vStG_address;
struct sockaddr_in vStG_myaddress;
s32 vS32G_socketDescriptor;
s32 vS32G_addressLen;
s32 vS32G_serveraddlen;
s32 sockid;


/*struct_correlator fSt_getCorrelator();


struct_feHandle fSt_getFeHandle();
struct_feHandle fSt_getBscpFeHandle();
struct_errReport fSt_getErrorReport();
struct_cbHandle fSt_getBscpCallbackHandle();
struct_cbHandle fN_getPhyCallbackHandle();
*/
boolean fB_initServer();
boolean fB_initClient();



#endif /*INITIALIZATION_H_*/
