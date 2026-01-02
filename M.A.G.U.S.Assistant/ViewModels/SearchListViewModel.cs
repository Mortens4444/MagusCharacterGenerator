using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.CustomEventArgs;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Views;
using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Things;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class SearchListViewModel : BaseViewModel
{
    private Character? character;
    private bool showOnlyAffordable = false;
    private string searchText = String.Empty;
    private double priceMultiplier = 1.0;
    private string categoryFilter = String.Empty;
    private string pageTitle = String.Empty;
    private DisplayItem? selectedItem;
    private CancellationTokenSource? filterCancellationTokenSource;

    private ISoundPlayer soundPlayer;

    public SearchListViewModel(ISoundPlayer soundPlayer)
    {
        this.soundPlayer = soundPlayer;
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

        Character = null;
        PriceMultiplier = 1.0;

        SetCategories();
    }

    public ICommand SelectCommand { get; }
    public ICommand ClearCommand { get; }

    public ObservableCollection<DisplayItem> Items { get; } = [];

    public ObservableCollection<DisplayItem> FilteredItems { get; } = [];
    
    public bool IsCharacterSet => Character != null && ShowAdvancedFilters;

    public ObservableCollection<ThingCategory> Categories { get; set; }

    public bool ShowAdvancedFilters
    {
        get => showAdvancedFilters;
        set
        {
            if (showAdvancedFilters == value)
            {
                return;
            }

            showAdvancedFilters = value;
            OnPropertyChanged();
        }
    }

    private ThingCategory selectedCategory = ThingCategory.All;
    private bool showAdvancedFilters;

    public ThingCategory SelectedCategory
    {
        get => selectedCategory;
        set
        {
            if (selectedCategory == value)
            {
                return;
            }

            selectedCategory = value;
            OnPropertyChanged();
            ApplyFilter();
        }
    }

    public Character? Character
    {
        get => character;
        set
        {
            if (character == value)
            {
                return;
            }

            character = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsCharacterSet));
            DebounceApplyFilter();
        }
    }

    public string CategoryFilter
    {
        get => categoryFilter;
        set
        {
            if (categoryFilter == value)
            {
                return;
            }

            categoryFilter = value ?? String.Empty;
            OnPropertyChanged();
            ApplyFilter();
        }
    }

    public double PriceMultiplier
    {
        get => priceMultiplier;
        set
        {
            var newValue = Math.Max(0.0, value);
            if (Math.Abs(priceMultiplier - newValue) < 0.001)
            {
                return;
            }

            priceMultiplier = newValue;
            OnPropertyChanged();

            RefreshAllItems();
            DebounceApplyFilter();
        }
    }

    public bool ShowOnlyAffordable
    {
        get => showOnlyAffordable;
        set
        {
            if (showOnlyAffordable == value)
            {
                return;
            }

            showOnlyAffordable = value;
            OnPropertyChanged();
            DebounceApplyFilter();
        }
    }

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
            DebounceApplyFilter();
        }
    }

    public string PageTitle
    {
        get => pageTitle;
        set
        {
            if (pageTitle == value)
            {
                return;
            }

            pageTitle = value ?? String.Empty;
            OnPropertyChanged();
        }
    }

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
            OnPropertyChanged();

            if (selectedItem != null)
            {
                _ = OpenDetailsAsync(selectedItem);
            }
        }
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

        FilteredItems.Clear();
        foreach (var it in q)
        {
            FilteredItems.Add(it);
        }
    }

    private async Task OpenDetailsAsync(DisplayItem item)
    {
        try
        {
            var mainPage = Application.Current != null && Application.Current.Windows.Count > 0 ? Application.Current.Windows[0].Page : null;
            if (mainPage?.Navigation != null)
            {
                Page page;
                if (item.Source is Creature creature)
                {
                    page = new CreatureDetailsPage(new CreatureDetailsViewModel(soundPlayer, creature));
                }
                else if (item.Source is Thing thing)
                {
                    var itemDetailsViewModel = new ItemDetailsViewModel(Character, thing, PriceMultiplier);
                    itemDetailsViewModel.Purchased += PurchaseHandler;
                    page = new ItemDetailsPage(itemDetailsViewModel);
                }
                else
                {
                    page = new ObjectObserverPage(new ObjectObserverViewModel(), item);
                }
                SelectedItem = null;
                await mainPage.Navigation.PushAsync(page).ConfigureAwait(true);
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private void PurchaseHandler(object? s, ThingPurchasedEventArgs args)
    {
        try
        {
            Character?.Buy(args.Thing);
            ApplyFilter();
            var mainPage = Application.Current != null && Application.Current.Windows.Count > 0 ? Application.Current.Windows[0].Page : null;
            mainPage?.Navigation.PopAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private Task DebounceApplyFilter()
    {
        filterCancellationTokenSource?.Cancel();
        filterCancellationTokenSource = new CancellationTokenSource();
        var token = filterCancellationTokenSource.Token;

        return Task.Delay(300, token)
            .ContinueWith(t =>
            {
                if (t.IsCanceled)
                {
                    return;
                }

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ApplyFilter();
                });
            }, token, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void RefreshAllItems()
    {
        if (Items == null)
        {
            return;
        }

        foreach (var item in Items.OfType<DisplayItem>())
        {
            if (item.Source is Thing thing)
            {
                thing.PriceMultiplier = PriceMultiplier;
                item.OnPropertyChanged(nameof(DisplayItem.RightText));
                item.OnPropertyChanged(nameof(DisplayItem.Enabled));
            }
        }
    }

    private void SetCategories()
    {
        var values = Enum.GetValues<ThingCategory>();

        var ordered = values
            .Where(v => v != ThingCategory.All)
            .OrderBy(v =>
            {
                var desc = v.GetType()
                            .GetField(v.ToString())?
                            .GetCustomAttribute<DescriptionAttribute>()?
                            .Description ?? v.ToString();

                var translated = Lng.Elem(desc);
                return translated ?? desc;
            })
            .ToList();

        ordered.Insert(0, ThingCategory.All);

        Categories = new ObservableCollection<ThingCategory>(ordered);
    }
}