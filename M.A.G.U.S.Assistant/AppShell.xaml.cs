using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Title = Lng.Elem("M.A.G.U.S. Assistant");
        }
    }
}
