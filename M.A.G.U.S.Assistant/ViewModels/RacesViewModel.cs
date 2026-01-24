using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Races;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class RacesViewModel : BaseViewModel
{
    public ObservableCollection<Race> Races { get; } = [];
    public ObservableCollection<Race> FilteredRaces { get; } = [];

    private string searchText = String.Empty;
    private AsyncRelayCommand? previewImageCommand;

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
            OnPropertyChanged();
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
            OnPropertyChanged();
        }
    }

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
            query = query.Where(r => Lng.Elem(r.Name)?.IndexOf(st, StringComparison.InvariantCultureIgnoreCase) >= 0).OrderBy(r => Lng.Elem(r.Name));
        }

        FilteredRaces.Clear();
        foreach (var it in query)
        {
            FilteredRaces.Add(it);
        }
    }

    public IAsyncRelayCommand PreviewImageCommand => previewImageCommand ??= new AsyncRelayCommand(PreviewImage);

    private Task PreviewImage()
    {
        return ImagePreviewService.ShowAsync(SelectedRace?.DefaultImage);
    }

    [RelayCommand]
    private void SelectNextRace()
    {
        if (SelectedRace == null || FilteredRaces.Count <= 1)
        {
            return;
        }

        var currentIndex = FilteredRaces.IndexOf(SelectedRace);
        if (currentIndex < FilteredRaces.Count - 1)
        {
            SelectedRace = FilteredRaces[currentIndex + 1];
        }
    }

    [RelayCommand]
    private void SelectPreviousRace()
    {
        if (SelectedRace == null || FilteredRaces.Count <= 1)
        {
            return;
        }

        var currentIndex = FilteredRaces.IndexOf(SelectedRace);
        if (currentIndex > 0)
        {
            SelectedRace = FilteredRaces[currentIndex - 1];
        }
    }
}
