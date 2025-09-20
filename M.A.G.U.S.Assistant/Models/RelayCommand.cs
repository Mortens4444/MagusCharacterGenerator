using System.Windows.Input;

namespace M.A.G.U.S.Assistant.Models;

internal partial class RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) : ICommand
{
    readonly Action<object?> _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    readonly Func<object?, bool>? _canExecute = canExecute;

    public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

    public void Execute(object? parameter) => _execute(parameter);

    public event EventHandler? CanExecuteChanged;

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
