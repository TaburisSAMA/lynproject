################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../src/ASNGATEWAY.c \
../src/InitTransport.c \
../src/Ipc.c \
../src/Receiver.c \
../src/Sender.c \
../src/ThreadWrapper.c \
../src/Utilities.c 

OBJS += \
./src/ASNGATEWAY.o \
./src/InitTransport.o \
./src/Ipc.o \
./src/Receiver.o \
./src/Sender.o \
./src/ThreadWrapper.o \
./src/Utilities.o 

C_DEPS += \
./src/ASNGATEWAY.d \
./src/InitTransport.d \
./src/Ipc.d \
./src/Receiver.d \
./src/Sender.d \
./src/ThreadWrapper.d \
./src/Utilities.d 


# Each subdirectory must supply rules for building sources it contributes
src/%.o: ../src/%.c
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C Compiler'
	gcc -I../include -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o"$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


