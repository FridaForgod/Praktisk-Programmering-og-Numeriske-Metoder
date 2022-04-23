all: Out.txt leastsquare.png
	cat Out.txt | less

Out.txt: main.exe
	mono $< >$@

leastsquare.png: fig.gpi Out.txt Makefile
	pyxplot $<

main.exe: main.cs leastsquare.dll matrix.dll
	mcs -target:exe -reference:leastsquare.dll -reference:matrix.dll $<

leastsquare.dll: leastsquare.cs matrix.dll QR-GramSchmidt.dll
	mcs -target:library -reference:matrix.dll -reference:QR-GramSchmidt.dll $<

QRDIR = ../../linear_equations/B_linear_equations

QR-GramSchmidt.dll: $(QRDIR)/QR-GramSchmidt.cs matrix.dll
	mcs -target:library -reference:matrix.dll -out:./$@ $<

LIBDIR = ../../../matlib

matrix.dll:\
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs
	mcs -target:library -out:./$@ $^

clean: rm -f *.exe *.dll *.txt
