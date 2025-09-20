using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Things;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

public class MarketViewModel : INotifyPropertyChanged
{
    public ObservableCollection<MarketItem> Items { get; } = [];
    public ObservableCollection<MarketItem> FilteredItems { get; } = [];

    string _searchText = String.Empty;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText == value)
            {
                return;
            }

            _searchText = value ?? String.Empty;
            OnPropertyChanged(nameof(SearchText));
            ApplyFilter();
        }
    }

    public string MinPriceText { get; set; } = String.Empty;
    public string MaxPriceText { get; set; } = String.Empty;

    public ICommand ApplyFilterCommand { get; }
    public ICommand ClearFilterCommand { get; }
    public ICommand ItemSelectedCommand { get; }

    public MarketViewModel()
    {
        ApplyFilterCommand = new RelayCommand(_ => ApplyFilter());
        ClearFilterCommand = new RelayCommand(_ => ClearFilter());
        ItemSelectedCommand = new RelayCommand(o => OnItemSelected(o as MarketItem));

        Seed();
        ApplyFilter();
    }

    void Seed()
    {
        var things = "M.A.G.U.S.Things".CreateInstancesFromNamespace<Thing>();
        var marketItems = things.Select(t => new MarketItem(t));

        foreach (var marketItem in marketItems)
        {
            Items.Add(marketItem);
        }
    }

    void ApplyFilter()
    {
        var query = Items.AsEnumerable();

        var st = SearchText?.Trim();
        if (!String.IsNullOrWhiteSpace(st))
        {
            query = query.Where(i => i.Name?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        FilteredItems.Clear();
        foreach (var it in query) FilteredItems.Add(it);
    }

    void ClearFilter()
    {
        SearchText = String.Empty;
        MinPriceText = String.Empty;
        MaxPriceText = String.Empty;
        ApplyFilter();
        OnPropertyChanged(nameof(MinPriceText));
        OnPropertyChanged(nameof(MaxPriceText));
    }

    void OnItemSelected(MarketItem? item)
    {
        if (item == null)
        {
            return;
        }
        // itt navigálhatsz, vagy más UI műveletet hajthatsz végre
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}