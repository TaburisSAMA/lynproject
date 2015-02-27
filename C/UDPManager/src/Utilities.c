#include <stdio.h>
#include "Utilities.h"
#include "Constants.h"
#include "InitTransport.h"


#include <stdarg.h>

char* type_name[278]=
{
	"unknown",
	"Accept/Reject Indicator",
	"Accounting Extension",
	"Action Code",
	"Action Time",
	"AK",
	"AK Context",
	"AK ID",
	"AK Lifetime",
	"AK SN",
	"Anchor ASN GW ID / Anchor DPF Identifier",

	"Anchor MM Context",
	"Anchor PC ID",
	"Anchor PC Relocation Destination",
	"Anchor PC Relocation Request Response",
	"Associated PHSI",
	"FA Revoke Reason",
	"Authentication Complete",
	"Authentication Result",
	"Authenticator ID",
	"RRQ",

	"Authorization Policy Support",
	"Available Radio Resource DL",
	"Available Radio Resource UL",
	"BE Data Delivery Service",
	"BS ID",
	"BS Info",
	"BS-originated EAP-Start Flag",
	"Care Of Address",
	"CID",
	"Classification Rule Index",

	"Classification Rule Action",
	"Classification Rule Priority",
	"Authentication Indication",
	"CMAC_KEY_COUNT",
	"Combined Resources Required",
	"Context Purpose Indicator",
	"Correlation ID",
	"Cryptographic Suite",
	"CS Type",
	"Data Integrity",

	"Data Integrity Info",
	"Data Path Encapsulation Type",
	"Data Path Establishment Option",
	"Data Path ID",
	"Data Path Info",
	"Data Path Integrity Mechanism",
	"Data Path Type",
	"DCD/UCD Configuration Change Count",
	"DCD Setting",
	"OFDMA Parameters Sets",

	"DHCP Key",
	"DHCP Key ID",
	"DHCP Key Lifetime",
	"DHCP Proxy Info",
	"DHCP Relay Address",
	"DHCP Relay Info",
	"DHCP Server Address",
	"DHCP Server List",
	"Direction",
	"DL PHY Quality Info",

	"DL PHY Service Level",
	"EAP Payload",
	"EIK",
	"ERT-VR Data Delivery Service",
	"PPAC",
	"FA-HA Key",
	"FA-HA Key Lifetime",
	"FA-HA SPI",
	"Failure Indication",
	"FA IP Address",

	"FA Relocation Indication",
	"Full DCD Setting",
	"Full UCD Setting",
	"Global Service Class Name",
	"HA IP Address",
	"HO Confirm Type",
	"Home Address",
	"HO Process Optimization",
	"HO Type",
	"Idle Mode Info",
	"Idle Mode Retain Info",
	"IP Destination Address and Mask",
	"IP Remained Time",
	"IP Source Address and Mask",
	"IP TOS/DSCP Range and Mask",
	"Key Change Indicator",
	"L-BSID",
	"Location Update Status",
	"AvailableInClient",
	"LU Result Indicator",
	"Maximum Latency",
	"Maximum Sustained Traffic Rate",
	"Maximum Traffic Burst",
	"Media Flow Type",
	"Minimum Reserved Traffic Rate",
	"MIP4 Info",
	"RRP",
	"MN-FA Key",
	"MN-FA SPI",
	"MS Authorization Context",
	"MS FA Context",
	"MSID",
	"MS Info",
	"MS Mobility Mode",
	"MS NAI",
	"MS Networking Context",
	"MS Security Context",
	"MS Security History",
	"Network Exit Indicator",
	"Newer TEK Parameters",
	"NRT-VR Data Delivery Service",
	"Older TEK Parameters",
	"Old Anchor PC ID",
	"Packet Classification Rule / Media Flow Description",
	"Paging Announce Timer",
	"Paging Cause",
	"Paging Controller ID",
	"Paging Cycle",
	"Paging Information",
	"Paging Offset",
	"Paging Start/Stop",
	"PC Relocation Indication",
	"Paging Group ID",
	"PHSF",
	"PHSI",
	"PHSM",
	"PHS Rule",
	"PHS Rule Action",
	"PHSS",
	"PHSV",
	"PPAQ",
	"PMIP4 Client Location",
	"PMK SN",
	"PKM2 Message Code",
	"Paging Interval Length",
	"PN Counter",
	"Preamble Index/Sub-channel Index",
	"Protocol",
	"Protocol Destination Port Range",
	"Protocol Source Port Range",
	"QoS Parameters",
	"Radio Resource Fluctuation",
	"MTG Profile",
	"REG Context",
	"Registration Type",
	"Relative Delay",
	"Registration Lifetime",
	"Quota Identifier",
	"Relocation Success Indicator",
	"Request/Transmission Policy",
	"Reservation Action",
	"Reservation Result",
	"Response Code",
	"Result Code",
	"ROHC/ECRTP Context ID",
	"Round Trip Delay",
	"RRM Absolute Threshold Value J",
	"RRM Averaging Time T",
	"RRM BS Info",
	"RRM BS-MS PHY Quality Info",
	"RRM Relative Threshold RT",
	"RRM Reporting Characteristics",
	"RRM Reporting Period P",
	"RRM Spare Capacity Report Type",
	"RT-VR Data Delivery Service",
	"RxPN Counter",
	"Volume Quota",
	"Volume Threshold",
	"SAID",
	"SA Descriptor",
	"SA Index",
	"SA Service Type",
	"SA Type",
	"SBC Context",
	"SDU BSN Map",
	"SDU Info",
	"SDU Size",
	"SDU SN",
	"Service Class Name",
	"Service Level Prediction",
	"Service Authorization Code",
	"Serving/Target Indicator",
	"SBC Capability Profile",
	"SFID",
	"SF Info",
	"Spare Capacity Indicator",
	"TEK",
	"TEK Lifetime",
	"TEK SN",
	"Tolerated Jitter",
	"Total Slots DL",
	"Total Slots UL",
	"Traffic Priority/QoS Priority",
	"Tunnel Endpoint",
	"UCD Setting",
	"UGS Data Delivery Service",
	"UL PHY Quality Info",
	"UL PHY Service Level",
	"Unsolicited Grant Interval",
	"Unsolicited Polling Interval",
	"VAAA IP Address",
	"VAAA Realm",
	"BS HO RSP Code",
	"Accounting Context",
	"HO ID",
	"Combined Resource Indicator",
	"R3 WiMAX Capability",
	"R3 Accounting Capabilities",
	"R3 Idle Notification Capabilities",
	"R3 CUI",
	"R3 Class",
	"R3 Framed IP Address",
	"R3 Framed IPv6 Prefix",
	"R3 AAA Session ID",
	"R3 Packet Flow Descriptor",
	"R3 Packet Data Flow ID",
	"R3 Service Data Flow ID",
	"R3 Service Profile ID",
	"R3 Direction",
	"R3 Activation Trigger",
	"R3 Transport Type",
	"R3 Uplink QoS ID",
	"R3 Downlink QoS ID",
	"R3 Uplink Classifier",
	"R3 Downlink Classifier",
	"R3 QoS Descriptor",
	"R3 QoS ID",
	"Media Flow Description in SDP Format",
	"unknown",
	"R3 Schedule Type",
	"unknown",
	"unknown",
	"unknown",
	"unknown",
	"unknown",
	"R3 Maximum Latency",
	"Reduced Resources Code",
	"R3 Media Flow Type",
	"unknown",
	"R3 SDU Size",
	"R3 Unsolicited Polling Interval",
	"R3 Acct Interim Interval",
	"Accounting Mode Provisioning",
	"Accounting Session/Flow Volume Counts",
	"Accounting Number of Bulk Sessions/Flows",
	"Accounting Bulk Session/Flow",
	"Account Type",
	"Interim Update Interval",
	"Cumulative Uplink Octets",
	"Cumulative Downlink Octets",
	"Cumulative Uplink Packets",
	"Cumulative Downlink Packets",
	"Time of Day Tariff Switch",
	"Time of Day Tariff Switch Time",
	"Time of Day Tariff Switch Offset",
	"Accounting Number of ToDs",
	"Uplink Octets at Tariff Switch",
	"Downlink Octets at Tariff Switch",
	"Uplink Packets at Tariff Switch",
	"Downlink Packets at Tariff Switch",
	"Vendor Specific TLV",
	"Paging Preference",
	"Idle Mode Authorization Indication",
	"Accounting IP Address",
	"Data Delivery Trigger",
	"MIP4 Security Info",
	"MN-FA Key Lifetime",
	"Idle Mode Timeout",
	"Classification Result",
	"Network assisted HO Supported",
	"Destination Identifier",
	"Source Identifier",
	"R3 Relocation Action",
	"Ungraceful Network Exit Indication",
	"Duration Quota",
	"Duration Threshold",
	"Resource Quota"
};


