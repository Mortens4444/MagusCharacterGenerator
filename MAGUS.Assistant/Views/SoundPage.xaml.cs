using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class SoundPage : NotifierPage
{
    public SoundPage(SoundViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}