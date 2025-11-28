using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
internal partial class SearchListPage : NotifierPage
{
    public SearchListPage(SearchListViewModel viewModel, string title, IEnumerable<DisplayItem> items)
    {
        InitializeComponent();
        BindingContext = viewModel;
        Title = title;
        viewModel.LoadItems(items);
    }
}