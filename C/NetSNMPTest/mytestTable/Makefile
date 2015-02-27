
CC=gcc
TABLE_PREFIX=mytestTable

NETSNMPCONFIG=net-snmp-config


# uncomment this if you have GNU make
NETSNMPCFLAGS := $(shell $(NETSNMPCONFIG) --base-cflags)
NETSNMPLIBS := $(shell $(NETSNMPCONFIG) --agent-libs)
#NETSNMPCFLAGS=`$(NETSNMPCONFIG) --base-cflags`
#NETSNMPLIBS=`$(NETSNMPCONFIG) --agent-libs`

LIBS=$(NETSNMPLIBS)


STRICT_FLAGS = -Wall -Wstrict-prototypes
CFLAGS=-I. $(NETSNMPCFLAGS) $(STRICT_FLAGS)


SRCS = 	$(TABLE_PREFIX).c \
	$(TABLE_PREFIX)_subagent.c 


OBJS =  $(TABLE_PREFIX).o \
	$(TABLE_PREFIX)_subagent.o 

TARGETS=$(TABLE_PREFIX)

.SUFFIXES:
.SUFFIXES: .c .o .deps


all: $(TARGETS)


$(TARGETS): $(LIB_DEPS)

$(TABLE_PREFIX): $(OBJS) $(TABLE_PREFIX)
	$(CC) -o $(TABLE_PREFIX) $(OBJS) $(LIBS)

clean:
	rm -f $(OBJS) $(TARGETS)

