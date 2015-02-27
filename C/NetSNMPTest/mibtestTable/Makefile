CC=gcc
NETSNMPCONFIG=net-snmp-config

# uncomment this if you have GNU make
NETSNMPCFLAGS := $(shell $(NETSNMPCONFIG) --base-cflags)
NETSNMPLIBS := $(shell $(NETSNMPCONFIG) --agent-libs)
#NETSNMPCFLAGS=`$(NETSNMPCONFIG) --base-cflags`
#NETSNMPLIBS=`$(NETSNMPCONFIG) --agent-libs`

LIBS=$(NETSNMPLIBS)


STRICT_FLAGS = -Wall -Wstrict-prototypes
CFLAGS=-I. $(NETSNMPCFLAGS) $(STRICT_FLAGS)

SRCS = 	mibtestTable_src/mibtestTable_data_get.c \
       	mibtestTable_src/mibtestTable_data_set.c \
       	mibtestTable_src/mibtestTable_data_access.c \
	mibtestTable_src/mibtestTable.c \
	mibtestTable_src/mibtestTable_subagent.c \
	mibtestTable_src/mibtestTable_interface.c

OBJS_DIR = obj

OBJS = $(foreach file,$(SRCS),$(file:.c=.o))


TARGETS=wimax_snmp_agent

.SUFFIXES:
.SUFFIXES: .c .o .deps


all: $(TARGETS)

$(TARGETS): $(OBJS) 
	@echo
	$(CC) -o $(TARGETS) $(OBJS) $(LIBS)

$(OBJS):%.o:%.c
#	echo $<
#	echo $@
	@echo
	$(CC) $(CFLAGS) -c $< -o $@
clean:
	rm -f $(OBJS) $(TARGETS)

