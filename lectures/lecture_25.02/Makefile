
erf:gnuplot.png: erg.pyxplot.png
	cat log-gpi | sed 's/pyxplot/gnuplot/' | tee log.gnu.gpi | gnuplot

erf.pyxplot.png: erf.data.txt erf.tab.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'error function' \n\
	set key left top \n\	
	plot [-1.5:1.5] [-2:2] \n\
	plot '$<' index 0 using 1:2 with lines title 'error function',\
	'erf.tab.txt' using 1:3 with points pointtype 2 title 'tab' \n\
	"| tee log.gpi | pyxplot

erf.data.txt: main.exe
	mono $< > $@
	
erf.tab.txt: Makefile
	echo 0 0 1 >@

all: main.exe

%.exe: %.cs
	mcs $<

test:
	echo $ x $
