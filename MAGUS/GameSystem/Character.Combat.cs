using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.GameSystem.FightMode;
using MAGUS.GameSystem.Magic;
using MAGUS.GameSystem.Psi;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Interfaces;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Specialities;
using MAGUS.Things.Weapons;
using MAGUS.Things.Weapons.OtherWeapons;
using MAGUS.Utils;
using System.Text.Json.Serialization;

namespace MAGUS.GameSystem;

public partial class Character : ICharacter
{
    private static readonly Fist fist = new();
    private CombatValueModifier selectedCombatValueModifier = CombatValueModifier.Base;
    private string? primaryWeaponId;
    private string? secondaryWeaponId;
    private Weapon? primaryWeapon;
    private Weapon? secondaryWeapon;
    private List<Attack>? attackModes;

    private int allocatedToInitiate;

    private int allocatedToAttack;

    private int allocatedToDefense;

    private int allocatedToAim;
    private int minInitiateValue;
    private int minAttackValue;
    private int minDefenseValue;
    private int minAimValue;
    private int lockedAllocatedToInitiate;
    private int lockedAllocatedToAttack;
    private int lockedAllocatedToDefense;
    private int lockedAllocatedToAim;

    public override double AttacksPerRound
    {
        get
        {
            var baseAttacksPerRound = (PrimaryWeapon ?? SecondaryWeapon)?.AttacksPerRound ?? fist.AttacksPerRound;
            return Quickness > 16 && Dexterity > 16 ? baseAttacksPerRound * 2 : baseAttacksPerRound;
        }
    }

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
                attackModes = [];
                var strengthDamageBonus = MathHelper.GetStrengthMeleeDamageBonus(Strength);

                if (PrimaryWeapon is IMeleeWeapon meleeWeapon)
                {
                    attackModes.Add(new MeleeAttack(meleeWeapon, AttackValue, strengthDamageBonus));
                }
                else if (PrimaryWeapon is IRangedWeapon rangedWeapon)
                {
                    attackModes.Add(new RangedAttack(rangedWeapon, AimValue));
                }

                if (SecondaryWeapon is IMeleeWeapon meleeWeapon2)
                {
                    attackModes.Add(new MeleeAttack(meleeWeapon2, AttackValue, strengthDamageBonus));
                }
                else if (SecondaryWeapon is IRangedWeapon rangedWeapon2)
                {
                    attackModes.Add(new RangedAttack(rangedWeapon2, AimValue));
                }
                attackModes.Add(new MeleeAttack(fist, AttackValue, strengthDamageBonus));

                foreach (var discipline in PsiDisciplineCatalog.GetAvailable(this))
                {
                    if (PsiPoints >= discipline.PsiPointCost)
                    {
                        attackModes.Add(new PsiAttack(discipline));
                    }
                }

