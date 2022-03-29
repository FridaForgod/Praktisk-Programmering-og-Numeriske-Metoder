using static System.Console;
using static System.Math;
class tests{
public static void Main(){
	
	// Tables for checking splines
	double[] xtable = new double[]{1,2,3,4,5};
	double[] ytable1 = new double[]{1,1,1,1,1};
	double[] c1 = new double[]{0,0,0,0};
	double[] b1 = new double[]{0,0,0,0};
	double[] ytable2 = new double[]{1,2,3,4,5};
	double[] c2 = new double[]{0,0,0,0};
	double[] b2 = new double[]{1,1,1,1};
	double[] ytable3 = new double[]{1,4,9,16,25};
	double[] c3 = new double[]{1,1,1,1};
	double[] b3 = new double[]{2,4,6,8};

	// Create splines	
	qspline q1 = new qspline(xtable, ytable1);
	qspline q2 = new qspline(xtable, ytable2);
	qspline q3 = new qspline(xtable, ytable3);

	WriteLine("Table 1");
	Write("Manually calculated cs: ");
	for(int i = 0; i<c1.Length; i++){
		Write($"{c1[i]} ");
	}
	WriteLine();
	Write("Program cs: ");
	for(int i = 0; i<c1.Length; i++){
		Write($"{q1.c[i]} ");
	}
	WriteLine();
	Write("Manually calculated bs: ");
	for(int i = 0; i<c1.Length; i++){
		Write($"{b1[i]} ");
	}
	WriteLine();
	Write("Program bs: ");
	for(int i = 0; i<c1.Length; i++){
		Write($"{q1.b[i]} ");
	}
		
	WriteLine();
	WriteLine();

	WriteLine("Table 2");
	Write("Manually calculated cs: ");
	for(int i = 0; i<c1.Length; i++){
		Write($"{c2[i]} ");
	}
	WriteLine();
	Write("Program cs: ");
	for(int i = 0; i<c1.Length; i++){
		Write($"{q2.c[i]} ");
	}
	WriteLine();
	Write("Manually calculated bs: ");
	for(int i = 0; i<c1.Length; i++){
		Write($"{b2[i]} ");
	}
	WriteLine();
	Write("Program bs: ");
	for(int i = 0; i<c1.Length; i++){
		Write($"{q2.b[i]} ");
	}

	WriteLine();
	WriteLine();

	WriteLine("Table 3");
	Write("Manually calculated cs: ");
	for(int i = 0; i<c1.Length; i++){
		Write($"{c3[i]} ");
	}
	WriteLine();
	Write("Program cs: ");
	for(int i = 0; i<c1.Length; i++){
		Write($"{q3.c[i]} ");
	}
	WriteLine();
	Write("Manually calculated bs: ");
	for(int i = 0; i<c1.Length; i++){
		Write($"{b3[i]} ");
	}
	WriteLine();
	Write("Program bs: ");
	for(int i = 0; i<c1.Length; i++){
		Write($"{q3.b[i]} ");
	}
}
}

