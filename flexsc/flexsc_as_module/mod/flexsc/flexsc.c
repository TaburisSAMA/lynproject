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
#include <linux/fs.h>		// Needed by filp
#include <linux/cdev.h>
#include <linux/mm.h>
#include <linux/kthread.h>
#ifdef MODVERSIONS
#  include <linux/modversions.h>
#endif
#include <asm/io.h>
#include <asm/uaccess.h>   // Needed by segment descriptors
#include <flexsc/flexsc.h>
#include <mod/flexsc/flexsc_syscalls.h>

#define _FLEX_SYSCALL_SEEK 100

#define MAX_SYSCALL_THREAD 128

static int ACTIVE_THREADS = 0;

typedef struct
{
	struct work_struct my_work;
	int index;
	int status;
} my_work_t;

//
// internal data
// length of the two memory areas
#define NPAGES 16 //256*4 = Buffers, 4*64 = syscall_entry
// pointer to the kmalloc'd area, rounded up to a page boundary
static char* __mod_kmalloc_area; //Starting Address
static char* __mod_syscall_buffers = NULL; //Starting Address + 4*64*64
// original pointer for kmalloc'd area as returned by kmalloc
static void* __mod_kmalloc_ptr = NULL;

/*
 * Workqueue structures.
 * */
static int __mod_valid_wq = 0;
static struct workqueue_struct *__mod_my_wq = NULL;
static my_work_t __mod_flex_work_data[MAX_SYSCALL_THREAD];

/*
 * kthread structures.
 * */
static struct task_struct* __mod_syscall_threads[MAX_SYSCALL_THREAD] =
{ 0 };

static struct syscall_page* __mod_shared_syscall_page = NULL;
static struct task_struct* __mod_registered_process = NULL;

static int __mod_flexsc_device_created = 0;

void __mod_print_entry(int i)
{
	int j = i / 64;
	int index = i % 64;
	printk("%d %d %d %d %ld %ld %ld %ld %ld %ld %ld\n", i, //
			__mod_shared_syscall_page[j].entries[index].syscall, //
			__mod_shared_syscall_page[j].entries[index].num_args, //
			__mod_shared_syscall_page[j].entries[index].status, //
			__mod_shared_syscall_page[j].entries[index].args[0], //
			__mod_shared_syscall_page[j].entries[index].args[1], //
			__mod_shared_syscall_page[j].entries[index].args[2], //
			__mod_shared_syscall_page[j].entries[index].args[3], //
			__mod_shared_syscall_page[j].entries[index].args[4], //
			__mod_shared_syscall_page[j].entries[index].args[5], //
			__mod_shared_syscall_page[j].entries[index].return_code);
}

