all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs vec.dll
	mcs -target:exe -out:main.exe -reference:vec.dll main.cs

vec.dll: Vec.cs
	mcs -target:library -out:vec.dll Vec.cs

clean:
	$(RM) *.exe *.dll [Oo]ut*.txt

test:
	mcs --version
