/*
 * flexsc.h
 *
 *  Created on: Oct 14, 2011
 *      Author: maksud
 */

#ifndef _FLEXSC_FLEXSC_H_
#define _FLEXSC_FLEXSC_H_

#include <linux/sched.h>

struct syscall_entry {
	unsigned char index;  //1 byte. for test purpose
	unsigned int syscall; //4 bytes
	unsigned char num_args; //1 byte
	unsigned char status; //1 byte
	long long args[6]; //48 bytes
	long long return_code; //8 byte
};

struct syscall_page {
	struct task_struct* threads[64];
	struct syscall_entry entries[64];
};

#endif /* _FLEXSC_FLEXSC_H_ */
