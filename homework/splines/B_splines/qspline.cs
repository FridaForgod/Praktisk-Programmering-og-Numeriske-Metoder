using static System.Math;
using System;
public class qspline{
	public double[] x,y,b,c;

	public qspline(double[] xs, double[] ys){
		this.x = xs;
		this.y = ys;
		int datalen = x.Length;
		this.b = new double[datalen-1];
		this.c = new double[datalen-1];
		
		// Determine pi
		double[] p = new double[datalen-1];
		double[] h = new double[datalen-1];
		for(int i=0; i<datalen-1; i++){
			h[i] = x[i+1] - x[i];
			p[i]=(y[i+1]-y[i])/h[i];
		}

		// Forward recursion
		double[] cforward = new double[datalen-1];
		cforward[0] = 0;
		for(int i=0; i<datalen-2; i++){
			cforward[i+1] = (p[i+1]-p[i] - cforward[i]*h[i])/h[i+1];
		}	

		// Backward recursion
		double[] cback = new double[datalen-1];
		cback[datalen-2] = 0;
		for(int i=datalen-3; i>=0; i--){
			cback[i] = (p[i+1]-p[i] - cback[i+1]*h[i+1])/h[i];
		}

		// Average
		for(int i=0; i<datalen-1; i++){
			c[i] = (cforward[i]+cback[i])/2;
		}

		for(int i=0; i<datalen-1; i++){
			b[i] = p[i]-c[i]*h[i];
		}

	}

	public static int binsearch(double[] x, double z){
		/* locates the interval for z by bisection */
		if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}

	public double eval(double z){
		int i = binsearch(x,z);
		double h = z-x[i];
		return y[i] + b[i]*h + c[i]*Pow(h,2);
	
	}

	public double deriv(double z){
		int i = binsearch(x,z);
		double h = z-x[i];
		return b[i] + 2.0*c[i]*h;
	}

	public double integral(double z){
		int idx = binsearch(x,z);
		double h = 0;
		double sum = 0;
		for(int i = 0; i<idx; i++)
		{
			h = x[i+1]-x[i];
			sum += y[i]*h + b[i]*Pow(h,2)/2 + c[i]*Pow(h,3)/3;
		}
		h = z - x[idx];
		sum += y[idx]*h + b[idx]*Pow(h,2)/2 + c[idx]*Pow(h,3)/3;
		return sum;
	}

}

