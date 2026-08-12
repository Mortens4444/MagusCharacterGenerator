using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class LanguagesPage : NotifierPage
{
    public LanguagesPage(LanguagesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
