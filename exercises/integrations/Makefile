all: Out.integ.txt Fig.erf.png

Fig.erf.png: fig.erf.gpi erf.data.txt
	pyxplot $<

Out.integ.txt erf.data.txt: main-integ.exe
	$(RUN) $< 1> Out.integ.txt 2> erf.data.txt

main-integ.exe: main-integ.cs matlib.dll

LIBDIR = ../../matlib
matlib.dll: integrate.cs
	mcs -target:library -out:matlib.dll integrate.cs

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	mcs -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt log*
