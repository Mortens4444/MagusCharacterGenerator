using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

public partial class ImagesPage : NotifierPage
{
	public ImagesPage()
	{
		InitializeComponent();
        this.BindingContext = new ImagesViewModel();
        //this.SetValue(Microsoft.Maui.Controls.Xaml.Xaml.IsInefficientModeProperty, false);
        this.Resources.Add("ImagesPageRoot", this); // ha szeretn�d x:Reference helyett
    }
}