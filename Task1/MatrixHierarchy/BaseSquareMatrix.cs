using System;
using Task1.DynamicVisitor;

namespace Task1.MatrixHierarchy
{

    public abstract class BaseSquareMatrix<T>
    { 
        protected T[] _matrix;
        public int Order { get; }
        public event EventHandler<MatrixChangedEventArgs<T>> ElementChanged;

        protected virtual void OnElementChanged(MatrixChangedEventArgs<T> args)
        {
            ElementChanged?.Invoke(this, args);
        }

        public static bool CompareToJaggedArray(BaseSquareMatrix<T> matrix, T[][] arrayMatrix)
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

        protected BaseSquareMatrix(int order)
        {
            Order = order;
        }

        //  Template method
        protected abstract T GetElement(int row, int col);

        protected abstract void SetElement(int row, int col, T value);

        protected BaseSquareMatrix(T[][] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            if (!CheckSquare(matrix))
                throw new ArgumentException(nameof(matrix));

            Order = matrix.Length;
        }

        //public abstract void Accept(IMatrixVisitor<T> visitor);

        // awful
        public BaseSquareMatrix<T> Accept(MatrixDynamicVisitor<T> visitor)
        {
            return visitor.DynamicVisit(this);
        }

        public static BaseSquareMatrix<T> operator +(BaseSquareMatrix<T> arg1, BaseSquareMatrix<T> arg2)
        {
           return  arg1.Sum(arg2);
        }

        protected virtual BaseSquareMatrix<T> Sum(BaseSquareMatrix<T> arg2)
        {
            T[][] result = new T[Order][];
            for (int i = 0; i < Order; i++)
            {
                result[i] = new T[Order];
            }
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    result[i][j] = (dynamic)this[i,j] + arg2[i, j];
                }
            }

            return new SquareMatrix<T>(result);
        }

        public T this[int row, int col]
        {
            get
            {
                if (row > Order || col > Order)
                    throw new ArgumentOutOfRangeException();

                return GetElement(row, col);

            }
            set
            {
                if (row > Order || col > Order)
                    throw new ArgumentOutOfRangeException();

                SetElement(row, col, value);
            }
        }
    }
}
