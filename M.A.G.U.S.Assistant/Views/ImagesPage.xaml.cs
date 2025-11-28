using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ImagesPage : NotifierPage
{
	public ImagesPage(ImagesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}