using System.Windows.Input;

namespace AC.ViewModel.Utilities
{
    public class RelayCommand<T> : ICommand where T : class
    {
        private readonly Action<T?> _executeDelegate;
        private readonly Func<T?, bool>? _canExecuteDelegate;

        public RelayCommand(Action<T?> execute, Func<T?, bool>? canExecute)
        {
            _executeDelegate = execute;
            _canExecuteDelegate = canExecute;
        }
        public RelayCommand(Action<T?> execute) : this(execute, canExecute: null) { }

        public bool CanExecute(object? parameter)
        {
            if (_canExecuteDelegate != null) return _canExecuteDelegate((T?)parameter);
            return true;
        }
        public void Execute(object? parameter)
        {
            _executeDelegate.Invoke((T?)parameter);
        }

        public event EventHandler? CanExecuteChanged;
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
// Split into Command and StateCommand