all: ODEsteps.png

ODEsteps.png: ODEsteps.txt Makefile
	/bin/echo -E '\
	set terminal png;\
	set out "$@";\
	set title "SciPY example";\
	set xlabel "time";\
	set ylabel "Numerical solution";\
	set key out;\
	set xrange[0:10];\
	plot \
	"$<" index 0 using 1:2 with lines title "$$\theta (t)$$",\
	"$<" index 0 using 1:3 with lines title "$$\omega (t)$$"\
	'| tee log | pyxplot

ODEsteps.txt: main.exe
	mono $< > $@

main.exe: main.cs vector.dll Runge-Kutta.dll genlist.dll
	mcs -target:exe -reference:vector.dll -reference:Runge-Kutta.dll -reference:genlist.dll $<

Runge-Kutta.dll: Runge-Kutta.cs vector.dll genlist.dll
	mcs -target:library -reference:vector.dll -reference:genlist.dll  -out:$@ Runge-Kutta.cs

LIBDIR = ../../../matlib

vector.dll:\
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs
	mcs -target:library -out:./$@ $^

genlist.dll: ../../generic_list/generic_list_C/genlist.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.txt *.dll
