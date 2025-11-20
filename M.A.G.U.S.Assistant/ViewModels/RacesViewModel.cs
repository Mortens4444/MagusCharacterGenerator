using M.A.G.U.S.Races;
using Mtf.Extensions;
using Mtf.LanguageService;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class RacesViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Race> Races { get; } = [];
    public ObservableCollection<Race> FilteredRaces { get; } = [];

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

    Race? _selectedRace;
    public Race? SelectedRace
    {
        get => _selectedRace;
        set
        {
            if (_selectedRace == value)
            {
                return;
            }

            _selectedRace = value;
            OnPropertyChanged(nameof(SelectedRace));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public RacesViewModel()
    {
        Seed();
        ApplyFilter();
    }

    private void Seed()
    {
        var races = "M.A.G.U.S.Races".CreateInstancesFromNamespace<Race>()
            .OrderBy(r => Lng.Elem(r.Name));

        Races.Clear();
        foreach (var race in races)
        {
            Races.Add(race);
        }
    }

    private void ApplyFilter()
    {
        var query = Races.AsEnumerable();
        var st = SearchText?.Trim();
        if (!String.IsNullOrWhiteSpace(st))
        {
            query = query.Where(r =>
                (r.Name?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0) ||
                (r.GetType().Name?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0))
                .OrderBy(r => Lng.Elem(r.Name));
        }

        FilteredRaces.Clear();
        foreach (var it in query)
        {
            FilteredRaces.Add(it);
        }
    }

    void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
