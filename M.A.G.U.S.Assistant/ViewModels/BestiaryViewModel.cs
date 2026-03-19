using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.Extensions;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class BestiaryViewModel : SearchListViewModel, IDisposable
{
    private readonly IShakeService? shakeService;

    public IShakeService? ShakeService => shakeService;

    public ICommand PickRandomCommand { get; }

    public ObservableCollection<TerrainType> AvailablePlaces { get; } = [];

    private TerrainType selectedPlace;

    public TerrainType SelectedPlace
    {
        get => selectedPlace;
        set
        {
            if (SetProperty(ref selectedPlace, value))
            {
                ApplyFilter();
            }
        }
    }

    public BestiaryViewModel(ISoundPlayer soundPlayer, IShakeService shakeService) : base(soundPlayer)
    {
        this.shakeService = shakeService;
        if (shakeService != null)
        {
            shakeService.ShakeDetected += OnShakeDetected;
        }
        PickRandomCommand = new RelayCommand(_ => PickRandomCreature());
        LoadAvailablePlaces();
        SelectedPlace = TerrainType.Anywhere;
    }

    private void PickRandomCreature()
    {
        SelectedItem = EnemyProvider.PickWeightedRandom(FilteredItems, c => (c.Source as Creature)?.Occurrence.GetWeight() ?? 0);
    }

    private void OnShakeDetected(object? sender, EventArgs e)
    {
        CommandExecutor.ExecuteOnUIThread(TriggerActionFromShake);
    }

    public void TriggerActionFromShake()
    {
        PickRandomCreature();
    }

    public void Dispose()
    {
        if (shakeService != null)
        {
            shakeService.ShakeDetected -= OnShakeDetected;
        }
    }

    public override void ApplyFilter()
    {
        if (isFiltering)
        {
            return;
        }

        if (!MainThread.IsMainThread)
        {
            MainThread.BeginInvokeOnMainThread(ApplyFilter);
            return;
        }

        try
        {
            isFiltering = true;
            var q = Items.AsEnumerable();
            var st = SearchText?.Trim();

            if (!String.IsNullOrWhiteSpace(st))
            {
                q = q.Where(i =>
                    (Lng.Elem(i.Title)?.IndexOf(st, StringComparison.InvariantCultureIgnoreCase) >= 0) ||
                    (Lng.Elem(i.Subtitle)?.IndexOf(st, StringComparison.InvariantCultureIgnoreCase) >= 0) ||
                    (Lng.Elem(i.Key)?.IndexOf(st, StringComparison.InvariantCultureIgnoreCase) >= 0));
            }

            if (SelectedCategory is ThingCategory thingCategory && thingCategory != ThingCategory.All)
            {
                q = q.Where(i => i.Source?.GetType().Namespace?.IndexOf(thingCategory.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0);
            }

            if (ShowOnlyAffordable && Character != null)
            {
                q = q.Where(i => i.Enabled);
            }

            if (SelectedPlace is TerrainType place && place != TerrainType.Unknown)
            {
                q = q.Where(i =>
                {
                    if (i.Source is not Creature creature)
                    {
                        return false;
                    }

                    if (place == TerrainType.Anywhere)
                    {
                        return true;
                    }

                    return creature.PlacesOfOccurrence.HasFlag(place);
                });
            }

            FilteredItems.Clear();
            foreach (var it in q)
            {
                FilteredItems.Add(it);
            }
        }
        finally
        {
            isFiltering = false;
        }
    }

    private void LoadAvailablePlaces()
    {
        var values = Enum
            .GetValues<TerrainType>()
            .OrderBy(x => Lng.Elem(x.GetDescription()));

        AvailablePlaces.Clear();
        foreach (var value in values)
        {
            AvailablePlaces.Add(value);
        }
    }
}