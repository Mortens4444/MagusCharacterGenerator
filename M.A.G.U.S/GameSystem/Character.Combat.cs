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
    private CombatValueModifier selectedCombatValueModifier = CombatValueModifier.Base;
    private int initiatingValue;
    private int attackValue;
    private int defenseValue;
    private int? aimingValue;
    private string? primaryWeaponId;
    private string? secondaryWeaponId;
    private Weapon? primaryWeapon;
    private Weapon? secondaryWeapon;
    private int totalCombatModifierPool;
    private int totalCurrentlyAllocated;
    private int initiatingValueOriginal;
    private int attackingValueOriginal;
    private int defendingValueOriginal;
    private int? aimingValueOriginal;
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

    private void SetPrimaryWeapon()
    {
        if (!String.IsNullOrEmpty(primaryWeaponId))
        {
            primaryWeapon = ResolveWeaponById(primaryWeaponId);
            OnPropertyChanged(nameof(PrimaryWeapon));
            RecalculateFightValues(settings);
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

    private void SetSecondaryWeapon()
    {
        if (!String.IsNullOrEmpty(secondaryWeaponId))
        {
            secondaryWeapon = ResolveWeaponById(secondaryWeaponId);
            OnPropertyChanged(nameof(SecondaryWeapon));
            RecalculateFightValues(settings);
        }
    }

    [JsonIgnore]
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

    [JsonIgnore]
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
                    attackModes.Add(new RangeAttack(rangedWeapon, AimingValue.Value));
                }
            }

            return attackModes;
        }
        protected set => attackModes = value;
    }

    public int FightValueModifier => BaseClass.FightValueModifier;

    private int combatModifier;
    public int CombatModifier
    {
        get
        {
            return combatModifier;
        }
        set
        {
            var newValue = Math.Max(0, value);
            if (combatModifier == newValue)
            {
                return;
            }

            combatModifier = newValue;
            SetCombatModifierHelperVariables(newValue);
            OnPropertyChanged();
            OnMaxLimitsChanged();
        }
    }

    public int InitiatingValueOriginal
    {
        get => initiatingValueOriginal;
        private set
        {
            if (value == 0 && initiatingValue > 0)
            {
                return;
            }

            if (initiatingValueOriginal == value)
            {
                return;
            }

            initiatingValueOriginal = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(InitiatingValueMaxLimit));
        }
    }

    public int AttackingValueOriginal
    {
        get => attackingValueOriginal;
        private set
        {
            if (value == 0 && attackValue > 0)
            {
                return;
            }

            if (attackingValueOriginal == value)
            {
                return;
            }

            attackingValueOriginal = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(AttackingValueMaxLimit));
        }
    }

    public int DefendingValueOriginal
    {
        get => defendingValueOriginal;
        private set
        {
            if (value == 0 && defenseValue > 0)
            {
                return;
            }

            if (defendingValueOriginal == value)
            {
                return;
            }

            defendingValueOriginal = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(DefendingValueMaxLimit));
        }
    }
    public int? AimingValueOriginal
    {
        get => aimingValueOriginal;
        private set
        {
            if (value == 0 && aimingValue > 0)
            {
                return;
            }

            if (aimingValueOriginal == value)
            {
                return;
            }

            aimingValueOriginal = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(AimingValueMaxLimit));
        }
    }

    public bool CanAllocateCombatModifier => CombatModifier != 0;

    public bool CanAllocateCombatModifierBase => CombatModifier == 0 && SelectedCombatValueModifier == CombatValueModifier.Base;

    public bool CanAllocateCombatModifierWithWeapon => CombatModifier == 0 && SelectedCombatValueModifier != CombatValueModifier.Base;

    public int InitiatingValueMaxLimit => InitiatingValue + CombatModifier;

    public int AttackingValueMaxLimit => AttackValue + CombatModifier;

    public int DefendingValueMaxLimit => DefenseValue + CombatModifier;

    public int? AimingValueMaxLimit => AimingValue + CombatModifier;

    public override int InitiatingValue
    {
        get => initiatingValue;
        set
        {
            if (value == initiatingValue)
            {
                return;
            }
            if (InitiatingValueOriginal == 0)
            {
                InitiatingValueOriginal = value;
            }
            initiatingValue = value;
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
                if (AttackingValueOriginal == 0)
                {
                    AttackingValueOriginal = value;
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
                if (DefendingValueOriginal == 0)
                {
                    DefendingValueOriginal = value;
                }
                defenseValue = value;
                OnPropertyChanged();

                RecalculateAllocatedCombatModifiers();
            }
        }
    }

    public override int? AimingValue
    {
        get => aimingValue;
        set
        {
            if (value != aimingValue)
            {
                if (AimingValueOriginal == 0)
                {
                    AimingValueOriginal = value;
                }
                aimingValue = value;
                OnPropertyChanged();

                RecalculateAllocatedCombatModifiers();
            }
        }
    }

    public int InitiatingValueWithSelectedWeapon => InitiatingValue + weaponFightModifier?.InitiatingValue ?? 0;
    public int AttackingValueWithSelectedWeapon => AttackValue + weaponFightModifier?.AttackValue ?? 0;
    public int DefendingValueWithSelectedWeapon => DefenseValue + weaponFightModifier?.DefenseValue ?? 0;
    public int AimingValueWithSelectedWeapon => AimingValue + weaponFightModifier?.AimingValue ?? 0;

    private void RecalculateAllocatedCombatModifiers()
    {
        var initiatorAllocated = Math.Max(0, InitiatingValue - InitiatingValueOriginal);
        var attackAllocated = Math.Max(0, AttackValue - AttackingValueOriginal);
        var defenseAllocated = Math.Max(0, DefenseValue - DefendingValueOriginal);
        var aimAllocated = Math.Max(0, AimingValue.Value - AimingValueOriginal.Value);

        totalCurrentlyAllocated = initiatorAllocated + attackAllocated + defenseAllocated + aimAllocated;

        combatModifier = Math.Max(0, totalCombatModifierPool - totalCurrentlyAllocated);

        OnPropertyChanged(nameof(CombatModifier));
        OnMaxLimitsChanged();
        OnPropertyChanged(nameof(InitiatingValueWithSelectedWeapon));
        OnPropertyChanged(nameof(AttackingValueWithSelectedWeapon));
        OnPropertyChanged(nameof(DefendingValueWithSelectedWeapon));
        OnPropertyChanged(nameof(AimingValueWithSelectedWeapon));
    }

    private void OnMaxLimitsChanged()
    {
        OnPropertyChanged(nameof(InitiatingValueMaxLimit));
        OnPropertyChanged(nameof(AttackingValueMaxLimit));
        OnPropertyChanged(nameof(DefendingValueMaxLimit));
        OnPropertyChanged(nameof(AimingValueMaxLimit));
    }

    private void CalculateFightValues(ISettings? settings)
    {
        if (BaseClass == null || Race == null)
        {
            return;
        }

        var fightModifiers = new FightModifier();
        var initiatorRace = Race.SpecialQualifications.GetSpeciality<GoodInitiator>();

        fightModifiers.InitiatingValue = initiatorRace != null ? initiatorRace.InitiatingBase : BaseClass.InitiatingBaseValue;
        fightModifiers.InitiatingValue += MathHelper.GetAboveAverageValue(Quickness);
        fightModifiers.InitiatingValue += MathHelper.GetAboveAverageValue(Dexterity);
        var headHunterInitiatingValueIncreasing = BaseClass.SpecialQualifications.GetSpeciality<HeadHunterInitiatingValueIncreasing>();
        if (headHunterInitiatingValueIncreasing != null)
        {
            fightModifiers.InitiatingValue += BaseClass.Level % 2;
        }
        var thiefInitiatingValueIncreasing = BaseClass.SpecialQualifications.GetSpeciality<ThiefInitiatingValueIncreasing>();
        if (thiefInitiatingValueIncreasing != null)
        {
            fightModifiers.InitiatingValue += BaseClass.Level;
        }

        fightModifiers.AttackValue = BaseClass.AttackingBaseValue;
        fightModifiers.AttackValue += MathHelper.GetAboveAverageValue(Strength);
        fightModifiers.AttackValue += MathHelper.GetAboveAverageValue(Quickness);
        fightModifiers.AttackValue += MathHelper.GetAboveAverageValue(Dexterity);

        fightModifiers.DefenseValue = BaseClass.DefendingBaseValue;
        fightModifiers.DefenseValue += MathHelper.GetAboveAverageValue(Quickness);
        fightModifiers.DefenseValue += MathHelper.GetAboveAverageValue(Dexterity);

        var archerClass = BaseClass.SpecialQualifications.FirstOrDefault(specialQualification => specialQualification is GoodArcher) as GoodArcher;
        var archerRace = Race.SpecialQualifications.GetSpeciality<GoodArcher>();

        try
        {
            fightModifiers.AimingValue = archerClass != null ? archerClass.AimingBase :
                archerRace != null ? archerRace.AimingBase : BaseClass.AimingBaseValue;
            fightModifiers.AimingValue += MathHelper.GetAboveAverageValue(Dexterity);
        }
        catch (InvalidOperationException)
        {
            fightModifiers.AimingValue = 0;
        }

        var (attackPercentage, defencePercentage, aimingPercentage) = DistributionProvider.Get(BaseClass, Race);
        var levelUpFightModifier = Calculate(settings, BaseClass, attackPercentage, defencePercentage, aimingPercentage);
        fightModifiers.InitiatingValue += levelUpFightModifier.InitiatingValue;
        fightModifiers.AttackValue += levelUpFightModifier.AttackValue;
        fightModifiers.DefenseValue += levelUpFightModifier.DefenseValue;
        fightModifiers.AimingValue += levelUpFightModifier.AimingValue;
        fightModifiers.CombatModifier += levelUpFightModifier.CombatModifier;

        InitiatingValueOriginal = fightModifiers.InitiatingValue;
        AttackingValueOriginal = fightModifiers.AttackValue;
        DefendingValueOriginal = fightModifiers.DefenseValue;
        AimingValueOriginal = fightModifiers.AimingValue;

        CombatModifier = Math.Max(0, fightModifiers.CombatModifier);

        InitiatingValue = fightModifiers.InitiatingValue;
        AttackValue = fightModifiers.AttackValue;
        DefenseValue = fightModifiers.DefenseValue;
        AimingValue = fightModifiers.AimingValue;
    }

    public void RecalculateFightValues(ISettings? settings)
    {
        CalculateFightValues(settings);
        weaponFightModifier = GetWeaponFightModifier();
        OnPropertyChanged(nameof(InitiatingValueWithSelectedWeapon));
        OnPropertyChanged(nameof(AttackingValueWithSelectedWeapon));
        OnPropertyChanged(nameof(DefendingValueWithSelectedWeapon));
        OnPropertyChanged(nameof(AimingValueWithSelectedWeapon));
        InvalidateAttackModes();
    }

    private WeaponFightModifier GetWeaponFightModifier()
    {
        var result = new WeaponFightModifier();
        var weapon = selectedCombatValueModifier switch
        {
            CombatValueModifier.PrimaryWeapon => PrimaryWeapon,
            CombatValueModifier.SecondaryWeapon => SecondaryWeapon,
            _ => null
        };

        if (weapon is IMeleeWeapon melee)
        {
            result.InitiatingValue = melee.InitiatingValue;
            result.AttackValue = melee.AttackingValue;
            result.DefenseValue = melee.DefendingValue;
        }
        else if (weapon is IRangedWeapon ranged)
        {
            result.InitiatingValue = ranged.InitiatingValue;
            result.AimingValue = ranged.AimingValue;
        }
        return result;
    }

    private void SetCombatModifierHelperVariables(int combatModifier)
    {
        totalCombatModifierPool = combatModifier;
        totalCurrentlyAllocated = 0;
    }

    private static FightModifier Calculate(ISettings? settings, IClass @class, int attackPercentage, int defencePercentage, int aimingPercentage)
    {
        var addFightValuesOnFirstLevel = settings?.AddFightValueOnFirstLevelForAllClass ?? true;
        var fightValues = (@class.AddFightValueOnFirstLevel || addFightValuesOnFirstLevel ? @class.Level : @class.Level - 1) * @class.FightValueModifier;

        var autoDistributeCombatValues = settings?.AutoDistributeCombatValues ?? false;
        if (!autoDistributeCombatValues)
        {
            return new FightModifier()
            {
                CombatModifier = fightValues
            };
        }
        var attackPoints = MathHelper.GetModifier(fightValues, attackPercentage);
        var defencePoints = MathHelper.GetModifier(fightValues, defencePercentage);
        var aimingPoints = MathHelper.GetModifier(fightValues, aimingPercentage);
        var initiatorPoints = fightValues - attackPoints - defencePoints - aimingPoints;
        if (initiatorPoints < 0)
        {
            throw new InvalidOperationException($"The amount of the percentages ({nameof(attackPercentage)} + {nameof(defencePercentage)} + {nameof(aimingPercentage)}) should be under or equal to 100 percent.");
        }

        return new FightModifier()
        {
            InitiatingValue = initiatorPoints,
            AttackValue = attackPoints,
            DefenseValue = defencePoints,
            AimingValue = aimingPoints
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
