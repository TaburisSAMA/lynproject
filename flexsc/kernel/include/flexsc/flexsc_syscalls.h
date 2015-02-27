/*
 * flex_syscalls.h
 *
 *  Created on: Oct 29, 2011
 *      Author: maksud
 */

#ifndef _FLEXSC_FLEXSC_SYSCALLS_H_
#define _FLEXSC_FLEXSC_SYSCALLS_H_

#include <linux/sched.h>
#include <linux/fs.h>

struct file* __flexsc_file_open(const char* path, int flags, int rights);
void __flexsc_file_close(struct file* file);
ssize_t __flexsc_file_pread(struct file* file, void* data, size_t size, loff_t offset);
ssize_t __flexsc_file_pwrite(struct file* file, const void* data, size_t size, loff_t offset);

#endif /* _FLEXSC_FLEXSC_SYSCALLS_H_ */
