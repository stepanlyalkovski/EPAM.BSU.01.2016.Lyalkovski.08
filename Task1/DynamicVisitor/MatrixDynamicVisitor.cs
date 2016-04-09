using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.MatrixHierarchy;

namespace Task1.DynamicVisitor
{
    public abstract class MatrixDynamicVisitor<T>
    {
        public BaseSquareMatrix<T> DynamicVisit(BaseSquareMatrix<T> matrix)
        {
            return Visit((dynamic) matrix);
        }

        protected abstract BaseSquareMatrix<T> Visit(BaseSquareMatrix<T> matrix);

        protected abstract BaseSquareMatrix<T> Visit(SymmetricMatrix<T> matrix);

        protected abstract BaseSquareMatrix<T> Visit(DiagonalMatrix<T> matrix);
    }
}
