using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class SoundPage : NotifierPage
{
    public SoundPage(SoundViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}