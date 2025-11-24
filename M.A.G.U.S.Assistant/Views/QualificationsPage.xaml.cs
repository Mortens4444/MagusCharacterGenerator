using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class QualificationsPage : NotifierPage
{
    public QualificationsPage(QualificationsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}