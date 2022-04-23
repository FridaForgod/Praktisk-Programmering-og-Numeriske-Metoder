all: Out.txt scipytest.png osc.png
	cat Out.txt

scipytest.png: fig_ODE.gpi Makefile
	pyxplot $<

osc.png: fig_osc.gpi Makefile
	pyxplot $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs vector.dll ode.dll
	mcs -target:exe -reference:vector.dll -reference:ode.dll $<

ode.dll: Runge-Kutta.cs vector.dll
	mcs -target:library -reference:vector.dll -out:$@ Runge-Kutta.cs

LIBDIR = ../../../matlib

vector.dll:\
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.txt *.dll

