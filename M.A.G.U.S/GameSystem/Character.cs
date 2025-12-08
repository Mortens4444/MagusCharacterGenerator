using M.A.G.U.S.Classes.NonPlayableCharacters;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.FightModifiers;
using M.A.G.U.S.GameSystem.Magic;
using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Races;
using M.A.G.U.S.Things;
using M.A.G.U.S.Things.Weapons;
using M.A.G.U.S.Utils;
using Mtf.Extensions;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace M.A.G.U.S.GameSystem;

public class Character : IFightModifier, ILiving, IAbilities, INotifyPropertyChanged
{
    private int strength;
    private int stamina;
    private int speed;
    private int dexterity;
    private int health;
    private int willpower;
    private int intelligence;
    private int astral;

    private int healthPoints;
    private int maxHealthPoints;
    private int painTolerancePoints;
    private int maxPainTolerancePoints;
    private int initiatingValue;
    private int attackingValue;
    private int defendingValue;
    private int aimingValue;
    private int unconsciousAstralMagicResistance;
    private int unconsciousMentalMagicResistance;
    private int psiPoints;
    private int maxPsiPoints;
    private int manaPoints;
    private int maxManaPoints;
    private int qualificationPoints;
    private bool calculateChanges;
    private Money money = new(0);
    private Weapon? primaryWeapon;
    private Weapon? secondaryWeapon;
    private string name;
    private IRace race;
    private string totalEquipmentWeight;
    private int totalCombatModifierPool;
    private int totalCurrentlyAllocated;
    private int initiatingValueOriginal;
    private int attackingValueOriginal;
    private int defendingValueOriginal;
    private int aimingValueOriginal;

    // TODO: Pass the correct method to count
    private readonly MultiClassMode multiClassMode = MultiClassMode.Normal_Or_SwitchedClass;
    private readonly ISettings? settings;

    public event PropertyChangedEventHandler? PropertyChanged;

    public Character() : this(null) { }

    public Character(ISettings? settings)
    {
        this.settings = settings;
        name = "Nobody";
        race = new Human();
        BaseClass = new Craftsman();
        Alignment = Alignment.Order;
        EnsureSubscriptions();
    }

    public Character(ISettings? settings, string name, IRace race, params IClass[] classes)
    {
        this.settings = settings;
        this.name = name;
        this.race = race;
        BaseClass = classes.First();
        Alignment = race.Alignment ?? BaseClass.Alignment;
        Classes = classes;
        CreateFirstLevel();
        EnsureSubscriptions();
    }

    #region Properties

    //public IEnumerable<Image> Images { get; set; }

