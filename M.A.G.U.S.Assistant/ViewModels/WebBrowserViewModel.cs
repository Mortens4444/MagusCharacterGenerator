using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class WebBrowserViewModel : BaseViewModel
{
    private string currentUrl;
    private bool isLoading;

    public WebBrowserViewModel()
    {
        CurrentUrl = "https://kalandozok.hu/ynev/";
        NavigateCommand = new AsyncRelayCommand(NavigateAsync);
        RefreshCommand = new AsyncRelayCommand(RefreshAsync);
        OpenExternalCommand = new RelayCommand(OpenExternal);
        GoBackCommand = new RelayCommand(GoBack);
        GoForwardCommand = new RelayCommand(GoForward);
    }

    public string CurrentUrl
    {
        get => currentUrl;
        set => SetProperty(ref currentUrl, value ?? String.Empty);
    }

    public bool IsLoading
    {
        get => isLoading;
        set => SetProperty(ref isLoading, value);
    }

    public ICommand NavigateCommand { get; }
    public ICommand RefreshCommand { get; }
    public ICommand OpenExternalCommand { get; }
    public ICommand GoBackCommand { get; }
    public ICommand GoForwardCommand { get; }

    private async Task NavigateAsync()
    {
        if (String.IsNullOrWhiteSpace(CurrentUrl))
        {
            return;
        }

        try
        {
            IsLoading = true;
            // a WebView.Source kötés miatt elég csak beállítani a CurrentUrl-et
            await Task.Delay(100).ConfigureAwait(false); // rövid jelzés a UI-nak; valós hálózati művelet a WebView kezeli
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task RefreshAsync()
    {
        IsLoading = true;
        await Task.Delay(100).ConfigureAwait(false);
        IsLoading = false;
    }

    private void OpenExternal()
    {
        try
        {
            var uri = new Uri(CurrentUrl);
            Launcher.OpenAsync(uri); // MAUI Launcher; hívható platformon
        }
        catch
        {
            // silently ignore or signal error via UI
        }
    }

    private static void GoBack()
    {
        // A WebView-ot code-behind-ból érdemes vezérelni: Browser.GoBack()
        // Itt csak placeholder, ha messaging/behavior-t használsz, küldj üzenetet a nézetnek.
    }

    private static void GoForward()
    {
        // placeholder, lásd GoBack megjegyzést
    }
}

//public class DelegateCommand : ICommand
//{
//    private readonly Func<Task> asyncExecute;
//    private readonly Action execute;
//    private readonly Func<bool> canExecute;

//    public DelegateCommand(Func<Task> executeAsync) { asyncExecute = executeAsync; }
//    public DelegateCommand(Action execute, Func<bool> canExecute = null) { this.execute = execute; this.canExecute = canExecute; }
//    public event EventHandler CanExecuteChanged;

//    public bool CanExecute(object parameter) => canExecute == null || canExecute();

//    public async void Execute(object parameter)
//    {
//        if (asyncExecute != null)
//        {
//            await asyncExecute();
//        }
//        else
//        {
//            execute?.Invoke();
//        }
//    }

//    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
//}
