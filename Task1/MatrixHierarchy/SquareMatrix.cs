﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{

    public abstract class SquareMatrix<T>
    {
        protected T[] _matrix;
        public int Order { get; }
        public event EventHandler<MatrixChangedEventArgs<T>> ElementChanged;

        protected virtual void OnElementChanged(MatrixChangedEventArgs<T> args)
        {
            ElementChanged?.Invoke(this, args);
        }

        public static bool CompareToJaggedArray(SquareMatrix<T> matrix, T[][] arrayMatrix)
        {
            if (arrayMatrix == null || (arrayMatrix.Length != matrix.Order || arrayMatrix[0].Length != matrix.Order))
                return false;

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    if (!matrix[i, j].Equals(arrayMatrix[i][j]))
                        return false;
                }
            }

            return true;
        }

        public static bool CheckSquare(T[][] matrix)
        {
            int order = matrix.Length;
            for (int i = 0; i < order; i++)
            {
                if (matrix[i].Length != order)
                    return false;
            }
            return true;
        }

        protected SquareMatrix(T[][] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            if (!CheckSquare(matrix))
                throw new ArgumentException(nameof(matrix));

            Order = matrix.Length;
        }

        public virtual T this[int row, int col]
        {
            get
            {
                return _matrix[row * Order + col];
            }
            set
            {
                _matrix[row * Order + col] = value;
            }
        }
    }
}