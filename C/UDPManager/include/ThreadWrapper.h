/*
 * ThreadWrapper.h
 *
 *  Created on: Nov 8, 2008
 *      Author: root
 */

#ifndef THREADWRAPPER_H_
#define THREADWRAPPER_H_
#include <pthread.h>
#include "DataTypes.h"

boolean fB_msgProcessThreadStart(void *(*__start_routine) (void *), void *__restrict __arg,s8* pvS8_threadName);

#endif /* THREADWRAPPER_H_ */
