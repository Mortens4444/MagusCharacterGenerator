using CommunityToolkit.Mvvm.Input;
using MAGUS.Assistant.Extensions;
using MAGUS.Assistant.Interfaces;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.Views;
using MAGUS.Enums;
using MAGUS.Extensions;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Magic;
using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Psi;
using MAGUS.Interfaces;
using MAGUS.Models;
using MAGUS.Qualifications;
using MAGUS.Services;
using MAGUS.Things;
using MAGUS.Things.Armors;
using MAGUS.Things.Weapons;
using Mtf.Extensions;
using Mtf.LanguageService;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;

namespace MAGUS.Assistant.ViewModels;

internal partial class CharacterViewModel(IPrintService printService, ISoundPlayer soundPlayer, IShakeService shakeService, ISettings settings, CharacterService characterService, SettingsService settingsService) : BaseViewModel, IDisposable
{
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

            SetProperty(ref character, value);

            if (character != null)
            {
                character.PropertyChanged += Character_PropertyChanged;
            }

            SetProperty(ref selectedCombatValueModifier, value?.SelectedCombatValueModifier ?? MAGUS.Enums.CombatValueModifier.Base, nameof(SelectedCombatValueModifier));
            SetProperty(ref primaryWeapon, value?.PrimaryWeapon, nameof(PrimaryWeapon));
            SetProperty(ref secondaryWeapon, value?.SecondaryWeapon, nameof(SecondaryWeapon));
            SetProperty(ref selectedArmor, value?.Armor, nameof(SelectedArmor));

            if (character?.Equipment is INotifyCollectionChanged nc)
            {
                subscribedEquipment = nc;
                subscribedEquipment.CollectionChanged += Equipment_CollectionChanged;
            }

            RefillAvailableWeapons();
            RefillAvailableArmors();

            OnPropertyChanged(nameof(AvailableArmors));
            OnPropertyChanged(nameof(AvailableWeapons));
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
            OnPropertyChanged(nameof(HasMagic));
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
            EatCommand.NotifyCanExecuteChanged();
            CastSpellCommand.NotifyCanExecuteChanged();
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
            if (Character?.PrimaryWeapon != null && Character.SelectedCombatValueModifier == MAGUS.Enums.CombatValueModifier.PrimaryWeapon)
            {
                customAttributes = Character.PrimaryWeapon.GetType().GetMethod(nameof(Character.PrimaryWeapon.GetDamage))?.GetCustomAttributes(false);
                formula = customAttributes.GetDiceThrowFormula();
                return formula?.GetDisplayFormula() ?? String.Empty;
            }
            if (Character?.SecondaryWeapon != null && Character.SelectedCombatValueModifier == MAGUS.Enums.CombatValueModifier.SecondaryWeapon)
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

    public bool HasPsi => Character?.Psi != null;
    public bool HasMagic => Character?.Sorcery != null || Character?.Psi != null;
    public int MaxPsiPoints => Character?.MaxPsiPoints ?? 0;
    public int PsiPoints => Character?.PsiPoints ?? 0;
    public int PsiPointsModifier => Character?.PsiPointsModifier ?? 0;

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