int __mod_perform_flex_system_call(struct syscall_entry* entry)
{
	char* buffer;
	if (entry->status == _FLEX_SUBMITTED)
	{
		//		kprint_true ? printk("~~~~~~~~~~~~~FOUND~~~~~~~~~~~~~~~~\n") : 1;
		//		kprint_true ? printk("##ENTRY From Worker Thread. [%d] = %d, [0]=%ld, [1]=%ld, [2]=%ld\n", entry->index, entry->syscall, entry->args[0], entry->args[1], entry->args[2]) : 1;
		switch (entry->syscall)
		{
		case _FLEX_SYSCALL_OPEN:
			buffer = __mod_syscall_buffers + entry->args[0];
			printk("open(%s, %ld, %ld)\n", buffer, entry->args[1], entry->args[2]);
			entry->return_code = __mod_file_open(buffer, entry->args[1], entry->args[2]);
			//			entry->return_code = __mod_open_fd(buffer, entry->args[1], entry->args[2]);
			break;

		case _FLEX_SYSCALL_CLOSE:
			printk("close(%ld)\n", entry->args[0]);
			entry->return_code = 0;
			__mod_file_close((struct file*) entry->args[0]);
			//			entry->return_code = __mod_close_fd(entry->args[0]);
			break;

		case _FLEX_SYSCALL_PREAD:
			printk("pread(%ld, %ld, %ld, %ld)\n", entry->args[0], entry->args[1], entry->args[2], entry->args[3]);
			buffer = __mod_syscall_buffers + entry->args[1];
			entry->return_code = __mod_file_pread((struct file*) entry->args[0], buffer, entry->args[2], entry->args[3]);
			break;

		case _FLEX_SYSCALL_PWRITE:
			printk("pwrite(%ld, %ld, %ld, %ld)\n", entry->args[0], entry->args[1], entry->args[2], entry->args[3]);
			buffer = __mod_syscall_buffers + entry->args[1];
			entry->return_code = __mod_file_pwrite((struct file*) entry->args[0], buffer, entry->args[2], entry->args[3]);
			break;

		case _FLEX_SYSCALL_READ:
			printk("read(%ld, %ld, %ld)\n", entry->args[0], entry->args[1], entry->args[2]);
			buffer = __mod_syscall_buffers + entry->args[1];
			entry->return_code = __mod_file_read((struct file*) entry->args[0], buffer, entry->args[2]);
			//			entry->return_code = __mod_read_fd(entry->args[0], buffer, entry->args[2]);
			break;

		case _FLEX_SYSCALL_WRITE:
			printk("write(%ld, %ld, %ld)\n", entry->args[0], entry->args[1], entry->args[2]);
			buffer = __mod_syscall_buffers + entry->args[1];
			entry->return_code = __mod_file_write((struct file*) entry->args[0], buffer, entry->args[2]);
			//			entry->return_code = __mod_write_fd(entry->args[0], buffer, entry->args[2]);
			break;

		case _FLEX_SYSCALL_SEEK:
			printk("seek(%ld, %ld, %ld)\n", entry->args[0], entry->args[1], entry->args[2]);
			//			buffer = __mod_syscall_buffers + entry->args[1];
			entry->return_code = __mod_file_seek((struct file*) entry->args[0], entry->args[1], entry->args[2]);
			//			entry->return_code = __mod_seek_fd(entry->args[0],  entry->args[1], entry->args[2]);
			//entry->return_code = 0;
			break;

		}
		printk("return_code = %ld\n", entry->return_code);
		entry->status = _FLEX_DONE;
	}
	return 0;
}

static void __mod_my_wq_function(struct work_struct *work)
{
	my_work_t *my_work = (my_work_t *) work;
	int index = my_work->index;
	int status = my_work->status;
	int j = index / 64;
	int i = index % 64;

	struct syscall_entry* entry = &__mod_shared_syscall_page[j].entries[i]; //User

	if (entry->status == _FLEX_SUBMITTED)
	{
		//print_entry(j);
		__mod_perform_flex_system_call(entry);
	}

	//	msleep(1);

	if (__mod_valid_wq && status == 1)
		queue_work(__mod_my_wq, (struct work_struct *) work);

	return;
}

int __mod_syscall_thread_run(void *work)
{
	my_work_t* my_work = (my_work_t *) work;
	int index = my_work->index;
	int j = index / 64;
	int i = index % 64;

	struct syscall_entry* entry = &__mod_shared_syscall_page[j].entries[i]; //User

	while (1)
	{
		//
		if (entry->status == _FLEX_SUBMITTED)
		{
			//print_entry(j);
			__mod_perform_flex_system_call(entry);
		}

		msleep(1);

		if (kthread_should_stop())
			break;
	}
	return 0;
}

//mmap portion//////////////
/* character device structures */
static dev_t __mod_mmap_dev;
static struct cdev __mod_mmap_cdev;

/* methods of the character device */
static int __mod_mmap_open(struct inode *inode, struct file *filp);
static int __mod_mmap_release(struct inode *inode, struct file *filp);
static int __mod_mmap_mmap(struct file *filp, struct vm_area_struct *vma);

/* the file operations, i.e. all character device methods */
static struct file_operations __mod_mmap_fops =
{ .open = __mod_mmap_open, .release = __mod_mmap_release, .mmap = __mod_mmap_mmap, };

/* character device open method */
static int __mod_mmap_open(struct inode *inode, struct file *filp)
{
	return 0;
}
/* character device last close method */
static int __mod_mmap_release(struct inode *inode, struct file *filp)
{
	return 0;
}

/* character device mmap method */
static int __mod_mmap_mmap(struct file *filp, struct vm_area_struct *vma)
{
	/* at offset NPAGES we map the kmalloc'd area */
	if (vma->vm_pgoff == NPAGES)
	{
		int ret;
		long length = vma->vm_end - vma->vm_start;

		/* check length - do not allow larger mappings than the number of pages allocated */
		if (length > NPAGES * PAGE_SIZE)
			return -EIO;

		/* map the whole physically contiguous area in one piece */
		if ((ret = remap_pfn_range(vma, vma->vm_start, virt_to_phys((void *) __mod_kmalloc_area) >> PAGE_SHIFT, length, vma->vm_page_prot)) < 0)
		{
			return ret;
		}

		return 0;
	}
	/* at any other offset we return an error */
	return -EIO;
}

