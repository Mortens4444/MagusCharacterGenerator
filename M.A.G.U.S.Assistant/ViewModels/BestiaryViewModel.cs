using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.Extensions;
using M.A.G.U.S.GameSystem.Places;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class BestiaryViewModel : SearchListViewModel, IDisposable
{
    private readonly IShakeService? shakeService;
    private bool includeAnywhere;
    private TerrainType selectedPlace;
    private BestiaryCategoryItem? selectedBestiaryCategory;
    private Country selectedCountry;

    public ObservableCollection<BestiaryCategoryItem> BestiaryCategories { get; } = [];
    public ObservableCollection<Country> AvailableCountries { get; } = [];

    public IShakeService? ShakeService => shakeService;

    public ICommand PickRandomCommand { get; }

    public ObservableCollection<TerrainType> AvailablePlaces { get; } = [];

    public BestiaryCategoryItem? SelectedBestiaryCategory
    {
        get => selectedBestiaryCategory;
        set
        {
            if (SetProperty(ref selectedBestiaryCategory, value))
            {
                ApplyFilter();
            }
        }
    }

    public Country SelectedCountry
    {
        get => selectedCountry;
        set
        {
            if (SetProperty(ref selectedCountry, value))
            {
                ApplyFilter();
            }
        }
    }

    public bool IncludeAnywhere
    {
        get => includeAnywhere;
        set
        {
            if (SetProperty(ref includeAnywhere, value))
            {
                ApplyFilter();
            }
        }
    }

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
        shakeService?.ShakeDetected += OnShakeDetected;
        PickRandomCommand = new RelayCommand(_ => PickRandomCreature());

        LoadAvailablePlaces();
        LoadBestiaryCategories();
        LoadAvailableCountries();

        //SelectedBestiaryCategory = BestiaryCategories[0];
        SelectedPlace = TerrainType.Anywhere;
        SelectedCountry = Country.Unknown;
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

            if (SelectedBestiaryCategory != null && !String.Equals(SelectedBestiaryCategory.Key, "All", StringComparison.OrdinalIgnoreCase))
            {
                q = q.Where(i =>
                {
                    var category = i.Source?.GetType().Namespace?.Split('.').LastOrDefault();
                    return String.Equals(category, SelectedBestiaryCategory.Key, StringComparison.OrdinalIgnoreCase);
                });
            }

            //if (SelectedCountry != Country.Unknown)
            //{
            //    q = q.Where(i =>
            //    {
            //        if (i.Source is not Creature creature)
            //        {
            //            return false;
            //        }

            //        //var matchesSelected = creature.Country.HasFlag(SelectedCountry);
            //        //var matchesAnywhere = creature.Country.HasFlag(Country.Anywhere);
            //        //return matchesSelected || matchesAnywhere;

            //        return creature.Country.HasFlag(SelectedCountry);
            //    });
            //}

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

                    var matchesSelected = creature.PlacesOfOccurrence.HasFlag(place);
                    //var matchesSelected = (creature.PlacesOfOccurrence & place) != 0;
                    if (!IncludeAnywhere)
                    {
                        return matchesSelected;
                    }

                    //var matchesAnywhere = creature.PlacesOfOccurrence.HasFlag(TerrainType.Anywhere);
                    var matchesAnywhere = (creature.PlacesOfOccurrence & TerrainType.Anywhere) != 0;
                    return matchesSelected || matchesAnywhere;
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

    public new void LoadItems(IEnumerable<DisplayItem> items)
    {
        base.LoadItems(items);
        LoadBestiaryCategories();
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

    private void LoadBestiaryCategories()
    {
        var categories = Items
            .OfType<DisplayItem>()
            .Select(i => i.Source?.GetType().Namespace?.Split('.').LastOrDefault())
            .Where(x => !String.IsNullOrWhiteSpace(x))
            .Distinct(StringComparer.InvariantCultureIgnoreCase)
            .OrderBy(x => Lng.Elem(x!) ?? x, StringComparer.InvariantCultureIgnoreCase)
            .Select(x => new BestiaryCategoryItem
            {
                Key = x!
            });

        BestiaryCategories.Clear();
        BestiaryCategories.Add(new BestiaryCategoryItem
        {
            Key = "All"
        });

        foreach (var category in categories)
        {
            BestiaryCategories.Add(category);
        }
    }

    private void LoadAvailableCountries()
    {
        var values = Enum
            .GetValues<Country>()
            .OrderBy(x => Lng.Elem(x.GetDescription()) ?? x.ToString(), StringComparer.InvariantCultureIgnoreCase);

        AvailableCountries.Clear();

        foreach (var value in values)
        {
            AvailableCountries.Add(value);
        }
    }
}