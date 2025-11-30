using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
internal partial class SearchListPage : NotifierPage
{
    public SearchListPage(SearchListViewModel viewModel, bool showAdvancedFilters, string title, IEnumerable<DisplayItem> items)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.ShowAdvancedFilters = showAdvancedFilters;
        Title = title;
        viewModel.LoadItems(items);
    }
}