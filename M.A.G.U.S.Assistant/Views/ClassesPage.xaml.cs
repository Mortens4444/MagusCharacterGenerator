using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ClassesPage : NotifierPage
{
    public ClassesPage(ClassesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}