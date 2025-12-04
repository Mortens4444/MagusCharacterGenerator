using CommunityToolkit.Mvvm.Messaging;
using Mtf.Maui.Controls.Models;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.Services;

public static class CommandExecutor
{
    public static void ExecuteOnUIThread(Action action)
    {
        if (action == null)
        {
            return;
        }

        MainThread.BeginInvokeOnMainThread(() =>
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        });
    }

    public static void ExecuteOnUIThread(ICommand command, object? parameter = null)
    {
        if (command == null)
        {
            return;
        }

        MainThread.BeginInvokeOnMainThread(() =>
        {
            try
            {
                if (command.CanExecute(parameter))
                {
                    command.Execute(parameter);
                }
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        });
    }

    public static void ExecuteOnUIThread(Func<Task> actionAsync)
    {
        if (actionAsync == null)
        {
            return;
        }

        MainThread.InvokeOnMainThreadAsync(async () =>
        {
            try
            {
                await actionAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        });
    }

    public static void ExecuteIf(Func<bool> predicate, Action action)
    {
        if (predicate == null || action == null)
        {
            return;
        }

        if (!predicate())
        {
            return;
        }

        ExecuteOnUIThread(action);
    }

    public static void ExecuteIfAsync(Func<bool> predicate, Func<Task> actionAsync)
    {
        if (predicate == null || actionAsync == null)
        {
            return;
        }

        if (!predicate())
        {
            return;
        }

        ExecuteOnUIThread(actionAsync);
    }
}
