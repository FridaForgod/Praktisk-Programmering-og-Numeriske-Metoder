using static System.Console;
using System;
using static System.Math;

public static partial class matlib{

	public static int binsearch(double[] x, double z)
		{/* locates the interval for z by bisection */ 
		if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}

	public static double linterp(double[] x, double[] y, double z){
		int i=binsearch(x,z);
		double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
		double dy=y[i+1]-y[i];
		return y[i]+dy/dx*(z-x[i]);
		
	}

	public static double linterpInteg(double[] x, double[] y, double z){
		double sum = 0;
		int idx = binsearch(x,z);
		for(int i = 0; i < idx; i++){
			double dy = y[i+1]-y[i], dx = x[i+1]-x[i];
			double pi = dy/dx;
			sum += y[i]*(x[i+1]-x[i])+pi*Pow(x[i+1]-x[i],2)/2;
		}
		double p = (y[idx+1]-y[idx])/(x[idx+1]-x[idx]);
		sum += y[idx]*(z-x[idx])+p*Pow(z-x[idx],2)/2;	
		return sum;
	}






}
