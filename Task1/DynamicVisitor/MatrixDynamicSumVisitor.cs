using System;
using System.Diagnostics;
using Task1.MatrixHierarchy;

namespace Task1.DynamicVisitor
{
    public class MatrixDynamicSumVisitor<T> : MatrixDynamicVisitor<T>
    {
        private readonly dynamic _otherMatrix;

        public MatrixDynamicSumVisitor(BaseSquareMatrix<T> otherMatrix)
        {
            _otherMatrix = otherMatrix;
        }

        protected override BaseSquareMatrix<T> Visit(BaseSquareMatrix<T> matrix)
        {
            return Sum(matrix, _otherMatrix);
        }

        protected override BaseSquareMatrix<T> Visit(SymmetricMatrix<T> matrix)
        {
            return Sum(matrix, _otherMatrix);
        }

        protected override BaseSquareMatrix<T> Visit(DiagonalMatrix<T> matrix)
        {
            return Sum(matrix, _otherMatrix);
        }

        public BaseSquareMatrix<T> Sum(BaseSquareMatrix<T> matrix1, BaseSquareMatrix<T> matrix2)
        {
            //Debug.WriteLine("BaseSquare method");
            T[][] result = new T[matrix1.Order][];
            for (int i = 0; i < matrix1.Order; i++)
            {
                result[i] = new T[matrix1.Order];
            }
            for (int i = 0; i < matrix1.Order; i++)
            {
                for (int j = 0; j < matrix1.Order; j++)
                {
                    result[i][j] = (dynamic)matrix1[i, j] + matrix2[i, j];
                }
            }

            return new SquareMatrix<T>(result);
        }

        public BaseSquareMatrix<T> Sum(SymmetricMatrix<T> matrix1, SymmetricMatrix<T> matrix2)
        {
            throw new NotImplementedException();
        }

        public BaseSquareMatrix<T> Sum(DiagonalMatrix<T> matrix1, DiagonalMatrix<T> matrix2)
        {
            //Debug.WriteLine("Diagonal method");
            T[] diagonalResult = new T[matrix1.Order];
            for (int i = 0; i < matrix1.Order; i++)
            {
                diagonalResult[i] = (dynamic)matrix1[i] + matrix2[i];
            }

            return new DiagonalMatrix<T>(diagonalResult);
        }

        public BaseSquareMatrix<T> Sum(SymmetricMatrix<T> matrix1, DiagonalMatrix<T> matrix2)
        {
            throw new NotImplementedException();
        }

        public BaseSquareMatrix<T> Sum(DiagonalMatrix<T> matrix1, SymmetricMatrix<T> matrix2)
        {
            throw new NotImplementedException();
        }
    }
}