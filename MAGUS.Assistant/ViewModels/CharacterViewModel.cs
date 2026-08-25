using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MAGUS.Assistant.Extensions;
using MAGUS.Assistant.Interfaces;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.Views;
using MAGUS.Enums;
using MAGUS.Extensions;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Languages;
using MAGUS.GameSystem.Magic;
using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Psi;
using MAGUS.GameSystem.Qualifications;
using MAGUS.GameSystem.Quests;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;
using MAGUS.Models;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Scientific;
using MAGUS.Services;
using MAGUS.Things;
using MAGUS.Things.Animals;
using MAGUS.Things.Armors;
using MAGUS.Things.Weapons;
using Mtf.Extensions;
using Mtf.Extensions.Services;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Messages;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;

namespace MAGUS.Assistant.ViewModels;

internal partial class CharacterViewModel(IPrintService printService, ISoundPlayer soundPlayer, IShakeService shakeService, ISettings settings, CharacterService characterService, SettingsService settingsService, IRuneTranslator runeTranslator, GameEventService gameEventService) : BaseViewModel, IDisposable
{
    private readonly IRuneTranslator runeTranslator = runeTranslator;
    private readonly GameEventService gameEventService = gameEventService;
    private string runePlainText = String.Empty;
    private string runeCipherText = String.Empty;
    private bool isUpdatingRuneText;

    private CombatValueModifier selectedCombatValueModifier;
    private Character? character;
    private INotifyCollectionChanged? subscribedEquipment;
    private Weapon? primaryWeapon;
    private Weapon? secondaryWeapon;
    private Armor? selectedArmor;
    private View? currentView;
    private readonly Dictionary<string, View> viewCache = [];
    private readonly IPrintService printService = printService;
    private readonly ISettings settings = settings;
    private readonly IShakeService shakeService = shakeService;
    private readonly ISoundPlayer soundPlayer = soundPlayer;
    protected readonly CharacterService characterService = characterService;
    private readonly SettingsService settingsService = settingsService;
    private static readonly IEnumerable<Alignment> alignments = [.. Enum.GetValues<Alignment>()];
    public IEnumerable<Alignment> Alignments => alignments;

    private static readonly IEnumerable<Deity> deities = [.. Enum.GetValues<Deity>()];
    public IEnumerable<Deity> Deities => deities;

    private static readonly IEnumerable<City> cities = [.. Enum.GetValues<City>().Where(c => c != City.Unknown)];
    public IEnumerable<City> Cities => cities;

    public ObservableCollection<CombatValueModifier> AvailableCombatValueModifiers { get; } = [.. Enum.GetValues<CombatValueModifier>()];

    public ObservableCollection<IWeapon> AvailableWeapons { get; } = [];

    public ObservableCollection<Armor> AvailableArmors { get; } = [];

    public CombatValueModifier SelectedCombatValueModifier
    {
        get => selectedCombatValueModifier;
        set
        {
            if (SetProperty(ref selectedCombatValueModifier, value))
            {
                Character?.SelectedCombatValueModifier = value;
                OnPropertyChanged(nameof(Damage));
            }
        }
    }

    public int AllocatedToInitiate => Character?.AllocatedToInitiate ?? 0;

    public int AllocatedToAttack => Character?.AllocatedToAttack ?? 0;

    public int AllocatedToDefense => Character?.AllocatedToDefense ?? 0;

    public int AllocatedToAim => Character?.AllocatedToAim ?? 0;

    public int AllocatedToInitiateMax => Character?.AllocatedToInitiateMax ?? 0;

    public int AllocatedToAttackMax => Character?.AllocatedToAttackMax ?? 0;

    public int AllocatedToDefenseMax => Character?.AllocatedToDefenseMax ?? 0;

    public int AllocatedToAimMax => Character?.AllocatedToAimMax ?? 0;

    public Weapon? PrimaryWeapon
    {
        get => primaryWeapon;
        set
        {
            if (SetProperty(ref primaryWeapon, value))
            {
                Character?.PrimaryWeapon = value;
            }
        }
    }

    public Weapon? SecondaryWeapon
    {
        get => secondaryWeapon;
        set
        {
            if (SetProperty(ref secondaryWeapon, value))
            {
                Character?.SecondaryWeapon = value;
            }
        }
    }

    public Armor? SelectedArmor
    {
        get => selectedArmor;
        set
        {
            if (SetProperty(ref selectedArmor, value))
            {
                Character?.Armor = value;
            }
        }
    }

    public Character? Character
    {
        get => character;
        protected set
        {
            if (character == value)
            {
                return;
            }

            if (subscribedEquipment != null)
            {
                subscribedEquipment.CollectionChanged -= Equipment_CollectionChanged;
                subscribedEquipment = null;
            }

            if (character != null)
            {
                character.PropertyChanged -= Character_PropertyChanged;
            }

            var arrivingAt = value is { IsTraveling: true, TravelProgress: >= 1 } ? value.TravelDestination : null;
            var finishedSleepHours = value is { IsSleeping: true, SleepProgress: >= 1 } ? value.SleepDurationHours : (double?)null;
            value?.CompleteTravelIfArrived();
            value?.ApplyElapsedHungerDecay();
            value?.ApplyElapsedSleepDecay();
            // Hunger keeps decaying during sleep, so reopening the app after enough real time has
            // passed can find a still-in-progress sleep (finishedSleepHours null) where hunger has
            // since dropped critical - same threshold as IsHungerCritical. See RefreshLiveProgress for
            // the equivalent live-page check.
            var interruptedByHunger = finishedSleepHours == null && value is { IsSleeping: true, HungerPercent: < 10 };
            // Don't re-announce waypoints already behind this character when their journey was already
            // in progress before this load (e.g. reopening the app mid-journey) - see RefreshLiveProgress.
            lastNotifiedTravelProgress = value?.TravelProgress ?? 0;
            SetProperty(ref character, value);

            if (value != null && arrivingAt is { } arrivedAt)
            {
                CompleteArrivalQuests(value, arrivedAt);
            }

            if (value != null && finishedSleepHours is { } sleptHours)
            {
                CompleteSleep(value, sleptHours);
            }
            else if (value != null && interruptedByHunger)
            {
                InterruptSleep(value, String.Format(Lng.Elem("Hunger wakes {0} up before a full night's rest."), value.Name));
            }

            if (value != null)
            {
                ExpireOverdueQuests(value);
            }

            if (character != null)
            {
                character.PropertyChanged += Character_PropertyChanged;
            }

            if (character?.Equipment is INotifyCollectionChanged nc)
            {
                subscribedEquipment = nc;
                subscribedEquipment.CollectionChanged += Equipment_CollectionChanged;
            }

            // AvailableWeapons/AvailableArmors (Picker ItemsSource) must be populated before
            // PrimaryWeapon/SecondaryWeapon/SelectedArmor (Picker SelectedItem) are set below -
            // otherwise the Picker's SelectedItem binding fires while ItemsSource is still empty,
            // can't find a match, and a later same-value re-notification is a no-op that never
            // retroactively re-selects it once ItemsSource does populate. This was showing as the
            // weapon/armor selection being "forgotten" every time the character reloads.
            RefillAvailableWeapons();
            RefillAvailableArmors();
            OnPropertyChanged(nameof(AvailableArmors));
            OnPropertyChanged(nameof(AvailableWeapons));

            SetProperty(ref selectedCombatValueModifier, value?.SelectedCombatValueModifier ?? MAGUS.Enums.CombatValueModifier.Base, nameof(SelectedCombatValueModifier));
            SetProperty(ref primaryWeapon, value?.PrimaryWeapon, nameof(PrimaryWeapon));
            SetProperty(ref secondaryWeapon, value?.SecondaryWeapon, nameof(SecondaryWeapon));
            SetProperty(ref selectedArmor, value?.Armor, nameof(SelectedArmor));

            OnPropertyChanged(nameof(PrimaryWeapon));
            OnPropertyChanged(nameof(SecondaryWeapon));

            OnPropertyChanged(nameof(Race));
            OnPropertyChanged(nameof(Class));
            OnPropertyChanged(nameof(Level));
            OnPropertyChanged(nameof(ExperiencePoints));
            OnPropertyChanged(nameof(CanLevelUp));
            OnPropertyChanged(nameof(PlayerCharacter));
            OnPropertyChanged(nameof(Alignment));
            OnPropertyChanged(nameof(Deity));
            OnPropertyChanged(nameof(Birthplace));
            OnPropertyChanged(nameof(CurrentLocation));
            OnPropertyChanged(nameof(TravelDestinations));
            OnPropertyChanged(nameof(AvailableQuestsHere));
            OnPropertyChanged(nameof(AcceptedQuests));
            OnPropertyChanged(nameof(SearchableQuestsHere));
            OnPropertyChanged(nameof(NegotiableQuestsHere));
            OnPropertyChanged(nameof(HealableQuestsHere));
            OnPropertyChanged(nameof(StealableQuestsHere));
            OnPropertyChanged(nameof(TrapSearchableQuestsHere));
            SetProperty(ref selectedTravelDestination, null, nameof(SelectedTravelDestination));
            OnPropertyChanged(nameof(IsTraveling));
            OnPropertyChanged(nameof(TravelProgress));
            OnPropertyChanged(nameof(TravelDestinationDescription));
            OnPropertyChanged(nameof(TravelWaypointsDescription));
            TravelCommand.NotifyCanExecuteChanged();
            StopTravelCommand.NotifyCanExecuteChanged();
            OnPropertyChanged(nameof(IsSleeping));
            OnPropertyChanged(nameof(SleepProgress));
            SleepCommand.NotifyCanExecuteChanged();
            StopSleepCommand.NotifyCanExecuteChanged();

            OnPropertyChanged(nameof(Strength));
            OnPropertyChanged(nameof(Stamina));
            OnPropertyChanged(nameof(Quickness));
            OnPropertyChanged(nameof(Dexterity));
            OnPropertyChanged(nameof(Health));
            OnPropertyChanged(nameof(Beauty));
            OnPropertyChanged(nameof(Willpower));
            OnPropertyChanged(nameof(Intelligence));
            OnPropertyChanged(nameof(Astral));
            OnPropertyChanged(nameof(Erudition));

            OnPropertyChanged(nameof(MaxHealthPoints));
            OnPropertyChanged(nameof(MaxPainTolerancePoints));
            OnPropertyChanged(nameof(PainToleranceModifierFormula));
            OnPropertyChanged(nameof(DeathCount));

            OnPropertyChanged(nameof(CanAllocateCombatModifier));
            OnPropertyChanged(nameof(MaxInitiateValue));
            OnPropertyChanged(nameof(InitiateValue));

            OnPropertyChanged(nameof(MaxAttackValue));
            OnPropertyChanged(nameof(AttackValue));

            OnPropertyChanged(nameof(MaxDefenseValue));
            OnPropertyChanged(nameof(DefenseValue));

            OnPropertyChanged(nameof(MaxAimValue));
            OnPropertyChanged(nameof(AimValue));
            
            OnPropertyChanged(nameof(RemainingCombatValueModifier));
            OnPropertyChanged(nameof(CombatValueModifierPerLevel));

            OnPropertyChanged(nameof(HasPsi));
            OnPropertyChanged(nameof(HasSorcery));
            OnPropertyChanged(nameof(HasMagic));
            OnPropertyChanged(nameof(HasRunicMagic));
            OnPropertyChanged(nameof(MaxPsiPoints));
            OnPropertyChanged(nameof(PsiPoints));
            OnPropertyChanged(nameof(PsiPointsModifier));
            BuildPsiShieldCommand.NotifyCanExecuteChanged();

            OnPropertyChanged(nameof(MaxManaPoints));
            OnPropertyChanged(nameof(ManaPoints));
            OnPropertyChanged(nameof(MaxManaPointsPerLevel));

            OnPropertyChanged(nameof(UnconsciousAstralMagicResistance));
            OnPropertyChanged(nameof(UnconsciousMentalMagicResistance));
            OnPropertyChanged(nameof(StaticAstralPsiShield));
            OnPropertyChanged(nameof(StaticMentalPsiShield));
            OnPropertyChanged(nameof(DynamicAstralPsiShield));
            OnPropertyChanged(nameof(DynamicMentalPsiShield));

            OnPropertyChanged(nameof(QualificationPoints));
            OnPropertyChanged(nameof(CanAllocateQualificationPoints));
            OnPropertyChanged(nameof(Qualifications));
            OnPropertyChanged(nameof(PercentQualifications));
            OnPropertyChanged(nameof(SpecialQualifications));

            OnPropertyChanged(nameof(Mithril));
            OnPropertyChanged(nameof(Gold));
            OnPropertyChanged(nameof(Silver));
            OnPropertyChanged(nameof(Copper));

            OnPropertyChanged(nameof(Damage));
            OnPropertyChanged(nameof(ArmorClass));
            OnPropertyChanged(nameof(ArmorCheckPenalty));

            OnPropertyChanged(nameof(Equipment));
            OnPropertyChanged(nameof(TotalEquipmentWeight));
            OnPropertyChanged(nameof(PortraitImage));

            OnPropertyChanged(nameof(HungerPercent));
            OnPropertyChanged(nameof(IsHungerCritical));
            OnPropertyChanged(nameof(SleepPercent));
            OnPropertyChanged(nameof(IsSleepCritical));

            SleepCommand.NotifyCanExecuteChanged();
            StopSleepCommand.NotifyCanExecuteChanged();
            EatCommand.NotifyCanExecuteChanged();
            CastSpellCommand.NotifyCanExecuteChanged();
            CastPsiCommand.NotifyCanExecuteChanged();
            HealCommand.NotifyCanExecuteChanged();
            SearchForTrapsCommand.NotifyCanExecuteChanged();
        }
    }

