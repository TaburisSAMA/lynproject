/*
 * Cmain.cpp
 *
 *  Created on: Nov 30, 2011
 *      Author: maksud
 */

#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <fcntl.h>

int main()
{

	char* p = malloc(128);
	strcpy(p, "Maksud\n");
	printf("My name is: %s\n", p);

	FILE* fp = fopen("stat.txt", "a+");
	fwrite(p, 1, strlen(p), fp);
	fclose(fp);

	long fd = open("a.txt", O_RDWR | O_CREAT | 0x8000, 0777);
	int n = strlen(p);
	write(fd, p, n);
	read(fd, p, n);
	close(fd);

	free(p);
}
