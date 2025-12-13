using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.FightModifiers;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Things.Weapons;
using M.A.G.U.S.Utils;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    private CombatValueModifier selectedCombatValueModifier = CombatValueModifier.Base;
    private int initiatingValue;
    private int attackingValue;
    private int defendingValue;
    private int aimingValue;
    private Weapon? primaryWeapon;
    private Weapon? secondaryWeapon;
    private int totalCombatModifierPool;
    private int totalCurrentlyAllocated;
    private int initiatingValueOriginal;
    private int attackingValueOriginal;
    private int defendingValueOriginal;
    private int aimingValueOriginal;
    private WeaponFightModifier weaponFightModifier;

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

    public Weapon? PrimaryWeapon
    {
        get => primaryWeapon;
        set
        {
            if (primaryWeapon != value)
            {
                primaryWeapon = value;
                OnPropertyChanged();
                RecalculateFightValues(settings);
            }
        }
    }

    public Weapon? SecondaryWeapon
    {
        get => secondaryWeapon;
        set
        {
            if (secondaryWeapon != value)
            {
                secondaryWeapon = value;
                OnPropertyChanged();
                RecalculateFightValues(settings);
            }
        }
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
            if (value == 0 && attackingValue > 0)
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
            if (value == 0 && defendingValue > 0)
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
    public int AimingValueOriginal
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

    public int InitiatingValueMaxLimit => InitiatingValue + CombatModifier;

    public int AttackingValueMaxLimit => AttackingValue + CombatModifier;

    public int DefendingValueMaxLimit => DefendingValue + CombatModifier;

    public int AimingValueMaxLimit => AimingValue + CombatModifier;

    public int InitiatingValue
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

    public int AttackingValue
    {
        get => attackingValue;
        set
        {
            if (value != attackingValue)
            {
                if (AttackingValueOriginal == 0)
                {
                    AttackingValueOriginal = value;
                }
                attackingValue = value;
                OnPropertyChanged();

                RecalculateAllocatedCombatModifiers();
            }
        }
    }

    public int DefendingValue
    {
        get => defendingValue;
        set
        {
            if (value != defendingValue)
            {
                if (DefendingValueOriginal == 0)
                {
                    DefendingValueOriginal = value;
                }
                defendingValue = value;
                OnPropertyChanged();

                RecalculateAllocatedCombatModifiers();
            }
        }
    }

    public int AimingValue
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
    public int AttackingValueWithSelectedWeapon => AttackingValue + weaponFightModifier?.AttackingValue ?? 0;
    public int DefendingValueWithSelectedWeapon => DefendingValue + weaponFightModifier?.DefendingValue ?? 0;
    public int AimingValueWithSelectedWeapon => AimingValue + weaponFightModifier?.AimingValue ?? 0;


    private void RecalculateAllocatedCombatModifiers()
    {
        var initiatorAllocated = Math.Max(0, InitiatingValue - InitiatingValueOriginal);
        var attackAllocated = Math.Max(0, AttackingValue - AttackingValueOriginal);
        var defenseAllocated = Math.Max(0, DefendingValue - DefendingValueOriginal);
        var aimAllocated = Math.Max(0, AimingValue - AimingValueOriginal);

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

        fightModifiers.AttackingValue = BaseClass.AttackingBaseValue;
        fightModifiers.AttackingValue += MathHelper.GetAboveAverageValue(Strength);
        fightModifiers.AttackingValue += MathHelper.GetAboveAverageValue(Quickness);
        fightModifiers.AttackingValue += MathHelper.GetAboveAverageValue(Dexterity);

        fightModifiers.DefendingValue = BaseClass.DefendingBaseValue;
        fightModifiers.DefendingValue += MathHelper.GetAboveAverageValue(Quickness);
        fightModifiers.DefendingValue += MathHelper.GetAboveAverageValue(Dexterity);

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
        fightModifiers.AttackingValue += levelUpFightModifier.AttackingValue;
        fightModifiers.DefendingValue += levelUpFightModifier.DefendingValue;
        fightModifiers.AimingValue += levelUpFightModifier.AimingValue;
        fightModifiers.CombatModifier += levelUpFightModifier.CombatModifier;

        InitiatingValueOriginal = fightModifiers.InitiatingValue;
        AttackingValueOriginal = fightModifiers.AttackingValue;
        DefendingValueOriginal = fightModifiers.DefendingValue;
        AimingValueOriginal = fightModifiers.AimingValue;

        CombatModifier = Math.Max(0, fightModifiers.CombatModifier);

        InitiatingValue = fightModifiers.InitiatingValue;
        AttackingValue = fightModifiers.AttackingValue;
        DefendingValue = fightModifiers.DefendingValue;
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
            result.AttackingValue = melee.AttackingValue;
            result.DefendingValue = melee.DefendingValue;
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
            AttackingValue = attackPoints,
            DefendingValue = defencePoints,
            AimingValue = aimingPoints
        };
    }
}