    private void Character_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(Character.ExperiencePoints):
                OnPropertyChanged(nameof(ExperiencePoints));
                OnPropertyChanged(nameof(CanLevelUp));
                LevelUpCommand.NotifyCanExecuteChanged();
                break;

            case nameof(Character.PendingLevelUps):
                OnPropertyChanged(nameof(CanLevelUp));
                LevelUpCommand.NotifyCanExecuteChanged();
                break;

            case nameof(Character.Level):
                OnPropertyChanged(nameof(Level));
                OnPropertyChanged(nameof(CanLevelUp));
                LevelUpCommand.NotifyCanExecuteChanged();
                break;

            case nameof(Character.CanAllocateCombatModifier):
                OnPropertyChanged(nameof(CanAllocateCombatModifier));
                break;

            case nameof(Character.RemainingCombatValueModifier):
                OnPropertyChanged(nameof(RemainingCombatValueModifier));
                OnPropertyChanged(nameof(CanAllocateCombatModifier));
                break;

            case nameof(Character.InitiateValue):
                OnPropertyChanged(nameof(InitiateValue));
                break;

            case nameof(Character.MinInitiateValue):
                OnPropertyChanged(nameof(MinInitiateValue));
                break;

            case nameof(Character.MaxInitiateValue):
                OnPropertyChanged(nameof(MaxInitiateValue));
                break;

            case nameof(Character.AttackValue):
                OnPropertyChanged(nameof(AttackValue));
                OnPropertyChanged(nameof(MaxAttackValue));
                break;

            case nameof(Character.MinAttackValue):
                OnPropertyChanged(nameof(MinAttackValue));
                break;

            case nameof(Character.MaxAttackValue):
                OnPropertyChanged(nameof(MaxAttackValue));
                break;

            case nameof(Character.DefenseValue):
                OnPropertyChanged(nameof(DefenseValue));
                OnPropertyChanged(nameof(MaxDefenseValue));
                break;

            case nameof(Character.MinDefenseValue):
                OnPropertyChanged(nameof(MinDefenseValue));
                break;

            case nameof(Character.MaxDefenseValue):
                OnPropertyChanged(nameof(MaxDefenseValue));
                break;

            case nameof(Character.AimValue):
                OnPropertyChanged(nameof(AimValue));
                OnPropertyChanged(nameof(MaxAimValue));
                break;

            case nameof(Character.MinAimValue):
                OnPropertyChanged(nameof(MinAimValue));
                break;

            case nameof(Character.MaxAimValue):
                OnPropertyChanged(nameof(MaxAimValue));
                break;

            case nameof(Character.Qualifications):
                OnPropertyChanged(nameof(Qualifications));
                OnPropertyChanged(nameof(QualificationPoints));
                break;

            case nameof(Character.Money):
                OnPropertyChanged(nameof(Mithril));
                OnPropertyChanged(nameof(Gold));
                OnPropertyChanged(nameof(Silver));
                OnPropertyChanged(nameof(Copper));
                break;

            case nameof(Character.Armor):
                OnPropertyChanged(nameof(ArmorClass));
                OnPropertyChanged(nameof(ArmorCheckPenalty));
                break;

