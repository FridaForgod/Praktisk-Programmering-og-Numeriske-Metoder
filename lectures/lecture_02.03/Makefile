all:ms.pdf

ms.pdf:ms.tex gamma_pyx.pdf gamma_gnu.tex
	pdflatex $<
	pdflatex $<
#	bibtex $<
#	pdflatex $<

gamma_gnu.tex:fig.gnuplot.gpi out.gamma.txt tab.gamma.txt
	gnuplot $<

gamma_pyx.pdf:fig.pyxplot.gpi out.gamma.txt tab.gamma.txt
	pyxplot $<

out.gamma.txt:main.exe
	mono $< >$@

main.exe: main.cs sfuns.dll

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)


%.dll: %.cs
	mcs -t:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)
