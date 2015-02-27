/*
 ============================================================================
 Name        : no_flexsc.c
 Author      : Maksud
 Version     :
 Copyright   : Your copyright notice
 Description : Hello World in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>
#include <fcntl.h>
#include <sys/time.h>
#include <time.h>
#include <pthread.h>
//
#define NUM_THREADS 2
//
typedef struct str_thdata
{
	int i;
} thdata;

pthread_t thread[NUM_THREADS]; /* thread variables */
thdata data[NUM_THREADS]; /* structs to be passed to threads */

long long timeval_diff(struct timeval *difference, struct timeval *end_time, struct timeval *start_time)
{
	struct timeval temp_diff;

	if (difference == NULL)
	{
		difference = &temp_diff;
	}

	difference->tv_sec = end_time->tv_sec - start_time->tv_sec;
	difference->tv_usec = end_time->tv_usec - start_time->tv_usec;

	/* Using while instead of if below makes the code slightly more robust. */

	while (difference->tv_usec < 0)
	{
		difference->tv_usec += 1000000;
		difference->tv_sec -= 1;
	}

	return 1000000LL * difference->tv_sec + difference->tv_usec;

} /* timeval_diff() */

void print_message_function(void *ptr)
{
	int i, j;
	thdata *data;
		//
	int oFlags = O_RDWR | O_CREAT | O_APPEND, oModes = 0777;
	char buffer[384];
	//
	data = (thdata *) ptr; /* type cast to a pointer to thdata */
	i = data->i;

	for (j = 0; j < 1000; j++)
	{
		sprintf(buffer, "/home/maksud/no_flex%d.txt", i);
		FILE* fp = fopen(buffer, "a+");
		fread(buffer, 1, 190, fp);
		sprintf(buffer, "This is a test. Hello from %d.\n", i);
		fwrite(buffer, 1, strlen(buffer), fp);
		fclose(fp);
	}
	pthread_exit(0);
}

int main(void)
{

	long long elapsed;
	struct timeval start, end, interval;
	int i;

	//
	if (gettimeofday(&start, NULL))
	{
		perror("error gettimeofday() #1");
		exit(1);
	}

	//Create Threads
	for (i = 0; i < NUM_THREADS; i++)
	{
		data[i].i = i;
		pthread_create(&thread[i], NULL, (void *) &print_message_function, (void *) &data[i]);
	}

	//Wait for the threads
	for (i = 0; i < NUM_THREADS; i++)
	{
		pthread_join(thread[i], NULL);
	}

	if (gettimeofday(&end, NULL))
	{
		perror("error gettimeofday() #2");
		exit(1);
	}

	elapsed = timeval_diff(&interval, &end, &start);
	printf("\nTime for syscall tasks and synchronization is %lld microseconds\n\n", elapsed); // output format: # microseconds


	printf("Last Action!\n");

	return 0;
}
