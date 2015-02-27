/*
 * flexsc_syscalls.c
 *
 *  Created on: Oct 24, 2011
 *      Author: maksud
 */

#include "iflexsc.h"
#include "flexsc_syscalls.h"
#include <stdlib.h>
#include <stdio.h>
#include <semaphore.h>  /* Semaphore */
//
extern struct syscall_buffer* base_buffers;
//
struct syscall_entry* flexsc_getpid(void)
{
	struct syscall_entry* entry = free_syscall_entry();
	if (entry != NULL)
	{
		entry->syscall = 39;
		entry->num_args = 0;
		entry->status = _FLEX_SUBMITTED;
		return entry;
	}
	else
	{
		printf("No Free Entry");
		return NULL;
	}
}

void printn(char* p, int n)
{
	int i;
	for (i = 0; i < n; i++)
	{
		printf("%d", p[i]);
	}
	printf("\n");
}

struct syscall_entry* flexsc_open_e(struct syscall_entry* entry, const char* filename, int mode, int rights)
{
	if (entry != NULL)
	{
		entry->syscall = _FLEX_SYSCALL_OPEN;
		entry->num_args = 3;
		entry->args[0] = (unsigned long) filename - (unsigned long) base_buffers; //Sending Memory Offset
		entry->args[1] = mode;
		entry->args[2] = rights;
		entry->status = _FLEX_SUBMITTED;
		//		printf("FILE:%s\n", (unsigned long) (buffers + entry->args[0]));
		return entry;
	}
	else
	{
		return NULL;
	}
}

struct syscall_entry* flexsc_close_e(struct syscall_entry* entry, long fileid)
{
	if (entry != NULL)
	{
		entry->syscall = _FLEX_SYSCALL_CLOSE;
		entry->num_args = 1;
		entry->args[0] = fileid;
		entry->status = _FLEX_SUBMITTED;
		return entry;
	}
	else
	{
		return NULL;
	}
}

struct syscall_entry* flexsc_write_e(struct syscall_entry* entry, long fileid, const void* data, size_t size, off_t offset)
{
	if (entry != NULL)
	{
		entry->syscall = _FLEX_SYSCALL_WRITE;
		entry->num_args = 4;
		entry->args[0] = fileid;
		entry->args[1] = (unsigned long) data - (unsigned long) base_buffers; //Sending Memory Offset
		entry->args[2] = size;
		entry->args[3] = offset;
		entry->status = _FLEX_SUBMITTED;
		//		printf("WRITE:%s\n", (unsigned long) (buffers + entry->args[2]));
		return entry;
	}
	else
	{
		return NULL;
	}
}

struct syscall_entry* flexsc_read_e(struct syscall_entry* entry, long fileid, void* data, size_t size, off_t offset)
{
	if (entry != NULL)
	{
		entry->syscall = _FLEX_SYSCALL_READ;
		entry->num_args = 4;
		entry->args[0] = fileid;
		entry->args[1] = (unsigned long) data - (unsigned long) base_buffers; //Sending Memory Offset
		entry->args[2] = size;
		entry->args[3] = offset;
		entry->status = _FLEX_SUBMITTED;
		//		printf("READ:%s\n", (unsigned long) (buffers + entry->args[2]));
		return entry;
	}
	else
	{
		return NULL;
	}
}
///////////////////////////////////////////////////////////////////////////////
struct syscall_entry* flexsc_open(const char* filename, int mode, int rights)
{
	struct syscall_entry* entry = free_syscall_entry();
	return flexsc_open_e(entry, filename, mode, rights);
}

struct syscall_entry* flexsc_close(long fileid)
{
	struct syscall_entry* entry = free_syscall_entry();
	return flexsc_close_e(entry, fileid);
}

struct syscall_entry* flexsc_write(long fileid, const void* data, size_t size, off_t offset)
{
	struct syscall_entry* entry = free_syscall_entry();
	return flexsc_write_e(entry, fileid, data, size, offset);
}

struct syscall_entry* flexsc_read(long fileid, void* data, size_t size, off_t offset)
{
	struct syscall_entry* entry = free_syscall_entry();
	return flexsc_read_e(entry, fileid, data, size, offset);
}

//////////////////////////////////////////
struct syscall_entry* flexsc_open_i(const char* filename, int mode, int rights, int i)
{
	struct syscall_entry* entry = free_syscall_entry_i(i);
	return flexsc_open_e(entry, filename, mode, rights);
}

struct syscall_entry* flexsc_close_i(long fileid, int i)
{
	struct syscall_entry* entry = free_syscall_entry_i(i);
	return flexsc_close_e(entry, fileid);
}

struct syscall_entry* flexsc_write_i(long fileid, const void* data, size_t size, off_t offset, int i)
{
	struct syscall_entry* entry = free_syscall_entry_i(i);
	return flexsc_write_e(entry, fileid, data, size, offset);
}

struct syscall_entry* flexsc_read_i(long fileid, void* data, size_t size, off_t offset, int i)
{
	struct syscall_entry* entry = free_syscall_entry_i(i);
	return flexsc_read_e(entry, fileid, data, size, offset);
}

