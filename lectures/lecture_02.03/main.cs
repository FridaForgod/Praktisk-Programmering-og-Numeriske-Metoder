using System;
using static System.Console;
class main{

public static void Main(){
	double dx=1.0/64, shift=dx/2;
	for(double x=-5+shift; x<=5; x+=dx)
		WriteLine($"{x} {sfuns.gamma(x)}");

}

}
