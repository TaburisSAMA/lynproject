obj-m += flexsc_module_all.o

flexsc_module_all-objs := mod/flexsc_module.o mod/flexsc/flexsc_syscalls.o mod/flexsc/flexsc_helper.o mod/flexsc/flexsc.o


all:
	make -C /lib/modules/$(shell uname -r)/build M=$(PWD) modules
clean:
	make -C /lib/modules/$(shell uname -r)/build M=$(PWD) clean