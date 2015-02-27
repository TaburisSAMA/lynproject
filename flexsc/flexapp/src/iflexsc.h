/*
 * iflexsc.h
 *
 *  Created on: Oct 24, 2011
 *      Author: maksud
 */

#ifndef IFLEXSC_H_
#define IFLEXSC_H_
#include <flexsc/flexsc.h>

#define NUM_THREADS 2

#define sys_flexsc_register 303
#define sys_flexsc_wait 304
#define sys_flexsc_register2 305

struct syscall_buffer
{
	char buffer[384];
};

//Explicit System Calls
struct syscall_page* flexsc_register_old(void);

//FlexSC Helpers
void flexsc_register(void);
struct syscall_entry* free_syscall_entry(void);
struct syscall_entry* free_syscall_entry_i(int i);
void flexsc_wait(void);

#endif /* IFLEXSC_H_ */
