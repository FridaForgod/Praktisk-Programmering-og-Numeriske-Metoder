all: Out.txt outfile.txt out.cmdline.txt
	cat $<

out.cmdline.txt:cmdline.exe Makefile
	mono cmdline.exe  1.23e-4 45 3e5 >$@

Out.txt: stdin.exe cmdline.exe 
	echo 1 2 3 4 5 6 7 8 9 | mono stdin.exe > $@

stdin.exe: stdin.cs
	mcs -target:exe .out $@ $<

cmdline.exe: cmdline.cs
	mono cmdline.exe 1 2 3 4 5 > out.txt

outfile.txt: fileio.cs
	mono fileio.exe -input:input.txt -output:out.txt

fileio.txt: fileio.cs
	mcs -target:exe -out:$@ $<

input.txt: Makefile
	echo -1.234e-5 99.9e+5 > $@
