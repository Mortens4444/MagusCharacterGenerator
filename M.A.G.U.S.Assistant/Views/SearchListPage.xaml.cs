using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Things;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Models;

namespace M.A.G.U.S.Assistant.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
internal partial class SearchListPage : NotifierPage
{
    internal SearchListViewModel ViewModel => BindingContext as SearchListViewModel;

    public SearchListPage(SearchListViewModel viewModel, string title, IEnumerable<DisplayItem> items)
    {
        InitializeComponent();
        BindingContext = viewModel;
        Title = title;
        ViewModel?.LoadItems(items);
    }

    protected virtual void OnDetailsClicked(object sender, EventArgs e)
    {
        try
        {
            var selected = ViewModel?.SelectedItem;
            if (selected == null)
            {
                WeakReferenceMessenger.Default.Send(Lng.Elem("Select an item first"));
            }

            var objToInspect = (object)selected;
            if (objToInspect != null)
            {
                var page = (Page)(objToInspect is DisplayItem displayItem ?
                    displayItem.Source is Creature creature ? 
                        new CreatureDetailsPage(new CreatureDetailsViewModel(creature)) :
                        new ItemDetailsPage(displayItem.Source as Thing) :
                    new ObjectInspectorPage(new ObjectInspectorViewModel(), objToInspect));
                Navigation.PushAsync(page);
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.Message));
        }
    }
}