    [RelayCommand(CanExecute = nameof(CanSleepOrEat))]
    private async Task SleepAsync()
    {
        if (Character is not { } character)
        {
            return;
        }

        await CharacterCareActions.SleepAsync(character, settingsService, characterService).ConfigureAwait(true);
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

    private bool CanCastSpell => Character is { } c && (c.Sorcery != null || c.Psi != null) && c.IsConscious;

    /// <summary>
    /// Casts a Mana spell or Psi discipline outside of combat - on this character or another saved
    /// one - via CombatEngine.CastOutsideCombatAsync, which reuses the same resolution rules a real
    /// Encounter turn would (hit roll against magic resistance, HP-vs-FP routing, the spell/discipline's
    /// own OnHit). Lets a conscious character use a healing spell on an unconscious ally (or
    /// themselves, before things get that bad).
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

        if (caster.Psi != null)
        {
            foreach (var discipline in PsiDisciplineCatalog.GetAvailable(caster))
            {
                if (caster.PsiPoints < discipline.PsiPointCost)
                {
                    continue;
                }

                options.Add((discipline.Name, new PsiAttack(discipline)));
            }
        }

        if (options.Count == 0)
        {
            await ShellNavigationService.DisplayAlertAsync(Lng.Elem("No affordable spell or psi discipline to cast right now.")).ConfigureAwait(true);
            return;
        }

        var spellChoice = await ShellNavigationService.DisplayActionSheetAsync(
            "Cast spell",
            "Cancel",
            null,
            [.. options.Select(o => o.Name)]).ConfigureAwait(true);

        var chosen = options.FirstOrDefault(o => o.Name == spellChoice);
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

        await ShellNavigationService.DisplayAlertAsync(
            "Cast spell",
            hit
                ? String.Format(Lng.Elem("{0} successfully casts {1} on {2}."), caster.Name, Lng.Elem(chosen.Name), target.Name)
                : String.Format(Lng.Elem("{0}'s {1} fails to affect {2}."), caster.Name, Lng.Elem(chosen.Name), target.Name)).ConfigureAwait(true);
    }

    private bool CanTravel => Character != null;

    /// <summary>
    /// Lets the player move this character to a different city: pick a destination, pick a
    /// transport mode, see the computed travel time (TravelCalculator.CalculateDays, built on the
    /// fixed CityCoordinates distance data - see Places/CityCoordinates.cs), confirm, then
    /// CurrentLocation updates and the character saves.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanTravel))]
    private async Task TravelAsync()
    {
        if (Character is not { } character)
        {
            return;
        }

        var destinationsByName = Cities
            .Where(c => c != character.CurrentLocation)
            .ToDictionary(c => c.GetDescription(), c => c);

        var destinationChoice = await ShellNavigationService.DisplayActionSheetAsync(
            "Travel",
            "Cancel",
            null,
            [.. destinationsByName.Keys]).ConfigureAwait(true);

        if (destinationChoice is null || !destinationsByName.TryGetValue(destinationChoice, out var destination))
        {
            return;
        }

        var modeChoice = await ShellNavigationService.DisplayActionSheetAsync(
            "Travel mode",
            "Cancel",
            null,
            [.. Enum.GetValues<TransportMode>().Select(m => m.ToString())]).ConfigureAwait(true);

        if (modeChoice is null || !Enum.TryParse<TransportMode>(modeChoice, out var mode))
        {
            return;
        }

        var days = TravelCalculator.CalculateDays(character.CurrentLocation, destination, mode, character);

        var confirm = await ShellNavigationService.DisplayAlertAsync(
            "Travel",
            String.Format(
                Lng.Elem("Traveling from {0} to {1} by {2} will take about {3:F1} days. Travel now?"),
                Lng.Elem(character.CurrentLocation.GetDescription()),
                Lng.Elem(destination.GetDescription()),
                Lng.Elem(mode.ToString()),
                days),
            Lng.Elem("Travel"),
            Lng.Elem("Cancel")).ConfigureAwait(true);

        if (!confirm)
        {
            return;
        }

        character.CurrentLocation = destination;
        await characterService.SaveAsync(character).ConfigureAwait(false);
    }

    [RelayCommand]
    private void ChangeTab(string tabIndex)
    {
        if (!viewCache.TryGetValue(tabIndex, out View? view))
        {
            view = tabIndex switch
            {
                "0" => new VerticalStackLayout
                {
                    Spacing = 15,
                    Children = { new CharacterOverviewView(), new HealthView() }
                },
                "1" => new AbilitiesView(),
                "2" => new CombatValuesView(),
                "3" => new PsiManaMagicResistanceView(),
                "4" => new QualificationsView(),
                "5" => new EquipmentView(),
                "6" => new CharacterCareView(),
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
