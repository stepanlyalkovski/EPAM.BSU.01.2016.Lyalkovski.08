namespace Task1
{
    public interface IMatrixVisitor<T>
    {
        void VisitS(SMatrix<T> sMatrix);
        void VisitDiagonal(DiagonalMatrix<T> dMatrix);
        void VisitSymmetric(SymmetricMatrix<T> symMatrix);
    }
}
