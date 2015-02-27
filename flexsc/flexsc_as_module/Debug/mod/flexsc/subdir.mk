################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
O_SRCS += \
../mod/flexsc/flexsc.o \
../mod/flexsc/flexsc_helper.o \
../mod/flexsc/flexsc_syscalls.o 

C_SRCS += \
../mod/flexsc/flexsc.c \
../mod/flexsc/flexsc_helper.c \
../mod/flexsc/flexsc_syscalls.c 

OBJS += \
./mod/flexsc/flexsc.o \
./mod/flexsc/flexsc_helper.o \
./mod/flexsc/flexsc_syscalls.o 

C_DEPS += \
./mod/flexsc/flexsc.d \
./mod/flexsc/flexsc_helper.d \
./mod/flexsc/flexsc_syscalls.d 


# Each subdirectory must supply rules for building sources it contributes
mod/flexsc/%.o: ../mod/flexsc/%.c
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C Compiler'
	gcc -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o"$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


