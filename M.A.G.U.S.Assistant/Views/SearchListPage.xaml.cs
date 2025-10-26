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

    public SearchListPage(string title, IEnumerable<DisplayItem> items)
    {
        InitializeComponent();
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
                WeakReferenceMessenger.Default.Send(Lng.Elem("Select a creature first"));
            }

            var objToInspect = (object)selected;
            var page = (Page)(objToInspect is DisplayItem displayItem ?
                displayItem.Source is Creature creature ? 
                    new CreatureDetailsPage(creature) :
                    new ItemDetailsPage(displayItem.Source as Thing) :
                new ObjectInspectorPage(objToInspect));
            Navigation.PushAsync(page);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.Message));
        }
    }
}