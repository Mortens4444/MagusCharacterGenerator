using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Bestiary;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Models;

namespace M.A.G.U.S.Assistant.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class SearchListPage : NotifierPage
{
    private SearchListViewModel ViewModel => BindingContext as SearchListViewModel;

    public SearchListPage(string title, IEnumerable<DisplayItem> items)
    {
        InitializeComponent();
        Title = title;
        ViewModel?.LoadItems(items);
    }

    void OnDetailsClicked(object sender, EventArgs e)
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
                new CreatureDetailsPage(displayItem.Source as Creature) :
                new ObjectInspectorPage(objToInspect));
            Navigation.PushAsync(page);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.Message));
        }
    }
}