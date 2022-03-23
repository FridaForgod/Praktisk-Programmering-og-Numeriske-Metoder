all: Fig.png main.exe

Fig.png: data.txt Makefile
	echo '\
	set term png;\
	set out "$@";\
	set title "Linear interpolation";\
	set xlabel "x";\
	set ylabel "y";\
	set key out;\
	plot \
	 "data.txt" index 0 with points pointtype 1 pointsize 1 title "data"\
	,"data.txt" index 1 with points pointtype 2 pointsize 1 title "linterp"\
	,"data.txt" index 1 with lines title "integrale";\
	' | tee log | pyxplot

data.txt:main.exe
	mono $< > $@

main.exe:main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

LIBDIR = ../../../matlib

matlib.dll: \
	linterp.cs \
	$(LIBDIR)/integrate/integrate.cs
	mcs -target:library -out:./$@ $^

clean:
	$(RM) *.exe *.dll *.png *.txt
