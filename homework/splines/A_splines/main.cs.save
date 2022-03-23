using static System.Console;
using static System.Math;
using System;

class main{
public static void Main(){
	var rnd=new System.Random();
	int n=7,N=10*n;
	var x=new double[n];
	var y=new double[n];
	for(int i=0;i<n;i++){
		x[i]=i;
		y[i]=rnd.NextDouble()*5;
		WriteLine($"{x[i]} {y[i]}");
		}
	WriteLine();
	WriteLine();
	for(int i=0;i<N;i++){
		double z=x[0]+i*(x[n-1]-x[0])/(N-1);
		WriteLine($"{z} {matlib.linterp(x,y,z)}");
	}
}
}
