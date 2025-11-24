using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class MapPage : NotifierPage
{
    public MapPage(WebBrowserViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}