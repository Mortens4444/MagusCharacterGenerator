using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class EnemySetupPage : NotifierPage
{
	public EnemySetupPage(EnemySetupViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}