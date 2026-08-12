using MAGUS.Assistant.Models;
using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

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