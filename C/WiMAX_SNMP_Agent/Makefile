CC=gcc
NETSNMPCONFIG=net-snmp-config

# uncomment this if you have GNU make
#NETSNMPCFLAGS := $(shell $(NETSNMPCONFIG) --base-cflags)
NETSNMPCFLAGS := -g -O0 -Dlinux -I/usr/include/rpm -I. -I/usr/local/include
NETSNMPLIBS := $(shell $(NETSNMPCONFIG) --agent-libs)

NETSNMPCFLAGS := $(shell $(NETSNMPCONFIG) --base-cflags)
NETSNMPLIBS := $(shell $(NETSNMPCONFIG) --agent-libs)

LIBS=$(NETSNMPLIBS)


STRICT_FLAGS = -Wall -Wstrict-prototypes
CFLAGS=-I. $(NETSNMPCFLAGS) $(STRICT_FLAGS) $(INCFLAGS)

INCFLAGS = -Iutil

SRCS = 	mibtestTable_src/mibtestTable_data_get.c \
       	mibtestTable_src/mibtestTable_data_set.c \
       	mibtestTable_src/mibtestTable_data_access.c \
		mibtestTable_src/mibtestTable.c \
		mibtestTable_src/mibtestTable_interface.c \
		\
		wmanTestDataHolder_src/wmanTestDataHolder.c \
		\
		wmanDevSsConfigFileEncodingTable_src/wmanDevSsConfigFileEncodingTable_data_get.c \
		wmanDevSsConfigFileEncodingTable_src/wmanDevSsConfigFileEncodingTable_data_set.c \
		wmanDevSsConfigFileEncodingTable_src/wmanDevSsConfigFileEncodingTable_data_access.c \
		wmanDevSsConfigFileEncodingTable_src/wmanDevSsConfigFileEncodingTable.c \
		wmanDevSsConfigFileEncodingTable_src/wmanDevSsConfigFileEncodingTable_interface.c \
		\
		wmanIfBsRegisteredSsTable_src/wmanIfBsRegisteredSsTable_data_get.c \
		wmanIfBsRegisteredSsTable_src/wmanIfBsRegisteredSsTable_data_set.c \
		wmanIfBsRegisteredSsTable_src/wmanIfBsRegisteredSsTable_data_access.c \
		wmanIfBsRegisteredSsTable_src/wmanIfBsRegisteredSsTable.c \
		wmanIfBsRegisteredSsTable_src/wmanIfBsRegisteredSsTable_interface.c \
		\
    	wmanIfBsProvisionedSfTable_src/wmanIfBsProvisionedSfTable_data_get.c \
    	wmanIfBsProvisionedSfTable_src/wmanIfBsProvisionedSfTable_data_set.c \
    	wmanIfBsProvisionedSfTable_src/wmanIfBsProvisionedSfTable_data_access.c \
    	wmanIfBsProvisionedSfTable_src/wmanIfBsProvisionedSfTable.c \
        wmanIfBsProvisionedSfTable_src/wmanIfBsProvisionedSfTable_interface.c \
		\
		wimax_snmp_subagent.c

#		util/Ipc.c \
#		util/Utilities.c \		
#		wmanIfBsRegisteredSsTable_src/wmanIfBsRegisteredSsTable.c \		

OBJS_DIR = .

OBJS = $(foreach file,$(SRCS),$(OBJS_DIR)/$(file:.c=.o))


TARGETS=wimax_snmp_agent

.SUFFIXES:
.SUFFIXES: .c .o .deps


all: $(TARGETS)

$(TARGETS): $(OBJS) 
	@echo
	$(CC) -o $(TARGETS) $(OBJS) $(LIBS)

$(OBJS):$(OBJS_DIR)/%.o:%.c
	@echo
	$(CC) $(CFLAGS) -c $< -o $@

clean:
	rm -f $(OBJS) $(TARGETS)
