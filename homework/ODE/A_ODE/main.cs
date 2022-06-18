using static System.Console;
using static System.Math;
using System;

public class main{
	public static void Main(){

		WriteLine(" _______________ A test of the Scipy ODE example_____________ ");
		WriteLine(" _______________ The results will be plotted in the file called ode.png _______________ ");

		Func<double, vector, vector> pend = delegate(double t, vector y){
			double b = 0.25;
			double c = 5.0;
			double theta = y[0];
			double omega = y[1];
			return new vector(omega, -b*omega - c*Sin(theta));
		
		};  // afslutter delegate
		
		// Initial Conditions
		double[] initconditions = new double[] {Math.PI - 0.1, 0.0};
		vector ya = new vector(initconditions);

		Func<double, vector, vector> OSC = delegate(double t, vector y){
			return new vector(y[1], -y[0]);
		
		}; // afslutter OSC


		double step = 1.0/16;
		using(var outfile = new System.IO.StreamWriter("scipyODE.txt")){
			for(double ti = step; ti<=10.0; ti+=step){
				vector solution = rkstep.driver(pend, ti - step, ya, ti);
				outfile.WriteLine($" {ti} {solution[0]} {solution[1]} ");
				ya = solution;

			} // afslutter for
		} // afslutter StreamWriter

		WriteLine(" _______________ This is a test on example ___________________ ");
		WriteLine(" ______________ The diferential equation u'' = -u is solved for initial conditions _________________ ");
		WriteLine(" --- The results are plotted in the file called osc.png");
		
		double[] initcos = new double[] {0.0, 1.0};
		vector yacos = new vector(initcos);
		using(var outfile = new System.IO.StreamWriter("osc.txt")){
			for(double ti = step; ti <= 10.0; ti += step){
				vector solution = rkstep.driver(OSC, ti - step, yacos, ti);
				outfile.WriteLine($" {ti} {solution[0]} {solution[1]} ");
				yacos = solution;
			} // afslutter for

		} // afslutter new

	} //afslutter Main

} //afslutter main
