using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class RacesPage : NotifierPage
{
    public RacesPage(RacesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}