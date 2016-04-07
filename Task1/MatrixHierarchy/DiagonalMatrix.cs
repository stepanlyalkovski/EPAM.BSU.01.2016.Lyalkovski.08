using System;
using System.Linq;

namespace Task1
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(T[][] matrix) : base(matrix)
        {
            if (!CheckDiagonal(matrix))
                throw new ArgumentException("matrix is not diagonal", nameof(matrix));

            _matrix = new T[Order];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (i == j)
                        _matrix[i] = matrix[i][j];
                }
            }

        }

        public T this[int index]
        {
            get
            {
                if (index > Order)
                    throw new IndexOutOfRangeException();

                return _matrix[index];
            }
            set
            {
                if (index > Order)
                    throw new IndexOutOfRangeException();

                _matrix[index] = value;
                OnElementChanged(new MatrixChangedEventArgs<T>(index, index, value));
            }
        }

        public override T this[int row, int col]
        {
            get
            {
                if (row > Order || col > Order)
                    throw new ArgumentOutOfRangeException();

                return row == col ? _matrix[row] : default(T);
            }

            // Liskov substitution principle: Would it be incorrect if I threw exception here?
            set
            {
                if (row > Order || col > Order)
                    throw new ArgumentOutOfRangeException();

                if (row != col) return;

                _matrix[row] = value;
                OnElementChanged(new MatrixChangedEventArgs<T>(row, col, value));
            }
        }

        private static bool CheckDiagonal(T[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix.Where((t, j) => i != j && !matrix[i][j].Equals(default(T))).Any())
                {
                    return false;
                }
            }
            return true;
        }
    }
}