/*
 * glibcwrapper.h
 *
 *  Created on: Nov 29, 2011
 *      Author: maksud
 */

#ifndef GLIBCWRAPPER_H_
#define GLIBCWRAPPER_H_

#include <flexsc/flexsc.h>

#define NUM_THREADS 64

#define sys_flexsc_register 303
#define sys_flexsc_wait 304
#define sys_flexsc_register2 305

struct syscall_entry_with_index
{
	int index;
	struct syscall_entry* entry;
};

struct syscall_buffer
{
	char buffer[384];
};

#include <stdlib.h>

struct syscall_entry* flexsc_getpid(struct syscall_entry* entry);

struct syscall_entry* flexsc_open_e(struct syscall_entry* entry, const char* filename, int mode, int rights);
struct syscall_entry* flexsc_close_e(struct syscall_entry* entry, long fileid);
struct syscall_entry* flexsc_write_e(struct syscall_entry* entry, long fileid, const void* data, size_t size, off_t offset);
struct syscall_entry* flexsc_read_e(struct syscall_entry* entry, long fileid, void* data, size_t size, off_t offset);

struct syscall_entry_with_index* flexsc_open(const char* filename, int mode, int rights);
struct syscall_entry_with_index* flexsc_close(long fileid);
struct syscall_entry_with_index* flexsc_read(long fileid, void* data, size_t size, off_t offset);
struct syscall_entry_with_index* flexsc_write(long fileid, const void* data, size_t size, off_t offset);


#endif /* GLIBCWRAPPER_H_ */
