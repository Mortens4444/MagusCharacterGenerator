using MAGUS.Assistant.Models;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class RunesPage : NotifierPage
{
	public RunesPage(RunesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		
		viewModel.LoadItems(PreloadService.Instance.Runes.Select(DisplayItem.FromObject));
    }
}