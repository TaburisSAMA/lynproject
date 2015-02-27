#include <linux/linkage.h>
#include <linux/kernel.h>
#include <linux/ioport.h>
#include <linux/workqueue.h>
#include <linux/wait.h>
#include <linux/kthread.h>
#include <linux/slab.h>
#include <linux/version.h>
#include <linux/init.h>
#include <linux/module.h>
#include <linux/fs.h>
#include <linux/cdev.h>
#include <linux/mm.h>
#include <linux/kthread.h>
#ifdef MODVERSIONS
#  include <linux/modversions.h>
#endif
#include <asm/io.h>

/*
 * flexsc_helper.c
 *
 *  Created on: Nov 10, 2011
 *      Author: maksud
 */

struct task_struct *__mod_flexsc_registered = NULL;
struct mm_struct *__mod_flexsc_registered_mm = NULL;

static char __mod_my_kernel_buf[4096 * 2];
static int __mod_my_loop = 0;
static struct page **__mod_my_pages;

int __mod_kt_func1(void *p);
int __mod_kt_func2(void *p);

int __mod_kt_func1(void *p)
{
	//	while (__mod_my_loop > 0)
	//	{
	//
	//		int kk = access_process_vm(__mod_flexsc_registered, (long unsigned int) p, __mod_my_kernel_buf, 10, 0);
	//		if (kk > 0)
	//		{
	//			printk("1. Line: %d,%d\n", __mod_my_kernel_buf[0], __mod_my_kernel_buf[1]);
	//		}
	//		else
	//			printk("0. Line: %d,%d\n", __mod_my_kernel_buf[0], __mod_my_kernel_buf[1]);
	//
	//		__mod_my_loop--;
	//		msleep(1000);
	//	}
	return 0;
}

int __mod_kt_func2(void *p)
{
	int rr;
	while (__mod_my_loop > 0)
	{
		printk("Accessing: PID=%d\n", __mod_flexsc_registered->pid);

		down_read(&__mod_flexsc_registered->mm->mmap_sem);
		rr = get_user_pages(__mod_flexsc_registered, __mod_flexsc_registered->mm, (long) p, 1, 1, 0, __mod_my_pages, NULL);
		up_read(&current->mm->mmap_sem);

		printk("get_user_pages %d\n", rr);

		__mod_my_loop--;
		msleep(1000);
	}
	return 0;
}

void __mod_sys_1(void* p)
{
	kthread_run("kth1", __mod_kt_func1, p);
	//might also store process context as I am in system call!! How?
}

void __mod_sys_2(void* p)
{
	__mod_my_pages = kmalloc(1 * sizeof(*__mod_my_pages), GFP_KERNEL);

	kthread_run("kth2", __mod_kt_func2, p);
	//might also store process context as I am in system call!! How?
}

void* __mod_sc1(void* p)
{
	__mod_my_loop = 10;

	__mod_flexsc_registered = current;
	__mod_flexsc_registered_mm = get_task_mm(current);

	__mod_sys_1(p);

	return (void*) 1;
}

void* __mod_sc2(void* p)
{
	__mod_my_loop = 10;

	__mod_flexsc_registered = current;
	__mod_flexsc_registered_mm = get_task_mm(current);

	__mod_sys_2(p);
	return (void*) 2;
}
