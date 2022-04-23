using System;
using static System.Math;

public static class leastsquare{
	public static (vector, matrix, vector) lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
		int n = x.size;
		int m = fs.Length;
		matrix A = new matrix(n,m);
		vector b = new vector(n);
		
		for(int i=0; i<n; i++){
			b[i] = y[i]/dy[i];
			for(int k=0; k<m; k++){
				A[i,k] = fs[k] (x[i])/dy[i];
			}// slutter for med k
		}//slutter for med n

		qrgs QRA = new qrgs(A);
		vector c = QRA.solve(b);
		
		matrix AtA = A.transpose()*A;
		qrgs solveAtA = new qrgs(AtA);
		matrix covs = solveAtA.inverse();

		vector errs = new vector(m);
		for(int i=0; i<m; i++){
			errs[i] = Sqrt(covs[i][i]);

		}// slutter for med m

		return (c,covs,errs);

	}//slutter lsfit

}// slutter leastsquare