    public string Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged();
            }
        }
    }

    public IClass BaseClass { get; set; }

    public IClass[] Classes { get; set; }

    public string RaceName => Race.Name ?? String.Empty;

    public string Class => BaseClass.Name ?? String.Empty;

    public int Level => BaseClass.Level;

    public int FightValueModifier => BaseClass.FightValueModifier;

    public IRace Race
    {
        get => race;
        set
        {
            if (race != value)
            {
                race = value;
                OnPropertyChanged();
            }
        }
    }

    public Money Money
    {
        get => money;
        set
        {
            if (money != value)
            {
                money = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(money.Summa));
            }
        }
    }

    public MultiClassMode MultiClassMode => multiClassMode;

    public int PercentQualificationPoints { get; set; }

    public int QualificationPoints
    {
        get => qualificationPoints;
        set
        {
            if (value != qualificationPoints)
            {
                qualificationPoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int UnconsciousAstralMagicResistance
    {
        get => unconsciousAstralMagicResistance;
        set
        {
            if (value != unconsciousAstralMagicResistance)
            {
                unconsciousAstralMagicResistance = value;
                OnPropertyChanged();
            }
        }
    }

    public int UnconsciousMentalMagicResistance
    {
        get => unconsciousMentalMagicResistance;
        set
        {
            if (value != unconsciousMentalMagicResistance)
            {
                unconsciousMentalMagicResistance = value;
                OnPropertyChanged();
            }
        }
    }

    private int combatModifier;
    public int CombatModifier
    {
        get
        {
            return combatModifier;
        }
        set
        {
            if (combatModifier == value)
            {
                return;
            }

            combatModifier = value;
            SetCombatModifierHelperVariables(value);
            OnPropertyChanged();
            OnMaxLimitsChanged();
        }
    }

    public int InitiatingValueOriginal
    {
        get => initiatingValueOriginal;
        private set
        {
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

    public bool CanAllocateQualificationPoints => QualificationPoints != 0;

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

    public int HealthPoints
    {
        get => healthPoints;
        set
        {
            if (value != healthPoints)
            {
                healthPoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int MaxHealthPoints
    {
        get => maxHealthPoints;
        set
        {
            if (value != maxHealthPoints)
            {
                maxHealthPoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int PainTolerancePoints
    {
        get => painTolerancePoints;
        set
        {
            if (value != painTolerancePoints)
            {
                painTolerancePoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int MaxPainTolerancePoints
    {
        get => maxPainTolerancePoints;
        set
        {
            if (value != maxPainTolerancePoints)
            {
                maxPainTolerancePoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int Strength
    {
        get => strength;
        set
        {
            if (value != strength)
            {
                strength = value;
                if (calculateChanges)
                {
                    CalculateFightValues(settings);
                }
                OnPropertyChanged();
            }
        }
    }

    public int Quickness
    {
        get => speed;
        set
        {
            if (value != speed)
            {
                speed = value;
                if (calculateChanges)
                {
                    CalculateFightValues(settings);
                }
                OnPropertyChanged();
            }
        }
    }

    public int Dexterity
    {
        get => dexterity;
        set
        {
            if (value != dexterity)
            {
                dexterity = value;
                if (calculateChanges)
                {
                    CalculateFightValues(settings);
                    CalculateQualificationPoints(settings);
                }
                OnPropertyChanged();
            }
        }
    }

    public int Stamina
    {
        get => stamina;
        set
        {
            if (value != stamina)
            {
                stamina = value;
                if (calculateChanges)
                {
                    CalculatePainTolerancePoints(settings);
                }
            }
            OnPropertyChanged();
        }
    }

    public int Health
    {
        get => health;
        set
        {
            if (value != health)
            {
                health = value;
                if (calculateChanges)
                {
                    CalculateLifePoints();
                }
                OnPropertyChanged();
            }
        }
    }

    public int Beauty { get; set; }

    public int Intelligence
    {
        get => intelligence;
        set
        {
            if (value != intelligence)
            {
                intelligence = value;
                if (calculateChanges)
                {
                    CalculatePsiPoints(settings);
                    CalculateManaPoints(settings);
                    CalculateQualificationPoints(settings);
                }
                OnPropertyChanged();
            }
        }
    }

    public int Willpower
    {
        get => willpower;
        set
        {
            if (value != willpower)
            {
                willpower = value;
                if (calculateChanges)
                {
                    CalculatePainTolerancePoints(settings);
                    CalculateUnconsciousMentalMagicResistance();
                }
                OnPropertyChanged();
            }
        }
    }

    public int Astral
    {
        get => astral;
        set
        {
            if (value != astral)
            {
                astral = value;
                if (calculateChanges)
                {
                    CalculateUnconsciousAstralMagicResistance();
                }
                OnPropertyChanged();
            }
        }
    }

    public int Bravery { get; set; }

    public int Erudition { get; set; }

    public int Detection { get; set; }

    public string Birthplace { get; set; }

    public string School { get; set; }

    public Alignment Alignment { get; set; }

    public Sorcery? Sorcery { get; set; }

    public IPsi? Psi { get; set; }

    public int ManaPoints
    {
        get => manaPoints;
        set
        {
            if (value != manaPoints)
            {
                manaPoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int MaxManaPoints
    {
        get => maxManaPoints;
        set
        {
            if (value != maxManaPoints)
            {
                maxManaPoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int MaxManaPointsPerLevel { get; set; }

    public int PsiPoints
    {
        get => psiPoints;
        set
        {
            if (value != psiPoints)
            {
                psiPoints = value;
                OnPropertyChanged();
            }
        }
    }

    public int MaxPsiPoints
    {
        get => maxPsiPoints;
        set
        {
            if (value != maxPsiPoints)
            {
                maxPsiPoints = value;
                OnPropertyChanged();
            }
        }
    }

    public string TotalEquipmentWeight
    {
        get => totalEquipmentWeight;
        set
        {
            if (value != totalEquipmentWeight)
            {
                totalEquipmentWeight = value;
                OnPropertyChanged();
            }
        }
    }

    public int PsiPointsModifier { get; set; }

    public QualificationList Qualifications { get; private set; } = [];

    public SpecialQualificationList SpecialQualifications { get; private set; } = [];

    public ObservableCollection<PercentQualification> PercentQualifications { get; private set; } = [];

    public ObservableCollection<Thing> Equipment { get; init; } = [];

    #endregion

    private void RecalculateAllocatedCombatModifiers()
    {
        var initiatorAllocated = Math.Max(0, InitiatingValue - InitiatingValueOriginal);
        var attackAllocated = Math.Max(0, AttackingValue - AttackingValueOriginal);
        var defenseAllocated = Math.Max(0, DefendingValue - DefendingValueOriginal);
        var aimAllocated = Math.Max(0, AimingValue - AimingValueOriginal);

        totalCurrentlyAllocated = initiatorAllocated + attackAllocated + defenseAllocated + aimAllocated;

        combatModifier = totalCombatModifierPool - totalCurrentlyAllocated;

        OnPropertyChanged(nameof(CombatModifier));
        OnMaxLimitsChanged();
    }

    private void OnMaxLimitsChanged()
    {
        OnPropertyChanged(nameof(InitiatingValueMaxLimit));
        OnPropertyChanged(nameof(AttackingValueMaxLimit));
        OnPropertyChanged(nameof(DefendingValueMaxLimit));
        OnPropertyChanged(nameof(AimingValueMaxLimit));
    }

    public void CalculateChanges()
    {
        calculateChanges = true;
    }

    private void EnsureSubscriptions()
    {
        Equipment.CollectionChanged += EquipmentOnCollectionChanged;
        Qualifications.CollectionChanged += Qualifications_CollectionChanged;
    }

    private void Qualifications_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(Qualifications));
    }

    private void EquipmentOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        TotalEquipmentWeight = (Equipment?.Sum(e => e.Weight) ?? 0).ToString("N1");
        OnPropertyChanged(nameof(Equipment));
    }

    public void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public static Character Load(string fullPath)
    {
        var result = ObjectSerializer.LoadFile<Character>(fullPath);
        result.CalculateChanges();
        return result;
    }

    private void CreateFirstLevel()
    {
        GenerateAbilities();
        CalculateQualificationPoints(settings);
        GetQualifications();
        CalculateFightValues(settings);

        CalculateLifePoints();
        CalculatePainTolerancePoints(settings);

        CalculateManaPoints(settings);
        CalculatePsiPoints(settings);

        CalculateUnconsciousAstralMagicResistance();
        CalculateUnconsciousMentalMagicResistance();

        CalculateGold();
    }

    private void CalculateGold()
    {
        money.Gold += Classes.Sum(@class => @class.Gold);
    }

    private void GenerateAbilities()
    {
        Strength = BaseClass.Strength + Race.Strength;
        Quickness = BaseClass.Quickness + Race.Quickness;
        Dexterity = BaseClass.Dexterity + Race.Dexterity;
        Stamina = BaseClass.Stamina + Race.Stamina;
        Health = BaseClass.Health + Race.Health;
        Beauty = BaseClass.Beauty + Race.Beauty;
        Intelligence = BaseClass.Intelligence + Race.Intelligence;
        Willpower = BaseClass.Willpower + Race.Willpower;
        Astral = BaseClass.Astral + Race.Astral;
        Bravery = BaseClass.Bravery;
        Erudition = BaseClass.Erudition;
        Detection = BaseClass.Detection;
    }

    private void CalculatePainTolerancePoints(ISettings? settings)
    {
        PainTolerancePoints = GameSystem.PainTolerancePoints.Calculate(this, settings);
        MaxPainTolerancePoints = PainTolerancePoints;
        OnPropertyChanged(nameof(PainTolerancePoints));
    }

    private void CalculateQualificationPoints(ISettings? settings)
    {
        var (qualificationPoints, percentQualificationPoints) = GameSystem.QualificationPoints.Calculate(this, settings);
        QualificationPoints = qualificationPoints;
        PercentQualificationPoints = percentQualificationPoints;
    }

    private void GetQualifications()
    {
        Qualifications.Clear();
        PercentQualifications.Clear();
        SpecialQualifications.Clear();

        foreach (var @class in Classes)
        {
            Qualifications.AddRange(@class.Qualifications.Concat(Race.Qualifications));
            PercentQualifications.AddRange(@class.PercentQualifications);

            var newQualifications = @class.FutureQualifications
                .Where(futureQualification => futureQualification.ActualLevel <= @class.Level);

            Qualifications.AddRange(newQualifications.Where(q => q.QualificationLevel == QualificationLevel.Base));
            var newMasterQualifications = newQualifications.Where(q => q.QualificationLevel == QualificationLevel.Master);
            foreach (var newMasterQualification in newMasterQualifications)
            {
                Qualifications.UpgradeOrAddQualification(newMasterQualification);
            }
        }
        var dexterityBasedPercentages = new List<Type> { typeof(Falling), typeof(Climbing), typeof(Jumping) };
        foreach (var percentQualification in PercentQualifications)
        {
            if (dexterityBasedPercentages.Contains(percentQualification.GetType()))
            {
                percentQualification.Percent += MathHelper.GetAboveAverageValue(Dexterity);
            }
        }
        if (PercentQualifications.FirstOrDefault(pq => pq is Falling) == null)
        {
            PercentQualifications.Add(new Falling(0));
        }
        if (PercentQualifications.FirstOrDefault(pq => pq is Climbing) == null)
        {
            PercentQualifications.Add(new Climbing(0));
        }
        if (PercentQualifications.FirstOrDefault(pq => pq is Jumping) == null)
        {
            PercentQualifications.Add(new Jumping(0));
        }
        
        SpecialQualifications.AddRange(BaseClass.SpecialQualifications);
        SpecialQualifications.AddRange(Race.SpecialQualifications);
        var cantLearnPsi = SpecialQualifications.GetSpeciality<CantLearnPsi>();
        if (cantLearnPsi != null)
        {
            for (int i = Qualifications.Count - 1; i >= 0; i--)
            {
                if (Qualifications[i] is IPsi)
                {
                    Qualifications.RemoveAt(i);
                }
            }
        }

        OnPropertyChanged(nameof(Qualifications));
        OnPropertyChanged(nameof(PercentQualifications));
        OnPropertyChanged(nameof(SpecialQualification));
    }

    private void CalculateFightValues(ISettings? settings)
    {
        var fightModifiers = FightValues.Calculate(this, settings);

        InitiatingValue = fightModifiers.InitiatingValue;
        AttackingValue = fightModifiers.AttackingValue;
        DefendingValue = fightModifiers.DefendingValue;
        AimingValue = fightModifiers.AimingValue;

        CombatModifier = fightModifiers.CombatModifier;
    }

    private void SetCombatModifierHelperVariables(int combatModifier)
    {
        totalCombatModifierPool = combatModifier;
        totalCurrentlyAllocated = 0;
    }

    private void CalculateLifePoints()
    {
        var additionalLifePoints = Race.SpecialQualifications.GetSpeciality<AdditionalLifePoints>();
        HealthPoints = BaseClass.BaseLifePoints;
        if (additionalLifePoints != null)
        {
            HealthPoints = additionalLifePoints.ExtraLifePoints;
        }
        HealthPoints += MathHelper.GetAboveAverageValue(Health);
        MaxHealthPoints = HealthPoints;
    }

    private void CalculateUnconsciousAstralMagicResistance()
    {
        var doubledPainToleranceBase = Race.SpecialQualifications.GetSpeciality<ExtraMagicResistanceOnLevelUp>();
        UnconsciousAstralMagicResistance = MathHelper.GetAboveAverageValue(Astral);
        UnconsciousAstralMagicResistance += (BaseClass.Level - 1) * (doubledPainToleranceBase?.ExtraResistancePoints ?? 0);
    }

    private void CalculateUnconsciousMentalMagicResistance()
    {
        var doubledPainToleranceBase = Race.SpecialQualifications.GetSpeciality<ExtraMagicResistanceOnLevelUp>();
        UnconsciousMentalMagicResistance = MathHelper.GetAboveAverageValue(Willpower);
        UnconsciousMentalMagicResistance += (BaseClass.Level - 1) * (doubledPainToleranceBase?.ExtraResistancePoints ?? 0);
    }

    private void CalculatePsiPoints(ISettings? settings)
    {
        var psiAttributes = GameSystem.PsiPoints.Calculate(this, settings);
        Psi = psiAttributes.Psi;
        PsiPoints = psiAttributes.PsiPoints;
        MaxPsiPoints = psiAttributes.PsiPoints;
        PsiPointsModifier = psiAttributes.PsiPointsModifier;
    }

    private void CalculateManaPoints(ISettings? settings)
    {
        var sorceryAttributes = GameSystem.ManaPoints.Calculate(this, settings);
        Sorcery = sorceryAttributes.Sorcery;
        ManaPoints = sorceryAttributes.ManaPoints;
        MaxManaPoints = sorceryAttributes.ManaPoints;
        MaxManaPointsPerLevel = sorceryAttributes.MaxManaPointsPerLevel;
    }

    public void Buy(Thing thing)
    {
        if (Money < thing.MultipliedPrice)
        {
            throw new InvalidOperationException("Cannot afford this item");
        }

        Money -= thing.MultipliedPrice;
        if (thing is Weapon weapon)
        {
            if (primaryWeapon == null)
            {
                primaryWeapon = weapon;
            }
            else
            {
                secondaryWeapon ??= weapon;
            }
        }
        Equipment.Add(thing);
        OnPropertyChanged(nameof(Money));
    }

    public bool CanLearn(Qualification qualification)
    {
        return CanLearn(qualification, QualificationLevel.Base, out _) || CanLearn(qualification, QualificationLevel.Master, out _);
    }

    public bool CanLearn(Qualification qualification, QualificationLevel qualificationLevel, out int qp)
    {
        var hasBase = Qualifications.Any(q => q.Name == qualification.Name && q.QualificationLevel == QualificationLevel.Base);
        var hasMaster = Qualifications.Any(q => q.Name == qualification.Name && q.QualificationLevel == QualificationLevel.Master);
        qp = qualificationLevel == QualificationLevel.Base ? qualification.QpToBaseQualification : qualification.QpToMasterQualification;
        if (hasBase)
        {
            qp -= qualification.QpToBaseQualification;
        }
        if (hasMaster)
        {
            qp -= qualification.QpToMasterQualification;
        }
        if (QualificationPoints < qp)
        {
            return false;
        }

        return true;
    }

    public void Learn(Qualification qualification, QualificationLevel qualificationLevel)
    {
        if (!CanLearn(qualification, qualificationLevel, out var qp))
        {
            throw new InvalidOperationException("Cannot learn this qualification");
        }
        QualificationPoints -= qp;
        Qualifications.Add(qualification);
    }
}
