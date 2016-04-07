namespace Task1
{
    public class SMatrix<T> : SquareMatrix<T>
    {
        public SMatrix(T[][] matrix) : base(matrix)
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
    }
}