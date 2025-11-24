using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class SoundPage : NotifierPage
{
    public SoundPage(SoundViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}