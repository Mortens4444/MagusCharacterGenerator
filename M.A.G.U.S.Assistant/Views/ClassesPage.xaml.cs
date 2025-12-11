using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ClassesPage : NotifierPage
{
    public ClassesPage(ClassesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}