void __mod_stop_syscall_threads(void)
{
	int i;
	for (i = 0; i < MAX_SYSCALL_THREAD; i++)
	{
		if (__mod_syscall_threads[i] != NULL)
		{
			kthread_stop(__mod_syscall_threads[i]);
			__mod_syscall_threads[i] = NULL;
		}
	}
}
void __mod_register_kthread_version(void)
{
	int i;

	__mod_stop_syscall_threads();

	for (i = 0; i < ACTIVE_THREADS; i++)
	{
		__mod_flex_work_data[i].index = i;
		__mod_syscall_threads[i] = kthread_run(__mod_syscall_thread_run, (void *) &__mod_flex_work_data[i], "__mod_syscall_thread");
	}
}

/*
 * Work Queue Implementation of syscall thread.
 *
 * */

void __mod_register_workqueue_version(void)
{
	int i, j, index, ret;

	if (__mod_my_wq != NULL)
	{
		//		valid_wq = 0;
		printk("Previous Work Queue Found!\n");
		//		destroy_workqueue(my_wq);
		//Initialize All the Works
		for (i = 0; i < MAX_SYSCALL_THREAD; i++)
		{
			// Activate deactivated threads.
			if (i < ACTIVE_THREADS && __mod_flex_work_data[i].status == 0)
			{
				printk("Activate a deactivated thread: %d!\n", i);
				__mod_flex_work_data[i].status = 1;
				ret = queue_work(__mod_my_wq, (struct work_struct *) &__mod_flex_work_data[i]);
			}

			//Stop the rest threads
			if (i >= ACTIVE_THREADS)
			{
				__mod_flex_work_data[i].status = 0;
			}
		}
	}
	else
	{
		printk("Creating Work Queue\n");
		__mod_my_wq = create_workqueue("mod_flexsc_queue");
		__mod_valid_wq = 1;

		if (__mod_my_wq == NULL)
		{
			printk("Problem Creating Work Queue\n");
			return;
		}

		//Initialize All the Works
		for (index = 0; index < MAX_SYSCALL_THREAD; index++)
		{
			j = index / 64;
			i = index % 64;
			//printk("Allocating necessary memories: %d\n", i);
			printk("+++++++++++++++++[%d] = S: %d, #: %d, St: %d, Args[5]=%ld\n", index, //
					__mod_shared_syscall_page[j].entries[i].syscall, //
					__mod_shared_syscall_page[j].entries[i].num_args, //
					__mod_shared_syscall_page[j].entries[i].status, //
					__mod_shared_syscall_page[j].entries[i].args[5]);
			//
			printk("*****************Creating Works:%d\n", index);
			INIT_WORK((struct work_struct *) &__mod_flex_work_data[index], __mod_my_wq_function);
			__mod_flex_work_data[index].index = index;
			__mod_flex_work_data[index].status = 0;
		}

		//Queue only active threads
		for (i = 0; i < ACTIVE_THREADS; i++)
		{
			__mod_flex_work_data[i].status = 1;
			ret = queue_work(__mod_my_wq, (struct work_struct *) &__mod_flex_work_data[i]);
		}
	}
}

