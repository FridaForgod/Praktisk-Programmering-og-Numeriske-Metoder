using System;
using static System.Console;
using static System.Math;
class main{
	static void Main(){
		
		//Her regner jeg sqrt(2)
		double sqrt2=Sqrt(2.0);
		Write($"sqrt(2)={sqrt2}\n");
		//Her tjekker jeg, at resultatet er korrekt
		Write($"sqrt2*sqrt2={sqrt2*sqrt2} (should be equal 2)\n");

		//Her regner jeg e^pi
		var epi = Pow(System.Math.E, System.Math.PI);
		Write($"e^pi = {epi}\n");

		//Her regner jeg pi^e
		var pie = Pow(System.Math.PI, System.Math.E);
		Write($"pi^e = {pie}\n");
	}

}
