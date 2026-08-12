using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class EnemySetupPage : NotifierPage
{
	public EnemySetupPage(EnemySetupViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}