void fV_print(s8 *pvS8Fp_format, ...)
{
  va_list vSt_ap;
  s8 *pvS8_p, *pvS8_sval;
  s32 vS32_ival;
  double dval;
  va_start(vSt_ap, pvS8Fp_format);
  for (pvS8_p = pvS8Fp_format; *pvS8_p; pvS8_p++) {
      if (*pvS8_p != '%') {
          putchar(*pvS8_p);
          continue;
      }
      switch (*++pvS8_p) {
      case 'd':
          vS32_ival = va_arg(vSt_ap, int);
          printf("%d", vS32_ival);
          break;
      case 'f':
          dval = va_arg(vSt_ap, double);
          printf("%f", dval);
          break;
      case 's':
          for (pvS8_sval = va_arg(vSt_ap, char *); *pvS8_sval; pvS8_sval++)
               putchar(*pvS8_sval);
          break;
      default:
          putchar(*pvS8_p);
          break;
      }
  }
  va_end(vSt_ap);
}


s32 fS32_closeSocket(s32 vS32Fp_socketDesc){

	s32 vS32_returnCode = close(vS32Fp_socketDesc);
	if ( vS32_returnCode == -1){
		fV_print("Socket Closing Failed.");
		return vS32_returnCode;
	}
	fV_print("Socket Closing Successful.");
	return vS32_returnCode;
}

