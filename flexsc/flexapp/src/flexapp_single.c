/*
 * flexapp_single.c
 *
 *  Created on: Nov 10, 2011
 *      Author: maksud
 */
#include "flexapp_single.h"
#include <stdio.h>
#include <stdlib.h>
#include "iflexsc.h"
#include "flexsc_syscalls.h"
#include <gnu/libc-version.h>
#include <linux/mman.h>
#include <fcntl.h>
#include <pthread.h>
#include <time.h>

#define wait_write(i) \
fd[i] = wait_and_return(entries[i]); \
entries[i] = flexsc_write(fd[i], 0, a, 4);

void print_message_function(void *ptr);

long long wait_and_return(struct syscall_entry* entry)
{
	//Can not proceed while status is not DONE
	while (entry->status != _FLEX_DONE)
	{
		//		printf("WAITING... for entry 1 return_code=%d, status=%d\n", entry1->return_code);
		//Nothing to Do.
	}
	long long fd1 = entry->return_code; //flexsc_open returns file descriptor.
	entry->status = _FLEX_FREE;
	return fd1;
}

#include <sys/time.h>
long long timeval_diff(struct timeval *difference, struct timeval *end_time, struct timeval *start_time)
{
	struct timeval temp_diff;

	//	printf("\n%ld,%ld,%ld,%ld\n", end_time->tv_sec, end_time->tv_usec, start_time->tv_sec, start_time->tv_usec);

	if (difference == NULL)
	{
		difference = &temp_diff;
	}

	difference->tv_sec = end_time->tv_sec - start_time->tv_sec;
	difference->tv_usec = end_time->tv_usec - start_time->tv_usec;

	/* Using while instead of if below makes the code slightly more robust. */

	while (difference->tv_usec < 0)
	{
		difference->tv_usec += 1000000;
		difference->tv_sec -= 1;
	}

	return 1000000LL * difference->tv_sec + difference->tv_usec;

} /* timeval_diff() */

void flexapp_single(void)
{
	long long elapsed;
	struct timeval start, end, interval;
	//	clock_t start_c, end_c;
	int a = 'A';
	a = a << 8 | 'B';
	a = a << 8 | 'C';
	a = a << 8 | 'D';
	a = a << 8 | 'B';
	a = a << 8 | 'C';
	a = a << 8 | 'D';
	a = a << 8 | 'B';
	a = a << 8 | 'C';
	a = a << 8 | 'D';

	if (gettimeofday(&start, NULL))
	{
		perror("error gettimeofday() #1");
		exit(1);
	}

	if (gettimeofday(&end, NULL))
	{
		perror("error gettimeofday() #2");
		exit(1);
	}
	elapsed = timeval_diff(&interval, &end, &start);
	printf("\nTime for initialization is %lld microseconds\n", elapsed); // output format: # microseconds


	int i1 = O_WRONLY | O_CREAT, i2 = 0644;

	struct syscall_entry* entries[64];
	long long fd[64];

	int i;

	if (gettimeofday(&start, NULL))
	{
		perror("error gettimeofday() #1");
		exit(1);
	}

	//	start_c = clock(); // put start of clock


	//Open System Call
	for (i = 0; i < 64; i++)
	{
		entries[i] = flexsc_open(i, i1, i2);
	}

	//Sync Point FlexSC-open
	for (i = 0; i < 64; i++)
	{
		fd[i] = wait_and_return(entries[i]);
	}

	//Write System Call
	for (i = 0; i < 64; i++)
	{
		entries[i] = flexsc_write(fd[i], 0, a, 4);
	}

	//Sync Point FlexSC-write
	for (i = 0; i < 64; i++)
	{
		wait_and_return(entries[i]);
	}

	//Close System Call
	for (i = 0; i < 64; i++)
	{
		entries[i] = flexsc_close(fd[i]);
	}

	//Sync Point FlexSC-close
	for (i = 0; i < 64; i++)
	{
		wait_and_return(entries[i]);
	}

	if (gettimeofday(&end, NULL))
	{
		perror("error gettimeofday() #2");
		exit(1);
	}

	//	end = clock(); // put end of clock

	elapsed = timeval_diff(&interval, &end, &start);
	printf("\nTime for syscall tasks and synchronization is %lld microseconds\n\n", elapsed); // output format: # microseconds
	//	printf("\n\nClock: %lf seconds\n",((double)end_c - start_c)/CLOCKS_PER_SEC);


	int i22 = 0;
	printf("Done Doing FlexSC. Enter any no:\n");
	scanf("%d", &i22);

	flexsc_register();

	puts("!!!DONE!!!"); /* prints !!!Hello World!!! */
}
