using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ItemDetailsPage : NotifierPage
{
    public ItemDetailsPage(ItemDetailsViewModel itemDetailsViewModel)
    {
        InitializeComponent();
        Title = Lng.Elem(itemDetailsViewModel.Thing.Name);
        BindingContext = itemDetailsViewModel;
    }
}