void fV_exitProgram(s32 vS32Fp_code){

	fV_print("Exiting.");
	exit(vS32Fp_code);
	return;

}

void * fV_allocateMemory(s32 vS32Fp_size){

	void *pvV_allocatedMemory = malloc (vS32Fp_size);
	if (pvV_allocatedMemory==NULL)
		fV_print("Memory Allocation Error");

	return pvV_allocatedMemory;
}

s32 fS32_setMemory(void *pvVFp_buffer, s32 vS32Fp_value, s32 vS32Fp_len){

	if (memset(pvVFp_buffer, vS32Fp_value, vS32Fp_len) == NULL){
		fV_print("Failed to Set Memory.");
		return -1;
	}
	//fV_print("Successful Memory Set.");
	return 0;
}

s32 fS32_copyMemory(void *pvVFp_destination, void *pvVFp_source, s32 vS32Fp_len){

	if (memcpy(pvVFp_destination, pvVFp_source, vS32Fp_len) == NULL){
		fV_print("Failed to Copy Memory.");
		return -1;
	}
	return 0;
}

void fV_freeMemory(void * pvVFp_buffer){

	free(pvVFp_buffer);
	return;
}


long fL_getIpAddress(char *pvCFp_ipAddr)
{
	char tempChar[4];
    int i = 0;
    int j = 0;
    int k = 0;
    long ipAddr = 0;
    char* pAddr = NULL;

    pAddr = (char*)&(ipAddr);

    for (k=0; k<3; k++)
    {
        j = 0;
        do {
            tempChar[j] = pvCFp_ipAddr[i];
            i++;
            j++;
        } while (pvCFp_ipAddr[i] != '.');
        i++;
        tempChar[j] = '\0';
        pAddr[k] = (char)(atoi(tempChar));
    }

    j = 0;
    do {
        tempChar[j] = pvCFp_ipAddr[i];
        i++;
        j++;
    } while (pvCFp_ipAddr[i] != '\0');
    tempChar[j] = '\0';
    pAddr[3] = (char)(atoi(tempChar));

    return htonl(ipAddr);

}



/* Function converts string representation of the MAC address
 * to the binary value.
 */
void fV_getMacAddress(char	*string,
				 	  unsigned char *ieee)
{
    unsigned int hex;
    unsigned char *ep;
    char *next  = 0;

    for(ep = ieee; *string; ep++)
    {
        hex = strtol(string, &next, 16);
        *ep = (unsigned char ) hex;
        string = next;
        if (*string == ':')
        {
            ++string;
        }
    }
} /* AppUtils_GetMacAddress() */

void fV_getDefaultSrcIp(u8 *pvU8Fp_srcIp){

	long vL_ip = fL_getIpAddress(BASE_STATION_IP);
	pvU8Fp_srcIp[0] = vL_ip & 255;
	vL_ip = vL_ip >> 8;
	pvU8Fp_srcIp[1] = vL_ip & 255;
	vL_ip = vL_ip >> 8;
	pvU8Fp_srcIp[2] = vL_ip & 255;
	pvU8Fp_srcIp[3] = vL_ip;

	return;
}

void fV_getDefaultDestIp(u8 *pvU8Fp_srcIp){

	long vL_ip = fL_getIpAddress(ASN_GATEWAY_IP);
	pvU8Fp_srcIp[0] = vL_ip & 255;
	vL_ip = vL_ip >> 8;
	pvU8Fp_srcIp[1] = vL_ip & 255;
	vL_ip = vL_ip >> 8;
	pvU8Fp_srcIp[2] = vL_ip & 255;
	pvU8Fp_srcIp[3] = vL_ip;

	return;
}

