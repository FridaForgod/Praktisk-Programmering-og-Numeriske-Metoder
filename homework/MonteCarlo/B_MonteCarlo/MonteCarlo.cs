using System;
using static System.Console;
using static System.Math;

public static class MonteCarlo{
	public static (double, double) plainmc (Func<vector,double> f, vector a, vector b, int N){
		int dim = a.size;
		double V = 1;
		for (int i=0; i<dim; i++){
			V *= b[i] - a[i];
		}
		
		double sum = 0;
		double sum2 = 0;
		var rand = new Random();

		var x = new vector(dim);
		for (int i=0; i<N; i++){
			for (int k=0; k<dim; k++){
				x[k] = a[k] + rand.NextDouble()*(b[k] - a[k]);
			}		
			double fx = f(x);
			sum += fx;
			sum2 += fx*fx;
		}
	
		double mean = sum/N;
		double sigma = Sqrt(sum2/N-mean*mean);
		var result = (mean*V,sigma*V/Sqrt(N));
		return result;

	} // afslutter plainmc

	public static (double, double) quasimc(Func<vector,double> f, vector a, vector b, int N){
		int dim = a.size;
		double V = 1;
		for (int i=0; i<dim; i++){
			V *= b[i] - a[i];
		}
		
		double sum = 0;
		double sum2 = 0;

		var x = new vector(dim);
		for (int i=0; i<N; i++){
			vector quasiR = halton(i,dim);
			for (int k=0; k < dim; k++){
				x[k] = a[k] + quasiR[k]*(b[k] - a[k]);
			}		
			double fx = f(x);
			sum += fx;
			sum2 += fx*fx;
		}
	
		double mean = sum/N;
		double sigma = Sqrt(sum2/N - mean*mean);
		var result = (mean*V,sigma*V/Sqrt(N));
		return result;

	} // afslutter quasimc


	public static double corput(int n, int bas){
		double q = 0;
		double bk = 1.0/bas;
		while(n>0){
			q += (n % bas) * bk;
			n /= bas;
			bk /= bas;
		}
		return q;
	} //afslutter corput


	public static vector halton(int n, int d, int shift=0){
		vector x = new vector(d);
		int[] bas = new int[] {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67};
		for(int i=0; i<d; i++){
			x[i] = corput(n, bas[i+shift]);
		}
		return x;
	
	} // afslutter halton



} // afslutter MonteCarlo

