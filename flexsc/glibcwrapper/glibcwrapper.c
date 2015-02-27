#include <stdio.h>

#define __USE_GNU
#include <dlfcn.h>
//#include <stdlib.h>
//#include <stdarg.h>
//#include <sys/syscall.h>
//#include <unistd.h>
//#include <sys/types.h>
//#include <sys/stat.h>
//#include <dirent.h>
#include <sys/syscall.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <dlfcn.h>
#include <dirent.h>
#include <stdarg.h>
#include <fcntl.h>

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

//static void __mtrace_init(void)
//{
//	real_malloc = dlsym(RTLD_NEXT, "malloc");
//	if (NULL == real_malloc)
//	{
//		fprintf(stderr, "Error in `dlsym`: %s\n", dlerror());
//		return;
//	}
//}
//
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






//char *fgets(char *str, int count, FILE *stream)
//{
//	printf("fgets(%d, %d, %d)\n", str, count, stream);
//	real_fgets(str, count, stream);
//	return str;
//}
//
//int fputs(const char *str, FILE *stream)
//{
//	printf("fputs(%d, %d)\n", str, stream);
//	size_t ret = real_fputs(str, stream);
//	return str;
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

	real_fopen = dlsym(RTLD_NEXT, "fopen");
//	real_freopen = dlsym(RTLD_NEXT, "freopen");
	real_fclose = dlsym(RTLD_NEXT, "fclose");
	real_fread = dlsym(RTLD_NEXT, "fread");
	real_fputs = dlsym(RTLD_NEXT, "fputs");
	real_fgets = dlsym(RTLD_NEXT, "fgets");
	real_fwrite = dlsym(RTLD_NEXT, "fwrite");
	real_fseek = dlsym(RTLD_NEXT, "fseek");

	//	real_pwrite = dlsym(RTLD_NEXT, "pwrite");
}
//
//int open(const char *path, int flags, ...)
//{
//	int fd;
//	//	printf("entering open(): %s\n", path);
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
//		fd = real_open(path, flags, mode);
//		printf("fd=%d: open called for %s\n", fd, path);
//		return fd;
//	}
//	else
//	{
//		fd = real_open(path, flags);
//		printf("fd=%d: open called for %s\n", fd, path);
//		return fd;
//	}
//}
//
//int close(int fd)
//{
//	printf("fd=%d: close called \n", fd);
//	return (real_close(fd));
//}
//
//ssize_t read(int fd, void *buf, size_t len)
//{
//	ssize_t n = (*real_read)(fd, buf, len);
//	printf("fd=%d: read (%d) = %d\n", fd, len, n);
//	return n;
//}
//
//ssize_t write(int fd, const void *buf, size_t len)
//{
//	ssize_t n = (*real_write)(fd, buf, len);
//	printf("fd=%d: write (%d) = %d\n", fd, len, n);
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
	FILE* fp = real_fopen(path, mode);
	printf("fd=%d\n", fp);

	return fp;
}

FILE* freopen(const char* path, const char* mode, FILE* stream)
{
	printf("freopen(%s, %s)\n", path, mode);
	FILE* fp = real_freopen(path, mode, stream);
	printf("fd=%d\n", fp);

	return fp;
}

int fclose(FILE *stream)
{
	printf("fclose(%d)\n", stream);
	int ret = real_fclose(stream);
	return ret;
}

size_t fread(void* ptr, size_t size, size_t n, FILE* stream)
{
	printf("fread(%d, %d, %d, %d)\n", ptr, size, n, stream);
	size_t ret = real_fread(ptr, size, n, stream);
	return ret;
}

size_t fwrite(const void* ptr, size_t size, size_t n, FILE* stream)
{
	printf("fwrite(%d, %d, %d, %d)\n", ptr, size, n, stream);
	size_t ret = real_fwrite(ptr, size, n, stream);
	return ret;
}
//

int fseek(FILE* stream, long int off, int whence)
{
	printf("fseek(%d, %d, %d)\n", stream, off, whence);
	int ret = real_fseek(stream, off, whence);
	return ret;
}
