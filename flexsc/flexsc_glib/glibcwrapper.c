#define WRAP_FLEXSC 1

#include <stdio.h>

#define __USE_GNU
#include <dlfcn.h>
#include <sys/syscall.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <dlfcn.h>
#include <dirent.h>
#include <stdarg.h>
#include <fcntl.h>
#include "glibcwrapper.h"
#include <sys/syscall.h>
#include <unistd.h>
#include <sys/mman.h>
#include <stdlib.h>
#include <semaphore.h>  /* Semaphore */
#include <pthread.h>
//
#define NPAGES 16
//FlexSC Helpers
static void flexsc_register(void);
static struct syscall_entry_with_index* free_syscall_entry(void);
static void flexsc_wait(void);

//static void* (*real_malloc)( size_t) = NULL;
static void init(void) __attribute__ ((constructor));
//
static FILE* (*real_fopen)(const char *path, const char *mode);
static int (*real_fclose)(FILE *__stream);
static size_t (*real_fread)(void* __ptr, size_t size, size_t n, FILE* stream);
static size_t (*real_fwrite)(const void* __ptr, size_t size, size_t n, FILE* stream);
static int (*real_fseek)(FILE *__stream, long int __off, int __whence);
static FILE* (*real_freopen)(const char* filename, const char* modes, FILE* stream);
static int (*real_fputs)(const char *str, FILE *stream);
static char* (*real_fgets)(char * __s, int __n, FILE* __stream);

//RAW
static int (*real_open)(__const char *name, int flags, ...);
static int (*real_close)(int fd);
static ssize_t (*real_read)(int fd, void *buf, size_t len);
static ssize_t (*real_write)(int fd, const void *buf, size_t len);
static ssize_t (*real_pread)(int, void *, size_t, off_t);
static ssize_t (*real_pwrite)(int, const void *, size_t, off_t);
static off_t (*real_lseek)(int, off_t, int);
struct dirent *(*real_readdir)(DIR *dir);

//
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
struct syscall_page* basepage; // 4 * 64 = 256 Threads
char* buffers; // 256 / 4 = 64

//struct syscall_buffer* base_buffers;
//
struct syscall_entry_with_index entries[NUM_THREADS];
static pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

static int last_index = 0;

int opened[4096] =
{ 0 };
struct syscall_entry* flexsc_getpid(struct syscall_entry* entry)
{
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
		//		printf("Buffer:%d\n", (unsigned long) (buffers + entry->args[0]));

