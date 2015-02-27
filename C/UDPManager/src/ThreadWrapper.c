/*
 * ThreadWrapper.c
 *
 *  Created on: Nov 8, 2008
 *      Author: root
 */
#include "ThreadWrapper.h"
#include "Utilities.h"

boolean fB_msgProcessThreadStart(void *(*__start_routine) (void *), void *__restrict __arg,s8*pvS8_threadName)
{
	pthread_t vSt_ssThread;
	s32 vS32_threadResult = pthread_create(&vSt_ssThread, NULL, __start_routine, __arg);


	if (vS32_threadResult != 0)
	{
		fV_print("%s thread creation failed",pvS8_threadName);
		return FALSE;
	}

	fV_print("%s thread created",pvS8_threadName);
	return TRUE;
}

