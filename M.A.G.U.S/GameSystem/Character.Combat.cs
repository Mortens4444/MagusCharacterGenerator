using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.FightModifiers;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Things.Weapons;
using M.A.G.U.S.Utils;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    private CombatValueModifier selectedCombatValueModifier = Enums.CombatValueModifier.Base;
    private int initiateValue;
    private int attackValue;
    private int defenseValue;
    private int aimValue;
    private int combatValueModifier;
    private string? primaryWeaponId;
    private string? secondaryWeaponId;
    private Weapon? primaryWeapon;
    private Weapon? secondaryWeapon;
    private int totalCombatModifierPool;
    private int totalCurrentlyAllocated;
    private int originalInitiateValue;
    private int originalAttackValue;
    private int originalDefenseValue;
    private int originalAimValue;
    private WeaponFightModifier weaponFightModifier;
    private List<Attack>? attackModes;

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
            RecalculateFightValues(settings);
        }
    }

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
                RecalculateFightValues(settings);
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
                OnPropertyChanged(nameof(PrimaryWeaponId));
                InvalidateAttackModes();
                RecalculateFightValues(settings);
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
                attackModes = [];

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

    public int CombatValueModifier
    {
        get
        {
            return combatValueModifier;
        }
        set
        {
            var newValue = Math.Max(0, value);
            if (combatValueModifier == newValue)
            {
                return;
            }

            combatValueModifier = newValue;
            SetCombatModifierHelperVariables(newValue);
            OnPropertyChanged();
            OnMaxLimitsChanged();
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int OriginalInitiateValue
    {
        get => originalInitiateValue;
        private set
        {
            if (value == 0 && initiateValue > 0)
            {
                return;
            }

            if (originalInitiateValue == value)
            {
                return;
            }

            originalInitiateValue = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(MaxInitiateValue));
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int OriginalAttackValue
    {
        get => originalAttackValue;
        private set
        {
            if (value == 0 && attackValue > 0)
            {
                return;
            }

            if (originalAttackValue == value)
            {
                return;
            }

            originalAttackValue = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(MaxAttackValue));
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int OriginalDefenseValue
    {
        get => originalDefenseValue;
        private set
        {
            if (value == 0 && defenseValue > 0)
            {
                return;
            }

            if (originalDefenseValue == value)
            {
                return;
            }

            originalDefenseValue = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(MaxDefenseValue));
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int OriginalAimValue
    {
        get => originalAimValue;
        private set
        {
            if (value == 0 && aimValue > 0)
            {
                return;
            }

            if (originalAimValue == value)
            {
                return;
            }

            originalAimValue = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(MaxAimValue));
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public bool CanAllocateCombatModifier => CombatValueModifier != 0;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public bool CanAllocateCombatModifierBase => CombatValueModifier == 0 && SelectedCombatValueModifier == Enums.CombatValueModifier.Base;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public bool CanAllocateCombatModifierWithWeapon => CombatValueModifier == 0 && SelectedCombatValueModifier != Enums.CombatValueModifier.Base;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int MaxInitiateValue => InitiateValue + CombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int MaxAttackValue => AttackValue + CombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int MaxDefenseValue => DefenseValue + CombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int MaxAimValue => AimValue + CombatValueModifier;

    public override int InitiateValue
    {
        get => initiateValue;
        set
        {
            if (value == initiateValue)
            {
                return;
            }
            if (OriginalInitiateValue == 0)
            {
                OriginalInitiateValue = value;
            }
            initiateValue = value;
            OnPropertyChanged();

            RecalculateAllocatedCombatModifiers();
        }
    }

    public override int AttackValue
    {
        get => attackValue;
        set
        {
            if (value != attackValue)
            {
                if (OriginalAttackValue == 0)
                {
                    OriginalAttackValue = value;
                }
                attackValue = value;
                OnPropertyChanged();

                RecalculateAllocatedCombatModifiers();
            }
        }
    }

    public override int DefenseValue
    {
        get => defenseValue;
        set
        {
            if (value != defenseValue)
            {
                if (OriginalDefenseValue == 0)
                {
                    OriginalDefenseValue = value;
                }
                defenseValue = value;
                OnPropertyChanged();

                RecalculateAllocatedCombatModifiers();
            }
        }
    }

    public override int AimValue
    {
        get => aimValue;
        set
        {
            if (value != aimValue)
            {
                if (OriginalAimValue == 0)
                {
                    OriginalAimValue = value;
                }
                aimValue = value;
                OnPropertyChanged();

                RecalculateAllocatedCombatModifiers();
            }
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int InitiateValueWithSelectedWeapon => InitiateValue + weaponFightModifier?.InitiateValue ?? 0;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int AttackValueWithSelectedWeapon => AttackValue + weaponFightModifier?.AttackValue ?? 0;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int DefenseValueWithSelectedWeapon => DefenseValue + weaponFightModifier?.DefenseValue ?? 0;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int AimValueWithSelectedWeapon => AimValue + weaponFightModifier?.AimValue ?? 0;

    private void SetPrimaryWeapon()
    {
        if (!String.IsNullOrEmpty(primaryWeaponId))
        {
            primaryWeapon = ResolveWeaponById(primaryWeaponId);
            OnPropertyChanged(nameof(PrimaryWeapon));
            RecalculateFightValues(settings);
        }
    }

    private void SetSecondaryWeapon()
    {
        if (!String.IsNullOrEmpty(secondaryWeaponId))
        {
            secondaryWeapon = ResolveWeaponById(secondaryWeaponId);
            OnPropertyChanged(nameof(SecondaryWeapon));
            RecalculateFightValues(settings);
        }
    }

    private void RecalculateAllocatedCombatModifiers()
    {
        if (isDeserializing)
        {
            return;
        }

        var initiatorAllocated = Math.Max(0, InitiateValue - OriginalInitiateValue);
        var attackAllocated = Math.Max(0, AttackValue - OriginalAttackValue);
        var defenseAllocated = Math.Max(0, DefenseValue - OriginalDefenseValue);
        var aimAllocated = Math.Max(0, AimValue - OriginalAimValue);

        totalCurrentlyAllocated = initiatorAllocated + attackAllocated + defenseAllocated + aimAllocated;

        combatValueModifier = Math.Max(0, totalCombatModifierPool - totalCurrentlyAllocated);

        OnPropertyChanged(nameof(CombatValueModifier));
        OnMaxLimitsChanged();
        OnPropertyChanged(nameof(InitiateValueWithSelectedWeapon));
        OnPropertyChanged(nameof(AttackValueWithSelectedWeapon));
        OnPropertyChanged(nameof(DefenseValueWithSelectedWeapon));
        OnPropertyChanged(nameof(AimValueWithSelectedWeapon));
    }

    private void OnMaxLimitsChanged()
    {
        OnPropertyChanged(nameof(MaxInitiateValue));
        OnPropertyChanged(nameof(MaxAttackValue));
        OnPropertyChanged(nameof(MaxDefenseValue));
        OnPropertyChanged(nameof(MaxAimValue));
    }

    private void CalculateFightValues(ISettings? settings)
    {
        if (BaseClass == null || Race == null)
        {
            return;
        }

        var combatModifiers = new CombatModifier();
        var initiatorRace = Race.SpecialQualifications.GetSpeciality<GoodInitiator>();

        combatModifiers.InitiateValue = initiatorRace != null ? initiatorRace.InitiateBase : BaseClass.InitiateBaseValue;
        combatModifiers.InitiateValue += MathHelper.GetAboveAverageValue(Quickness);
        combatModifiers.InitiateValue += MathHelper.GetAboveAverageValue(Dexterity);
        var headHunterInitiateValueIncreasing = BaseClass.SpecialQualifications.GetSpeciality<HeadHunterInitiateValueIncreasing>();
        if (headHunterInitiateValueIncreasing != null)
        {
            combatModifiers.InitiateValue += BaseClass.Level % 2;
        }
        var thiefInitiateValueIncreasing = BaseClass.SpecialQualifications.GetSpeciality<ThiefInitiateValueIncreasing>();
        if (thiefInitiateValueIncreasing != null)
        {
            combatModifiers.InitiateValue += BaseClass.Level;
        }

        combatModifiers.AttackValue = BaseClass.AttackBaseValue;
        combatModifiers.AttackValue += MathHelper.GetAboveAverageValue(Strength);
        combatModifiers.AttackValue += MathHelper.GetAboveAverageValue(Quickness);
        combatModifiers.AttackValue += MathHelper.GetAboveAverageValue(Dexterity);

        combatModifiers.DefenseValue = BaseClass.DefenseBaseValue;
        combatModifiers.DefenseValue += MathHelper.GetAboveAverageValue(Quickness);
        combatModifiers.DefenseValue += MathHelper.GetAboveAverageValue(Dexterity);

        var archerClass = BaseClass.SpecialQualifications.FirstOrDefault(specialQualification => specialQualification is GoodArcher) as GoodArcher;
        var archerRace = Race.SpecialQualifications.GetSpeciality<GoodArcher>();

        try
        {
            combatModifiers.AimValue = archerClass != null ? archerClass.AimBase :
                archerRace != null ? archerRace.AimBase : BaseClass.AimBaseValue;
            combatModifiers.AimValue += MathHelper.GetAboveAverageValue(Dexterity);
        }
        catch (InvalidOperationException)
        {
            combatModifiers.AimValue = 0;
        }

        var (attackPercentage, defencePercentage, aimingPercentage) = DistributionProvider.Get(BaseClass, Race);
        var levelUpFightModifier = Calculate(settings, BaseClass, attackPercentage, defencePercentage, aimingPercentage);
        combatModifiers.InitiateValue += levelUpFightModifier.InitiateValue;
        combatModifiers.AttackValue += levelUpFightModifier.AttackValue;
        combatModifiers.DefenseValue += levelUpFightModifier.DefenseValue;
        combatModifiers.AimValue += levelUpFightModifier.AimValue;
        combatModifiers.CombatModifierPoints += levelUpFightModifier.CombatModifierPoints;

        OriginalInitiateValue = combatModifiers.InitiateValue;
        OriginalAttackValue = combatModifiers.AttackValue;
        OriginalDefenseValue = combatModifiers.DefenseValue;
        OriginalAimValue = combatModifiers.AimValue;

        CombatValueModifier = Math.Max(0, combatModifiers.CombatModifierPoints);

        InitiateValue = combatModifiers.InitiateValue;
        AttackValue = combatModifiers.AttackValue;
        DefenseValue = combatModifiers.DefenseValue;
        AimValue = combatModifiers.AimValue;
    }

    public void RecalculateFightValues(ISettings? settings)
    {
        CalculateFightValues(settings);
        weaponFightModifier = GetWeaponFightModifier();
        OnPropertyChanged(nameof(InitiateValueWithSelectedWeapon));
        OnPropertyChanged(nameof(AttackValueWithSelectedWeapon));
        OnPropertyChanged(nameof(DefenseValueWithSelectedWeapon));
        OnPropertyChanged(nameof(AimValueWithSelectedWeapon));
        InvalidateAttackModes();
    }

    private WeaponFightModifier GetWeaponFightModifier()
    {
        var result = new WeaponFightModifier();
        var weapon = selectedCombatValueModifier switch
        {
            Enums.CombatValueModifier.PrimaryWeapon => PrimaryWeapon,
            Enums.CombatValueModifier.SecondaryWeapon => SecondaryWeapon,
            _ => null
        };

        if (weapon is IMeleeWeapon melee)
        {
            result.InitiateValue = melee.InitiateValue;
            result.AttackValue = melee.AttackValue;
            result.DefenseValue = melee.DefenseValue;
        }
        else if (weapon is IRangedWeapon ranged)
        {
            result.InitiateValue = ranged.InitiateValue;
            result.AimValue = ranged.AimValue;
        }
        return result;
    }

    private void SetCombatModifierHelperVariables(int combatModifier)
    {
        totalCombatModifierPool = combatModifier;
        totalCurrentlyAllocated = 0;
    }

    private static CombatModifier Calculate(ISettings? settings, IClass @class, int attackPercentage, int defencePercentage, int aimingPercentage)
    {
        var addFightValuesOnFirstLevel = settings?.AddFightValueOnFirstLevelForAllClass ?? true;
        var fightValues = (@class.AddFightValueOnFirstLevel || addFightValuesOnFirstLevel ? @class.Level : @class.Level - 1) * @class.CombatValueModifierPerLevel;

        var autoDistributeCombatValues = settings?.AutoDistributeCombatValues ?? false;
        if (!autoDistributeCombatValues)
        {
            return new CombatModifier()
            {
                CombatModifierPoints = fightValues
            };
        }
        var attackPoints = MathHelper.GetModifier(fightValues, attackPercentage);
        var defencePoints = MathHelper.GetModifier(fightValues, defencePercentage);
        var aimingPoints = MathHelper.GetModifier(fightValues, aimingPercentage);
        var InitiatePoints = fightValues - attackPoints - defencePoints - aimingPoints;
        if (InitiatePoints < 0)
        {
            throw new InvalidOperationException($"The amount of the percentages ({nameof(attackPercentage)} + {nameof(defencePercentage)} + {nameof(aimingPercentage)}) should be under or equal to 100 percent.");
        }

        return new CombatModifier()
        {
            InitiateValue = InitiatePoints,
            AttackValue = attackPoints,
            DefenseValue = defencePoints,
            AimValue = aimingPoints
        };
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
