out.txt:main.exe
	mono $< > $@

main.exe:main.cs lib.dll
	mcs -target:exe main.cs -reference:lib.dll

lib.dll: integrate.cs
	mcs -target:library -out:$@ $<
