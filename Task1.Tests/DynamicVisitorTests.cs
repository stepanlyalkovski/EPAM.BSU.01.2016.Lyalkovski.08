using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using Task1.DynamicVisitor;
using Task1.MatrixHierarchy;

namespace Task1.Tests
{
    [TestFixture]
    public class DynamicVisitorTests
    {
        private readonly int[][] diagonalMatrixInts =
            {
                new int[3] {1, 0, 0},
                new int[3] {0, 5, 0},
                new int[3] {0, 0, 9},
            };

        private readonly int[][] squareMatrixInts =
           {
                new int[3] {9, 4, 2},
                new int[3] {5, 5, 5},
                new int[3] {0, 1, 1},
            };

        private readonly int[][] symmetricMatrixInts =
           {
                new int[3] {1, 2, 3},
                new int[3] {2, 3, 4},
                new int[3] {3, 4, 5},
            };

        [Test]
        public void SumWith_DiagonalMatrices_ResultIsDiagonalMatrix()
        {
            var squareMatrix = new SquareMatrix<int>(squareMatrixInts);
            var diagonalMatrix = new DiagonalMatrix<int>(diagonalMatrixInts);
            var symmetricMatrix = new SymmetricMatrix<int>(symmetricMatrixInts);

            BaseSquareMatrix<int> baseMatrix = diagonalMatrix;
            var result = diagonalMatrix.SumWith(diagonalMatrix);
            Debug.WriteLine(result.GetType());
            for (int i = 0; i < result.Order; i++)
            {
                for (int j = 0; j < result.Order; j++)
                {
                    Debug.Write(result[i,j] + " ");
                }
            }

            Assert.True(result is DiagonalMatrix<int>);
        }
    }
}