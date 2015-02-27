#ifndef CONSTANTS_H_
#define CONSTANTS_H_

#include "DataTypes.h"

#define WIMAX_PORT_NUMBER 2231
#define SOCKET_DOMAIN AF_INET
#define SOCKET_TYPE SOCK_DGRAM
#define SOCKET_PROTOCOL "udp"
#define LISTEN_QUEUE_LEN 5
#define RECEIVER_BUFFER_SIZE 1024
#define PACKET_SIZE 4096
#define PACKET_HEADER_LENGTH 20
#define MAX_WIMAX_PACKET_LENGTH 65535
#define BASE_STATION_IP "172.16.0.236"
#define ASN_GATEWAY_IP "127.0.0.1"
#define MAX_NUM_OF_MS_PER_SECTOR 256
#define MAX_NUM_OF_FUNCTION_TYPES 10
#define MAX_NUM_OF_TRANSACTION_ENTRIES 1024

/*
 * Function Types
 */
#define QoS_FUNCTION 1
#define HO_CONTROL_FUNCTION 2
#define DATA_PATH_CONTROL_FUNCTION 3
#define CONTEXT_TRANSFER_FUNCTION 4
#define R3_MOBILITY_FUNCTION 5
#define PAGING_FUNCTION 6
#define RRM_FUNCTION 7
#define AUTHENTICATION_RELAY_FUNCTION 8
#define MS_STATE_FUNCTION 9
#define IM_OPERATIONS_FUNCTION 10

/*
 * Message Types
 */

//DATA_PATH_CONTROL_FUNCTION
#define PATH_DEREG_REQ 		1
#define PATH_DEREG_RSP 		2
#define PATH_DEREG_ACK		3

#define PATH_MOD_REQ 		4
#define PATH_MOD_RSP	 	5
#define PATH_MOD_ACK		6

#define PATH_PREREG_REQ 	7
#define PATH_PREREG_RSP 	8
#define PATH_PREREG_ACK		9

#define PATH_REG_REQ 		10
#define PATH_REG_RSP 		11
#define PATH_REG_ACK		12

//HO control & Context Transfer
#define HO_REQ 1
#define HO_RSP 2
#define HO_ACK 3
#define HO_CNF 4
#define HO_COMPLETE 5
#define HO_IND 26
#define CONTEXT_REQUEST_INDICATOR 27
#define CONTEXT_REPORT_INDICATOR  28
#define CMAC_KEY_COUNT_UPDATE     29
#define CMAC_KEY_COUNT_UPDATE_ACK 30

#define INITIATOR_MS 0
#define INITIATOR_BS 1

//6 Paging
#define Paging_Announce				1
#define Delete_MS_Entry_Req			2
#define PC_Relocation_Ind			3
#define PC_Relocation_Ack			4

//10 IM Operations
#define IM_Entry_State_Change_Req	1
#define IM_Entry_State_Change_Rsp	2
#define IM_Entry_State_Change_Ack	3
#define IM_Exit_State_Change_Req	4
#define IM_Exit_State_Change_Rsp	5
#define Initiate_Paging_Req			6
#define Initiate_Paging_Rsp			7
#define LU_Req						8
#define LU_Rsp						9
#define LU_Cnf						10

/**
 * Message Queue Path Strings
 */

#define MSGQ_PATH_FOR_FAPI_RESPONSE_HANDLER "/bin/df"
#define MSGQ_PATH_FOR_REASSEMBLER "/bin/bash"
#define MSGQ_PATH_FOR_PARSER "/bin/echo"
#define MSGQ_PATH_FOR_DISPATCHER "/bin/cp"

#define MSGQ_PATH_FOR_APPLICATIONS "/bin/mkdir"
#define MSGQ_PATH_FOR_APPLICATIONS_TBS "/bin/rmdir"

#define MSGQ_PATH_FOR_BUILDER "/bin/date"
#define MSGQ_PATH_FOR_SENDER "/bin/ps"
#define MSGQ_PATH_SS_NETWORK_ENTRY_CTRL "/bin/ls"
#define MSGQ_PATH_SS_NETWORK_ENTRY_EVENT "/bin/rmdir"

#define MSGQ_PATH_FOR_HO_CONTROL "/bin/hostname"/*HO Control*/
#define MSGQ_PATH_FOR_HO_CONTROL_EVENT "/bin/vi"/*HO Control*/
#define MSGQ_PATH_TEST_HO_CTRL "/bin/ps"

#define MSGQ_PATH_SFM_CONTROL 		"/bin/rm"			//SFM
#define MSGQ_PATH_SFM_CONTROL_EVENT "/bin/nautilus"		//SFM

#define MSGQ_PATH_FOR_CTXT_TRANSFER "/bin/mail"	// Context Transfer Module

/*
 * SS States
 */
#define SS_STATE_READY_FOR_ENTRY 2
#define SS_STATE_ENTRY_COMPLETE 4
#define SS_STATE_NET_EXIT_INITIATED 6
#define SS_STATE_RUNNING 8
/**
 * Ho Control States
 * */
#define SS_STATE_HO_STARTED 21
#define SS_STATE_HO_CANCELED 22
#define SS_STATE_HO_COMPLETED 23

/**
 * IMP states
 **/
#define SS_STATE_LOCATION_UPDATE_STARTED	91
#define SS_STATE_LOCATION_UPDATE_FINISHED	92
#define SS_STATE_IDLE_MODE_ENTRY_INITIATED	93

#define SS_STATE_MRH_TIMER_STARTED			95

#define SS_STATE_IDLE_MODE_EXIT_INITIATED	94

#define SS_STATE_PAGING_STARTED				98
#define SS_STATE_PAGING_STOP_CMD_RECEIVED	96
#define SS_STATE_MAX_PAGING_RETRY_DONE		97


/**
 *RRM - function type = 7
 * */
#define R6_PHY_PARAMETERS_REQ					1
#define R6_PHY_PARAMETERS_RPT					2
#define R4_R6_SPARE_CAPACITY_REQ				3
#define R4_R6_SPARE_CAPACITY_RPT				4
#define R6_NEIGHBOR_BS_RESOURCE_STATUS_UPDATE	5
#define R4_R6_RADIO_CONFIG_UPADATE_REQ			6
#define R4_R6_RADIO_CONFIG_UPADATE_RPT			7
#define R4_R6_RADIO_CONFIG_UPADATE_ACK			8

#define ASNGW_RELAY TRUE

#endif
