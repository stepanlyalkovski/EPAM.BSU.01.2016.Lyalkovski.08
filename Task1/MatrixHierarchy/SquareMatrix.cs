namespace Task1.MatrixHierarchy
{
    public class SquareMatrix<T> : BaseSquareMatrix<T>
    {
        public SquareMatrix(T[][] matrix) : base(matrix)
        {
            _matrix = new T[Order * Order];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int rowOffset = Order * i;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    _matrix[rowOffset + j] = matrix[i][j];
                }
            }
        }

        protected override T GetElement(int row, int col)
        {
            return _matrix[row * Order + col];
        }

        protected override void SetElement(int row, int col, T value)
        {
            _matrix[row*Order + col] = value;
            OnElementChanged(new MatrixChangedEventArgs<T>(row, col, value));
        }

    }
}