using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ImagesPage : NotifierPage
{
	public ImagesPage()
	{
		InitializeComponent();
        BindingContext = new ImagesViewModel();
        Resources.Add("ImagesPageRoot", this);
    }
}