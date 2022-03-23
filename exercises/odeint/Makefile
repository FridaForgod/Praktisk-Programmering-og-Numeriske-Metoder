CSC = mcs
RUN = mono

all: Fig.oscillator.png

Fig.oscillator.png: fig.oscillator.gpi oscillator.data.txt
	pyxplot $<

oscillator.data.txt: main-ode.exe
	$(RUN) $< 1> $@ 2>log

main-ode.exe: main-ode.cs matlib.dll

LIBDIR = ../../matlib
matlib.dll: \
	$(LIBDIR)/odeint/ode.cs \
	$(LIBDIR)/matrix/vector.cs
	mcs -target:library -out:./$@ $^

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	mcs -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt log*
