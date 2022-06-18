public class qrgs{

	public matrix Q,R;

	public qrgs(matrix A){
		Q = A.copy();
		int m = A.size2;
		R = new matrix(m,m);
		
		for(int i=0; i<m; i++){
			R[i,i] = Q[i].norm();
			Q[i] /= R[i,i];
			
			for(int j=i+1; j<m; j++){
				R[i,j] = Q[i].dot(Q[j]);
				Q[j] -= Q[i] * R[i,j];

			} // afslutter for

		} // afslutter for

	} //afslutter qrgs

} // afslutter class qrgs
