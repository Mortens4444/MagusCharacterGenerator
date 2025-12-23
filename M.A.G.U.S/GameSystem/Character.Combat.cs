using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Things.Weapons;
using M.A.G.U.S.Things.Weapons.OtherWeapons;
using M.A.G.U.S.Utils;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    private static readonly Fist fist = new();
    private CombatValueModifier selectedCombatValueModifier = Enums.CombatValueModifier.Base;
    private int combatValueModifier;
    private string? primaryWeaponId;
    private string? secondaryWeaponId;
    private Weapon? primaryWeapon;
    private Weapon? secondaryWeapon;
    private List<Attack>? attackModes;

    private int allocatedToInitiate;

    private int allocatedToAttack;

    private int allocatedToDefense;

    private int allocatedToAim;

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public CombatValueModifier SelectedCombatValueModifier
    {
        get => selectedCombatValueModifier;
        set
        {
            if (value == selectedCombatValueModifier)
            {
                return;
            }

            selectedCombatValueModifier = value;
            OnPropertyChanged();
            OnCombatValuesChanged();
        }
    }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public string? PrimaryWeaponId
    {
        get => primaryWeaponId;
        set
        {
            if (primaryWeaponId == value)
            {
                return;
            }

            primaryWeaponId = value;
            OnPropertyChanged();
            SetPrimaryWeapon();
        }
    }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public string? SecondaryWeaponId
    {
        get => secondaryWeaponId;
        set
        {
            if (secondaryWeaponId == value)
            {
                return;
            }

            secondaryWeaponId = value;
            OnPropertyChanged();
            SetSecondaryWeapon();
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public Weapon? PrimaryWeapon
    {
        get => primaryWeapon;
        set
        {
            if (primaryWeapon != value)
            {
                primaryWeapon = value;
                primaryWeaponId = primaryWeapon?.Id;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PrimaryWeaponId));
                InvalidateAttackModes();
            }
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public Weapon? SecondaryWeapon
    {
        get => secondaryWeapon;
        set
        {
            if (secondaryWeapon != value)
            {
                secondaryWeapon = value;
                secondaryWeaponId = secondaryWeapon?.Id;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SecondaryWeaponId));
                InvalidateAttackModes();
            }
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override List<Attack> AttackModes
    {
        get
        {
            if (attackModes == null)
            {
                attackModes = [new MeleeAttack(fist, AttackValue)];

                if (PrimaryWeapon is IMeleeWeapon meleeWeapon)
                {
                    attackModes.Add(new MeleeAttack(meleeWeapon, AttackValue));
                }
                else if (PrimaryWeapon is IRangedWeapon rangedWeapon)
                {
                    attackModes.Add(new RangeAttack(rangedWeapon, AimValue));
                }
            }

            return attackModes;
        }
        protected set => attackModes = value;
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int CombatValueModifierPerLevel => BaseClass.CombatValueModifierPerLevel;

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int CombatValueModifier
    {
        get
        {
            return combatValueModifier;
        }
        set
        {
            if (combatValueModifier == value)
            {
                return;
            }

            combatValueModifier = value;
            OnPropertyChanged();
            OnMaxLimitsChanged();
            OnCombatValuesChanged();
            OnPropertyChanged(nameof(CanAllocateCombatModifier));
        }
    }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int TotalCombatValueModifier { get; set; }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int AllocatedToInitiate { get => allocatedToInitiate; private set => allocatedToInitiate = value; }
    
    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int AllocatedToAttack { get => allocatedToAttack; private set => allocatedToAttack = value; }

    [JsonInclude, Newtonsoft.Json.JsonProperty] 
    public int AllocatedToDefense { get => allocatedToDefense; private set => allocatedToDefense = value; }

    [JsonInclude, Newtonsoft.Json.JsonProperty] 
    public int AllocatedToAim { get => allocatedToAim; private set => allocatedToAim = value; }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int MinInitiateValue { get; private set; }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int MinAttackValue { get; private set; }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int MinDefenseValue { get; private set; }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int MinAimValue { get; private set; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public bool CanAllocateCombatModifier => CombatValueModifier > 0;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int MaxInitiateValue => InitiateValue + CombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int MaxAttackValue => AttackValue + CombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int MaxDefenseValue => DefenseValue + CombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int MaxAimValue => AimValue + CombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int InitiateValue
    {
        get
        {
            var initiatorRace = Race.SpecialQualifications.GetSpeciality<GoodInitiator>();

            var @base = initiatorRace != null ? initiatorRace.InitiateBase : BaseClass.InitiateBaseValue;
            @base += MathHelper.GetAboveAverageValue(Quickness);
            @base += MathHelper.GetAboveAverageValue(Dexterity);
            var headHunterInitiateValueIncreasing = BaseClass.SpecialQualifications.GetSpeciality<HeadHunterInitiateValueIncreasing>();
            if (headHunterInitiateValueIncreasing != null)
            {
                @base += BaseClass.Level % 2;
            }
            var thiefInitiateValueIncreasing = BaseClass.SpecialQualifications.GetSpeciality<ThiefInitiateValueIncreasing>();
            if (thiefInitiateValueIncreasing != null)
            {
                @base += BaseClass.Level;
            }

            var weaponBonus = selectedCombatValueModifier switch
            {
                Enums.CombatValueModifier.PrimaryWeapon when PrimaryWeapon is IWeapon weapon => weapon.InitiateValue,
                Enums.CombatValueModifier.SecondaryWeapon when SecondaryWeapon is IWeapon secondaryWeapon => secondaryWeapon.InitiateValue,
                _ => fist.InitiateValue,
            };

            return @base + AllocatedToInitiate + weaponBonus;
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int AttackValue
    {
        get
        {
            var @base = BaseClass.AttackBaseValue;
            @base += MathHelper.GetAboveAverageValue(Strength);
            @base += MathHelper.GetAboveAverageValue(Quickness);
            @base += MathHelper.GetAboveAverageValue(Dexterity);
            
            var weaponBonus = selectedCombatValueModifier switch
            {
                Enums.CombatValueModifier.PrimaryWeapon when PrimaryWeapon is IMeleeWeapon meleeWeapon => meleeWeapon.AttackValue,
                Enums.CombatValueModifier.SecondaryWeapon when SecondaryWeapon is IMeleeWeapon secondaryMeleeWeapon => secondaryMeleeWeapon.AttackValue,
                _ => fist.AttackValue,
            };

            return @base + AllocatedToAttack + weaponBonus;
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int DefenseValue
    {
        get
        {
            var @base = BaseClass.DefenseBaseValue;
            @base += MathHelper.GetAboveAverageValue(Quickness);
            @base += MathHelper.GetAboveAverageValue(Dexterity);

            var weaponBonus = selectedCombatValueModifier switch
            {
                Enums.CombatValueModifier.PrimaryWeapon when PrimaryWeapon is IMeleeWeapon meleeWeapon => meleeWeapon.DefenseValue,
                Enums.CombatValueModifier.SecondaryWeapon when SecondaryWeapon is IMeleeWeapon secondaryMeleeWeapon => secondaryMeleeWeapon.DefenseValue,
                _ => fist.DefenseValue,
            };

            return @base + AllocatedToDefense + weaponBonus;
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public override int AimValue
    {
        get
        {
            var archerClass = BaseClass.SpecialQualifications.FirstOrDefault(specialQualification => specialQualification is GoodArcher) as GoodArcher;
            var archerRace = Race.SpecialQualifications.GetSpeciality<GoodArcher>();
            var @base = Math.Max(Math.Max(archerClass?.AimBase ?? 0, archerRace?.AimBase ?? 0), BaseClass.AimBaseValue);
            @base += MathHelper.GetAboveAverageValue(Dexterity);
            
            var weaponBonus = selectedCombatValueModifier switch
            {
                Enums.CombatValueModifier.PrimaryWeapon when PrimaryWeapon is IRangedWeapon rangedWeapon => rangedWeapon.AimValue,
                Enums.CombatValueModifier.SecondaryWeapon when SecondaryWeapon is IRangedWeapon secondaryRangedWeapon => secondaryRangedWeapon.AimValue,
                _ => 0,
            };

            return @base + AllocatedToAim + weaponBonus;
        }
    }

    public void ChangeInitiator(int delta) => ChangeAllocation(ref allocatedToInitiate, delta);

    public void ChangeAttack(int delta) => ChangeAllocation(ref allocatedToAttack, delta);

    public void ChangeDefense(int delta) => ChangeAllocation(ref allocatedToDefense, delta);

    public void ChangeAim(int delta) => ChangeAllocation(ref allocatedToAim, delta);

    private void ChangeAllocation(ref int allocated, int delta)
    {
        if (delta == 0)
        {
            return;
        }

        if (delta > 0 && CombatValueModifier < delta)
        {
            return;
        }

        if (delta < 0 && allocated + delta < 0)
        {
            return;
        }

        allocated += delta;
        CombatValueModifier -= delta;
    }

    private void SetPrimaryWeapon()
    {
        if (!String.IsNullOrEmpty(primaryWeaponId))
        {
            primaryWeapon = ResolveWeaponById(primaryWeaponId);
            OnPropertyChanged(nameof(PrimaryWeapon));
        }
    }

    private void SetSecondaryWeapon()
    {
        if (!String.IsNullOrEmpty(secondaryWeaponId))
        {
            secondaryWeapon = ResolveWeaponById(secondaryWeaponId);
            OnPropertyChanged(nameof(SecondaryWeapon));
        }
    }

    private void OnCombatValuesChanged()
    {
        OnPropertyChanged(nameof(InitiateValue));
        OnPropertyChanged(nameof(AttackValue));
        OnPropertyChanged(nameof(DefenseValue));
        OnPropertyChanged(nameof(AimValue));
    }

    private void OnMaxLimitsChanged()
    {
        OnPropertyChanged(nameof(MaxInitiateValue));
        OnPropertyChanged(nameof(MaxAttackValue));
        OnPropertyChanged(nameof(MaxDefenseValue));
        OnPropertyChanged(nameof(MaxAimValue));
    }

    private void CalculateCombatValueModifier(ISettings? settings)
    {
        var (attackPercentage, defencePercentage, aimingPercentage) = DistributionProvider.Get(BaseClass, Race);
        var addCombatValuesOnFirstLevel = settings?.AddCombatValueOnFirstLevelForAllClass ?? true;
        var combatValueModifier = (BaseClass.AddCombatModifierOnFirstLevel || addCombatValuesOnFirstLevel ? BaseClass.Level : BaseClass.Level - 1) * BaseClass.CombatValueModifierPerLevel;

        var autoDistributeCombatValues = settings?.AutoDistributeCombatValues ?? false;
        if (autoDistributeCombatValues)
        {
            AllocatedToAttack = MathHelper.GetModifier(combatValueModifier, attackPercentage);
            AllocatedToDefense = MathHelper.GetModifier(combatValueModifier, defencePercentage);
            AllocatedToAim = MathHelper.GetModifier(combatValueModifier, aimingPercentage);
            AllocatedToInitiate = combatValueModifier - allocatedToAttack - allocatedToDefense - allocatedToAim;
            if (AllocatedToInitiate < 0)
            {
                throw new InvalidOperationException($"The amount of the percentages ({nameof(attackPercentage)} + {nameof(defencePercentage)} + {nameof(aimingPercentage)}) should be under or equal to 100 percent.");
            }
        }
        else
        {
            TotalCombatValueModifier = combatValueModifier;
            int alreadyAllocated = AllocatedToAttack + AllocatedToDefense + AllocatedToAim + AllocatedToInitiate;
            CombatValueModifier = combatValueModifier - alreadyAllocated;
        }
        SetOriginalCombatValues();
    }

    private void SetOriginalCombatValues()
    {
        MinInitiateValue = InitiateValue;
        MinAttackValue = AttackValue;
        MinDefenseValue = DefenseValue;
        MinAimValue = AimValue;
        OnPropertyChanged(nameof(MinInitiateValue));
        OnPropertyChanged(nameof(MinAttackValue));
        OnPropertyChanged(nameof(MinDefenseValue));
        OnPropertyChanged(nameof(MinAimValue));
    }

    [DiceThrow(ThrowType._1D2)]
    public override int GetDamage()
    {
        return fist.GetDamage();
    }

    private Weapon? ResolveWeaponById(string? id)
    {
        if (String.IsNullOrEmpty(id) || Equipment == null)
        {
            return null;
        }

        return Equipment.OfType<Weapon>().FirstOrDefault(weapon => weapon.Id == id);
    }

    private void InvalidateAttackModes()
    {
        attackModes = null;
        OnPropertyChanged(nameof(AttackModes));
    }
}
