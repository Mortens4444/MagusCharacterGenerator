using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Things;
using M.A.G.U.S.Things.Weapons;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Versioning;

namespace M.A.G.U.S.Assistant.ViewModels;

[SupportedOSPlatform("windows10.0.17763")]
internal partial class CharacterViewModel : BaseViewModel
{
    private CombatValueModifier selectedCombatValueModifier;
    private Character? character;
    private INotifyCollectionChanged? subscribedEquipment;
    private Weapon? primaryWeapon;
    private Weapon? secondaryWeapon;
    private static readonly IEnumerable<Alignment> alignments = [.. Enum.GetValues<Alignment>()];

    public IEnumerable<Alignment> Alignments => alignments;

    public ObservableCollection<CombatValueModifier> AvailableCombatValueModifiers { get; } = [.. Enum.GetValues<CombatValueModifier>()];

    public ObservableCollection<IWeapon> AvailableWeapons { get; } = [];

    public CombatValueModifier SelectedCombatValueModifier
    {
        get => selectedCombatValueModifier;
        set
        {
            if (SetProperty(ref selectedCombatValueModifier, value))
            {
                if (Character != null)
                {
                    Character.SelectedCombatValueModifier = value;
                }
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
                if (Character != null)
                {
                    Character.PrimaryWeapon = value;
                }
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
                if (Character != null)
                {
                    Character.SecondaryWeapon = value;
                }
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

            SetProperty(ref character, value);
            SetProperty(ref selectedCombatValueModifier, value?.SelectedCombatValueModifier ?? M.A.G.U.S.Enums.CombatValueModifier.Base, nameof(SelectedCombatValueModifier));
            SetProperty(ref primaryWeapon, value?.PrimaryWeapon, nameof(PrimaryWeapon));
            SetProperty(ref secondaryWeapon, value?.SecondaryWeapon, nameof(SecondaryWeapon));

            if (character?.Equipment is INotifyCollectionChanged nc)
            {
                subscribedEquipment = nc;
                subscribedEquipment.CollectionChanged += Equipment_CollectionChanged;
            }

            RefillAvailableWeapons();

            primaryWeapon = Character?.PrimaryWeapon;
            secondaryWeapon = Character?.SecondaryWeapon;

            OnPropertyChanged(nameof(AvailableWeapons));
            OnPropertyChanged(nameof(PrimaryWeapon));
            OnPropertyChanged(nameof(SecondaryWeapon));

            OnPropertyChanged(nameof(Race));
            OnPropertyChanged(nameof(Class));
            OnPropertyChanged(nameof(Level));
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
            OnPropertyChanged(nameof(HealthPoints));
            OnPropertyChanged(nameof(MaxPainTolerancePoints));
            OnPropertyChanged(nameof(PainTolerancePoints));
            OnPropertyChanged(nameof(PainToleranceModifierFormula));

            OnPropertyChanged(nameof(CanAllocateCombatModifierBase));
            OnPropertyChanged(nameof(CanAllocateCombatModifierWithWeapon));
            OnPropertyChanged(nameof(CanAllocateCombatModifier));
            OnPropertyChanged(nameof(OriginalInitiateValue));
            OnPropertyChanged(nameof(MaxInitiateValue));
            OnPropertyChanged(nameof(InitiateValue));
            OnPropertyChanged(nameof(InitiateValueWithSelectedWeapon));

            OnPropertyChanged(nameof(OriginalAttackValue));
            OnPropertyChanged(nameof(MaxAttackValue));
            OnPropertyChanged(nameof(AttackValue));
            OnPropertyChanged(nameof(AttackValueWithSelectedWeapon));

            OnPropertyChanged(nameof(OriginalDefenseValue));
            OnPropertyChanged(nameof(MaxDefenseValue));
            OnPropertyChanged(nameof(DefenseValue));
            OnPropertyChanged(nameof(DefenseValueWithSelectedWeapon));

            OnPropertyChanged(nameof(OriginalAimValue));
            OnPropertyChanged(nameof(MaxAimValue));
            OnPropertyChanged(nameof(AimValue));
            OnPropertyChanged(nameof(AimValueWithSelectedWeapon));
            
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

            OnPropertyChanged(nameof(Equipment));
            OnPropertyChanged(nameof(TotalEquipmentWeight));
        }
    }

    public string Race => Character?.RaceName ?? String.Empty;

    public string Class => Character?.Class ?? String.Empty;

    public int Level => Character?.Level ?? 1;

    public bool PlayerCharacter => Character?.PlayerCharacter ?? false;

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
    public int HealthPoints => Character?.HealthPoints ?? 0;
    public int MaxPainTolerancePoints => Character?.MaxPainTolerancePoints ?? 0;
    public int PainTolerancePoints => Character?.PainTolerancePoints ?? 0;
    
    public int CombatValueModifier => Character?.CombatValueModifier ?? 0;
    public int CombatValueModifierPerLevel => Character?.CombatValueModifierPerLevel ?? 0;
    public bool CanAllocateCombatModifier => Character?.CanAllocateCombatModifier ?? false;
    public bool CanAllocateCombatModifierBase => Character?.CanAllocateCombatModifierBase ?? false;
    public bool CanAllocateCombatModifierWithWeapon => Character?.CanAllocateCombatModifierWithWeapon ?? false;
    public int OriginalInitiateValue => Character?.OriginalInitiateValue ?? 0;
    public int MaxInitiateValue => Character?.MaxInitiateValue ?? 0;
    public int InitiateValue => Character?.InitiateValue ?? 0;
    public int InitiateValueWithSelectedWeapon => Character?.InitiateValueWithSelectedWeapon ?? 0;
    public int OriginalAttackValue => Character?.OriginalAttackValue ?? 0;
    public int MaxAttackValue => Character?.MaxAttackValue ?? 0;
    public int AttackValue => Character?.AttackValue ?? 0;
    public int AttackValueWithSelectedWeapon => Character?.AttackValueWithSelectedWeapon ?? 0;
    public int OriginalDefenseValue => Character?.OriginalDefenseValue ?? 0;
    public int MaxDefenseValue => Character?.MaxDefenseValue ?? 0;
    public int DefenseValue => Character?.DefenseValue ?? 0;
    public int DefenseValueWithSelectedWeapon => Character?.DefenseValueWithSelectedWeapon ?? 0;
    public int OriginalAimValue => Character?.OriginalAimValue ?? 0;
    public int MaxAimValue => Character?.MaxAimValue ?? 0;
    public int AimValue => Character?.AimValue ?? 0;
    public int AimValueWithSelectedWeapon => Character?.AimValueWithSelectedWeapon ?? 0;

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

    private void Equipment_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) => RefillAvailableWeapons();
    
    private void RefillAvailableWeapons()
    {
        AvailableWeapons.Clear();
        foreach (var weapon in Character?.Equipment?.OfType<IWeapon>() ?? [])
        {
            AvailableWeapons.Add(weapon);
        }
    }
}
