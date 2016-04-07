namespace Task1
{
    public class SumMatrixVisitor<T> : IMatrixVisitor<T>
    {
        private SquareMatrix<T> _matrix;

        public SumMatrixVisitor(SquareMatrix<T> matrix)
        {
            _matrix = matrix;
        }

        public void VisitS(SMatrix<T> sMatrix)
        {
            
        }

        public void VisitDiagonal(DiagonalMatrix<T> dMatrix)
        {
            throw new System.NotImplementedException();
        }

        public void VisitSymmetric(SymmetricMatrix<T> symMatrix)
        {
            throw new System.NotImplementedException();
        }

        private SquareMatrix<T> Sum(SquareMatrix<T> arg1, SquareMatrix<T> arg2)
        {
            T[][] result = new T[arg1.Order][];
            for (int i = 0; i < arg1.Order; i++)
            {
                result[i] = new T[arg1.Order];
            }
            for (int i = 0; i < arg1.Order; i++)
            {
                for (int j = 0; j < arg1.Order; j++)
                {
                    result[i][j] = (dynamic)arg1[i, j] + arg2[i, j];
                }
            }

           return new SMatrix<T>(result);
        }
    }
}