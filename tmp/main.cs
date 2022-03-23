using System;
using static System.Console;
class main{
	public static void Main(){
		Func<double,double> f = delegate(double x){return x;};
		double result = integrate.quad(f,0,1);
		WriteLine($"result={result}");
	}
}
