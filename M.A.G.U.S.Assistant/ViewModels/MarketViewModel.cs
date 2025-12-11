using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Things;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class MarketViewModel : INotifyPropertyChanged
{
    public ObservableCollection<MarketItem> Items { get; } = [];

    public ObservableCollection<MarketItem> FilteredItems { get; } = [];

    string searchText = String.Empty;
    public string SearchText
    {
        get => searchText;
        set
        {
            if (searchText == value)
            {
                return;
            }

            searchText = value ?? String.Empty;
            OnPropertyChanged(nameof(SearchText));
            ApplyFilter();
        }
    }

    public ICommand ApplyFilterCommand { get; }
    public ICommand ClearFilterCommand { get; }
    public ICommand ItemSelectedCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public MarketViewModel()
    {
        ApplyFilterCommand = new RelayCommand(_ => ApplyFilter());
        ClearFilterCommand = new RelayCommand(_ => ClearFilter());
        ItemSelectedCommand = new RelayCommand(o => OnItemSelected(o as MarketItem));

        Seed();
        ApplyFilter();
    }

    private void Seed()
    {
        var things = "M.A.G.U.S.Things".CreateInstancesFromNamespace<Thing>();
        var marketItems = things.Select(t => new MarketItem(t))
            .OrderBy(t => t.Name);

        Items.Clear();
        foreach (var marketItem in marketItems)
        {
            Items.Add(marketItem);
        }
    }

    private void ApplyFilter()
    {
        var query = Items.AsEnumerable();

        var st = SearchText?.Trim();
        if (!String.IsNullOrWhiteSpace(st))
        {
            query = query.Where(i => Lng.Elem(i.Name)?.IndexOf(st, StringComparison.InvariantCultureIgnoreCase) >= 0)
                .OrderBy(i => Lng.Elem(i.Name));
        }

        FilteredItems.Clear();
        foreach (var it in query)
        {
            FilteredItems.Add(it);
        }
    }

    private void ClearFilter()
    {
        SearchText = String.Empty;
        ApplyFilter();
    }

    private static void OnItemSelected(MarketItem? item)
    {
        if (item == null)
        {
            return;
        }
    }

    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}