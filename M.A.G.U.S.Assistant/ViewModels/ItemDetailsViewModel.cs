using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.CustomEventArgs;
using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Enums;
using M.A.G.U.S.Extensions;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.PoisonsAndIllnesses;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Things;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.MagicalObjects;
using M.A.G.U.S.Things.Shields;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class ItemDetailsViewModel : BaseViewModel
{
    private Thing? selectedRuneTarget;
    private AsyncRelayCommand? previewImageCommand;

    public ItemDetailsViewModel(Character? character, Thing thingToBuy, double priceMultiplier)
    {
        ThingToBuy = thingToBuy;
        IsBuyButtonVisible = character != null && character.Money >= thingToBuy.MultipliedPrice;

        if (character != null)
        {
            Type targetType;
            if (thingToBuy is RuneArmor)
            {
                targetType = typeof(Armor);
            }
            else if (thingToBuy is RuneSword)
            {
                targetType = typeof(IMeleeWeapon);
            }
            else
            {
                targetType = typeof(Thing);
            }

            var targets = character.Equipment.Where(e => targetType.IsAssignableFrom(e.GetType())).ToList();

            foreach (var item in targets)
            {
                item.PriceMultiplier = priceMultiplier;
                RuneTargets.Add(item);
            }

            IsRunecraftingVisible = RuneTargets.Any() && (thingToBuy is RuneArmor || thingToBuy is RuneSword);
            SelectedRuneTarget = RuneTargets.FirstOrDefault();
        }
        else
        {
            IsRunecraftingVisible = false;
        }

        Name = thingToBuy.Name;
        Description = thingToBuy.Description;
        Money = (SelectedRuneTarget != null ? SelectedRuneTarget.MultipliedPrice * 2 : thingToBuy.MultipliedPrice).ToTranslatedString();
        Weight = thingToBuy.Weight;
        DefaultImage = thingToBuy.DefaultImage;

        BuyCommand = new RelayCommand(() =>  OnPurchased(ThingToBuy));
        CloseCommand = new RelayCommand(() => OnClosed());
    }

    public Shield? Shield => ThingToBuy as Shield;
    public Armor? Armor => ThingToBuy as Armor;
    public string ProtectedMainPlacesText => Armor?.ProtectedMainPlaces.ToLocalizedString() ?? String.Empty;
    public IWeapon? Weapon => ThingToBuy as IWeapon;
    public IMeleeWeapon? MeleeWeapon => ThingToBuy as IMeleeWeapon;
    public IRangedWeapon? RangedWeapon => ThingToBuy as IRangedWeapon;
    public Poison? Poison => ThingToBuy as Poison;
    public PoisonDuration? Duration => Poison?.PoisonDuration;
    public PoisonOnsetTime? OnsetTime => Poison?.PoisonOnsetTime;
    public PoisonType? PoisonType => Poison?.PoisonType;
    public string PoisonDurationText => Lng.Elem(Duration?.GetDescription() ?? String.Empty);
    public string PoisonOnsetTimeText => Lng.Elem(OnsetTime?.GetDescription() ?? String.Empty);
    public string PoisonTypeText => Lng.Elem(PoisonType?.GetDescription() ?? String.Empty);
    public string PoisonOnsetDisplay => OnsetTime == null ? String.Empty : $"{OnsetTime.GetDescription()}{FormatDice(OnsetTime?.GetDiceFormula())}";
    public string PoisonDurationDisplay => Duration == null ? String.Empty : $"{Duration.GetDescription()}{FormatDice(Duration?.GetDiceFormula())}";
    private static string FormatDice(string? dice) => String.IsNullOrWhiteSpace(dice) ? String.Empty : $" ({dice})";
    public int? PoisonLevel => Poison?.Level;
    public bool IsPoison => Poison != null;
    public bool IsShield => Shield != null;
    public bool IsArmor => Armor != null;
    public bool IsWeapon => Weapon != null && !IsShield;
    public bool IsMelee => MeleeWeapon != null;
    public bool IsRanged => RangedWeapon != null;
    public bool IsBuyButtonVisible { get; init; }
    public string Name { get; } = String.Empty;
    public string Description { get; } = String.Empty;
    public string DefaultImage { get; } = String.Empty;
    public string Money { get; set; } = String.Empty;
    public double Weight { get; }
    public Thing ThingToBuy { get; private set; }
    public bool IsRunecraftingVisible { get; }

    public ICommand BuyCommand { get; }
    public ICommand CloseCommand { get; }

    public event EventHandler<ThingPurchasedEventArgs>? Purchased;
    public event EventHandler? Closed;

    public string WeaponDamage => Weapon?.DamageFormula?.GetDisplayFormula() ?? String.Empty;

    public Thing? SelectedRuneTarget
    {
        get => selectedRuneTarget;
        set
        {
            if (SetProperty(ref selectedRuneTarget, value))
            {
                OnSelectedRuneTargetChanged();
            }
        }
    }

    public ObservableCollection<Thing> RuneTargets { get; } = [];

    protected virtual void OnPurchased(Thing thing)
    {
        Purchased?.Invoke(this, new ThingPurchasedEventArgs(thing));
    }

    protected virtual void OnClosed()
    {
        Closed?.Invoke(this, EventArgs.Empty);
    }

    private void OnSelectedRuneTargetChanged()
    {
        Money = (SelectedRuneTarget!.MultipliedPrice * 2).ToTranslatedString();
        OnPropertyChanged(nameof(Money));
    }

    public IAsyncRelayCommand PreviewImageCommand => previewImageCommand ??= new AsyncRelayCommand(PreviewImage);

    private Task PreviewImage()
    {
        return ImagePreviewService.ShowAsync(DefaultImage);
    }
}
