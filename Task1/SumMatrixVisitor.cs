using System.Runtime.CompilerServices;
using Task1.MatrixHierarchy;

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
            throw new System.NotImplementedException();
        }

        public void VisitDiagonal(DiagonalMatrix<T> dMatrix)
        {
            throw new System.NotImplementedException();
        }

        public void VisitSymmetric(SymmetricMatrix<T> symMatrix)
        {
            //symMatrix = Sum(symMatrix, (_matrix));
        }

        private static SquareMatrix<T> Sum(SquareMatrix<T> arg1, SquareMatrix<T> arg2)
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

        private static DiagonalMatrix<T> Sum(DiagonalMatrix<T> arg1, DiagonalMatrix<T> arg2)
        {
            T[] result = new T[arg1.Order];

            for (int i = 0; i < arg1.Order; i++)
            {
                result[i] = (dynamic) arg1[i] + arg2[i];
            }

            return new DiagonalMatrix<T>(result);
        }
    }
}