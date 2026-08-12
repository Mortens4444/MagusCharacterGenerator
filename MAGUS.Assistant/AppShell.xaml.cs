using Mtf.LanguageService;

namespace MAGUS.Assistant;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Title = Lng.Elem("MAGUS Assistant");

        Lng.LanguageChanged += Lng_LanguageChanged;
    }

    private void Lng_LanguageChanged()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (Application.Current?.MainPage != null)
            {
                Application.Current.MainPage.FlowDirection = Lng.IsRtl
                    ? FlowDirection.RightToLeft
                    : FlowDirection.LeftToRight;
            }
        });
    }
}
