using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Things;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ItemDetailsPage : NotifierPage
{
    public ItemDetailsPage(Thing thing)
    {
        ArgumentNullException.ThrowIfNull(thing);
        InitializeComponent();
        Title = Lng.Elem(thing.Name);
        BindingContext = new ItemDetailsViewModel(thing);
    }
}
