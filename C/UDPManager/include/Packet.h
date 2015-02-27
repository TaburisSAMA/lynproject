#ifndef PACKET_H_
#define PACKET_H_

#include "DataTypes.h"
//#include "HOLib.h"

#define MSID_LEN 6
#define MSG_HEADER_RESERVED_LEN 4
#define MAX_FRAGMENT_SIZE 1024
#define MORE_FRAGMENT_FLAG_MASK 4

u16 vU16_numOfPad;

struct struct_packetHeader {

	u8 vU8_version; 
	u8 vU8_flags;
	u8 vU8_functionType;
	
	u3 vU3_OPID;
	u5 vU5_messageType;

	u16 vU16_packetLength;
	u8 aU8_MSID[MSID_LEN];
	u8 aU8_reserved[MSG_HEADER_RESERVED_LEN];
	u16 vU16_transactionID;
	u16 vU16_offset;

};

struct struct_parsedPacket {
	struct struct_packetHeader vSt_header;
	s8 *pvS8_body;
	
};

struct struct_tlv{
	u16 vU16_type;
	u16 vU16_length;
	u16 vU16_numOfChildren;
	//u16 vU16_IndexAsChild;
	union{
		s8 *pvS8_tlvValue;
		struct struct_tlv *pvSt_subTLVs;
	}vU_value;
};

boolean fB_isCompletePacket(s8 *pvS8Fp_message );
u16 fU16_getTransactionID(s8 *pvS8Fp_message);
u16 fU16_getPacketLength(s8 *pvS8Fp_message );
struct struct_packetHeader fSt_extractHeader(s8 *pvS8Fp_message);
struct struct_packetHeader fSt_formHeader(u8 vU8Fp_version,
										  u8 vU8Fp_flags, 
										  u8 vU8Fp_functionType, 
										  u3 vU3Fp_OPID, 
										  u5 vU5Fp_messageType,
										  u16 vU16Fp_packetLength, 
										  u8 *pvU8Fp_MSID,
										  u16 vU16Fp_transactionID,
										  u16 vU16Fp_offset);

struct struct_tlv fSt_makeTLV(u16 vU16Fp_type, u16 vU16Fp_length, 
		                      s8 *pvS8Fp_value);
struct struct_tlv fSt_makeParentTLV(u16 vU16Fp_type, u16 vU16Fp_numOfChildren);
void fV_addSubTLV(struct struct_tlv *pvStFp_parentTLV, struct struct_tlv vStFp_childTLV, 
		          s32 vS32Fp_index);

void fpS8_makeBody(struct struct_tlv vStFp_tlv, u16 vU16Fp_version, s8* pvS8_body, u16 u16_index);
void fV_makeBodyFromTLVs(struct struct_tlv vStFp_tlv, s8 *pvS8Fp_body);
void fV_makeBodyFromHeader(struct struct_packetHeader vStFp_header, s8 *pvS8Fp_body);

#endif /*PACKET_H_*/
