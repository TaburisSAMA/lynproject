/*
 * flexapp_threaded.c
 *
 *  Created on: Nov 10, 2011
 *      Author: maksud
 */

#include "flexapp_threaded.h"
#include <stdio.h>
#include <stdlib.h>
#include "iflexsc.h"
#include "flexsc_syscalls.h"
#include <gnu/libc-version.h>
#include <linux/mman.h>
#include <fcntl.h>
#include <pthread.h>
#include <time.h>
#include <string.h>
//
//extern char* buffers;
extern struct syscall_buffer* base_buffers;
//
typedef struct str_thdata
{
	int i;
} thdata;
//
pthread_t thread[NUM_THREADS]; /* thread variables */
thdata data[NUM_THREADS]; /* structs to be passed to threads */
//
long wait_and_return2(struct syscall_entry* entry)
{
	//Can not proceed while status is not DONE
	while (entry->status != _FLEX_DONE)
	{
		//		printf("WAITING... for entry 1 return_code=%d, status=%d\n", entry1->return_code);
		//Nothing to Do.
	}
	long fd1 = (unsigned long) entry->return_code; //flexsc_open returns file descriptor.
	entry->status = _FLEX_FREE;
	return fd1;
}

//
void print_message_function(void *ptr)
{
	int i, j;
	thdata *data;
	long fd = 0, rv;
	struct syscall_entry* entry;
	//
	int oFlags = O_RDWR | O_CREAT | O_APPEND, oModes = 0777;
	char* buffer;
	//
	data = (thdata *) ptr; /* type cast to a pointer to thdata */
	i = data->i;
	buffer = base_buffers[i].buffer;
	//

	for (j = 0; j < 1000; j++)
	{
		{
			//Open
			sprintf(buffer, "/home/maksud/FILE-%d.txt", i);
			entry = flexsc_open_i(buffer, oFlags, oModes, i);
			fd = wait_and_return2(entry);
		}
		//
		{
			//Read
			entry = flexsc_read_i(fd, buffer, 190, 0, i);
			rv = wait_and_return2(entry);
			//
//			while (rv > 0)
//			{
//				buffer[rv - 1] = 0;
//				//printf("READ:%s\n", buffer);
//				//printf("ReturnValue-Read: %d:%d\n", i, rv);
//				entry = flexsc_read_i(fd, buffer, 192, 0, i);
//				rv = wait_and_return2(entry);
//			}
		}
		//
		{
			//Write
			sprintf(buffer, "This is a test. Hello from %d.\n", i);
			entry = flexsc_write_i(fd, buffer, strlen(buffer), 0, i);
			rv = wait_and_return2(entry);
			//			printf("ReturnValue-Write: %d:%d\n", i, rv);
		}
		//
		{
			//Close
			entry = flexsc_close_i(fd, i);
			wait_and_return2(entry);
		}
	}

	//	printf("Thread %d returned\n", i);
	pthread_exit(0); /* exit */
} /* print_message_function ( void *ptr ) */

void flexapp_threaded(void)
{
	long long elapsed;
	struct timeval start, end, interval;
	int i;

	//
	if (gettimeofday(&start, NULL))
	{
		perror("error gettimeofday() #1");
		exit(1);
	}

	for (i = 0; i < NUM_THREADS; i++)
	{
		data[i].i = i;
		pthread_create(&thread[i], NULL, (void *) &print_message_function, (void *) &data[i]);
	}

	for (i = 0; i < NUM_THREADS; i++)
	{
		pthread_join(thread[i], NULL);
	}

	if (gettimeofday(&end, NULL))
	{
		perror("error gettimeofday() #2");
		exit(1);
	}

	elapsed = timeval_diff(&interval, &end, &start);
	printf("\nTime for syscall tasks and synchronization is %lld microseconds\n\n", elapsed); // output format: # microseconds


	printf("Last Action!\n");

}
