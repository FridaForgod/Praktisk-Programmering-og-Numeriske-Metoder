using static System.Math;
using static System.Console;
using System;
using static table;
class main{

	public static void Main(){
		for(int n=1; n<=3; n++){
			WriteLine($"Printing table [x, sin(x)] for n={n}");
			Func<double, double> sinnx = delegate(double x){return Sin(n*x);};
			make_table(sinnx, 0, 2*PI, 0.1);
			WriteLine();
		
		}


	}

}
