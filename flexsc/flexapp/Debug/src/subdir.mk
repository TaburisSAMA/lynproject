################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../src/flexapp.c \
../src/flexapp_single.c \
../src/flexapp_threaded.c 

OBJS += \
./src/flexapp.o \
./src/flexapp_single.o \
./src/flexapp_threaded.o 

C_DEPS += \
./src/flexapp.d \
./src/flexapp_single.d \
./src/flexapp_threaded.d 


# Each subdirectory must supply rules for building sources it contributes
src/%.o: ../src/%.c
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C Compiler'
	gcc -I/home/maksud/workspace/flexsc -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o"$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


