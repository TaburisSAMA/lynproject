//#include <linux/linkage.h>
//#include <linux/kernel.h>
//#include <linux/ioport.h>
//#include <linux/workqueue.h>
//#include <linux/wait.h>
//#include <linux/kthread.h>
//#include <linux/slab.h>
//#include <linux/fs.h>      // Needed by filp
//#include <asm/uaccess.h>   // Needed by segment descriptors
#include "mod/flexsc/flexsc_syscalls.h"
//#include <flexsc/flexsc.h>


#include <linux/slab.h>
#include <linux/stat.h>
#include <linux/fcntl.h>
#include <linux/fs.h>
#include <linux/file.h>
#include <linux/uio.h>
#include <linux/fsnotify.h>
#include <linux/security.h>
#include <linux/module.h>
#include <linux/syscalls.h>
#include <linux/pagemap.h>
#include <linux/splice.h>
//#include "read_write.h"

#include <asm/uaccess.h>
#include <asm/unistd.h>


static inline loff_t file_pos_read(struct file *file)
{
	return file->f_pos;
}

static inline void file_pos_write(struct file *file, loff_t pos)
{
	file->f_pos = pos;
}

//INTERNAL_SYSCALL
struct file* __mod_file_open(const char* path, int flags, int rights)
{
	struct file* filp = NULL;
	mm_segment_t oldfs;
	int err = 0;
	ssize_t ret = -EBADF;

	oldfs = get_fs();
	set_fs(get_ds());
	{
		filp = filp_open(path, flags, rights);
	}
	set_fs(oldfs);
	if (IS_ERR(filp))
	{
		err = PTR_ERR(filp);
		printk("Problem Opening %d\n", err);
		return NULL;
	}
	return filp;
}

void __mod_file_close(struct file* file)
{
	filp_close(file, NULL);
}

loff_t __mod_file_seek(struct file *file, loff_t offset, int origin)
{
	ssize_t ret = -EBADF;
	mm_segment_t oldfs;

	oldfs = get_fs();
	set_fs(get_ds());

	ret = vfs_llseek(file, offset, origin);

	set_fs(oldfs);
	return ret;
}

ssize_t __mod_file_pread(struct file* file, void* data, size_t size, loff_t offset)
{
	ssize_t ret = -EBADF;
	mm_segment_t oldfs;

	oldfs = get_fs();
	set_fs(get_ds());

	ret = vfs_read(file, data, size, &offset);

	set_fs(oldfs);
	return ret;
}

ssize_t __mod_file_pwrite(struct file* file, const void* data, size_t size, loff_t offset)
{
	ssize_t ret = -EBADF;
	mm_segment_t oldfs;

	oldfs = get_fs();
	set_fs(get_ds());

	ret = vfs_write(file, data, size, &offset);

	set_fs(oldfs);
	return ret;
}

ssize_t __mod_file_read(struct file* file, void* buf, size_t count)
{
	ssize_t ret = -EBADF;
	mm_segment_t oldfs;
	{
		oldfs = get_fs();
		set_fs(get_ds());
	}
	{
		loff_t pos = file_pos_read(file);
		ret = vfs_read(file, buf, count, &pos);
		file_pos_write(file, pos);
	}
	{
		set_fs(oldfs);
	}
	return ret;
}

ssize_t __mod_file_write(struct file* file, const void* buf, size_t count)
{
	ssize_t ret = -EBADF;
	mm_segment_t oldfs;
	{
		oldfs = get_fs();
		set_fs(get_ds());
	}
	{
		loff_t pos = file_pos_read(file);
		ret = vfs_write(file, buf, count, &pos);
		file_pos_write(file, pos);
	}
	{
		set_fs(oldfs);
	}
	return ret;
}

//Alternatives...
int __mod_open_fd(const char* filename, int flags, int mode)
{
	int fd;
	mm_segment_t old_fs = get_fs();
	set_fs(KERNEL_DS);
	//
	fd = do_sys_open(AT_FDCWD, filename, flags, mode);
	//
	set_fs(old_fs);
	return fd;
}

int __mod_close_fd(int fd)
{
	mm_segment_t old_fs = get_fs();
	set_fs(KERNEL_DS);
	//
	sys_close(fd);
	//
	set_fs(old_fs);
	return 0;
}
ssize_t __mod_read_fd(int fd, char* buf, int count)
{
	struct file *file;
	ssize_t ret = -EBADF;
	int fput_needed;
	//
	mm_segment_t old_fs = get_fs();
	set_fs(KERNEL_DS);
	//
	file = fget_light(fd, &fput_needed);
	if (file)
	{
		loff_t pos = file_pos_read(file);
		ret = vfs_read(file, buf, count, &pos);
		file_pos_write(file, pos);
		fput_light(file, fput_needed);
	}
	//
	set_fs(old_fs);
	return ret;
}

ssize_t __mod_write_fd(int fd, const char* buf, int count)
{
	struct file *file;
	ssize_t ret = -EBADF;
	int fput_needed;
	//
	mm_segment_t old_fs = get_fs();
	set_fs(KERNEL_DS);
	//
	file = fget_light(fd, &fput_needed);
	if (file)
	{
		loff_t pos = file_pos_read(file);
		ret = vfs_write(file, buf, count, &pos);
		file_pos_write(file, pos);
		fput_light(file, fput_needed);
	}
	//
	set_fs(old_fs);
	return ret;
}
