using System;
using static System.Math;
using static System.Double;

public static class integrate ( 
	Func<double,double> f,
	double a,
	double b,
	double delta = 0.001,
	double epsilon = 0.001,
	double f2 = NaN,
	double f3 = NaN, 
	)
	
	double h = b - a;

	if(IsNaN(f2))
		f2 = f(a+2*h)/6;





} //afslutter qudratures
