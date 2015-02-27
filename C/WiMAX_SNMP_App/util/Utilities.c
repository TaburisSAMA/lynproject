#include <stdio.h>
#include "Utilities.h"
#include <stdarg.h>


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
