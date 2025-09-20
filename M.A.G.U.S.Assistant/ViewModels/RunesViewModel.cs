using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.GameSystem.Runes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

public class RunesViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Rune> Runes { get; } = [];
    public ObservableCollection<Rune> FilteredRunes { get; } = [];

    string _searchText = String.Empty;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText == value)
                return;

            _searchText = value ?? String.Empty;
            OnPropertyChanged(nameof(SearchText));
            ApplyFilter();
        }
    }

    public ICommand ApplyFilterCommand { get; }
    public ICommand ClearFilterCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public RunesViewModel()
    {
        ApplyFilterCommand = new RelayCommand(_ => ApplyFilter());
        ClearFilterCommand = new RelayCommand(_ => ClearFilter());

        Seed();
        ApplyFilter();
    }

    private void Seed()
    {
        // Dinamikusan példányosítja a namespace összes Rune osztályát
        var runes = "M.A.G.U.S.GameSystem.Runes".CreateInstancesFromNamespace<Rune>()
            .OrderBy(r => r.Name);

        Runes.Clear();
        foreach (var rune in runes)
        {
            Runes.Add(rune);
        }
    }

    private void ApplyFilter()
    {
        var query = Runes.AsEnumerable();

        var st = SearchText?.Trim();
        if (!String.IsNullOrWhiteSpace(st))
        {
            query = query.Where(r =>
                (r.Name?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0) ||
                (r.Meaning?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0))
                .OrderBy(r => r.Name);
        }

        FilteredRunes.Clear();
        foreach (var rune in query)
        {
            FilteredRunes.Add(rune);
        }
    }

    private void ClearFilter()
    {
        SearchText = String.Empty;
        ApplyFilter();
    }

    private void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
