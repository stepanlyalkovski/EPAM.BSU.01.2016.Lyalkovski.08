using System;
using System.Data;
using Task1.DynamicVisitor;
using Task1.MatrixHierarchy;

namespace Task1
{
    public static class MatrixExtensions
    {
        
        public static BaseSquareMatrix<T> SumWith<T>(this BaseSquareMatrix<T> matrix, BaseSquareMatrix<T> otherMatrix)
        {
            var visitor = new MatrixDynamicSumVisitor<T>(otherMatrix);
            return matrix.Accept(visitor);
        }
       
    }
}
