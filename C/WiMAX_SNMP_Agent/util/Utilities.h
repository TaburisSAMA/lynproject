#ifndef UTILITIES_H_

#define UTILITIES_H_

#include "DataTypes.h"
#include "stdlib.h"
#include "string.h"
#include "unistd.h"

char *type_name[278];

void fV_print(s8 *pvS8Fp_format, ...);
s32 fS32_closeSocket(s32 vS32Fp_socketDesc);
void * fV_allocateMemory(s32 vS32Fp_size);
s32 fS32_setMemory(void *pvVFp_buffer, s32 vS32Fp_value, s32 vS32Fp_len);
s32 fS32_copyMemory(void *pvVFp_destination, void *pvVFp_source, s32 vS32Fp_len);
void fV_exitProgram(s32 vS32Fp_code);
void fV_freeMemory(void *);
// utilities
long fL_getIpAddress(char 	*pvCFp_ipAddr);
void fV_getMacAddress(char			*string,
				 	  unsigned char *ieee);
void fV_getDefaultSrcIp(u8 *pvU8Fp_srcIp);
void fV_getDefaultDestIp(u8 *pvU8Fp_srcIp);
#endif

