using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class ClassesPage : NotifierPage
{
    public ClassesPage(ClassesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}