using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class MapPage : NotifierPage
{
    public MapPage(WebBrowserViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}