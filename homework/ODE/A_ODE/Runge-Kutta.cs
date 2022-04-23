using System;
using static System.Math;

public class rkstep{
	public static (vector, vector) step(
		Func<double, vector, vector> f,
		double x,
		vector y,	
		double h){

		//Her indsætter jeg mine værdier. De kommer fra tabellen på side 7 i noten ODE

		//c værdier:
		double c1 = 0;
		double c2 = 1.0/4;
		double c3 = 3.0/8;
		double c4 = 12.0/13;
		double c5 = 1.0;
		double c6 = 1.0/2;

		//b værdier:
		double b1 = 16.0/135;
		double b2 = 0;
		double b3 = 6656.0/12825;
		double b4 = 28561.0/56430;
		double b5 = -9.0/50;
		double b6 = 2.0/55;

		//bs værdier:
		double b1s = 25.0/216;
		double b2s = 0;
		double b3s = 1408.0/2565;
		double b4s = 2197.0/4104;
		double b5s = -1.0/5;
		double b6s = 0;

		//a1 værdier:
		double a11 = 0;	
		double a21 = 1.0/4;
		double a31 = 3.0/32;
		double a41 = 1932.0/2197;
		double a51 = 439.0/216;
		double a61 = -8.0/27;

		//a2 værdier:
		double a32 = 9.0/32;
		double a42 = -7200.0/2197;
		double a52 = -8.0;
		double a62 = 2.0;

		//a3 værdier:
		double a43 = 7296.0/2197;
		double a53 = 3680.0/513;
		double a63 = -3544.0/2565;

		//a4 værdier:
		double a54 = -845.0/4104;
		double a64 = 1859.0/4104;

		//a5 værdier:
		double a65 = -11.0/40;

		//Her indsætter jeg ligningerne for K. De kommer fra ligning 19 på side 4 i noten ODE
		vector K1 = h*f(x,y);
		vector K2 = h*f(x+c2*h, y+a21*K1);
		vector K3 = h*f(x+c3*h, y+a31*K1+a32*K2);
		vector K4 = h*f(x+c4*h, y+a41*K1+a42*K2+a43*K3);
		vector K5 = h*f(x+c5*h, y+a51*K1+a52*K2+a53*K3+a54*K4);
		vector K6 = h*f(x+c6*h, y+a61*K1+a62*K2+a63*K3+a64*K4+a65*K5);
		
		//Jeg indsætter mine y-værdier. De kommer fra ligning 18 og 22 i noten ODE
		vector ys = y+b1s*K1+b2s*K2+b3s*K3+b4s*K4+b5s*K5+b6s*K6;
		vector yh = y+b1*K1+b2*K2+b3*K3+b4*K4+b5*K5+b6*K6;
		vector er = yh-ys;

		return (yh, er);


	} // afslutter step

	
	public static vector driver(
		Func<double, vector, vector> f,
		double a, 
		vector ya,
		double b,
		double h=0.01,
		double acc = 1e-3,
		double eps = 1e-3
		){

		if(a>b) throw new Exception("The startpoint a must be lower than the endpoint b");
		double x = a;
		vector y = ya;

		int i = 0; int maxIter = 50000;
		while(i<=maxIter){
			if(x>=b){return y;}
			if(x+h>b){h = b-x;}
			var (yh, erv) = step(f,x,y,h);
			double tol = Max(acc, yh.norm()*eps)*Sqrt(h/(b-a));
			double err = erv.norm();
			if(err <= tol){
				x+=h;
				y=yh;

			} //afslutter if
			
			double power = 0.25;
			double safety = 0.95;
			h *= Min(Pow(tol/err, power)*safety,2);

		} // afslutter while
		
		throw new Exception("You have exceeded the maximum number of steps. Time to stop!");

	} //afslutter driver

} // afslutter rkstep
