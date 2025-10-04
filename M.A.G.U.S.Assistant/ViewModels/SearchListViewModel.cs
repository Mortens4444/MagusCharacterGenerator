using M.A.G.U.S.Assistant.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

public class SearchListViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<DisplayItem> Items { get; } = new ObservableCollection<DisplayItem>();
    public ObservableCollection<DisplayItem> FilteredItems { get; } = new ObservableCollection<DisplayItem>();

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

    private string pageTitle = String.Empty;
    public string PageTitle
    {
        get => pageTitle;
        set
        {
            if (pageTitle == value) return;
            pageTitle = value ?? String.Empty;
            OnPropertyChanged(nameof(PageTitle));
        }
    }

    DisplayItem? selectedItem;
    public DisplayItem? SelectedItem
    {
        get => selectedItem;
        set
        {
            if (selectedItem == value)
            {
                return;
            }

            selectedItem = value;
            OnPropertyChanged(nameof(SelectedItem));
        }
    }

    public ICommand SelectCommand { get; }
    public ICommand ClearCommand { get; }

    public SearchListViewModel()
    {
        SelectCommand = new RelayCommand(o =>
        {
            if (o is DisplayItem di)
            {
                SelectedItem = di;
            }
        });

        ClearCommand = new RelayCommand(_ =>
        {
            SearchText = String.Empty;
        });
    }

    public void LoadItems(IEnumerable<DisplayItem> items)
    {
        Items.Clear();
        foreach (var it in items)
        {
            Items.Add(it);
        }

        ApplyFilter();
    }

    public void ApplyFilter()
    {
        var q = Items.AsEnumerable();
        var st = SearchText?.Trim();
        if (!String.IsNullOrWhiteSpace(st))
        {
            q = q.Where(i =>
                (i.Title?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0) ||
                (i.Subtitle?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0) ||
                (i.Key?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0));
        }

        FilteredItems.Clear();
        foreach (var it in q)
        {
            FilteredItems.Add(it);
        }
    }

    void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}