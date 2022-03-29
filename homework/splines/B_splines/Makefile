all: Fig.png main.exe test.txt

Fig.png: data.txt Makefile
	echo '\
	set term png;\
	set out "$@";\
	set title "Quadratic spline";\
	set xlabel "x";\
	set ylabel "y";\
	set key out;\
	plot \
	"data.txt" index 0 using 1:2 with points pointtype 3 pointsize 1 title "Data"\
	,"data.txt" index 1 using 1:2 with lines title "Q-spline"\
	,"data.txt" index 1 using 1:3 with lines title "Derivative"\
	,"data.txt" index 1 using 1:4 with lines title "Integral";\
	' | tee log | pyxplot

data.txt:main.exe
	mono $< > $@

test.txt: test.exe
	mono $< > $@

main.exe:main.cs qspline.dll
	mcs -target:exe -out:$@ -reference:qspline.dll $<

test.exe: test.cs qspline.dll
	mcs -target:exe -out:$@ -reference:qspline.dll $<

qspline.dll: qspline.cs 
	mcs -target:library -out:./$@ $^

clean:
	$(RM) *.exe *.dll *.png *.txt

