using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels
{
    public class WebBrowserViewModel : ObservableObject
    {
        public WebBrowserViewModel()
        {
            CurrentUrl = "https://kalandozok.hu/ynev/";
            NavigateCommand = new DelegateCommand(async () => await NavigateAsync());
            RefreshCommand = new DelegateCommand(async () => await RefreshAsync());
            OpenExternalCommand = new DelegateCommand(() => OpenExternal());
            GoBackCommand = new DelegateCommand(() => GoBack());
            GoForwardCommand = new DelegateCommand(() => GoForward());
        }

        string currentUrl;
        public string CurrentUrl
        {
            get => currentUrl;
            set => SetProperty(ref currentUrl, value ?? String.Empty);
        }

        bool isLoading;
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

        async Task NavigateAsync()
        {
            if (string.IsNullOrWhiteSpace(CurrentUrl))
                return;

            try
            {
                IsLoading = true;
                // a WebView.Source kötés miatt elég csak beállítani a CurrentUrl-et
                await Task.Delay(100); // rövid jelzés a UI-nak; valós hálózati művelet a WebView kezeli
            }
            finally
            {
                IsLoading = false;
            }
        }

        async Task RefreshAsync()
        {
            IsLoading = true;
            await Task.Delay(100);
            IsLoading = false;
        }

        void OpenExternal()
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

        void GoBack()
        {
            // A WebView-ot code-behind-ból érdemes vezérelni: Browser.GoBack()
            // Itt csak placeholder, ha messaging/behavior-t használsz, küldj üzenetet a nézetnek.
        }

        void GoForward()
        {
            // placeholder, lásd GoBack megjegyzést
        }
    }

    // Egyszerű DelegateCommand (rövid, de használható)
    public class DelegateCommand : ICommand
    {
        readonly Func<Task> asyncExecute;
        readonly Action execute;
        readonly Func<bool> canExecute;

        public DelegateCommand(Func<Task> executeAsync) { asyncExecute = executeAsync; }
        public DelegateCommand(Action execute, Func<bool> canExecute = null) { this.execute = execute; this.canExecute = canExecute; }

        public bool CanExecute(object parameter) => canExecute == null || canExecute();

        public async void Execute(object parameter)
        {
            if (asyncExecute != null) await asyncExecute();
            else execute?.Invoke();
        }

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
