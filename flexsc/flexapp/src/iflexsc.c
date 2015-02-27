/*
 * iflexsc.c
 *
 *  Created on: Oct 24, 2011
 *      Author: maksud
 */

#include "iflexsc.h"
#include <sys/syscall.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdio.h>
#include <sys/types.h>
#include <stdio.h>
#include <unistd.h>
#include <sys/mman.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <stdlib.h>
#include <semaphore.h>  /* Semaphore */
#include <pthread.h>
#define NPAGES 16

struct syscall_page* basepage; // 4 * 64 = 256 Threads
//char* buffers; // 256 / 4 = 64
struct syscall_buffer* base_buffers;
//
//struct syscall_entry* entries[NUM_THREADS];
static pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

static int last_index = 0;

void printstack(void)
{
	int i, j, index;
	printf("\n");
	for (index = 0; index < NUM_THREADS; index++)
	{
		i = index % 64;
		j = index / 64;

		printf("%d ", index);
		printf("%d ", basepage[j].entries[i].syscall);
		printf("%d ", basepage[j].entries[i].num_args);
		printf("%d ", basepage[j].entries[i].status);
		printf("%ld ", basepage[j].entries[i].return_code);
		printf("%ld ", basepage[j].entries[i].args[0]);
		printf("%ld ", basepage[j].entries[i].args[1]);
		printf("%ld ", basepage[j].entries[i].args[2]);
		printf("%ld ", basepage[j].entries[i].args[3]);
		printf("%ld ", basepage[j].entries[i].args[4]);
		printf("%ld \n", basepage[j].entries[i].args[5]);
	}
	printf("\n");
}

struct syscall_page* flexsc_register_old(void)
{
	syscall(sys_flexsc_register);
	return NULL;
}

void flexsc_register(void)
{
	int index, i, j;
	int fd;
	unsigned char* kadr;
	int len = NPAGES * getpagesize();

	syscall(sys_flexsc_register2, (void*) (NUM_THREADS * 128));

	if ((fd = open("node2", O_RDWR | O_SYNC)) < 0)
	{
		perror("open");
		exit(-1);
	}
	kadr = mmap(0, len, PROT_READ | PROT_WRITE, MAP_SHARED | MAP_LOCKED, fd, len);
	if (kadr == MAP_FAILED)
	{
		perror("mmap");
		exit(-1);
	}
	close(fd);

	basepage = (struct syscall_page*) kadr; //First 4 * 4096 are reserved for 256 syscall threads
	base_buffers = (struct syscall_buffer*) (kadr + 4 * 64 * 64); //Rest 12 * 4096 / 128 = 384 bytes per thread buffer.
	//

	printf("Basepage: %ld, %p\n", (long) basepage, basepage);
	for (index = 0; index < NUM_THREADS; index++)
	{
		j = index / 64;
		i = index % 64;
		//

		basepage[j].entries[i].args[0] = 0;
		basepage[j].entries[i].args[1] = 0;
		basepage[j].entries[i].args[2] = 0;
		basepage[j].entries[i].args[3] = 0;
		basepage[j].entries[i].args[4] = 0;
		basepage[j].entries[i].args[5] = i + 100;
		basepage[j].entries[i].syscall = 0;
		basepage[j].entries[i].status = 0;
		basepage[j].entries[i].num_args = 0;
		basepage[j].entries[i].return_code = 0;
	}
}

void flexsc_wait(void)
{
	long pid = (long) getpid();
	long ret = syscall(sys_flexsc_wait);
	printf("%ld %ld\n", pid, ret);
}

struct syscall_page* allocate_register(void)
{
	return malloc(sizeof(struct syscall_page));
}

int last_used = 0;

struct syscall_entry* free_syscall_entry_i(int i)
{
	//	return &basepage[i / 64].entries[i % 64];
	return free_syscall_entry();
}

struct syscall_entry* free_syscall_entry(void)
{
	int i, j, index;
	//	printf("Try to Access.\n");
	struct syscall_entry* entry = NULL;

	pthread_mutex_lock(&mutex);
	for (index = 0; index < NUM_THREADS; index++)
	{
		//
		last_index = (last_index + 1) % NUM_THREADS;
		j = last_index / 64;
		i = last_index % 64;

		if (basepage[j].entries[i].status == _FLEX_FREE)
		{
			//			printf("Found! %d, %d\n", j, i);
			basepage[j].entries[i].status = _FLEX_RESERVED; // RESERVED
			entry = &basepage[j].entries[i];
			break;
		}
	}
	pthread_mutex_unlock(&mutex);

	if (entry == NULL)
	{
		printf("Could not find a Empty Entry, NULL\n");
		for (index = 0; index < NUM_THREADS; index++)
		{
			j = index / 64;
			i = index % 64;
			printf("Index[%d]=%d\n", index, basepage[j].entries[i].status);
		}
	}
	//		return free_syscall_entry();
	//	printf("Got Access?\n: %p", entry);
	return entry; // Sorry, No Free Entry.
}
