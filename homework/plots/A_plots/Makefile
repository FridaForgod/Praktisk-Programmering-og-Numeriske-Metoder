erf.pyxplot.png: erf.data.txt erf.tab.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'error function' \n\
	plot [-1.5:1.5] [-1:1] '$<' index 0 using 1:2 with lines title 'error function','erf.tab.txt'  with points pointtype 7 title 'tab' \n\
	"| tee log.gpi | pyxplot

erf.data.txt: main.exe
	mono $< > $@

all: main.exe

%.exe: %.cs
	mcs $< > $@
