using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class LanguagesPage : NotifierPage
{
    public LanguagesPage(LanguagesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
