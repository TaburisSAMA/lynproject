################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
O_SRCS += \
../mod/flexsc_module.o 

C_SRCS += \
../mod/flexsc_module.c 

OBJS += \
./mod/flexsc_module.o 

C_DEPS += \
./mod/flexsc_module.d 


# Each subdirectory must supply rules for building sources it contributes
mod/%.o: ../mod/%.c
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C Compiler'
	gcc -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o"$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


