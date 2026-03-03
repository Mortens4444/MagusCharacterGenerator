using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class RunesPage : NotifierPage
{
	public RunesPage(RunesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		
		viewModel.LoadItems(PreloadService.Instance.Runes.Select(DisplayItem.FromObject));
    }
}