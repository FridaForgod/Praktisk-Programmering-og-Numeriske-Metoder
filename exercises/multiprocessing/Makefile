all: Out.txt
	cat $<

Out.txt: main.cs Makefile
	cat /dev/null > $@
	/bin/time --portability --output $@ --append mono main.exe 2e6 >> $@

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*