void* __mod_register(void* user_pages)
{
	int i, j, index, ret;
	long params = (long) user_pages;
	int thread_type = params % 128;
	ACTIVE_THREADS = params / 128;

	//	struct syscall_page* pp;
	printk("Registering Process: PID = %d\n", current->pid);
	__mod_registered_process = current;

	printk("Number of Threads=%d\n", ACTIVE_THREADS);
	printk("Register: %p\n", __mod_kmalloc_ptr);

	printk("Sizeof syscall page is: %ld", sizeof(struct syscall_page));

	/**
	 * If already allocated, not allocate again. Use previous memory.
	 */
	if (__mod_kmalloc_ptr == NULL)
	{
		printk("Size of memory: %d\n", (NPAGES + 2) * PAGE_SIZE);
		/* allocate a memory area with kmalloc. Will be rounded up to a page boundary */
		if ((__mod_kmalloc_ptr = kmalloc((NPAGES + 2) * PAGE_SIZE, GFP_KERNEL)) == NULL)
		{
			printk("Yo, No memory.\n");
			ret = -ENOMEM;
			goto out;
		}

		//printk("__kmalloc_ptr: %ld, %p\n", __mod_kmalloc_ptr, __mod_kmalloc_ptr);
		/* round it up to the page bondary */
		__mod_kmalloc_area = (char *) ((((unsigned long) __mod_kmalloc_ptr) + PAGE_SIZE - 1) & PAGE_MASK);
		//printk("__mod_kmalloc_area: %ld, %p\n", __mod_kmalloc_area, __mod_kmalloc_area);

		/* mark the pages reserved */
		for (i = 0; i < NPAGES * PAGE_SIZE; i += PAGE_SIZE)
		{
			SetPageReserved(virt_to_page(((unsigned long) __mod_kmalloc_area) + i));
		}
		//
		__mod_shared_syscall_page = (struct syscall_page*) __mod_kmalloc_area; // kmalloced area is the actual area.
		__mod_syscall_buffers = (char*) (__mod_kmalloc_area + 4 * 64 * 64);
		//
		for (index = 0; index < MAX_SYSCALL_THREAD; index++)
		{
			j = index / 64;
			i = index % 64;
			//
			__mod_shared_syscall_page[j].entries[i].status = _FLEX_FREE;
			__mod_shared_syscall_page[j].entries[i].syscall = 0;
			__mod_shared_syscall_page[j].entries[i].num_args = 0;
			__mod_shared_syscall_page[j].entries[i].return_code = 0;
			__mod_shared_syscall_page[j].entries[i].args[0] = 0;
			__mod_shared_syscall_page[j].entries[i].args[1] = 0;
			__mod_shared_syscall_page[j].entries[i].args[2] = 0;
			__mod_shared_syscall_page[j].entries[i].args[3] = 0;
			__mod_shared_syscall_page[j].entries[i].args[4] = 0;
			__mod_shared_syscall_page[j].entries[i].args[5] = 10000 + i;
		}

		printk("Allocated Memory!\n");
	}

	for (i = 0; i < MAX_SYSCALL_THREAD; i++)
	{
		__mod_print_entry(i);
	}

	/*
	 * Create Character Device
	 * */

	if (__mod_flexsc_device_created == 0)
	{
		//We implemented a character device called mmap
		/* get the major number of the character device */
		if ((ret = alloc_chrdev_region(&__mod_mmap_dev, 0, 1, "flexsc")) < 0)
		{
			printk("could not allocate major number for mmap\n");
			goto out_kfree;
		}

		/* initialize the device structure and register the device with the kernel */
		cdev_init(&__mod_mmap_cdev, &__mod_mmap_fops);
		if ((ret = cdev_add(&__mod_mmap_cdev, __mod_mmap_dev, 1)) < 0)
		{
			printk("could not allocate chrdev for mmap\n");
			goto out_unalloc_region;
		}

		__mod_flexsc_device_created = 1;
	}

	// KThread Implementation
	if (thread_type)//Non Zero== Kthread
	{
		printk("Using kthread as syscall thread\n");
		__mod_register_kthread_version();
	}
	else
	{
		printk("Using workqueue as syscall thread\n");
		__mod_stop_syscall_threads();
		__mod_register_workqueue_version();
	}
	printk("flexsc_registration Complete.\n");
	return NULL;

	out_unalloc_region: printk("out_unalloc_region\n");
	unregister_chrdev_region(__mod_mmap_dev, 1);
	//
	//out_vfree: vfree(vmalloc_area);
	//
	out_kfree: printk("out_kfree\n");
	kfree(__mod_kmalloc_ptr);
	//
	out: printk("out\n");
	return NULL;

}

long __mod_wait(void)
{
	return current->pid;
}

/*
 * Using it as an unregister option.
 * */
void* __mod_unregister(void)
{
	int i;
	__mod_valid_wq = 0;

	__mod_stop_syscall_threads();

	/* remove the character deivce */
	cdev_del(&__mod_mmap_cdev);
	unregister_chrdev_region(__mod_mmap_dev, 1);

	/* unreserve the pages */
	for (i = 0; i < NPAGES * PAGE_SIZE; i += PAGE_SIZE)
	{
		ClearPageReserved(virt_to_page(((unsigned long) __mod_kmalloc_area) + i));
	}
	/* free the memory areas */
	kfree(__mod_kmalloc_ptr);
	return NULL;
}

