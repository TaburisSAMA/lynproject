#ifndef DATATYPES_H_
#define DATATYPES_H_

#include <pthread.h>

typedef enum bool {
    FALSE = 0,
    TRUE = 1
} boolean;

typedef unsigned char		u8 ;
typedef char			s8 ;
typedef unsigned short		u16;
typedef short			s16;
typedef unsigned int		u32;
typedef int			s32;
typedef unsigned long long int	u64;
typedef long long int		s64;
typedef float			f32;
typedef long double		f64;

typedef struct uint3{
	unsigned int value:3;
} u3;

typedef struct uint5{
	unsigned int value:5;
} u5;

typedef struct uint1{
	unsigned int value:1;
}u1;


struct struct_messageQID{
	s32 vS32_msgQIDRW;
	s32 vS32_msgQIDW;
};

struct struct_error{
	boolean vB_isError;
	s32 vS32_errorType;
};


struct struct_error vStG_error;


#endif /*DATATYPES_H_*/
