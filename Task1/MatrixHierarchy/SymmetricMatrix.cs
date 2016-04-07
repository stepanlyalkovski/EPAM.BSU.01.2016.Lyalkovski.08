using System;
using System.Linq;

namespace Task1
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(T[][] matrix) : base(matrix)
        {
            if (!CheckTranspose(matrix))
                throw new ArgumentException("matrix is not symmetric", nameof(matrix));

            int size = (int)((Math.Pow(Order, 2) + Order) / 2);
            _matrix = new T[size];
            int offset = 0;

            for (int i = 0; i < Order; i++, offset += i)
            {
                for (int j = 0; j <= i; j++)
                {
                    _matrix[j + offset] = matrix[i][j];
                }
            }

        }

        public override T this[int row, int col]
        {
            get
            {
                if (row > Order || col > Order)
                    throw new ArgumentOutOfRangeException();

                return _matrix[GetIndex(row, col)];
            }
            set
            {
                if (row > Order || col > Order)
                    throw new ArgumentOutOfRangeException();

                _matrix[GetIndex(row, col)] = value;
                OnElementChanged(new MatrixChangedEventArgs<T>(row, col, value));
            }
        }

        private static bool CheckTranspose(T[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix.Where((t, j) => !matrix[i][j].Equals(t[i])).Any())
                {
                    return false;
                }
            }
            return true;
        }

        #region row-column translation
        private static int GetIndex(int row, int col)
        {
            return row > col ? GetOffset(row) + col : GetOffset(col) + row;
        }

        private static int GetOffset(int row)
        {
            int result = 0;
            int rowNumber = 0;
            while (row-- > 0)
            {
                rowNumber++;
                result += rowNumber;
            }
            return result;
        }
        #endregion
    }
}