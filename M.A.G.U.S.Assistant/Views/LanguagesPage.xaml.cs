using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class LanguagesPage : NotifierPage
{
    public LanguagesPage(LanguagesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
