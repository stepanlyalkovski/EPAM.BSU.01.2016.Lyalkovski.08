using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1.MatrixHierarchy;

namespace Task1.Tests
{
    
    [TestFixture]
    public class DiagonalMatrixTests
    {

        private readonly int[][] diagonalMatrixInts =
            {
                new int[3] {1, 0, 0},
                new int[3] {0, 5, 0},
                new int[3] {0, 0, 9},
            };

        

        [Test]
        public void DiagonalMatrixInts_TwoDimensionalArrayInts_InitializedWithoutExceptionsAndEqualToSourceArray()
        {
            var diagonalMatrix = new DiagonalMatrix<int>(diagonalMatrixInts);

            Assert.IsTrue(SquareMatrix<int>.CompareToJaggedArray(diagonalMatrix, diagonalMatrixInts));
        }

        [Test]
        [ExpectedException("System.ArgumentException")]
        public void DiagonalMatrixInts_TwoDimensionalArrayInts_InitializedWithException()
        {
            int[][] squareMatrix =
            {
                new int[3] {1, 4, 25},
                new int[3] {12, 5, 1},
                new int[3] {34, 0, 9},
            };

            var diagonalMatrix = new DiagonalMatrix<int>(squareMatrix);
        }

        [Test]
        public void DiagonalMatrixInts_ChangeDiagonalElement_EventGenerated()
        {
            var diagonalMatrix = new DiagonalMatrix<int>(diagonalMatrixInts);
            var subscriber = new MatrixTestSubscriber<int>(); 

            subscriber.Subscribe(diagonalMatrix);
            diagonalMatrix[2] = 99;

            Assert.IsTrue(subscriber.WasCalled);
        }

    }
}
