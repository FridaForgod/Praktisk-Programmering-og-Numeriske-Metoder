using System;
using static System.Math;
using static System.Console;

class main{

	public static void Main(){
		
		double[] x = new double[]{1, 2, 3, 4, 6, 9, 10, 13, 15};
		double[] y = new double[]{117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1};
		double[] dy = new double[]{5,5,5,5,5,5,1,1,1,1};
		var fs = new Func<double,double>[] { z=> 1.0, z => z};
		double[] logy = new double[y.Length];
		double[] dlogy = new double[y.Length];

		for(int i=0; i<y.Length; i++){
			logy[i] = Log(y[i]);
			dlogy[i] = dy[i]/y[i];
			
		}// slutter for
	
		var fit = leastsquare.lsfit(fs, x, logy, dlogy);
		vector coefficients = fit.Item1;
		matrix covs = fit.Item2;
		vector errs = fit.Item3;
		double halflife_err = Log(2)*errs[1]/Pow(coefficients[1],2);

		for(int i=0; i<y.Length; i++){
			WriteLine($"{x[i]} {y[i]} {dy[i]}");

		}// slutter for med i

		WriteLine();
		WriteLine();

		for(double i=1; i<16; i+=1.0/4){
			WriteLine($"{i} {Exp(coefficients[0]) * Exp(coefficients[1]*i)}");
		} //afslutter for

		WriteLine();
		WriteLine();

		for(double i=1; i<16; i+=1.0/4){
			WriteLine($"{i} {Exp(coefficients[0] + errs[0]) * Exp((coefficients[1] + errs[1])*i)}");
		
		}// sluter for med i

		WriteLine();
		WriteLine();

		for(double i=1; i<16; i+=1.0/4){
			WriteLine($"{i} {Exp(coefficients[0] - errs[0]) * Exp((coefficients[1] - errs[1])*i)}");	
		} // slutter for

		
		WriteLine($"Half-life from fit: {-Log(2)/coefficients[1]} days");	
		WriteLine("Half-life of 224-Ra is 3.6 days.\n");
		WriteLine($"Uncertainties on fitting coefficients (fit to f(x) = c1 + c2*x):");
		WriteLine($"∆c1 = {errs[0]}");
		WriteLine($"∆c2 = {errs[1]}\n");
		WriteLine($"Gives half life with uncertainty:");
		WriteLine($"lambda = {-Log(2)/coefficients[1]} +- {halflife_err} days\nThis does not agree with the actual value within the uncertainty.");
		WriteLine($"Covariance matrix:");
		covs.print();



	}// slutter Main

}// slutter main


