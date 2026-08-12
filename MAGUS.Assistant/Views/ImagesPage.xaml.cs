using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class ImagesPage : NotifierPage
{
	public ImagesPage(ImagesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}