all: gamma.gnuplot.png

gamma.gnuplot.png: gamma.data.txt Makefile gamma.tab.txt
	echo "\
		set terminal png \n\
		set output '$@' \n\
		set xlabel 'x' \n\
		set ylabel 'y' \n\
		set title 'gamma function' \n\
		plot [0:5] '$<' index 0 using 1:2 with lines title 'gamma function', 'gamma.tab.txt' with pointtype 7 title 'tab' \n\
		"| tee log.gpi | gnuplot

gamma.data.txt: gamma.exe
	mono $< > $@

%.exe: %.cs
	mcs $<
