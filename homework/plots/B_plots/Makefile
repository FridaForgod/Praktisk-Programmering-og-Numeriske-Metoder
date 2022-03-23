all: lngamma.pyxplot.png gamma.pyxplot.png

lngamma.pyxplot.png: lngamma.data.txt Makefile lngamma.tab.txt
	echo "\
		set terminal png \n\
		set output '$@' \n\
		set xlabel 'x' \n\
		set ylabel 'y' \n\
		set title 'ln(gamma) function' \n\
		plot [0: 7] '$<' index 0 using 1:2 with lines title 'ln(gamma) function',\ \n\
		'lngamma.tab.txt' with points pointtype 3 title 'tab' \n\
		"| tee log.gpi | pyxplot

gamma.pyxplot.png: gamma.data.txt Makefile gamma.tab.txt
	echo "\
		set terminal png \n\
		set output '$@' \n\
		set xlabel 'x' \n\
		set ylabel 'y' \n\
		set title 'gamma function' \n\
		plot [0:7] '$<' index 0 using 1:2 with lines title 'gamma function',\ \n\
		'gamma.tab.txt' with points pointtype 3 title 'tab' \n\
		"| tee log.gpi | pyxplot

lngamma.data.txt: lngamma.exe
	mono $< > $@

gamma.data.txt: gamma.exe
	mono $< > $@

%.exe: %.cs
	mcs $<
