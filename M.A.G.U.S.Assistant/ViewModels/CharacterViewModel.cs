using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Things;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.Weapons;
using Mtf.LanguageService.MAUI;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CharacterViewModel(IPrintService printService) : BaseViewModel, IDisposable
{
    private CombatValueModifier selectedCombatValueModifier;
    private Character? character;
    private INotifyCollectionChanged? subscribedEquipment;
    private Weapon? primaryWeapon;
    private Weapon? secondaryWeapon;
    private Armor? selectedArmor;
    private readonly IPrintService printService = printService;
    private static readonly IEnumerable<Alignment> alignments = [.. Enum.GetValues<Alignment>()];

    public IEnumerable<Alignment> Alignments => alignments;

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
            }
        }
    }

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

            SetProperty(ref selectedCombatValueModifier, value?.SelectedCombatValueModifier ?? M.A.G.U.S.Enums.CombatValueModifier.Base, nameof(SelectedCombatValueModifier));
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

            OnPropertyChanged(nameof(AvailableWeapons));
            OnPropertyChanged(nameof(PrimaryWeapon));
            OnPropertyChanged(nameof(SecondaryWeapon));

            OnPropertyChanged(nameof(Race));
            OnPropertyChanged(nameof(Class));
            OnPropertyChanged(nameof(Level));
            OnPropertyChanged(nameof(ExperiencePoints));
            OnPropertyChanged(nameof(PlayerCharacter));
            OnPropertyChanged(nameof(Alignment));

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

            OnPropertyChanged(nameof(CanAllocateCombatModifier));
            OnPropertyChanged(nameof(MaxInitiateValue));
            OnPropertyChanged(nameof(InitiateValue));

            OnPropertyChanged(nameof(MaxAttackValue));
            OnPropertyChanged(nameof(AttackValue));

            OnPropertyChanged(nameof(MaxDefenseValue));
            OnPropertyChanged(nameof(DefenseValue));

            OnPropertyChanged(nameof(MaxAimValue));
            OnPropertyChanged(nameof(AimValue));
            
            OnPropertyChanged(nameof(CombatValueModifier));
            OnPropertyChanged(nameof(CombatValueModifierPerLevel));

            OnPropertyChanged(nameof(MaxPsiPoints));
            OnPropertyChanged(nameof(PsiPoints));
            OnPropertyChanged(nameof(PsiPointsModifier));

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

            OnPropertyChanged(nameof(ArmorClass));
            OnPropertyChanged(nameof(ArmorCheckPenalty));

            OnPropertyChanged(nameof(Equipment));
            OnPropertyChanged(nameof(TotalEquipmentWeight));
        }
    }

    private void Character_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(Character.CanAllocateCombatModifier):
                OnPropertyChanged(nameof(CanAllocateCombatModifier));
                IncrementInitiatorCommand.NotifyCanExecuteChanged();
                DecrementInitiatorCommand.NotifyCanExecuteChanged();
                IncrementAttackCommand.NotifyCanExecuteChanged();
                DecrementAttackCommand.NotifyCanExecuteChanged();
                IncrementDefenseCommand.NotifyCanExecuteChanged();
                DecrementDefenseCommand.NotifyCanExecuteChanged();
                IncrementAimCommand.NotifyCanExecuteChanged();
                DecrementAimCommand.NotifyCanExecuteChanged();
                break;

            case nameof(Character.CombatValueModifier):
                OnPropertyChanged(nameof(CombatValueModifier));
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

    public int ExperiencePoints => Character?.BaseClass?.ExperiencePoints ?? 0;

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

    public int ArmorClass => Character?.Armor?.ArmorClass ?? 0;
    public int ArmorCheckPenalty => Character?.Armor?.ArmorCheckPenalty ?? 0;

    public int CombatValueModifier => Character?.CombatValueModifier ?? 0;
    public int CombatValueModifierPerLevel => Character?.CombatValueModifierPerLevel ?? 0;
    public bool CanAllocateCombatModifier => Character?.CanAllocateCombatModifier ?? false;
    
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

    public int MaxPsiPoints => Character?.MaxPsiPoints ?? 0;
    public int PsiPoints => Character?.PsiPoints ?? 0;
    public int PsiPointsModifier => Character?.PsiPointsModifier ?? 0;

    public int MaxManaPoints => Character?.MaxManaPoints ?? 0;
    public int ManaPoints => Character?.ManaPoints ?? 0;
    public int MaxManaPointsPerLevel => Character?.MaxManaPointsPerLevel ?? 0;

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

    public string PainToleranceModifierFormula
    {
        get
        {
            var formula = Character?.BaseClass?.GetPainToleranceModifierFormula();
            return formula?.GetDisplayFormula() ?? String.Empty;
        }
    }

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void IncrementInitiator() => Character?.ChangeInitiator(1);

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void DecrementInitiator() => Character?.ChangeInitiator(-1);

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void IncrementAttack() => Character?.ChangeAttack(1);

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void DecrementAttack() => Character?.ChangeAttack(-1);

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void IncrementDefense() => Character?.ChangeDefense(1);

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void DecrementDefense() => Character?.ChangeDefense(-1);

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void IncrementAim() => Character?.ChangeAim(1);

    [RelayCommand(CanExecute = nameof(CanAllocateCombatModifier))]
    public void DecrementAim() => Character?.ChangeAim(-1);

    [RelayCommand]
    public async Task Print()
    {
        if (Character == null)
        {
            return;
        }

        var answer = await Shell.Current.DisplayAlertAsync(Lng.Elem("Print"), Lng.Elem("Do you want to print character sheet?"), Lng.Elem("Yes"), Lng.Elem("No")).ConfigureAwait(false);
        if (answer)
        {
            var htmlService = new CharacterHtmlService();
            var htmlContent = htmlService.GenerateCharacterHtml(Character);
            await printService.PrintHtmlAsync(htmlContent, $"M.A.G.U.S. - {Character.Name}").ConfigureAwait(false);
        }
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
                break;

            case NotifyCollectionChangedAction.Remove:
                foreach (IWeapon weapon in e.OldItems?.OfType<IWeapon>() ?? [])
                {
                    AvailableWeapons.Remove(weapon);
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
        if (Character?.Equipment != null)
        {
            foreach (var item in Character.Equipment)
            {
                if (item is Armor armor)
                {
                    AvailableArmors.Add(armor);
                }
            }
        }
    }

    public void Dispose()
    {
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
