using static System.Console;
using static System.Math;
class main{
public static void Main(){
	
	double[] xs = new double[] {0, 0.4, 0.8, 1.2, 1.6, 2.0, 2.4, 2.8, 3.2, 3.6, 4.0, 4.4, 4.8, 5.2, 5.6, 6.0, 6.4};
	double[] ys = new double[17];
	for(int i=0; i<ys.Length; i++){ys[i]=Sin(xs[i]);}

	for(int i=0; i<xs.Length; i++){
		WriteLine($"{xs[i]} {ys[i]}");
	}
	WriteLine();
	WriteLine();
	for(double z=0; z<=6.4; z+=1.0/64){
		WriteLine($"{z} {matlib.linterp(xs,ys,z)} {matlib.linterpInteg(xs,ys,z)}");
	}
		
}
}

