/*
 * flexsc.h
 *
 *  Created on: Oct 14, 2011
 *      Author: maksud
 */

#ifndef _FLEXSC_MOD_FLEXSC_H_
#define _FLEXSC_MOD_FLEXSC_H_

void* __mod_unregister(void);
void* __mod_register(void* user_pages);

#define FLEXSC_BUFFER_SIZE 384

struct flexsc_buffer
{
	char data[FLEXSC_BUFFER_SIZE];
};

#endif /* _FLEXSC_MOD_FLEXSC_H_ */