                foreach (var spell in SpellCatalog.GetAvailable(this))
                {
                    if (ManaPoints >= spell.ManaCost)
                    {
                        attackModes.Add(new SpellAttack(spell));
                    }
                }
            }

            return attackModes;
        }
        protected set => attackModes = value;
    }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int LockedAllocatedToInitiate { get => lockedAllocatedToInitiate; private set => lockedAllocatedToInitiate = value; }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int LockedAllocatedToAttack { get => lockedAllocatedToAttack; private set => lockedAllocatedToAttack = value; }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int LockedAllocatedToDefense { get => lockedAllocatedToDefense; private set => lockedAllocatedToDefense = value; }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int LockedAllocatedToAim { get => lockedAllocatedToAim; private set => lockedAllocatedToAim = value; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int CombatValueModifierPerLevel => BaseClass.CombatValueModifierPerLevel;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int RemainingCombatValueModifier => TotalCombatValueModifier - AllocatedToInitiate - AllocatedToAttack - AllocatedToDefense - AllocatedToAim;

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
    public int MinInitiateValue
    {
        get => minInitiateValue;
        private set
        {
            if (minInitiateValue != value)
            {
                minInitiateValue = value;
                OnPropertyChanged();
            }
        }
    }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int MinAttackValue
    {
        get => minAttackValue;
        private set
        {
            if (minAttackValue != value)
            {
                minAttackValue = value;
                OnPropertyChanged();
            }
        }
    }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int MinDefenseValue
    {
        get => minDefenseValue;
        private set
        {
            if (minDefenseValue != value)
            {
                minDefenseValue = value;
                OnPropertyChanged();
            }
        }
    }

    [JsonInclude, Newtonsoft.Json.JsonProperty]
    public int MinAimValue
    {
        get => minAimValue;
        private set
        {
            if (minAimValue != value)
            {
                minAimValue = value;
                OnPropertyChanged();
            }
        }
    }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int AllocatedToInitiateMax => AllocatedToInitiate + RemainingCombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int AllocatedToAttackMax => AllocatedToAttack + RemainingCombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int AllocatedToDefenseMax => AllocatedToDefense + RemainingCombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int AllocatedToAimMax => AllocatedToAim + RemainingCombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public bool CanAllocateCombatModifier => TotalCombatValueModifier > 0;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int MaxInitiateValue => MinInitiateValue + AllocatedToInitiate + RemainingCombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int MaxAttackValue => MinAttackValue + AllocatedToAttack + RemainingCombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int MaxDefenseValue => MinDefenseValue + AllocatedToDefense + RemainingCombatValueModifier;

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public int MaxAimValue => MinAimValue + AllocatedToAim + RemainingCombatValueModifier;

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
                CombatValueModifier.PrimaryWeapon or CombatValueModifier.PrimaryWeaponThrown when PrimaryWeapon is IWeapon weapon => weapon.InitiateValue,
                CombatValueModifier.SecondaryWeapon or CombatValueModifier.SecondaryWeaponThrown when SecondaryWeapon is IWeapon secondaryWeapon => secondaryWeapon.InitiateValue,
                _ => fist.InitiateValue,
            };

            return @base + AllocatedToInitiate + weaponBonus + GetWeaponUseModifier().InitiateValue + TemporaryModifiers.Sum(m => m.InitiateValue);
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
                CombatValueModifier.PrimaryWeapon or CombatValueModifier.PrimaryWeaponThrown when PrimaryWeapon is IMeleeWeapon meleeWeapon => meleeWeapon.AttackValue,
                CombatValueModifier.SecondaryWeapon or CombatValueModifier.SecondaryWeaponThrown when SecondaryWeapon is IMeleeWeapon secondaryMeleeWeapon => secondaryMeleeWeapon.AttackValue,
                _ => fist.AttackValue,
            };

            return @base + AllocatedToAttack + weaponBonus + GetWeaponUseModifier().AttackValue + GetWeaponThrowingModifier() + PsiSurgeAttackBonus + TemporaryModifiers.Sum(m => m.AttackValue);
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
                CombatValueModifier.PrimaryWeapon when PrimaryWeapon is IMeleeWeapon meleeWeapon => meleeWeapon.DefenseValue,
                CombatValueModifier.SecondaryWeapon when SecondaryWeapon is IMeleeWeapon secondaryMeleeWeapon => secondaryMeleeWeapon.DefenseValue,
                _ => fist.DefenseValue,
            };

            return @base + AllocatedToDefense + weaponBonus + GetWeaponUseModifier().DefenseValue + TemporaryModifiers.Sum(m => m.DefenseValue);
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
                CombatValueModifier.PrimaryWeapon when PrimaryWeapon is IRangedWeapon rangedWeapon => rangedWeapon.AimValue,
                CombatValueModifier.SecondaryWeapon when SecondaryWeapon is IRangedWeapon secondaryRangedWeapon => secondaryRangedWeapon.AimValue,
                _ => 0,
            };

            return @base + AllocatedToAim + weaponBonus + GetWeaponUseModifier().AimValue + TemporaryModifiers.Sum(m => m.AimValue);
        }
    }

    public void SetWeapons()
    {
        primaryWeapon = ResolveWeaponById(PrimaryWeaponId);
        secondaryWeapon = ResolveWeaponById(SecondaryWeaponId);
    }

    /// <summary>
    /// KÉ/TÉ/VÉ/CÉ modifier from the Weapon use (Fegyverhasználat) qualification for whichever weapon
    /// is currently selected via SelectedCombatValueModifier (Első Törvénykönyv, "Képzetlen
    /// fegyverforgatás" and "Harci Képzettségek - Fegyverhasználat"): no matching qualification at all
    /// is an untrained penalty (-10/-25/-20, plus -30 Aim for a ranged weapon), Base level is neutral,
    /// and Master level grants +5/+10/+10/+10. Fist attacks (Ökölharc) are a separate qualification and
    /// are not affected here.
    /// </summary>
    private WeaponCombatModifier GetWeaponUseModifier()
    {
        var selectedWeapon = selectedCombatValueModifier switch
        {
            CombatValueModifier.PrimaryWeapon => PrimaryWeapon,
            CombatValueModifier.SecondaryWeapon => SecondaryWeapon,
            _ => null,
        };

        if (selectedWeapon == null)
        {
            return new WeaponCombatModifier();
        }

        var weaponUse = new WeaponUse { Weapon = selectedWeapon };
        if (HasQualification(weaponUse, QualificationLevel.Master))
        {
            return new WeaponCombatModifier { InitiateValue = 5, AttackValue = 10, DefenseValue = 10, AimValue = 10 };
        }

        if (HasQualification(weaponUse, QualificationLevel.Base))
        {
            return new WeaponCombatModifier();
        }

        var untrainedAimPenalty = selectedWeapon is IRangedWeapon ? -30 : 0;
        return new WeaponCombatModifier { InitiateValue = -10, AttackValue = -25, DefenseValue = -20, AimValue = untrainedAimPenalty };
    }

    /// <summary>
    /// TÉ modifier from the Weapon throwing (Fegyverdobás) qualification when SelectedCombatValueModifier
    /// is one of the "thrown" modes (Első Törvénykönyv, "Fegyverdobás"): throwing always resolves as an
    /// Attack Roll, never an Aim Roll, so this only ever affects Attack value. No matching qualification
    /// is the untrained penalty (-25, same magnitude as Képzetlen fegyverforgatás's TÉ penalty), Base
    /// level is neutral ("nincsen mínusza"), and Master level adds +10.
    /// </summary>
    private int GetWeaponThrowingModifier()
    {
        var thrownWeapon = selectedCombatValueModifier switch
        {
            CombatValueModifier.PrimaryWeaponThrown => PrimaryWeapon,
            CombatValueModifier.SecondaryWeaponThrown => SecondaryWeapon,
            _ => null,
        };

        if (thrownWeapon == null)
        {
            return 0;
        }

        var weaponThrowing = new WeaponThrowing { Weapon = thrownWeapon };
        if (HasQualification(weaponThrowing, QualificationLevel.Master))
        {
            return 10;
        }

        if (HasQualification(weaponThrowing, QualificationLevel.Base))
        {
            return 0;
        }

        return -25;
    }

    public void ChangeInitiator(int delta) => ChangeAllocation(ref allocatedToInitiate, delta, AllocationTarget.Initiate);
    public void ChangeAttack(int delta) => ChangeAllocation(ref allocatedToAttack, delta, AllocationTarget.Attack);
    public void ChangeDefense(int delta) => ChangeAllocation(ref allocatedToDefense, delta, AllocationTarget.Defense);
    public void ChangeAim(int delta) => ChangeAllocation(ref allocatedToAim, delta, AllocationTarget.Aim);

    public void CommitAllocations()
    {
        LockedAllocatedToInitiate = AllocatedToInitiate;
        LockedAllocatedToAttack = AllocatedToAttack;
        LockedAllocatedToDefense = AllocatedToDefense;
        LockedAllocatedToAim = AllocatedToAim;
    }

    private void ChangeAllocation(ref int allocated, int delta, AllocationTarget target)
    {
        if (delta == 0)
        {
            return;
        }

        if (delta > 0 && RemainingCombatValueModifier < delta)
        {
            NotifyAllocationChanged(target);
            return;
        }

        int lockedValue = GetLockedValueForTarget(target);

        if (delta < 0 && allocated + delta < lockedValue)
        {
            return;
        }

        allocated += delta;

        NotifyAllocationChanged(target);
    }

    private int GetLockedValueForTarget(AllocationTarget target)
    {
        return target switch
        {
            AllocationTarget.Initiate => LockedAllocatedToInitiate,
            AllocationTarget.Attack => LockedAllocatedToAttack,
            AllocationTarget.Defense => LockedAllocatedToDefense,
            AllocationTarget.Aim => LockedAllocatedToAim,
            _ => 0
        };
    }

    private void NotifyAllocationChanged(AllocationTarget target)
    {
        OnPropertyChanged(nameof(RemainingCombatValueModifier));
        OnPropertyChanged(nameof(CanAllocateCombatModifier));

        switch (target)
        {
            case AllocationTarget.Initiate:
                OnPropertyChanged(nameof(AllocatedToInitiate));
                OnPropertyChanged(nameof(AllocatedToInitiateMax));
                OnPropertyChanged(nameof(InitiateValue));
                OnMaxLimitsChanged();
                break;
            case AllocationTarget.Attack:
                OnPropertyChanged(nameof(AllocatedToAttack));
                OnPropertyChanged(nameof(AllocatedToAttackMax));
                OnPropertyChanged(nameof(AttackValue));
                OnMaxLimitsChanged();
                break;
            case AllocationTarget.Defense:
                OnPropertyChanged(nameof(AllocatedToDefense));
                OnPropertyChanged(nameof(AllocatedToDefenseMax));
                OnPropertyChanged(nameof(DefenseValue));
                OnMaxLimitsChanged();
                break;
            case AllocationTarget.Aim:
                OnPropertyChanged(nameof(AllocatedToAim));
                OnPropertyChanged(nameof(AllocatedToAimMax));
                OnPropertyChanged(nameof(AimValue));
                OnMaxLimitsChanged();
                break;
        }
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

        TotalCombatValueModifier = combatValueModifier;
        var autoDistributeCombatValues = settings?.AutoDistributeCombatValues ?? false;
        if (autoDistributeCombatValues)
        {
            int attack = MathHelper.GetModifier(combatValueModifier, attackPercentage);
            int defense = MathHelper.GetModifier(combatValueModifier, defencePercentage);
            int aim = MathHelper.GetModifier(combatValueModifier, aimingPercentage);

            int used = attack + defense + aim;
            if (used > combatValueModifier)
            {
                aim -= (used - combatValueModifier);
            }

            AllocatedToAttack = attack;
            AllocatedToDefense = defense;
            AllocatedToAim = aim;

            AllocatedToInitiate = Math.Max(0, combatValueModifier - AllocatedToAttack - AllocatedToDefense - AllocatedToAim);
            if (AllocatedToInitiate < 0)
            {
                throw new InvalidOperationException($"The amount of the percentages ({nameof(attackPercentage)} + {nameof(defencePercentage)} + {nameof(aimingPercentage)}) should be under or equal to 100 percent.");
            }
        }

        SetOriginalCombatValues();
    }

    private void SetOriginalCombatValues()
    {
        MinInitiateValue = InitiateValue;
        MinAttackValue = AttackValue;
        MinDefenseValue = DefenseValue;
        MinAimValue = AimValue;
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
