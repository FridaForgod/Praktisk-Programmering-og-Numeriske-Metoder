using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main {
	public static void Main(){
		QRdecomp();

	} // afslutter Main

	public static void QRdecomp(){
		int n = 6;
		int m = 4;

		matrix A = new matrix(n,m);

		Random rand = new Random();
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				A[i,j] = rand.Next(15);		

			} // afslutter for

		} // afslutter for

		WriteLine($"This a matrix A:");
		A.print();


	} // afslutter QRdecomp



} // afslutter main