            case nameof(Character.CurrentLocation):
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(TravelDestinations));
                OnPropertyChanged(nameof(AvailableQuestsHere));
                OnPropertyChanged(nameof(SearchableQuestsHere));
                OnPropertyChanged(nameof(NegotiableQuestsHere));
                OnPropertyChanged(nameof(HealableQuestsHere));
                OnPropertyChanged(nameof(StealableQuestsHere));
                OnPropertyChanged(nameof(TrapSearchableQuestsHere));
                break;

            case nameof(Character.HungerPercent):
                OnPropertyChanged(nameof(HungerPercent));
                OnPropertyChanged(nameof(IsHungerCritical));
                break;

            case nameof(Character.SleepPercent):
                OnPropertyChanged(nameof(SleepPercent));
                OnPropertyChanged(nameof(IsSleepCritical));
                break;

            case nameof(Character.ActualPainTolerancePoints):
            case nameof(Character.ActualHealthPoints):
                CastSpellCommand.NotifyCanExecuteChanged();
                CastPsiCommand.NotifyCanExecuteChanged();
                break;

            case nameof(Character.ManaPoints):
                OnPropertyChanged(nameof(ManaPoints));
                CastSpellCommand.NotifyCanExecuteChanged();
                break;

            case nameof(Character.PsiPoints):
                OnPropertyChanged(nameof(PsiPoints));
                CastPsiCommand.NotifyCanExecuteChanged();
                break;

            case nameof(Character.Equipment):
                OnPropertyChanged(nameof(Equipment));
                break;

            case nameof(Character.TotalEquipmentWeight):
                OnPropertyChanged(nameof(TotalEquipmentWeight));
                break;
        }
    }

    public string Race => Character?.RaceName ?? String.Empty;

    public string Class => Character?.Class ?? String.Empty;

    public int Level => Character?.Level ?? 1;

    public bool PlayerCharacter => Character?.PlayerCharacter ?? false;

    public ulong ExperiencePoints => Character?.BaseClass?.ExperiencePoints ?? 0;

    public Alignment Alignment
    {
        get
        {
            return Character?.Alignment ?? Alignment.Order;
        }
        set
        {
            if (Character != null && Character.Alignment != value)
            {
                Character.Alignment = value;
                OnPropertyChanged();
            }
        }
    }

    public Deity Deity
    {
        get
        {
            return Character?.Deity ?? Deity.Unbeliever;
        }
        set
        {
            if (Character != null && Character.Deity != value)
            {
                Character.Deity = value;
                OnPropertyChanged();
            }
        }
    }

    public City Birthplace
    {
        get
        {
            return Character?.Birthplace ?? City.Unknown;
        }
        set
        {
            if (Character != null && Character.Birthplace != value)
            {
                Character.Birthplace = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }
    }

    public City CurrentLocation => Character?.CurrentLocation ?? City.Unknown;

    // Materialized into a concrete array (like Cities itself) rather than left as a lazy .Where()
    // iterator - Picker.ItemsSource on Windows/WinUI doesn't reliably populate from a plain deferred
    // IEnumerable, which was showing as an empty dropdown despite this always having entries.
    public IEnumerable<City> TravelDestinations => [.. Cities.Where(c => c != CurrentLocation)];

    private City? selectedTravelDestination;
    public City? SelectedTravelDestination
    {
        get => selectedTravelDestination;
        set
        {
            if (SetProperty(ref selectedTravelDestination, value))
            {
                TravelCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public bool IsTraveling => Character?.IsTraveling ?? false;

    public double TravelProgress => Character?.TravelProgress ?? 0;

    public string TravelDestinationDescription => Character?.TravelDestination is { } destination ? Lng.Elem(destination.GetDescription()) : String.Empty;

    /// <summary>"Route passes near: X, Y (passed)" - the current journey's waypoint cities (see Character.TravelWaypoints), marking the ones already reached at the current TravelProgress. Empty when not traveling or there are none along the way.</summary>
    public string TravelWaypointsDescription
    {
        get
        {
            if (Character is not { IsTraveling: true } character)
            {
                return String.Empty;
            }

            var waypoints = character.TravelWaypoints;
            if (waypoints.Count == 0)
            {
                return String.Empty;
            }

            var progress = character.TravelProgress;
            var described = waypoints.Select(w => w.RouteFraction <= progress
                ? String.Format(Lng.Elem("{0} (passed)"), Lng.Elem(w.City.GetDescription()))
                : Lng.Elem(w.City.GetDescription()));

            return String.Format(Lng.Elem("Route passes near: {0}"), String.Join(", ", described));
        }
    }

    public int Strength => Character?.Strength ?? 0;
    public int Stamina => Character?.Stamina ?? 0;
    public int Quickness => Character?.Quickness ?? 0;
    public int Dexterity => Character?.Dexterity ?? 0;
    public int Health => Character?.Health ?? 0;
    public int Beauty => Character?.Beauty ?? 0;
    public int Willpower => Character?.Willpower ?? 0;
    public int Intelligence => Character?.Intelligence ?? 0;
    public int Astral => Character?.Astral ?? 0;
    public int Erudition => Character?.Erudition ?? 0;
    public int MaxHealthPoints => Character?.MaxHealthPoints ?? 0;
    public int MaxPainTolerancePoints => Character?.MaxPainTolerancePoints ?? 0;
    public int DeathCount => Character?.DeathCount ?? 0;

    public int ArmorClass => Character?.Armor?.ArmorClass ?? 0;
    public int ArmorCheckPenalty => Character?.Armor?.ArmorCheckPenalty ?? 0;

    public int RemainingCombatValueModifier => Character?.RemainingCombatValueModifier ?? 0;

    public string Damage
    {
        get
        {
            object[]? customAttributes;
            DiceThrowFormula? formula;
            if (Character?.PrimaryWeapon != null && Character.SelectedCombatValueModifier is MAGUS.Enums.CombatValueModifier.PrimaryWeapon or MAGUS.Enums.CombatValueModifier.PrimaryWeaponThrown)
            {
                customAttributes = Character.PrimaryWeapon.GetType().GetMethod(nameof(Character.PrimaryWeapon.GetDamage))?.GetCustomAttributes(false);
                formula = customAttributes.GetDiceThrowFormula();
                return formula?.GetDisplayFormula() ?? String.Empty;
            }
            if (Character?.SecondaryWeapon != null && Character.SelectedCombatValueModifier is MAGUS.Enums.CombatValueModifier.SecondaryWeapon or MAGUS.Enums.CombatValueModifier.SecondaryWeaponThrown)
            {
                customAttributes = Character.SecondaryWeapon.GetType().GetMethod(nameof(Character.SecondaryWeapon.GetDamage))?.GetCustomAttributes(false);
                formula = customAttributes.GetDiceThrowFormula();
                return formula?.GetDisplayFormula() ?? String.Empty;
            }

            customAttributes = Character?.GetType().GetMethod(nameof(Character.GetDamage))?.GetCustomAttributes(false);
            formula = customAttributes.GetDiceThrowFormula();
            return formula?.GetDisplayFormula() ?? String.Empty;
        }
    }
    
    public int CombatValueModifierPerLevel => Character?.CombatValueModifierPerLevel ?? 0;
    public bool CanAllocateCombatModifier => Character?.CanAllocateCombatModifier ?? false;

    public bool CanLevelUp => Character?.CanUpgrade ?? false; //Character?.PendingLevelUps > 0;

    public int MinInitiateValue => Character?.MinInitiateValue ?? 0;
    public int MaxInitiateValue => Character?.MaxInitiateValue ?? 0;
    public int InitiateValue => Character?.InitiateValue ?? 0;
    
    public int MinAttackValue => Character?.MinAttackValue ?? 0;
    public int MaxAttackValue => Character?.MaxAttackValue ?? 0;
    public int AttackValue => Character?.AttackValue ?? 0;
    
    public int MinDefenseValue => Character?.MinDefenseValue ?? 0;
    public int MaxDefenseValue => Character?.MaxDefenseValue ?? 0;
    public int DefenseValue => Character?.DefenseValue ?? 0;
    
    public int MinAimValue => Character?.MinAimValue ?? 0;
    public int MaxAimValue => Character?.MaxAimValue ?? 0;
    public int AimValue => Character?.AimValue ?? 0;

    public double HungerPercent => Character?.HungerPercent ?? 100;
    public bool IsHungerCritical => HungerPercent < 10;

    public double SleepPercent => Character?.SleepPercent ?? 100;
    public bool IsSleepCritical => SleepPercent < 10;

    public bool IsSleeping => Character?.IsSleeping ?? false;
    public double SleepProgress => Character?.SleepProgress ?? 0;

    public bool HasPsi => Character?.Psi != null;
    public bool HasSorcery => Character?.Sorcery != null;
    public bool HasMagic => Character?.Sorcery != null || Character?.Psi != null;
    public bool HasRunicMagic => Character?.HasRunicMagic() ?? false;
    public int MaxPsiPoints => Character?.MaxPsiPoints ?? 0;
    public int PsiPoints => Character?.PsiPoints ?? 0;
    public int PsiPointsModifier => Character?.PsiPointsModifier ?? 0;

    public string RunePlainText
    {
        get => runePlainText;
        set
        {
            if (runePlainText == value)
            {
                return;
            }

            runePlainText = value ?? String.Empty;
            OnPropertyChanged();

            if (isUpdatingRuneText)
            {
                return;
            }

            try
            {
                isUpdatingRuneText = true;
                RuneCipherText = runeTranslator.ToRunes(runePlainText);
            }
            finally
            {
                isUpdatingRuneText = false;
            }
        }
    }

    public string RuneCipherText
    {
        get => runeCipherText;
        set
        {
            if (runeCipherText == value)
            {
                return;
            }

            runeCipherText = value ?? String.Empty;
            OnPropertyChanged();

            if (isUpdatingRuneText)
            {
                return;
            }

            try
            {
                isUpdatingRuneText = true;
                RunePlainText = runeTranslator.ToPlain(runeCipherText);
            }
            finally
            {
                isUpdatingRuneText = false;
            }
        }
    }

    [RelayCommand]
    private async Task CopyRuneCipherTextAsync()
    {
        if (String.IsNullOrEmpty(RuneCipherText))
        {
            return;
        }

        await Clipboard.SetTextAsync(RuneCipherText).ConfigureAwait(false);
        WeakReferenceMessenger.Default.Send(new ShowInfoMessage(Lng.Elem("Copied"), Lng.Elem("Runes copied to clipboard")));
    }

    public int MaxManaPoints => Character?.MaxManaPoints ?? 0;
    public int ManaPoints => Character?.ManaPoints ?? 0;

    public string MaxManaPointsPerLevel
    {
        get
        {
            var formula = Character?.MaxManaPointsPerLevelFormula;
            return formula != null ? formula.GetDisplayFormula() : (Character?.MaxManaPointsPerLevel ?? 0).ToString(CultureInfo.InvariantCulture);
        }
    }

    public int UnconsciousAstralMagicResistance => Character?.UnconsciousAstralMagicResistance ?? 0;
    public int UnconsciousMentalMagicResistance => Character?.UnconsciousMentalMagicResistance ?? 0;
    public int StaticAstralPsiShield => Character?.StaticAstralPsiShield ?? 0;
    public int StaticMentalPsiShield => Character?.StaticMentalPsiShield ?? 0;
    public int DynamicAstralPsiShield => Character?.DynamicAstralPsiShield ?? 0;
    public int DynamicMentalPsiShield => Character?.DynamicMentalPsiShield ?? 0;

    public int QualificationPoints => Character?.QualificationPoints ?? 0;
    public bool CanAllocateQualificationPoints => Character?.CanAllocateQualificationPoints ?? false;
    public QualificationList Qualifications => Character?.Qualifications ?? [];
    public PercentQualificationList PercentQualifications => Character?.PercentQualifications ?? [];
    public SpecialQualificationList SpecialQualifications => Character?.SpecialQualifications ?? [];

    /// <summary>
    /// True only while a brand-new character is still being built (see
    /// CharacterGeneratorViewModel.CanReviseQualificationSelection) - QualificationsView.xaml uses this,
    /// together with Qualification.IsSelectable, to keep the "Choose" button revisitable during
    /// creation but lock it once the character has been saved, so a Weapon use/Weapon throwing/Ancient
    /// tongue lore/Language lore pick already made on a saved character can no longer be changed.
    /// </summary>
    public virtual bool CanReviseQualificationSelection => false;

    /// <summary>
    /// Fills in the Weapon/Language a class/race-granted qualification left unset (see
    /// Qualification.NeedsSelection) - unlike learning a brand-new qualification via
    /// QualificationDetailsViewModel, this mutates the character's own already-owned instance in
    /// place, which is safe here because Class.Qualifications/FutureQualifications hand out fresh
    /// per-character instances, never the shared PreloadService catalogue ones.
    /// </summary>
    [RelayCommand]
    private async Task SelectQualificationAttributeAsync(Qualification qualification)
    {
        if (Character is not { } character || qualification == null)
        {
            return;
        }

        try
        {
            string confirmation;

            switch (qualification)
            {
                case WeaponQualification wq:
                    var weapons = PreloadService.Instance.Weapons;
                    var weaponChoice = await ShellNavigationService.DisplayActionSheetAsync(
                        "Choose weapon",
                        "Cancel",
                        null,
                        [.. weapons.Select(w => w.Name)]).ConfigureAwait(true);

                    // DisplayActionSheetAsync translates each button label via Lng.Elem(), so the
                    // returned choice must be matched back the same way (see PickLanguageAsync below,
                    // which already does this) - comparing against the raw w.Name only matches by luck,
                    // whenever a given weapon happens to have no translation entry.
                    var weapon = weapons.FirstOrDefault(w => Lng.Elem(w.Name) == weaponChoice);
                    if (weapon == null)
                    {
                        return;
                    }

                    wq.Weapon = weapon;
                    confirmation = $"{qualification.Name}: {weapon.Name}";
                    break;

                case AncientTongueLore atl:
                    var ancientLanguage = await PickLanguageAsync(Enum.GetValues<AntientLanguage>()).ConfigureAwait(true);
                    if (ancientLanguage == null)
                    {
                        return;
                    }

                    atl.Language = ancientLanguage;
                    confirmation = $"{qualification.Name}: {Lng.Elem(ancientLanguage.Value.GetDescription())}";
                    break;

                case LanguageLore ll:
                    var language = await PickLanguageAsync(Enum.GetValues<Language>()).ConfigureAwait(true);
                    if (language == null)
                    {
                        return;
                    }

                    ll.Language = language;
                    confirmation = $"{qualification.Name}: {Lng.Elem(language.Value.GetDescription())}";
                    break;

                default:
                    return;
            }

            await characterService.SaveAsync(character).ConfigureAwait(true);

            // Qualification isn't INotifyPropertyChanged, so mutating Weapon/Language in place never
            // updates the "Choose" button's NeedsSelection binding - force the CollectionView to
            // re-realize this item's DataTemplate (and re-read NeedsSelection) via a real CollectionChanged.
            var index = character.Qualifications.IndexOf(qualification);
            if (index >= 0)
            {
                character.Qualifications.RemoveAt(index);
                character.Qualifications.Insert(index, qualification);
            }

            OnPropertyChanged(nameof(Qualifications));

            // Several classes grant multiple same-named ICanHaveMany slots at once (e.g. Warrior grants
            // three separate "Weapon use" entries) - before a weapon/language is picked they're all
            // labelled identically (see QualificationNameConverter), so without this confirmation a
            // successful save is indistinguishable from nothing having happened: the very next row
            // still reads "Weapon use - Choose", just for a different, still-empty slot.
            await ShellNavigationService.DisplayAlertAsync("Saved", confirmation).ConfigureAwait(true);
        }
        catch (Exception ex)
        {
            // SelectQualificationAttributeCommand is invoked as fire-and-forget from a Button.Command
            // binding, and MauiProgram's global TaskScheduler.UnobservedTaskException handler doesn't
            // show anything in-app (only logs/emails) - without this, a failure here is completely
            // silent: the "Choose" button just... does nothing, with no error and no clue why.
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private static async Task<TEnum?> PickLanguageAsync<TEnum>(TEnum[] values) where TEnum : struct, Enum
    {
        var choice = await ShellNavigationService.DisplayActionSheetAsync(
            "Choose language",
            "Cancel",
            null,
            [.. values.Select(v => Lng.Elem(v.GetDescription()))]).ConfigureAwait(true);

        if (choice == null)
        {
            return null;
        }

        var index = Array.FindIndex(values, v => Lng.Elem(v.GetDescription()) == choice);
        return index < 0 ? null : values[index];
    }


    public decimal Mithril => Character?.Money?.Mithril ?? 0;
    public decimal Gold => Character?.Money?.Gold ?? 0;
    public decimal Silver => Character?.Money?.Silver ?? 0;
    public decimal Copper => Character?.Money?.Copper ?? 0;
    
    public ObservableCollection<Thing> Equipment => Character?.Equipment ?? [];
    public string TotalEquipmentWeight => Character?.TotalEquipmentWeight ?? String.Empty;
    public string PortraitImage => Character?.RandomImage ?? String.Empty;

    public View? CurrentView
    {
        get
        {
            if (currentView == null)
            {
                ChangeTab("0");
            }
            return currentView;
        }
        set => SetProperty(ref currentView, value);
    }

    public string PainToleranceModifierFormula
    {
        get
        {
            var formula = Character?.BaseClass?.GetPainToleranceModifierFormula();
            return formula?.GetDisplayFormula() ?? String.Empty;
        }
    }

    [RelayCommand]
    public async Task DeleteEquipmentAsync(Thing thing)
    {
        if (thing == null || Character == null)
        {
            return;
        }

        var answer = await ShellNavigationService.DisplayAlertAsync(
                "Confirm delete",
                String.Format(Lng.Elem("Are you sure you want to delete '{0}'?"), Lng.Elem(thing.Name)),
                "Delete",
                "Cancel").ConfigureAwait(true);

        if (answer)
        {
            Character.RemoveEquipment(thing);
        }
    }

    [RelayCommand]
    public async Task SellItemAsync(Thing thing)
    {
        if (thing == null || Character == null)
        {
            return;
        }

        var price = thing.MultipliedPrice;
        var answer = await ShellNavigationService.DisplayAlertAsync(
            "Confirm sell",
            String.Concat(
                String.Format(Lng.Elem("Are you sure you want to sell '{0}'?"), Lng.Elem(thing.Name)),
                Environment.NewLine,
                $"{Lng.Elem("Selling price")}: {price.ToTranslatedString()}"
            ),
            "Sell",
            "Cancel").ConfigureAwait(true);

        if (answer)
        {
            Character.Sell(thing);
        }
    }

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void IncrementInitiator()
    {
        Character?.ChangeInitiator(1);
        ChangeCombatValueModifierButtonStates();
    }

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void DecrementInitiator()
    {
        Character?.ChangeInitiator(-1);
        ChangeCombatValueModifierButtonStates();
    }

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void IncrementAttack()
    {
        Character?.ChangeAttack(1);
        ChangeCombatValueModifierButtonStates();
    }

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void DecrementAttack()
    {
        Character?.ChangeAttack(-1);
        ChangeCombatValueModifierButtonStates();
    }

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void IncrementDefense()
    {
        Character?.ChangeDefense(1);
        ChangeCombatValueModifierButtonStates();
    }

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void DecrementDefense()
    {
        Character?.ChangeDefense(-1);
        ChangeCombatValueModifierButtonStates();
    }

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void IncrementAim()
    {
        Character?.ChangeAim(1);
        ChangeCombatValueModifierButtonStates();
    }

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void DecrementAim()
    {
        Character?.ChangeAim(-1);
        ChangeCombatValueModifierButtonStates();
    }

    [RelayCommand(CanExecute = nameof(CanLevelUp))]
    public async Task LevelUpAsync()
    {
        if (Character == null)
        {
            return;
        }
        
        try
        {
            int painIncrease;
            if (settings.AutoIncreasePainTolerance)
            {
                painIncrease = Character.BaseClass.GetPainToleranceModifier();
            }
            else
            {
                var painToleranceModifierFormula = Character.BaseClass.GetPainToleranceModifierFormula();
                var page = new RollFormulaPage(soundPlayer, shakeService, painToleranceModifierFormula, $"{Lng.Elem("Level up")} - {Lng.Elem("PTP")} ({Character.Level + 1}. {Lng.Elem("Level")})");
                await ShellNavigationService.ShowPageAsync(page).ConfigureAwait(true);
                painIncrease = await page.ResultTask.ConfigureAwait(true);
            }

            int manaIncrease = 0;

            if (Character.Sorcery != null)
            {
                var manaFormula = Character.MaxManaPointsPerLevelFormula;
                if (String.IsNullOrEmpty(manaFormula?.Formula))
                {
                    manaIncrease = Character.MaxManaPointsPerLevel;
                }
                else
                {
                    if (settings.AutoIncreaseManaPoints)
                    {
                        var magic = Character.BaseClass.SpecialQualifications.GetSpeciality<Sorcery>();
                        manaIncrease = magic != null ? magic.GetManaPointsModifier() : 0;
                    }
                    else
                    {
                        var page = new RollFormulaPage(soundPlayer, shakeService, manaFormula, $"{Lng.Elem("Level up")} - {Lng.Elem("Mana-points")} ({Character.Level + 1}. {Lng.Elem("Level")})");
                        await ShellNavigationService.ShowPageAsync(page).ConfigureAwait(true);
                        manaIncrease = await page.ResultTask.ConfigureAwait(true);
                    }
                }
            }

            Character.ApplyLevelUp(painIncrease, manaIncrease);
            OnPropertyChanged(String.Empty);

            OnPropertyChanged(nameof(Level));
            OnPropertyChanged(nameof(ExperiencePoints));
            OnPropertyChanged(nameof(CanLevelUp));

            LevelUpCommand.NotifyCanExecuteChanged();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            await ShellNavigationService.DisplayAlertAsync(ex.Message).ConfigureAwait(true);
        }
    }

    private void ChangeCombatValueModifierButtonStates()
    {
        OnPropertyChanged(nameof(MaxInitiateValue));
        OnPropertyChanged(nameof(MaxAttackValue));
        OnPropertyChanged(nameof(MaxDefenseValue));
        OnPropertyChanged(nameof(MaxAimValue));
        OnPropertyChanged(nameof(CanAllocateCombatModifier));
        IncrementInitiatorCommand.NotifyCanExecuteChanged();
        DecrementInitiatorCommand.NotifyCanExecuteChanged();
        IncrementAttackCommand.NotifyCanExecuteChanged();
        DecrementAttackCommand.NotifyCanExecuteChanged();
        IncrementDefenseCommand.NotifyCanExecuteChanged();
        DecrementDefenseCommand.NotifyCanExecuteChanged();
        IncrementAimCommand.NotifyCanExecuteChanged();
        DecrementAimCommand.NotifyCanExecuteChanged();
    }

    private bool CanBuildPsiShield() => Character?.Psi != null;

    /// <summary>
    /// Building a psi shield (unlike dismantling one, see EncounterViewModel.DismantlePsiShieldAsync)
    /// only happens here, outside combat, since it represents preparation time the book doesn't let
    /// a character spend mid-fight.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanBuildPsiShield))]
    public async Task BuildPsiShieldAsync()
    {
        if (Character is not { Psi: not null } character)
        {
            return;
        }

        var choice = await ShellNavigationService.DisplayActionSheetAsync(
            "Psi shield",
            "Cancel",
            null,
            "Static astral",
            "Static mental",
            "Dynamic astral",
            "Dynamic mental").ConfigureAwait(true);

        var isAstral = choice is "Static astral" or "Dynamic astral";
        switch (choice)
        {
            case "Static astral" or "Static mental":
                await BuildStaticPsiShieldAsync(character, isAstral).ConfigureAwait(true);
                break;
            case "Dynamic astral" or "Dynamic mental":
                await AdjustDynamicPsiShieldAsync(character, isAstral).ConfigureAwait(true);
                break;
        }

        OnPropertyChanged(nameof(PsiPoints));
        OnPropertyChanged(nameof(StaticAstralPsiShield));
        OnPropertyChanged(nameof(StaticMentalPsiShield));
        OnPropertyChanged(nameof(DynamicAstralPsiShield));
        OnPropertyChanged(nameof(DynamicMentalPsiShield));
    }

    private static async Task BuildStaticPsiShieldAsync(Character character, bool isAstral)
    {
        var existing = isAstral ? character.StaticAstralPsiShield : character.StaticMentalPsiShield;
        if (existing > 0)
        {
            var remove = await ShellNavigationService.DisplayAlertAsync(
                "Psi shield",
                String.Format(Lng.Elem("A strength-{0} Statikus Pajzs already stands here. Dismantle it?"), existing),
                Lng.Elem("Dismantle"),
                Lng.Elem("Keep it")).ConfigureAwait(true);

            if (remove)
            {
                character.RemoveStaticPsiShield(isAstral);
            }

            return;
        }

        var pointsText = await ShellNavigationService.DisplayPromptAsync(
            "Psi shield",
            String.Format(Lng.Elem("Spend how many psi points (max {0}) on a permanent Statikus Pajzs? Once built, its strength can't be changed."), character.PsiPoints),
            "OK",
            "Cancel",
            character.PsiPoints.ToString(CultureInfo.InvariantCulture)).ConfigureAwait(true);

        if (String.IsNullOrWhiteSpace(pointsText) || !int.TryParse(pointsText, NumberStyles.Integer, CultureInfo.InvariantCulture, out var points))
        {
            return;
        }

        if (!character.TryBuildStaticPsiShield(isAstral, points))
        {
            await ShellNavigationService.DisplayAlertAsync(Lng.Elem("Not enough psi points.")).ConfigureAwait(true);
        }
    }

    private static async Task AdjustDynamicPsiShieldAsync(Character character, bool isAstral)
    {
        var current = isAstral ? character.DynamicAstralPsiShield : character.DynamicMentalPsiShield;

        var deltaText = await ShellNavigationService.DisplayPromptAsync(
            "Psi shield",
            String.Format(
                Lng.Elem("Dinamikus Pajzs currently holds {0} psi points ({1} free). Enter psi points to add, or a negative number to withdraw:"),
                current,
                character.PsiPoints),
            "OK",
            "Cancel",
            "0").ConfigureAwait(true);

        if (String.IsNullOrWhiteSpace(deltaText) || !int.TryParse(deltaText, NumberStyles.Integer, CultureInfo.InvariantCulture, out var delta) || delta == 0)
        {
            return;
        }

        if (!character.TryAdjustDynamicPsiShield(isAstral, delta))
        {
            await ShellNavigationService.DisplayAlertAsync(Lng.Elem(delta > 0 ? "Not enough free psi points." : "The shield doesn't hold that many psi points.")).ConfigureAwait(true);
        }
    }

    [RelayCommand]
    public async Task ChangePortraitAsync()
    {
        if (Character == null)
        {
            return;
        }

        await PreloadService.Instance.InitializeAsync().ConfigureAwait(true);

        var pickerViewModel = new CharacterPortraitPickerViewModel(Character.Images);
        var pickerPage = new CharacterPortraitPickerPage(pickerViewModel);

        await ShellNavigationService.ShowModalPageAsync(pickerPage).ConfigureAwait(true);
        var result = await pickerPage.ResultTask.ConfigureAwait(true);

        if (result != null)
        {
            Character.Images = [.. result];
            OnPropertyChanged(nameof(PortraitImage));
        }
    }

    [RelayCommand]
    public async Task Print()
    {
        if (Character == null)
        {
            return;
        }

        var answer = await ShellNavigationService.DisplayAlertAsync("Print", "Do you want to print character sheet?", "Yes", "No").ConfigureAwait(false);
        if (answer)
        {
            var htmlService = new CharacterHtmlService();
            var htmlContent = htmlService.GenerateCharacterHtml(Character);
            await printService.PrintHtmlAsync(htmlContent, $"MAGUS - {Character.Name}").ConfigureAwait(false);
        }
    }

    private bool CanSleepOrEat => Character != null;

    private bool CanSleep => Character is { IsSleeping: false };

    [RelayCommand(CanExecute = nameof(CanSleep))]
    private async Task SleepAsync()
    {
        if (Character is not { } character)
        {
            return;
        }

        await CharacterCareActions.SleepAsync(character, characterService, gameEventService).ConfigureAwait(true);

        OnPropertyChanged(nameof(IsSleeping));
        OnPropertyChanged(nameof(SleepProgress));
        SleepCommand.NotifyCanExecuteChanged();
    }

    private bool CanStopSleep => Character is { IsSleeping: true };

    /// <summary>
    /// Lets the player wake the character up early, before SleepDurationHours has fully elapsed -
    /// mirrors StopTravelAsync. Restoration is prorated to however long they actually slept in real
    /// time (Character.ElapsedSleepHours) rather than the full planned duration - see InterruptSleep.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanStopSleep))]
    private void StopSleep()
    {
        if (Character is not { IsSleeping: true } character)
        {
            return;
        }

        InterruptSleep(character, String.Format(Lng.Elem("{0} wakes up early, only partially rested."), character.Name));

        OnPropertyChanged(nameof(IsSleeping));
        OnPropertyChanged(nameof(SleepProgress));
        SleepCommand.NotifyCanExecuteChanged();
        StopSleepCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(CanExecute = nameof(CanSleepOrEat))]
    private async Task EatAsync()
    {
        if (Character is not { } character)
        {
            return;
        }

        await CharacterCareActions.EatAsync(character, characterService).ConfigureAwait(true);
    }

    [RelayCommand(CanExecute = nameof(CanSleepOrEat))]
    private async Task UseHealingItemAsync()
    {
        if (Character is not { } character)
        {
            return;
        }

        await CharacterCareActions.UseHealingItemAsync(character, characterService).ConfigureAwait(true);
    }

    private bool CanCastSpell => Character is { Sorcery: not null, IsConscious: true };

    /// <summary>
    /// Casts a Mana spell outside of combat - on this character or another saved one - via
    /// CombatEngine.CastOutsideCombatAsync, which reuses the same resolution rules a real Encounter
    /// turn would (hit roll against magic resistance, HP-vs-FP routing, the spell's own OnHit).
    /// Lets a conscious character use a healing spell on an unconscious ally (or themselves, before
    /// things get that bad). Psi disciplines are cast separately via CastPsiAsync.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanCastSpell))]
    private async Task CastSpellAsync()
    {
        if (Character is not { IsConscious: true } caster)
        {
            return;
        }

        var options = new List<(string Name, MysticAttack Attack)>();

        foreach (var spell in SpellCatalog.GetAvailable(caster))
        {
            if (caster.ManaPoints < spell.ManaCost)
            {
                continue;
            }

            if (spell.PainTolerancePointCost > 0 && (caster.ActualPainTolerancePoints is not int fp || fp < spell.PainTolerancePointCost))
            {
                continue;
            }

            options.Add((spell.Name, new SpellAttack(spell)));
        }

        if (options.Count == 0)
        {
            await ShellNavigationService.DisplayAlertAsync(Lng.Elem("No affordable spell to cast right now.")).ConfigureAwait(true);
            return;
        }

        await CastAsync(caster, "Cast spell", options).ConfigureAwait(true);
    }

    private bool CanCastPsi => Character is { Psi: not null, IsConscious: true };

    /// <summary>
    /// Casts a Psi discipline outside of combat - the Psi counterpart to CastSpellAsync, same
    /// resolution path (see CastAsync) but drawing from PsiPoints/Psi disciplines instead of
    /// ManaPoints/spells.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanCastPsi))]
    private async Task CastPsiAsync()
    {
        if (Character is not { IsConscious: true } caster)
        {
            return;
        }

        var options = new List<(string Name, MysticAttack Attack)>();

        foreach (var discipline in PsiDisciplineCatalog.GetAvailable(caster))
        {
            if (caster.PsiPoints < discipline.PsiPointCost)
            {
                continue;
            }

            options.Add((discipline.Name, new PsiAttack(discipline)));
        }

        if (options.Count == 0)
        {
            await ShellNavigationService.DisplayAlertAsync(Lng.Elem("No affordable psi discipline to cast right now.")).ConfigureAwait(true);
            return;
        }

        await CastAsync(caster, "Cast psi", options).ConfigureAwait(true);
    }

    /// <summary>
    /// Shared target-pick/resolve/save flow behind both CastSpellAsync and CastPsiAsync: pick a
    /// target (self or any other saved, living character), resolve the chosen attack via
    /// CombatEngine.CastOutsideCombatAsync, save both participants, and report the outcome.
    /// </summary>
    private async Task CastAsync(Character caster, string title, List<(string Name, MysticAttack Attack)> options)
    {
        var choice = await ShellNavigationService.DisplayActionSheetAsync(
            title,
            "Cancel",
            null,
            [.. options.Select(o => o.Name)]).ConfigureAwait(true);

        var chosen = options.FirstOrDefault(o => o.Name == choice);
        if (chosen.Attack == null)
        {
            return;
        }

        var others = (await characterService.GetAllAsync().ConfigureAwait(true))
            .Where(c => c.Name != caster.Name && !c.IsDead)
            .ToList();

        var selfLabel = String.Format(Lng.Elem("Self ({0})"), caster.Name);
        var targetNames = new List<string> { selfLabel };
        targetNames.AddRange(others.Select(c => c.Name));

        var targetChoice = await ShellNavigationService.DisplayActionSheetAsync(
            "Target",
            "Cancel",
            null,
            [.. targetNames]).ConfigureAwait(true);

        if (String.IsNullOrEmpty(targetChoice))
        {
            return;
        }

        var target = targetChoice == selfLabel ? caster : others.FirstOrDefault(c => c.Name == targetChoice);
        if (target == null)
        {
            return;
        }

        var hit = await CombatEngine.CastOutsideCombatAsync(caster, target, chosen.Attack, new AutoCombatRollService()).ConfigureAwait(true);

        await characterService.SaveAsync(caster).ConfigureAwait(false);
        if (target != caster)
        {
            await characterService.SaveAsync(target).ConfigureAwait(false);
        }

        OnPropertyChanged(String.Empty);
        CastSpellCommand.NotifyCanExecuteChanged();
        CastPsiCommand.NotifyCanExecuteChanged();

        await ShellNavigationService.DisplayAlertAsync(
            title,
            hit
                ? String.Format(Lng.Elem("{0} successfully casts {1} on {2}."), caster.Name, Lng.Elem(chosen.Name), target.Name)
                : String.Format(Lng.Elem("{0}'s {1} fails to affect {2}."), caster.Name, Lng.Elem(chosen.Name), target.Name)).ConfigureAwait(true);
    }

    private bool CanTravel => Character is { IsTraveling: false } && SelectedTravelDestination.HasValue;

    /// <summary>Progress already accounted for when the last waypoint-passing notification fired for the current journey - see RefreshLiveProgress. Reset to 0 whenever a new journey starts.</summary>
    private double lastNotifiedTravelProgress;

    /// <summary>
    /// Lets the player move this character to a different city: destination is picked via
    /// SelectedTravelDestination (bound to a Picker in PlacesView.xaml, since PlacesView is where
    /// the player already sees Birthplace/CurrentLocation), then this command picks a transport
    /// mode, shows the computed travel time (TravelCalculator.CalculateDays, built on the fixed
    /// CityCoordinates distance data - see Places/CityCoordinates.cs), confirms, then the journey
    /// starts (Character.TravelDestination/TravelDepartureUtc/TravelDurationDays) and
    /// CurrentLocation updates only once TravelProgress reaches 1 - see Character.CompleteTravelIfArrived.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanTravel))]
    private async Task TravelAsync()
    {
        if (Character is not { } character || character.IsTraveling || SelectedTravelDestination is not { } destination)
        {
            return;
        }

        // Where the journey actually starts from: Position already holds it once a character has
        // traveled or stopped mid-route before (see Character.StopTraveling). Otherwise fall back to
        // Birthplace's coordinates - and if even that is unset, there's genuinely no known starting
        // point yet, so ask for one instead of guessing a random city.
        var origin = character.Position;
        if (origin is null && character.Birthplace != City.Unknown)
        {
            origin = CityCoordinates.GetPosition(character.Birthplace);
        }

        if (origin is null)
        {
            await ShellNavigationService.DisplayAlertAsync(
                Lng.Elem("Travel"),
                Lng.Elem("This character's starting location isn't known yet - set a Birthplace before traveling."),
                Lng.Elem("OK")).ConfigureAwait(true);
            return;
        }

        character.Position ??= origin;

        var availableModes = Enum.GetValues<TransportMode>()
            .Where(m => m != TransportMode.Horseback || character.HasItem<Horse>())
            .ToList();

        // DisplayActionSheetAsync translates each button label before returning the tapped choice, so
        // comparing it back against TransportMode.ToString() (raw English) would silently fail to
        // match in any non-English locale - compare against the same pre-translated labels instead.
        var modeChoice = await ShellNavigationService.DisplayActionSheetAsync(
            "Travel mode",
            "Cancel",
            null,
            [.. availableModes.Select(m => Lng.Elem(m.ToString()))]).ConfigureAwait(true);

        var modeIndex = availableModes.FindIndex(m => Lng.Elem(m.ToString()) == modeChoice);
        if (modeIndex < 0)
        {
            return;
        }

        var mode = availableModes[modeIndex];
        var destinationPosition = CityCoordinates.GetPosition(destination);

        var days = TravelCalculator.CalculateDays(origin.Value, destinationPosition, mode, character);

        // Traveling by Ship means paying for passage - there's no book fare table, see
        // TravelCalculator.CalculateShipFare - so this is charged instead of owning transport outright.
        var fare = mode == TransportMode.Ship ? TravelCalculator.CalculateShipFare(origin.Value, destinationPosition) : Money.Free;
        if (mode == TransportMode.Ship && character.Money < fare)
        {
            await ShellNavigationService.DisplayAlertAsync(
                Lng.Elem("Travel"),
                String.Format(Lng.Elem("You cannot afford the {0} fare for passage to {1}."), fare.ToTranslatedString(), Lng.Elem(destination.GetDescription())),
                Lng.Elem("OK")).ConfigureAwait(true);
            return;
        }

        var message = mode == TransportMode.Ship
            ? String.Format(
                Lng.Elem("Traveling from {0} to {1} by {2} will take about {3:F1} days and cost {4} in fare. Travel now?"),
                Lng.Elem(character.CurrentLocation.GetDescription()),
                Lng.Elem(destination.GetDescription()),
                Lng.Elem(mode.ToString()),
                days,
                fare.ToTranslatedString())
            : String.Format(
                Lng.Elem("Traveling from {0} to {1} by {2} will take about {3:F1} days. Travel now?"),
                Lng.Elem(character.CurrentLocation.GetDescription()),
                Lng.Elem(destination.GetDescription()),
                Lng.Elem(mode.ToString()),
                days);

        var confirm = await ShellNavigationService.DisplayAlertAsync(
            "Travel",
            message,
            Lng.Elem("Travel"),
            Lng.Elem("Cancel")).ConfigureAwait(true);

        if (!confirm)
        {
            return;
        }

        if (mode == TransportMode.Ship)
        {
            character.Money -= fare;
        }

        character.TravelDestination = destination;
        character.TravelDepartureUtc = DateTime.UtcNow;
        character.TravelDurationDays = days;
        await characterService.SaveAsync(character).ConfigureAwait(true);

        lastNotifiedTravelProgress = 0;
        SelectedTravelDestination = null;
        OnPropertyChanged(nameof(IsTraveling));
        OnPropertyChanged(nameof(TravelProgress));
        OnPropertyChanged(nameof(TravelDestinationDescription));
        OnPropertyChanged(nameof(TravelWaypointsDescription));
        OnPropertyChanged(nameof(TravelDestinations));
        TravelCommand.NotifyCanExecuteChanged();
        StopTravelCommand.NotifyCanExecuteChanged();

        var escortQuest = AcceptedQuests.FirstOrDefault(q => q.EscortDestination == destination);
        if (escortQuest != null)
        {
            var dangerRoll = new DiceThrow()._1D100();
            if (dangerRoll <= escortQuest.EscortDangerChance)
            {
                await ShellNavigationService.DisplayAlertAsync(
                    Lng.Elem("Travel"),
                    String.Format(Lng.Elem("Something moves along the road to {0}, {1}."), Lng.Elem(destination.GetDescription()), character.Name)).ConfigureAwait(true);

                await gameEventService.TriggerRandomEncounterAsync(character).ConfigureAwait(true);
            }
        }
    }

    private bool CanStopTravel => Character is { IsTraveling: true };

    /// <summary>
    /// Cancels an in-progress journey early (see Character.StopTraveling) - CurrentLocation becomes
    /// City.Unknown rather than snapping to either end, since the character is somewhere on the road,
    /// not fully at their origin or their destination.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanStopTravel))]
    private async Task StopTravelAsync()
    {
        if (Character is not { IsTraveling: true } character)
        {
            return;
        }

        character.StopTraveling();
        await characterService.SaveAsync(character).ConfigureAwait(true);

        OnPropertyChanged(nameof(IsTraveling));
        OnPropertyChanged(nameof(TravelProgress));
        OnPropertyChanged(nameof(TravelWaypointsDescription));
        OnPropertyChanged(nameof(CurrentLocation));
        OnPropertyChanged(nameof(TravelDestinations));
        TravelCommand.NotifyCanExecuteChanged();
        StopTravelCommand.NotifyCanExecuteChanged();
    }

    /// <summary>
    /// Re-evaluates travel/sleep progress and resolves either one if it just finished - called
    /// periodically (see PlacesView.xaml.cs/CharacterCareView.xaml.cs) while a page showing a
    /// progress bar is open, so it visibly advances and arrival/waking resolve without the player
    /// needing to navigate away and back to hit the normal lazy "catch up" trigger on the Character
    /// setter.
    /// </summary>
    public void RefreshLiveProgress()
    {
        if (Character is not { } character)
        {
            return;
        }

        if (character.IsTraveling && character.TravelProgress >= 1 && character.TravelDestination is { } arrivedAt)
        {
            character.CompleteTravelIfArrived();
            CompleteArrivalQuests(character, arrivedAt);
            OnPropertyChanged(nameof(CurrentLocation));
            OnPropertyChanged(nameof(TravelDestinations));
        }
        else if (character.IsTraveling)
        {
            // Flavor notification for each waypoint city the route has newly passed near since the
            // last tick - see Character.TravelWaypoints/TravelCalculator.FindWaypointCities. Compared
            // against lastNotifiedTravelProgress (not "already notified" per city) so a waypoint is
            // announced once even if this ticks past several of them between refreshes.
            var progress = character.TravelProgress;
            var justPassed = character.TravelWaypoints.Where(w => w.RouteFraction > lastNotifiedTravelProgress && w.RouteFraction <= progress);
            foreach (var waypoint in justPassed)
            {
                WeakReferenceMessenger.Default.Send(new ShowInfoMessage(
                    Lng.Elem("On the road"),
                    String.Format(Lng.Elem("The route to {0} passes near {1}, {2}."), TravelDestinationDescription, Lng.Elem(waypoint.City.GetDescription()), character.Name)));
            }

            lastNotifiedTravelProgress = progress;
            OnPropertyChanged(nameof(TravelWaypointsDescription));
        }

        if (character.IsSleeping && character.SleepProgress >= 1)
        {
            CompleteSleep(character, character.SleepDurationHours);
        }
        else if (character.IsSleeping)
        {
            // Hunger keeps decaying during sleep (Character.ApplyElapsedHungerDecay has no IsSleeping
            // guard, unlike sleep's own decay) - so a long enough sleep can run the character into
            // critical hunger before SleepDurationHours is up. Same threshold as IsHungerCritical.
            character.ApplyElapsedHungerDecay();
            if (character.HungerPercent < 10)
            {
                InterruptSleep(character, String.Format(Lng.Elem("Hunger wakes {0} up before a full night's rest."), character.Name));
            }
        }

        OnPropertyChanged(nameof(IsTraveling));
        OnPropertyChanged(nameof(TravelProgress));
        OnPropertyChanged(nameof(IsSleeping));
        OnPropertyChanged(nameof(SleepProgress));
        OnPropertyChanged(nameof(HungerPercent));
        OnPropertyChanged(nameof(IsHungerCritical));
        TravelCommand.NotifyCanExecuteChanged();
        StopTravelCommand.NotifyCanExecuteChanged();
        SleepCommand.NotifyCanExecuteChanged();
        StopSleepCommand.NotifyCanExecuteChanged();

        ExpireOverdueQuests(character);
    }

    /// <summary>
    /// Completes any quest whose destination is the city the character just arrived in via Travel
    /// (see Character.CompleteTravelIfArrived and the Character setter above, which detects "just
    /// arrived" before clearing TravelDestination and calls this) - an Accepted quest with a matching
    /// Quest.EscortDestination (escorting someone there), or an ItemObtained quest with a matching
    /// Quest.DeliveryDestination (carrying a found item there). Either way it finishes itself on
    /// arrival, without the player needing to press "Mark complete" by hand.
    /// </summary>
    private void CompleteArrivalQuests(Character character, City arrivedAt)
    {
        var matchingQuests = PreloadService.Instance.Quests
            .Where(q =>
                (q.EscortDestination == arrivedAt && character.GetQuestStatus(q) == QuestStatus.Accepted) ||
                (q.DeliveryDestination == arrivedAt && character.GetQuestStatus(q) == QuestStatus.ItemObtained))
            .ToList();

        if (matchingQuests.Count == 0)
        {
            return;
        }

        foreach (var quest in matchingQuests)
        {
            character.CompleteQuest(quest);

            WeakReferenceMessenger.Default.Send(new ShowInfoMessage(
                Lng.Elem("Quest complete"),
                String.Format(
                    Lng.Elem("{0} arrives safely in {1}. \"{2}\" is complete - {3}{4}."),
                    character.Name,
                    Lng.Elem(arrivedAt.GetDescription()),
                    Lng.Elem(quest.Name),
                    quest.MoneyReward.ToTranslatedString(),
                    quest.ExperienceReward > 0 ? String.Format(Lng.Elem(" and {0} XP"), quest.ExperienceReward) : String.Empty)));
        }

        _ = characterService.SaveAsync(character);
    }

    /// <summary>
    /// Applies the settings-configured per-hour restoration for <paramref name="hours"/> of sleep to
    /// HP/PRP/Mana/Psi - the math needs SettingsService, which only lives at this layer, so unlike
    /// CompleteTravelIfArrived this can't be resolved entirely inside Character itself. Shared by
    /// CompleteSleep (a full night, hours = SleepDurationHours) and InterruptSleep (a cut-short one,
    /// hours = however much real time actually passed - see Character.ElapsedSleepHours).
    /// </summary>
    private void ApplySleepRestoration(Character character, double hours)
    {
        character.ActualHealthPoints = Math.Min(character.MaxHealthPoints, character.ActualHealthPoints + (int)Math.Round(hours * settingsService.RestoreHealthPointsPerHourOfSleep));
        character.ManaPoints = Math.Min(character.MaxManaPoints, character.ManaPoints + (int)Math.Round(hours * settingsService.RestoreManaPointsPerHourOfSleep));
        character.PsiPoints = Math.Min(character.MaxPsiPoints, character.PsiPoints + (int)Math.Round(hours * settingsService.RestorePsiPointsPerHourOfSleep));

        if (character.MaxPainTolerancePoints.HasValue)
        {
            var restored = (int)Math.Round(hours * settingsService.RestorePainTolerancePointsPerHourOfSleep);
            character.ActualPainTolerancePoints = Math.Min(character.MaxPainTolerancePoints.Value, (character.ActualPainTolerancePoints ?? 0) + restored);
        }
    }

    /// <summary>
    /// Applies the full-duration restoration for a sleep that ran its course (see
    /// Character.IsSleeping/SleepProgress, set by CharacterCareActions.SleepAsync) and clears the
    /// sleep state.
    /// </summary>
    private void CompleteSleep(Character character, double hours)
    {
        ApplySleepRestoration(character, hours);
        character.ClearSleepState();
        _ = characterService.SaveAsync(character);

        WeakReferenceMessenger.Default.Send(new ShowInfoMessage(
            Lng.Elem("Sleep"),
            String.Format(Lng.Elem("{0} wakes up feeling refreshed."), character.Name)));
    }

    /// <summary>
    /// Ends an in-progress sleep before SleepDurationHours has fully elapsed - either the player
    /// cutting it short (StopSleep) or hunger becoming critical mid-sleep (RefreshLiveProgress/the
    /// Character setter's catch-up hook). Restores HP/PRP/Mana/Psi prorated to however many hours
    /// actually passed (Character.ElapsedSleepHours) rather than the full planned duration, then
    /// clears the sleep state. The caller supplies the wake-up message since the two cases read very
    /// differently ("wakes up early" vs. "hunger wakes them up").
    /// </summary>
    private void InterruptSleep(Character character, string wakeMessage)
    {
        ApplySleepRestoration(character, character.ElapsedSleepHours);
        character.ClearSleepState();
        _ = characterService.SaveAsync(character);

        WeakReferenceMessenger.Default.Send(new ShowInfoMessage(Lng.Elem("Sleep"), wakeMessage));
    }

    /// <summary>Fails any timed quest (see Quest.TimeLimitHours) whose deadline has passed, one "quest failed" notification per quest, and saves if anything changed.</summary>
    private void ExpireOverdueQuests(Character character)
    {
        var expiredKeys = character.ExpireOverdueQuests(PreloadService.Instance.Quests);
        if (expiredKeys.Count == 0)
        {
            return;
        }

        foreach (var key in expiredKeys)
        {
            var quest = PreloadService.Instance.Quests.FirstOrDefault(q => q.Key == key);
            if (quest == null)
            {
                continue;
            }

            WeakReferenceMessenger.Default.Send(new ShowInfoMessage(
                Lng.Elem("Quest failed"),
                String.Format(Lng.Elem("Too much time has passed - \"{0}\" can no longer be completed."), Lng.Elem(quest.Name))));
        }

        OnPropertyChanged(nameof(AvailableQuestsHere));
        OnPropertyChanged(nameof(AcceptedQuests));
        OnPropertyChanged(nameof(SearchableQuestsHere));
        OnPropertyChanged(nameof(NegotiableQuestsHere));
        OnPropertyChanged(nameof(HealableQuestsHere));
        OnPropertyChanged(nameof(StealableQuestsHere));
        OnPropertyChanged(nameof(TrapSearchableQuestsHere));

        _ = characterService.SaveAsync(character);
    }

    /// <summary>Quests offered in the character's CurrentLocation that haven't been accepted or completed yet - see PlacesView.xaml.</summary>
    public IEnumerable<Quest> AvailableQuestsHere => Character is not { } character
        ? []
        : PreloadService.Instance.Quests.Where(q => q.City == character.CurrentLocation && character.GetQuestStatus(q) == QuestStatus.NotStarted);

    /// <summary>
    /// Quests this character has accepted (or, for a delivery quest, already found the item for) but
    /// not yet completed, regardless of which city they're set in - so they stay visible while
    /// traveling.
    /// </summary>
    public IEnumerable<Quest> AcceptedQuests => Character is not { } character
        ? []
        : PreloadService.Instance.Quests.Where(q => character.GetQuestStatus(q) is QuestStatus.Accepted or QuestStatus.ItemObtained);

    /// <summary>
    /// Accepted (not yet found) quests whose Quest.SearchLocation is the character's CurrentLocation
    /// right now - the ones a Search action here could actually advance. Deliberately checks
    /// QuestStatus.Accepted directly rather than filtering AcceptedQuests, so a delivery quest that
    /// already reached ItemObtained doesn't get offered here again just because the character is
    /// still standing where they found it.
    /// </summary>
    public IEnumerable<Quest> SearchableQuestsHere => Character is not { } character
        ? []
        : PreloadService.Instance.Quests.Where(q => q.SearchLocation == character.CurrentLocation && character.GetQuestStatus(q) == QuestStatus.Accepted);

    /// <summary>Accepted quests with a Quest.DialogueRoot, offered in the character's CurrentLocation right now - the ones a Negotiate action here could advance.</summary>
    public IEnumerable<Quest> NegotiableQuestsHere => Character is not { } character
        ? []
        : PreloadService.Instance.Quests.Where(q => q.DialogueRoot != null && q.City == character.CurrentLocation && character.GetQuestStatus(q) == QuestStatus.Accepted);

    /// <summary>Accepted quests with Quest.RequiresHealing, offered in the character's CurrentLocation right now - the ones a Treat action here could complete, if CanHeal allows it.</summary>
    public IEnumerable<Quest> HealableQuestsHere => Character is not { } character
        ? []
        : PreloadService.Instance.Quests.Where(q => q.RequiresHealing && q.City == character.CurrentLocation && character.GetQuestStatus(q) == QuestStatus.Accepted);

    /// <summary>Accepted quests whose Quest.StealLocation is the character's CurrentLocation right now - the ones a Steal action here could advance.</summary>
    public IEnumerable<Quest> StealableQuestsHere => Character is not { } character
        ? []
        : PreloadService.Instance.Quests.Where(q => q.StealLocation == character.CurrentLocation && character.GetQuestStatus(q) == QuestStatus.Accepted);

    /// <summary>Accepted quests whose Quest.TrapLocation is the character's CurrentLocation right now - the ones a Search for traps/secret doors action here could advance, if TrapSearchSkillPercent allows it.</summary>
    public IEnumerable<Quest> TrapSearchableQuestsHere => Character is not { } character
        ? []
        : PreloadService.Instance.Quests.Where(q => q.TrapLocation == character.CurrentLocation && character.GetQuestStatus(q) == QuestStatus.Accepted);

    [RelayCommand]
    private void AcceptQuest(Quest quest)
    {
        if (Character is not { } character || quest == null)
        {
            return;
        }

        character.AcceptQuest(quest);
        _ = characterService.SaveAsync(character);

        OnPropertyChanged(nameof(AvailableQuestsHere));
        OnPropertyChanged(nameof(AcceptedQuests));
        OnPropertyChanged(nameof(SearchableQuestsHere));
        OnPropertyChanged(nameof(NegotiableQuestsHere));
        OnPropertyChanged(nameof(HealableQuestsHere));
        OnPropertyChanged(nameof(StealableQuestsHere));
        OnPropertyChanged(nameof(TrapSearchableQuestsHere));
    }

    [RelayCommand]
    private async Task CompleteQuestAsync(Quest quest)
    {
        if (Character is not { } character || quest == null)
        {
            return;
        }

        character.CompleteQuest(quest);
        await characterService.SaveAsync(character).ConfigureAwait(true);

        OnPropertyChanged(nameof(AvailableQuestsHere));
        OnPropertyChanged(nameof(AcceptedQuests));
        OnPropertyChanged(nameof(SearchableQuestsHere));
        OnPropertyChanged(nameof(NegotiableQuestsHere));
        OnPropertyChanged(nameof(HealableQuestsHere));
        OnPropertyChanged(nameof(StealableQuestsHere));
        OnPropertyChanged(nameof(TrapSearchableQuestsHere));

        await ShellNavigationService.DisplayAlertAsync(
            Lng.Elem("Quest complete"),
            String.Format(
                Lng.Elem("{0} completes \"{1}\" and earns {2}{3}."),
                character.Name,
                Lng.Elem(quest.Name),
                quest.MoneyReward.ToTranslatedString(),
                quest.ExperienceReward > 0 ? String.Format(Lng.Elem(" and {0} XP"), quest.ExperienceReward) : String.Empty)).ConfigureAwait(true);
    }

    /// <summary>
    /// A single search attempt for a quest whose Quest.SearchLocation matches where the character is
    /// standing right now (see SearchableQuestsHere) - rolls a d100 against the quest's
    /// SearchDifficulty (default 90, so roughly 1-in-10 per try). On success, a plain search quest
    /// completes outright; a delivery quest (Quest.HasDeliveryDestination) instead moves to
    /// QuestStatus.ItemObtained - the item still needs carrying to DeliveryDestination, completed by
    /// CompleteArrivalQuests once the character gets there. A miss usually costs nothing but the
    /// attempt itself, so the player can just try again later - but per Quest.SearchDangerChance
    /// (default 25%), a miss can instead drop the character into an unplanned fight via
    /// GameEventService.TriggerRandomEncounterAsync, same as the background Ambush event.
    /// </summary>
    [RelayCommand]
    private async Task SearchAsync(Quest quest)
    {
        if (Character is not { } character || quest == null)
        {
            return;
        }

        var roll = new DiceThrow()._1D100();
        if (roll <= quest.SearchDifficulty)
        {
            var dangerRoll = new DiceThrow()._1D100();
            if (dangerRoll <= quest.SearchDangerChance)
            {
                await ShellNavigationService.DisplayAlertAsync(
                    Lng.Elem("Search"),
                    String.Format(Lng.Elem("{0} finds no sign of it in {1} - but something else finds {0} instead."), character.Name, Lng.Elem(character.CurrentLocation.GetDescription()))).ConfigureAwait(true);

                await gameEventService.TriggerRandomEncounterAsync(character).ConfigureAwait(true);
                return;
            }

            await ShellNavigationService.DisplayAlertAsync(
                Lng.Elem("Search"),
                String.Format(Lng.Elem("{0} searches {1} but finds no sign of it yet. Worth trying again."), character.Name, Lng.Elem(character.CurrentLocation.GetDescription()))).ConfigureAwait(true);
            return;
        }

        if (quest.HasDeliveryDestination)
        {
            character.MarkItemObtained(quest);
            await characterService.SaveAsync(character).ConfigureAwait(true);

            OnPropertyChanged(nameof(AvailableQuestsHere));
            OnPropertyChanged(nameof(AcceptedQuests));
            OnPropertyChanged(nameof(SearchableQuestsHere));
            OnPropertyChanged(nameof(NegotiableQuestsHere));
            OnPropertyChanged(nameof(HealableQuestsHere));
            OnPropertyChanged(nameof(StealableQuestsHere));
            OnPropertyChanged(nameof(TrapSearchableQuestsHere));

            await ShellNavigationService.DisplayAlertAsync(
                Lng.Elem("Search"),
                String.Format(
                    Lng.Elem("{0} searches {1} and finds {2}! Now it needs to be carried to {3}."),
                    character.Name,
                    Lng.Elem(character.CurrentLocation.GetDescription()),
                    Lng.Elem(quest.DeliveryItemName),
                    Lng.Elem(quest.DeliveryDestination!.Value.GetDescription()))).ConfigureAwait(true);
            return;
        }

        character.CompleteQuest(quest);
        await characterService.SaveAsync(character).ConfigureAwait(true);

        OnPropertyChanged(nameof(AvailableQuestsHere));
        OnPropertyChanged(nameof(AcceptedQuests));
        OnPropertyChanged(nameof(SearchableQuestsHere));
        OnPropertyChanged(nameof(NegotiableQuestsHere));
        OnPropertyChanged(nameof(HealableQuestsHere));
        OnPropertyChanged(nameof(StealableQuestsHere));
        OnPropertyChanged(nameof(TrapSearchableQuestsHere));

        await ShellNavigationService.DisplayAlertAsync(
            Lng.Elem("Search"),
            String.Format(
                Lng.Elem("{0} searches {1} and finally finds what they were looking for! \"{2}\" is complete - {3}{4}."),
                character.Name,
                Lng.Elem(character.CurrentLocation.GetDescription()),
                Lng.Elem(quest.Name),
                quest.MoneyReward.ToTranslatedString(),
                quest.ExperienceReward > 0 ? String.Format(Lng.Elem(" and {0} XP"), quest.ExperienceReward) : String.Empty)).ConfigureAwait(true);
    }

    /// <summary>
    /// Opens the branching negotiation for a quest with a Quest.DialogueRoot (see DialoguePage) and
    /// acts on how it ends: Success completes the quest and pays out, Failure just closes the
    /// conversation (the player can try again from the start next time), and Danger drops the
    /// character into an unplanned fight via GameEventService.TriggerRandomEncounterAsync - the wrong
    /// answer at the wrong moment.
    /// </summary>
    [RelayCommand]
    private async Task NegotiateAsync(Quest quest)
    {
        if (Character is not { } character || quest?.DialogueRoot is not { } root)
        {
            return;
        }

        var dialoguePage = new DialoguePage(root);
        await ShellNavigationService.ShowModalPageAsync(dialoguePage).ConfigureAwait(true);
        var outcome = await dialoguePage.ResultTask.ConfigureAwait(true);

        switch (outcome)
        {
            case DialogueOutcome.Success:
                character.CompleteQuest(quest);
                await characterService.SaveAsync(character).ConfigureAwait(true);

                OnPropertyChanged(nameof(AvailableQuestsHere));
                OnPropertyChanged(nameof(AcceptedQuests));
                OnPropertyChanged(nameof(SearchableQuestsHere));
                OnPropertyChanged(nameof(NegotiableQuestsHere));
                OnPropertyChanged(nameof(HealableQuestsHere));
                OnPropertyChanged(nameof(StealableQuestsHere));
                OnPropertyChanged(nameof(TrapSearchableQuestsHere));

                await ShellNavigationService.DisplayAlertAsync(
                    Lng.Elem("Quest complete"),
                    String.Format(
                        Lng.Elem("{0} finds the right words. \"{1}\" is complete - {2}{3}."),
                        character.Name,
                        Lng.Elem(quest.Name),
                        quest.MoneyReward.ToTranslatedString(),
                        quest.ExperienceReward > 0 ? String.Format(Lng.Elem(" and {0} XP"), quest.ExperienceReward) : String.Empty)).ConfigureAwait(true);
                break;

            case DialogueOutcome.PartialSuccess:
                character.CompleteQuest(quest, 0.5);
                await characterService.SaveAsync(character).ConfigureAwait(true);

                OnPropertyChanged(nameof(AvailableQuestsHere));
                OnPropertyChanged(nameof(AcceptedQuests));
                OnPropertyChanged(nameof(SearchableQuestsHere));
                OnPropertyChanged(nameof(NegotiableQuestsHere));
                OnPropertyChanged(nameof(HealableQuestsHere));
                OnPropertyChanged(nameof(StealableQuestsHere));
                OnPropertyChanged(nameof(TrapSearchableQuestsHere));

                await ShellNavigationService.DisplayAlertAsync(
                    Lng.Elem("Quest complete"),
                    String.Format(
                        Lng.Elem("{0} settles for a compromise. \"{1}\" is complete, but only for half the reward - {2}{3}."),
                        character.Name,
                        Lng.Elem(quest.Name),
                        (quest.MoneyReward * 0.5).ToTranslatedString(),
                        quest.ExperienceReward > 0 ? String.Format(Lng.Elem(" and {0} XP"), (ulong)(quest.ExperienceReward * 0.5)) : String.Empty)).ConfigureAwait(true);
                break;

            case DialogueOutcome.Danger:
                await ShellNavigationService.DisplayAlertAsync(
                    Lng.Elem("Negotiation"),
                    String.Format(Lng.Elem("The conversation turns hostile, {0}."), character.Name)).ConfigureAwait(true);
                await gameEventService.TriggerRandomEncounterAsync(character).ConfigureAwait(true);
                break;

            default:
                await ShellNavigationService.DisplayAlertAsync(
                    Lng.Elem("Negotiation"),
                    String.Format(Lng.Elem("{0} doesn't manage to sway them this time. Worth trying again."), character.Name)).ConfigureAwait(true);
                break;
        }
    }

    private bool CanHeal => Character?.CanHeal() ?? false;

    /// <summary>
    /// Treats a quest's injured NPC (Quest.RequiresHealing) - unlike Search, there's no roll: having
    /// the ability to help (Character.CanHeal - the Healing qualification or a known IHealingSpell)
    /// IS the resolution, so this just completes the quest outright. The button is disabled via
    /// CanHeal when the character has neither.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanHeal))]
    private async Task HealAsync(Quest quest)
    {
        if (Character is not { } character || quest == null)
        {
            return;
        }

        character.CompleteQuest(quest);
        await characterService.SaveAsync(character).ConfigureAwait(true);

        OnPropertyChanged(nameof(AvailableQuestsHere));
        OnPropertyChanged(nameof(AcceptedQuests));
        OnPropertyChanged(nameof(SearchableQuestsHere));
        OnPropertyChanged(nameof(NegotiableQuestsHere));
        OnPropertyChanged(nameof(HealableQuestsHere));
        OnPropertyChanged(nameof(StealableQuestsHere));
        OnPropertyChanged(nameof(TrapSearchableQuestsHere));

        await ShellNavigationService.DisplayAlertAsync(
            Lng.Elem("Quest complete"),
            String.Format(
                Lng.Elem("{0} treats the injury. \"{1}\" is complete - {2}{3}."),
                character.Name,
                Lng.Elem(quest.Name),
                quest.MoneyReward.ToTranslatedString(),
                quest.ExperienceReward > 0 ? String.Format(Lng.Elem(" and {0} XP"), quest.ExperienceReward) : String.Empty)).ConfigureAwait(true);
    }

    /// <summary>
    /// A single theft attempt for a quest whose Quest.StealLocation matches where the character is
    /// standing right now (see StealableQuestsHere) - no qualification required, just a d100 roll
    /// against Quest.StealDifficulty, the same shape as SearchAsync. A miss usually costs nothing,
    /// but per Quest.StealDangerChance a miss can instead get the character caught - dropping them
    /// into an unplanned fight via GameEventService.TriggerRandomEncounterAsync, same as Search/Escort
    /// danger.
    /// </summary>
    [RelayCommand]
    private async Task StealAsync(Quest quest)
    {
        if (Character is not { } character || quest == null)
        {
            return;
        }

        var roll = new DiceThrow()._1D100();
        if (roll <= quest.StealDifficulty)
        {
            var dangerRoll = new DiceThrow()._1D100();
            if (dangerRoll <= quest.StealDangerChance)
            {
                await ShellNavigationService.DisplayAlertAsync(
                    Lng.Elem("Steal"),
                    String.Format(Lng.Elem("{0} fumbles the attempt in {1} - and someone notices."), character.Name, Lng.Elem(character.CurrentLocation.GetDescription()))).ConfigureAwait(true);

                await gameEventService.TriggerRandomEncounterAsync(character).ConfigureAwait(true);
                return;
            }

            await ShellNavigationService.DisplayAlertAsync(
                Lng.Elem("Steal"),
                String.Format(Lng.Elem("{0} doesn't find the right moment yet in {1}. Worth trying again."), character.Name, Lng.Elem(character.CurrentLocation.GetDescription()))).ConfigureAwait(true);
            return;
        }

        character.CompleteQuest(quest);
        await characterService.SaveAsync(character).ConfigureAwait(true);

        OnPropertyChanged(nameof(AvailableQuestsHere));
        OnPropertyChanged(nameof(AcceptedQuests));
        OnPropertyChanged(nameof(SearchableQuestsHere));
        OnPropertyChanged(nameof(NegotiableQuestsHere));
        OnPropertyChanged(nameof(HealableQuestsHere));
        OnPropertyChanged(nameof(StealableQuestsHere));
        OnPropertyChanged(nameof(TrapSearchableQuestsHere));

        await ShellNavigationService.DisplayAlertAsync(
            Lng.Elem("Steal"),
            String.Format(
                Lng.Elem("{0} slips away clean! \"{1}\" is complete - {2}{3}."),
                character.Name,
                Lng.Elem(quest.Name),
                quest.MoneyReward.ToTranslatedString(),
                quest.ExperienceReward > 0 ? String.Format(Lng.Elem(" and {0} XP"), quest.ExperienceReward) : String.Empty)).ConfigureAwait(true);
    }

    private bool CanSearchForTraps => (Character?.TrapSearchSkillPercent() ?? 0) > 0;

    /// <summary>
    /// A single trap/secret-door search attempt for a quest whose Quest.TrapLocation matches where
    /// the character is standing right now (see TrapSearchableQuestsHere) - gated on
    /// Character.TrapSearchSkillPercent (the button is disabled without TrapDetection/SecretDoorSearch),
    /// and rolled against that character-specific percent instead of a flat difficulty like Search
    /// uses. A miss usually costs nothing, but per Quest.TrapDangerChance a miss can instead spring
    /// the trap - direct damage rather than an ambush, since a trap going off isn't a random encounter.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanSearchForTraps))]
    private async Task SearchForTrapsAsync(Quest quest)
    {
        if (Character is not { } character || quest == null)
        {
            return;
        }

        var skillPercent = character.TrapSearchSkillPercent();
        var roll = new DiceThrow()._1D100();
        if (roll > skillPercent)
        {
            var dangerRoll = new DiceThrow()._1D100();
            if (dangerRoll <= quest.TrapDangerChance)
            {
                var damage = new DiceThrow()._1D6();
                character.ActualHealthPoints = Math.Max(0, character.ActualHealthPoints - damage);
                await characterService.SaveAsync(character).ConfigureAwait(true);

                await ShellNavigationService.DisplayAlertAsync(
                    Lng.Elem("Search"),
                    String.Format(Lng.Elem("{0} misses it - and springs the trap, taking {1} damage."), character.Name, damage)).ConfigureAwait(true);
                return;
            }

            await ShellNavigationService.DisplayAlertAsync(
                Lng.Elem("Search"),
                String.Format(Lng.Elem("{0} finds nothing in {1} yet. Worth trying again."), character.Name, Lng.Elem(character.CurrentLocation.GetDescription()))).ConfigureAwait(true);
            return;
        }

        character.CompleteQuest(quest);
        await characterService.SaveAsync(character).ConfigureAwait(true);

        OnPropertyChanged(nameof(AvailableQuestsHere));
        OnPropertyChanged(nameof(AcceptedQuests));
        OnPropertyChanged(nameof(SearchableQuestsHere));
        OnPropertyChanged(nameof(NegotiableQuestsHere));
        OnPropertyChanged(nameof(HealableQuestsHere));
        OnPropertyChanged(nameof(StealableQuestsHere));
        OnPropertyChanged(nameof(TrapSearchableQuestsHere));

        await ShellNavigationService.DisplayAlertAsync(
            Lng.Elem("Search"),
            String.Format(
                Lng.Elem("{0} spots it! \"{1}\" is complete - {2}{3}."),
                character.Name,
                Lng.Elem(quest.Name),
                quest.MoneyReward.ToTranslatedString(),
                quest.ExperienceReward > 0 ? String.Format(Lng.Elem(" and {0} XP"), quest.ExperienceReward) : String.Empty)).ConfigureAwait(true);
    }

    [RelayCommand]
    private void ChangeTab(string tabIndex)
    {
        if (!viewCache.TryGetValue(tabIndex, out View? view))
        {
            view = tabIndex switch
            {
                "0" => new CharacterOverviewView(),
                "1" => new AbilitiesView(),
                "2" => new CombatValuesView(),
                "3" => new ArmorsView(),
                "4" => new PlacesView(),

                "5" => new HealthView(),
                "6" => new PsiManaMagicResistanceView(),
                "7" => new QualificationsView(),
                "8" => new EquipmentView(),
                "9" => new CharacterCareView(),
                _ => null
            };

            if (view != null)
            {
                viewCache[tabIndex] = view;
            }
        }

        CurrentView = view;
    }

    private void Equipment_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach (IWeapon weapon in e.NewItems?.OfType<IWeapon>() ?? [])
                {
                    AvailableWeapons.Add(weapon);
                }
                foreach (Armor armor in e.NewItems?.OfType<Armor>() ?? [])
                {
                    AvailableArmors.Add(armor);
                }
                break;

            case NotifyCollectionChangedAction.Remove:
                foreach (IWeapon weapon in e.OldItems?.OfType<IWeapon>() ?? [])
                {
                    AvailableWeapons.Remove(weapon);
                }
                foreach (Armor armor in e.OldItems?.OfType<Armor>() ?? [])
                {
                    AvailableArmors.Remove(armor);
                }
                break;

            case NotifyCollectionChangedAction.Reset:
            case NotifyCollectionChangedAction.Replace:
                RefillAvailableWeapons();
                RefillAvailableArmors();
                break;
        }
    }

    private void RefillAvailableWeapons()
    {
        AvailableWeapons.Clear();
        foreach (var weapon in Character?.Equipment?.OfType<IWeapon>() ?? [])
        {
            AvailableWeapons.Add(weapon);
        }
    }

    private void RefillAvailableArmors()
    {
        AvailableArmors.Clear();
        foreach (var armor in Character?.Equipment?.OfType<Armor>() ?? [])
        {
            AvailableArmors.Add(armor);
        }
    }

    public void Dispose()
    {
        shakeService?.Dispose();
        if (subscribedEquipment != null)
        {
            subscribedEquipment.CollectionChanged -= Equipment_CollectionChanged;
        }

        if (character != null)
        {
            character.PropertyChanged -= Character_PropertyChanged;
        }
    }
}
