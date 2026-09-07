using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class CharactersPage : NotifierPage
{
    public CharactersPage(CharactersViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

        // Loaded (not OnAppearing) - OnAppearing can fire while the page's native view is still
        // being attached/measured during the Shell push transition, so an async data load that
        // completes mid-animation can update the CollectionView's ItemsSource before it has a
        // native layout pass to render into, leaving it blank until the user navigates away and back.
        Loaded += async (_, _) => await viewModel.LoadCharactersAsync().ConfigureAwait(false);
    }
}