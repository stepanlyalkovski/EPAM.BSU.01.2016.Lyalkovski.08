using System.Diagnostics;
using System.Threading;

namespace Task1.Tests
{
    public class MatrixTestSubscriber<T>
    {
        public bool WasCalled { get; private set; } = false;

        public void Subscribe(SquareMatrix<T> matrix)
        {
            matrix.ElementChanged += EventGenerated;
        }

        private void EventGenerated(object sender, MatrixChangedEventArgs<T> args)
        {
            Debug.WriteLine($"Event generated\n row: {args.Row}, column: {args.Column}, new value: {args.newValue}");
            WasCalled = true;
        }      
    }
}