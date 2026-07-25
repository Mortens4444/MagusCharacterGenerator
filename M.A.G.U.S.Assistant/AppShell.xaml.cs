using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Title = Lng.Elem("M.A.G.U.S. Assistant");

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
