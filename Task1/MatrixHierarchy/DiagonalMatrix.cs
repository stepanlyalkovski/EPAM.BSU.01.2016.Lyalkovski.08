using System;
using System.Linq;

namespace Task1.MatrixHierarchy
{
    public class DiagonalMatrix<T> : BaseSquareMatrix<T>
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

        public DiagonalMatrix(T[] diagonal) : base(diagonal.Length)
        {
            _matrix = new T[Order];

            for (int i = 0; i < Order; i++)
            {
                _matrix[i] = diagonal[i];
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

        protected override T GetElement(int row, int col)
        {
            return row == col ? _matrix[row] : default(T);
        }

        protected override void SetElement(int row, int col, T value)
        {
            if (row != col) return;

            _matrix[row] = value;
            OnElementChanged(new MatrixChangedEventArgs<T>(row, col, value));
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