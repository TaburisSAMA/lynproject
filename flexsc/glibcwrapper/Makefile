# All Target
all: 
	@echo '--gcc--'
	gcc -shared -ldl -fPIC glibcwrapper.c -o glibcwrapper.so 
	gcc -o main glibc_main.c


# Other Targets
clean:
	-$(RM) *.o *.so *.out "main"
	-@echo ' '
