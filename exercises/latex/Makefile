all: ms.pdf

ms.pdf:ms.tex exp_pyx.pdf
	pdflatex $<
	pdflatex $<
#	bibtex $<
#	pdflatex $<

exp_pyx.pdf:fig.pyxplot.gpi out.exp.txt tab.exp.txt
	pyxplot $<

out.exp.txt:main.exe
	mono $< >$@

main.exe: main.cs sfuns.dll

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	mcs -t:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

