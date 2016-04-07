using System;

namespace Task1
{
    public class MatrixChangedEventArgs<T> : EventArgs
    {
        public int Row { get; }
        public int Column { get; }
        public T newValue { get; }

        public MatrixChangedEventArgs(int row, int column, T newValue)
        {
            Row = row;
            Column = column;
            this.newValue = newValue;
        }
    }
}