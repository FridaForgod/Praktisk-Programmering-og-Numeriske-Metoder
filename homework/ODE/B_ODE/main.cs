using System;
using static System.Math;
using static System.Console;

public class main{
	public static void Main(){
	
		Func<double, vector, vector> pend = delegate(double t, vector y){
			double d = 0.25;
			double c = 5.0;
			double theta = y[0];
			double omega = y[1];
			return new vector(omega, -d*omega - c*Sin(theta));
	

		}; //afslutter

		double[] initconditions = new double[] {Math.PI - 0.1, 0.0};
		vector ya = new vector(initconditions);
	
		var xlist = new genlist<double>();
		var ylist = new genlist<vector>();
	
		double a = 0.0;
		double b = 10.0;
		double h = 0.01;
		double acc = 1e-6;
		double eps = 1e-6;

		vector solution = rkstep.driver(pend, a, ya, b, xlist, ylist, h, acc, eps);
			for(int i=0; i<xlist.size; i++){
				WriteLine($"{xlist.data[i]} {ylist.data[i][0]} {ylist.data[i][1]}");
	
			}

	} // afslutter Main

} // afslutter main
/*
public static vector driver(
Func<double, vector, vector> f,
double a,
vector ya,
double b,
genlist<double> xlist = null,
genlist<vector> ylist = null,
double h=0.01,
double acc = 1e-3,
double eps = 1e-3
)
*/
