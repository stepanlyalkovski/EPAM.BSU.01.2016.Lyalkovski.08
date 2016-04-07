namespace Task1
{
    public class SumMatrixVisitor<T> : IMatrixVisitor<T>
    {
        public void VisitS(SMatrix<T> sMatrix)
        {
            throw new System.NotImplementedException();
        }

        public void VisitDiagonal(DiagonalMatrix<T> dMatrix)
        {
            throw new System.NotImplementedException();
        }

        public void VisitSymmetric(SymmetricMatrix<T> symMatrix)
        {
            throw new System.NotImplementedException();
        }
    }
}