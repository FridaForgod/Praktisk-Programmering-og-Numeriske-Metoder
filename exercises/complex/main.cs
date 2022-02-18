using System;
using static System.Console;
using static System.Math;
using static cmath;

class main{
	static void Main(){
		//Her regner jeg sqrt(-1)
		complex z = new complex(-1);
		complex w = sqrt(z);
		w.print("sqrt(-1) = ");

		//Her regner jeg sqrt(i)
		var sq_i = sqrt(cmath.I);
		WriteLine($"square(i) = {sq_i}");

		//Her regner jeg 5+2i
		complex u = new complex(5,2);
		u.print("5+2i = ");

		//Her regner jeg e**i
		var ei = exp(cmath.I);
		WriteLine($"e**i = {ei}");

		//Her regner jeg e**i_pi
		var eipi = exp(cmath.I*System.Math.PI);
		WriteLine($"e^ipi = {eipi}");

		//Her regner jeg i^i
		var ii = cmath.pow(cmath.I,cmath.I);
		WriteLine($"i^i = {ii}");

		//Her regner jeg ln(i)
		var lni = log(cmath.I);
		WriteLine($"ln(i) = {lni}");

		//Her regner jeg sin(ipi)
		var sinipi = sin(System.Math.PI*cmath.I);
		WriteLine($"sin(ipi) = {sinipi}");
			
}
}
