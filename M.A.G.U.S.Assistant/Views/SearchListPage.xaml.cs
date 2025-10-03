using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class SearchListPage : ContentPage
{
    private SearchListViewModel ViewModel => BindingContext as SearchListViewModel;

    public string PageTitle
    {
        get => Title ?? String.Empty;
        set => Title = value;
    }

    public string LabelText
    {
        get => String.Empty;
        set { /* placeholder for binding */ }
    }

    public SearchListPage(string title, IEnumerable<Models.DisplayItem> items)
    {
        InitializeComponent();
        Translator.Translate(this);
        PageTitle = title;
        ViewModel?.LoadItems(items);
    }
}