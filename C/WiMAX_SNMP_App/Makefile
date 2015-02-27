CXXFLAGS =	-O2 -g -Wall -fmessage-length=0
	
CC=gcc
NETSNMPCONFIG=net-snmp-config


LIBS=


STRICT_FLAGS = -Wall -Wstrict-prototypes
CFLAGS=-I. $(CXXFLAGS)

SRCS = 	util/Ipc.c \
		util/Utilities.c \
		WiMAX_SNMP_Application.c

OBJS_DIR = .

OBJS = $(foreach file,$(SRCS),$(OBJS_DIR)/$(file:.c=.o))


TARGETS=WiMAX_SNMP_Application

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
	