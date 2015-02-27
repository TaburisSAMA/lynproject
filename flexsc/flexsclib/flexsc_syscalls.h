/*
 * flexsc_syscalls.h
 *
 *  Created on: Oct 24, 2011
 *      Author: maksud
 */

#ifndef FLEXSC_SYSCALLS_H_
#define FLEXSC_SYSCALLS_H_

#include <stdlib.h>

struct syscall_entry* flexsc_getpid(void);

struct syscall_entry* flexsc_open_e(struct syscall_entry* entry, const char* filename, int mode, int rights);
struct syscall_entry* flexsc_close_e(struct syscall_entry* entry, long fileid);
struct syscall_entry* flexsc_write_e(struct syscall_entry* entry, long fileid, const void* data, size_t size, off_t offset);
struct syscall_entry* flexsc_read_e(struct syscall_entry* entry, long fileid, void* data, size_t size, off_t offset);

struct syscall_entry* flexsc_open(const char* filename, int mode, int rights);
struct syscall_entry* flexsc_close(long fileid);
struct syscall_entry* flexsc_read(long fileid, void* data, size_t size, off_t offset);
struct syscall_entry* flexsc_write(long fileid, const void* data, size_t size, off_t offset);

struct syscall_entry* flexsc_open_i(const char* filename, int mode, int rights, int i);
struct syscall_entry* flexsc_close_i(long fileid, int i);
struct syscall_entry* flexsc_read_i(long fileid, void* data, size_t size, off_t offset, int i);
struct syscall_entry* flexsc_write_i(long fileid, const void* data, size_t size, off_t offset, int i);

#endif /* FLEXSC_SYSCALLS_H_ */
