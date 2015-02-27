/*
 ============================================================================
 Name        : flexapp.c
 Author      : Maksud
 Version     :
 Copyright   : Your copyright notice
 Description : Hello World in C, Ansi-style
 ============================================================================
 */

#include "flexapp_single.h"
#include "flexapp_threaded.h"
#include <stdlib.h>
#include <stdio.h>
#include "iflexsc.h"
#include "flexsc_syscalls.h"

int main(void)
{
	flexsc_register();
	//	flexapp_single();
	printf("Sizeof syscall page is: %d", sizeof(struct syscall_page));
	flexapp_threaded();

	return EXIT_SUCCESS;
}

