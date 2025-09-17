using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

public class MarketItem
{
    public string Name { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public string ImageName { get; set; } = "market";
    public string Description { get; set; } = String.Empty;
    public string PriceString => $"{Price:0.##} Ft";
}

public class MarketViewModel : INotifyPropertyChanged
{
    public ObservableCollection<MarketItem> Items { get; } = new ObservableCollection<MarketItem>();
    public ObservableCollection<MarketItem> FilteredItems { get; } = new ObservableCollection<MarketItem>();

    string _searchText = String.Empty;
    public string SearchText
    {
        get => _searchText;
        set { _searchText = value; OnPropertyChanged(nameof(SearchText)); }
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
        var sample = new[]
        {
            new MarketItem { Name = "Alma", Price = 120, Description = "Édes alma", ImageName = "apple" },
            new MarketItem { Name = "Kenyér", Price = 420, Description = "Friss kenyér", ImageName = "bread" },
            new MarketItem { Name = "Tej", Price = 350, Description = "1L tej", ImageName = "milk" },
            new MarketItem { Name = "Sajt", Price = 1890, Description = "Gouda", ImageName = "cheese" },
        };

        foreach (var it in sample) Items.Add(it);
    }

    void ApplyFilter()
    {
        decimal? min = ParseDecimal(MinPriceText);
        decimal? max = ParseDecimal(MaxPriceText);
        var query = Items.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            var st = SearchText.Trim();
            query = query.Where(i => i.Name.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                                     i.Description.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        if (min.HasValue) query = query.Where(i => i.Price >= min.Value);
        if (max.HasValue) query = query.Where(i => i.Price <= max.Value);

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

    decimal? ParseDecimal(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return null;
        return decimal.TryParse(s.Trim(), out var d) ? (decimal?)d : null;
    }

    void OnItemSelected(MarketItem? item)
    {
        if (item == null) return;
        // itt navigálhatsz, vagy más UI műveletet hajthatsz végre
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

// Egyszerű RelayCommand
public class RelayCommand : ICommand
{
    readonly Action<object?> _execute;
    readonly Func<object?, bool>? _canExecute;

    public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;
    public void Execute(object? parameter) => _execute(parameter);
    public event EventHandler? CanExecuteChanged;
    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
