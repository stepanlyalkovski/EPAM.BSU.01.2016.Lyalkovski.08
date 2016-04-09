using Task1.MatrixHierarchy;

namespace Task1
{
    public interface IMatrixVisitor<T>
    {
        void VisitS(SquareMatrix<T> squareMatrix);
        void VisitDiagonal(DiagonalMatrix<T> dMatrix);
        void VisitSymmetric(SymmetricMatrix<T> symMatrix);
    }
}