		entry->syscall = _FLEX_SYSCALL_OPEN;
		entry->num_args = 3;
		entry->args[0] = (unsigned long) filename - (unsigned long) buffers; //Sending Memory Offset
		entry->args[1] = mode;
		entry->args[2] = rights;
		entry->status = _FLEX_SUBMITTED;

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
		entry->args[1] = (unsigned long) data - (unsigned long) buffers; //Sending Memory Offset
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
		entry->args[1] = (unsigned long) data - (unsigned long) buffers; //Sending Memory Offset
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

void flexsc_register(void)
{
	int index, i, j;
	int fd;
	unsigned char* kadr;
	int len = NPAGES * getpagesize();

	//	syscall(sys_flexsc_register2, (void*) (NUM_THREADS * 128));
	if ((fd = real_open("node2", O_RDWR | O_SYNC)) < 0)
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
	real_close(fd);

	basepage = (struct syscall_page*) kadr; //First 4 * 4096 are reserved for 256 syscall threads
	buffers = (char*) (kadr + 4 * 64 * 64); //Rest 12 * 4096 / 128 = 384 bytes per thread buffer.
	//

	printf("Basepage: %ld, %p\n", (long) basepage, basepage);
	for (index = 0; index < NUM_THREADS; index++)
	{
		j = index / 64;
		i = index % 64;
		//
		entries[index].index = index;
		entries[index].entry = &basepage[j].entries[i];

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
	for (index = 0; index < 4096; index++)
	{
		opened[index] = 0;
	}
	printstack();

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

struct syscall_entry_with_index* free_syscall_entry(void)
{
	int i, j, index;
	//	printf("Try to Access.\n");
	struct syscall_entry_with_index* entry = NULL;

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
			entry = &entries[last_index];
			entry->index = last_index;
			entry->entry = &basepage[j].entries[i];
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
////////////////////////////////////////////////////////////////////////////////
//
//static void __mtrace_init(void)
//{
//	real_malloc = dlsym(RTLD_NEXT, "malloc");
//	if (NULL == real_malloc)
//	{
//		fprintf(stderr, "Error in `dlsym`: %s\n", dlerror());
//		return;
//	}
//}

//void *malloc(size_t size)
//{
//	if (real_malloc == NULL)
//		__mtrace_init();
//
//	void *p = NULL;
//	fprintf(stderr, "malloc(%d) = ", size);
//	p = real_malloc(size);
//	fprintf(stderr, "%p\n", p);
//	//
//	printf("Maksud\n");
//	return p;
//}

static void init(void)
{
	printf("init()\n");

	real_open = dlsym(RTLD_NEXT, "open");
	real_readdir = dlsym(RTLD_NEXT, "readdir");
	real_close = dlsym(RTLD_NEXT, "close");
	real_read = dlsym(RTLD_NEXT, "read");
	real_write = dlsym(RTLD_NEXT, "write");
	real_pread = dlsym(RTLD_NEXT, "pread");
	real_pwrite = dlsym(RTLD_NEXT, "pwrite");
	real_lseek = dlsym(RTLD_NEXT, "lseek");

	//

	real_fopen = dlsym(RTLD_NEXT, "fopen");
	real_freopen = dlsym(RTLD_NEXT, "freopen");
	real_fclose = dlsym(RTLD_NEXT, "fclose");
	real_fread = dlsym(RTLD_NEXT, "fread");
	real_fputs = dlsym(RTLD_NEXT, "fputs");
	real_fgets = dlsym(RTLD_NEXT, "fgets");
	real_fwrite = dlsym(RTLD_NEXT, "fwrite");
	real_fseek = dlsym(RTLD_NEXT, "fseek");

	flexsc_register();

	printf("WRAP_FLEXSC: %d\n", WRAP_FLEXSC);

	//	real_pwrite = dlsym(RTLD_NEXT, "pwrite");
}

long wait_and_return2(struct syscall_entry* entry)
{
	//Can not proceed while status is not DONE
	while (entry->status != _FLEX_DONE)
	{
		//		printf("Stuck Here!");
	}
	long rv = (unsigned long) entry->return_code; //flexsc_open returns file descriptor.
	entry->status = _FLEX_FREE;
	return rv;
}

FILE* __flexsc_open(const char *path, int flags, int mode)
{
	long fd;
	char* buffer;
	struct syscall_entry_with_index* entry = free_syscall_entry();
	//
	//		printf("Index: %d\n", entry->index);
	//		printf("Last Index: %d\n", last_index);
	//
	buffer = (char*) (buffers + 384 * entry->index);
	strcpy(buffer, path);
	//	printf("Filename: %s\n", buffer);
	//
	flexsc_open_e(entry->entry, buffer, flags, mode);
	fd = wait_and_return2(entry->entry);

//	FILE* fp = malloc(sizeof(FILE));
//	fp->_markers = fd;
//	fp->_fileno = 0;

	printf("%ld\n", fd);
	return (FILE*) fp;
}

//int open(const char *path, int flags, ...)
//{
//	int fd;
//	printf("syscall::open(%s, %d, ...)\n", path, flags);
//
//	if (dlerror())
//		return -1;
//
//	if (flags & O_CREAT)
//	{
//		va_list arg_list;
//		mode_t mode;
//
//		va_start(arg_list, flags);
//		mode = va_arg(arg_list, mode_t);
//		va_end(arg_list);
//
//		if (WRAP_FLEXSC)
//		{
//			fd = __flexsc_open(path, flags, mode);
//			opened[fd] = 1;
//		}
//		else
//		{
//			fd = real_open(path, flags, mode);
//		}
//		printf("fd=%d: open(%s, %d, %d)\n", fd, path, flags, mode);
//		return fd;
//	}
//	else
//	{
//		if (WRAP_FLEXSC)
//		{
//			fd = __flexsc_open(path, flags, 0777);
//			opened[fd] = 1;
//		}
//		else
//		{
//			fd = real_open(path, flags);
//		}
//		printf("fd=%d: open(%s, %d)\n", fd, path, flags);
//		return fd;
//	}
//}

int __flexsc_close(FILE* fd)
{
	//	struct syscall_entry_with_index* entry = free_syscall_entry();
	//	flexsc_close_e(entry->entry, fd);
	//	fd = wait_and_return2(entry->entry);
	return 0;
}

//int close(int fd)
//{
//	printf("syscall::close(%d)\n", fd);
//
//	int n;
//	printf("close(%d)\n", fd);
//	if (WRAP_FLEXSC)
//	{
//		opened[fd] = 0;
//		n = __flexsc_close(fd);
//		printf("close(%d)=%d\n", fd, n);
//	}
//	else
//	{
//		n = (real_close(fd));
//		printf("close(%d)=%d\n", fd, n);
//	}
//	return n;
//}

ssize_t __flexsc_read(FILE* fd, void *buf, size_t len)
{
	struct syscall_entry_with_index* entry;
	char* buffer;
	int remain = len, maxlen = 0;
	ssize_t n = 0, tmp = 0;

	printf("__flexsc_read(%d, buf, %d)\n", fd, len);

	do
	{
		entry = free_syscall_entry();
		buffer = (char*) (buffers + 384 * entry->index);

		maxlen = remain > 384 ? 384 : remain;//
		if (n + maxlen > len)
			maxlen = len - n;//

		printf("Reading... %d\n", maxlen);

		flexsc_read_e(entry->entry, fd, buffer, maxlen, 0);
		tmp = wait_and_return2(entry->entry);

		printf("Reading... fd:%d n:%d, tmp:%d\n", fd, n, tmp);

		if (tmp > 0)
		{
			memcpy(buf + n, buffer, tmp);
			n += tmp;
		}
	} while (tmp > 0);

	return n;
}

//ssize_t read(int fd, void *buf, size_t len)
//{
//	printf("syscall::read(%d, buf, %d) && %d \n", fd, len, opened[fd]);
//
//	ssize_t n;
//	if (WRAP_FLEXSC)
//	{
//		printf("Flex: read(%d, buf, %d)\n", fd, len);
//		n = __flexsc_read(fd, buf, len);
//		printf("Flex: n = %d\n", n);
//	}
//	else
//	{
//		printf("Real: read(%d, buf, %d)\n", fd, len);
//		n = (*real_read)(fd, buf, len);
//		printf("Real: n = %d\n", n);
//
//	}
//	return n;
//}

ssize_t __flexsc_write(FILE* fd, const void *buf, size_t len)
{
	struct syscall_entry_with_index* entry;
	char* buffer;
	int remain = len, maxlen = 0;
	ssize_t n = 0, tmp = 0;

	do
	{
		entry = free_syscall_entry();
		buffer = (char*) (buffers + 384 * entry->index);

		maxlen = remain > 384 ? 384 : remain;//
		memcpy(buffer, buf + n, maxlen);
		flexsc_write_e(entry->entry, fd, buffer, maxlen, 0);
		tmp = wait_and_return2(entry->entry);
		//		printf("Writing... fd:%d n:%d, tmp:%d\n", fd, n, tmp);

		if (tmp > 0)
		{
			remain -= tmp;
			n += tmp;
		}
	} while (tmp > 0);

	return n;
}

//ssize_t write(int fd, const void *buf, size_t len)
//{
//
//	printf("syscall::write(%d, buf, %d)\n", fd, len);
//
//	ssize_t n;
//	if (WRAP_FLEXSC)
//	{
//		printf("Flex: write(%d, buf, %d)\n", fd, len);
//		n = __flexsc_write(fd, buf, len);
//		printf("Flex: n = %d\n", n);
//	}
//	else
//	{
//		printf("Real: write(%d, buf, %d)\n", fd, len);
//		n = (*real_write)(fd, buf, len);
//		printf("Real: n = %d\n", n);
//	}
//	return n;
//}
//
//ssize_t pread(int fd, void *buf, size_t len, off_t off)
//{
//	printf("fd=%d: pread (%d -> n=%d) \n", fd, len, off);
//	return (*real_pread)(fd, buf, len, off);
//}
//
//ssize_t pwrite(int fd, const void *buf, size_t len, off_t off)
//{
//	printf("fd=%d: pwrite (%d -> n=%d) \n", fd, len, off);
//	return (*real_pwrite)(fd, buf, len, off);
//}
//off_t lseek(int fd, off_t off, int whence)
//{
//	printf("fd=%d: lseek called \n", fd);
//	return (*real_lseek)(fd, off, whence);
//}
//struct dirent *readdir(DIR *dir)
//{
//	printf("readdir called\n");
//	return (real_readdir(dir));
//}

FILE* fopen(const char *path, const char *mode)
{
	printf("fopen(%s, %s)\n", path, mode);

	int oflags = 0, omode;
	int read_write, i;
	int oprot = 0666;

	if (!WRAP_FLEXSC)
	{
		FILE* fp = real_fopen(path, mode);
		printf("fd=%ld\n", fp);
		return fp;
	}
	else
	{
		//
		switch (*mode)
		{
		case 'r':
			omode = O_RDONLY;
			//		read_write = _IO_NO_WRITES;
			break;
		case 'w':
			omode = O_WRONLY;
			oflags = O_CREAT | O_TRUNC;
			//		read_write = _IO_NO_READS;
			break;
		case 'a':
			omode = O_WRONLY;
			oflags = O_CREAT | O_APPEND;
			//		read_write = _IO_NO_READS | _IO_IS_APPENDING;
			break;
		default:
			//		__set_errno(EINVAL);
			return NULL;
		}
		//
		for (i = 1; i < 6; ++i)
		{
			switch (*++mode)
			{
			case '\0':
				break;
			case '+':
				omode = O_RDWR;
				//			read_write &= _IO_IS_APPENDING;
				//#ifdef _LIBC
				//			last_recognized = mode;
				//#endif
				continue;
			case 'x':
				oflags |= O_EXCL;
				//#ifdef _LIBC
				//			last_recognized = mode;
				//#endif
				continue;
			case 'b':
				//#ifdef _LIBC
				//			last_recognized = mode;
				//#endif
				continue;
			case 'm':
				//			fp->_flags2 |= _IO_FLAGS2_MMAP;
				continue;
			case 'c':
				//			fp->_flags2 |= _IO_FLAGS2_NOTCANCEL;
				continue;
				//#ifdef O_CLOEXEC
			case 'e':
				oflags |= O_CLOEXEC;
				continue;
				//#endif
			default:
				/* Ignore.  */
				continue;
			}
			break;
		}

		FILE* fp = __flexsc_open(path, omode | oflags, oprot);
		printf("fd=%ld\n", fp);
		return fp;
	}
}

//
//FILE* freopen(const char* path, const char* mode, FILE* stream)
//{
//	printf("freopen(%s, %s)\n", path, mode);
//	FILE* fp = real_freopen(path, mode, stream);
//	printf("fd=%d\n", fp);
//
//	return fp;
//}
//
int fclose(FILE *stream)
{
	int ret;

	printf("fclose(%ld)\n", stream);
	if (WRAP_FLEXSC)
	{

		ret = __flexsc_close(stream);
	}
	else
	{
		free(stream);
		//		ret = real_fclose(stream);
		return 0;
	}
	return ret;
}
//
size_t fread(void* ptr, size_t size, size_t n, FILE* stream)
{
	printf("fread(%ld, %d, %d, %ld)\n", ptr, size, n, stream->_markers);
	size_t ret = WRAP_FLEXSC ? __flexsc_read(stream->_markers, ptr, n * size) : real_fread(ptr, size, n, stream);
	return ret;
}
//
size_t fwrite(const void* ptr, size_t size, size_t n, FILE* stream)
{
	printf("fwrite(%ld, %d, %d, %ld)\n", ptr, size, n, stream->_markers);
	//	size_t ret = real_fwrite(ptr, size, n, stream);
	//	size_t request = n * size;
	size_t ret = WRAP_FLEXSC ? __flexsc_write(stream->_markers, ptr, n * size) : real_fwrite(ptr, size, n, stream);
	return ret;
}
//
int fseek(FILE* stream, long int off, int whence)
{
	printf("fseek(%ld, %d, %d)\n", stream, off, whence);
	int ret = WRAP_FLEXSC ? 0 : real_fseek(stream, off, whence);
	return ret;
}
