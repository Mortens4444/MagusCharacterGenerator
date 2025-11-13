using M.A.G.U.S.Classes.Fighter;
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
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace M.A.G.U.S.GameSystem;

public class Character : IFightModifier, ILiving, IAbilities, INotifyPropertyChanged
{
	private sbyte strength;
    private sbyte stamina;
	private sbyte speed;
	private sbyte dexterity;
	private sbyte health;
	private sbyte willpower;
	private sbyte intelligence;
	private sbyte astral;

	private short healthPoints;
	private short maxHealthPoints;
    private short painTolerancePoints;
	private short maxPainTolerancePoints;
	private short initiatingValue;
	private short attackingValue;
	private short defendingValue;
	private short aimingValue;
	private short unconsciousAstralMagicResistance;
	private short unconsciousMentalMagicResistance;
	private ushort psiPoints;
	private ushort maxPsiPoints;
    private ushort manaPoints;
	private ushort maxManaPoints;
    private ushort qualificationPoints;
	private bool calculateChanges;
	private Money money = new(0);
    private Weapon? primaryWeapon;
    private Weapon? secondaryWeapon;
    private string name;
    private IRace race;
    private string totalEquipmentWeight;

    // TODO: Pass the correct method to count
    private readonly MultiClassMode multiClassMode = MultiClassMode.Normal_Or_SwitchedClass;

	public event PropertyChangedEventHandler? PropertyChanged;

    public Character()
	{
		name = "Nobody";
		race = new Human();
		BaseClass = new Warrior();
        EnsureEquipmentSubscription();
    }

    public Character(string name, IRace race, params IClass[] classes)
	{
		this.name = name;
        this.race = race;
		BaseClass = classes.First();
		Classes = classes;
		CreateFirstLevel();
        EnsureEquipmentSubscription();
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

    public ushort PercentQualificationPoints { get; set; }

	public ushort QualificationPoints
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

	public short UnconsciousAstralMagicResistance
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

	public short UnconsciousMentalMagicResistance
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

	public short InitiatingValue
	{
		get => initiatingValue;
		set
		{
			if (value != initiatingValue)
			{
				initiatingValue = value;
				OnPropertyChanged();
			}
		}
	}

	public short AttackingValue
	{
		get => attackingValue;
		set
		{
			if (value != attackingValue)
			{
				attackingValue = value;
				OnPropertyChanged();
			}
		}
	}

	public short DefendingValue
	{
		get => defendingValue;
		set
		{
			if (value != defendingValue)
			{
				defendingValue = value;
				OnPropertyChanged();
			}
		}
	}

	public short AimingValue
	{
		get => aimingValue;
		set
		{
			if (value != aimingValue)
			{
				aimingValue = value;
				OnPropertyChanged();
			}
		}
	}

	public short HealthPoints
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

	public short MaxHealthPoints
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

	public short PainTolerancePoints
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
    public short MaxPainTolerancePoints
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

    public sbyte Strength
	{
		get => strength;
		set
		{
			if (value != strength)
			{
				strength = value;
				if (calculateChanges)
				{
					CalculateFightValues();
				}
                OnPropertyChanged();
            }
		}
	}

	public sbyte Quickness
	{
		get => speed;
		set
		{
			if (value != speed)
			{
				speed = value;
				if (calculateChanges)
				{
					CalculateFightValues();
				}
                OnPropertyChanged();
            }
		}
	}

	public sbyte Dexterity
	{
		get => dexterity;
		set
		{
			if (value != dexterity)
			{
				dexterity = value;
				if (calculateChanges)
				{
					CalculateFightValues();
					CalculateQualificationPoints();
                }
                OnPropertyChanged();
            }
		}
	}

    public sbyte Stamina
	{
		get => stamina;
		set
		{
			if (value != stamina)
			{
				stamina = value;
				if (calculateChanges)
				{
                    CalculatePainTolerancePoints();
				}
			}
            OnPropertyChanged();
        }
	}

    public sbyte Health
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

	public sbyte Beauty { get; set; }

    public sbyte Intelligence
	{
		get => intelligence;
		set
		{
			if (value != intelligence)
			{
				intelligence = value;
				if (calculateChanges)
				{
					CalculatePsiPoints();
					CalculateManaPoints();
					CalculateQualificationPoints();
				}
                OnPropertyChanged();
            }
		}
	}

    public sbyte Willpower
	{
		get => willpower;
		set
		{
			if (value != willpower)
			{
				willpower = value;
				if (calculateChanges)
				{
					CalculatePainTolerancePoints();
					CalculateUnconsciousMentalMagicResistance();
				}
                OnPropertyChanged();
            }
		}
	}

	public sbyte Astral
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

	public sbyte Bravery { get; set; }

	public sbyte Erudition { get; set; }

    public sbyte Detection { get; set; }

    public string Birthplace { get; set; }

    public string School { get; set; }

    public string Alignment { get; set; }

    public Sorcery? Sorcery { get; set; }

	public IPsi? Psi { get; set; }

	public ushort ManaPoints
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

    public ushort MaxManaPoints
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

    public ushort MaxManaPointsPerLevel { get; set; }

    public ushort PsiPoints
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

    public ushort MaxPsiPoints
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

    public byte PsiPointsModifier { get; set; }

	public QualificationList Qualifications { get; private set; } = [];

	public SpecialQualificationList SpecialQualifications { get; private set; } = [];

    public ObservableCollection<PercentQualification> PercentQualifications { get; private set; } = [];

    public ObservableCollection<Thing> Equipment { get; init; } = [];

    #endregion

    public void CalculateChanges()
    {
        calculateChanges = true;
    }

    private void EnsureEquipmentSubscription()
    {
        Equipment.CollectionChanged -= EquipmentOnCollectionChanged;
        Equipment.CollectionChanged += EquipmentOnCollectionChanged;
    }

    private void EquipmentOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        TotalEquipmentWeight = (Equipment?.Sum(e => e.Weight) ?? 0).ToString("N1");
        Debug.WriteLine($"Equipment changed. TotalEquipmentWeight={TotalEquipmentWeight}");
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
		CalculateQualificationPoints();
		GetQualifications();
		CalculateFightValues();

		CalculateLifePoints();
		CalculatePainTolerancePoints();

		CalculateManaPoints();
		CalculatePsiPoints();

		CalculateUnconsciousAstralMagicResistance();
		CalculateUnconsciousMentalMagicResistance();

		CalculateGold();
	}

	private void CalculateGold()
	{
		money.Gold += (short)Classes.Sum(@class => @class.Gold);
	}

	private void GenerateAbilities()
	{
		Strength = (sbyte)(BaseClass.Strength + Race.Strength);
		Quickness = (sbyte)(BaseClass.Quickness + Race.Quickness);
        Dexterity = (sbyte)(BaseClass.Dexterity + Race.Dexterity);
		Stamina = (sbyte)(BaseClass.Stamina + Race.Stamina);
		Health = (sbyte)(BaseClass.Health + Race.Health);
		Beauty = (sbyte)(BaseClass.Beauty + Race.Beauty);
		Intelligence = (sbyte)(BaseClass.Intelligence + Race.Intelligence);
		Willpower = (sbyte)(BaseClass.Willpower + Race.Willpower);
		Astral = (sbyte)(BaseClass.Astral + Race.Astral);
		Bravery = BaseClass.Bravery;
		Erudition = BaseClass.Erudition;
		Detection = BaseClass.Detection;
    }

    private void CalculatePainTolerancePoints()
    {
        PainTolerancePoints = GameSystem.PainTolerancePoints.Calculate(this);
        MaxPainTolerancePoints = PainTolerancePoints;
        OnPropertyChanged(nameof(PainTolerancePoints));
    }

    private void CalculateQualificationPoints()
    {
        var (qualificationPoints, percentQualificationPoints) = GameSystem.QualificationPoints.Calculate(this);
        QualificationPoints = qualificationPoints;
        PercentQualificationPoints = percentQualificationPoints;
    }

    private void GetQualifications()
	{
		SpecialQualifications.AddRange(Race.SpecialQualifications);
		Qualifications.Clear();

        foreach (var @class in Classes)
		{
			Qualifications.AddRange(@class.Qualifications);
			PercentQualifications.AddRange(@class.PercentQualifications);

            var newQualifications = @class.FutureQualifications
				.Where(futureQualification => futureQualification.MasterQualificationLevel <= @class.Level);

            var newBaseQualifications = newQualifications
                .Where(futureQualification => futureQualification.QualificationLevel == QualificationLevel.Base);

            Qualifications.AddRange(newBaseQualifications);

            var newMasterQualifications = newQualifications.Except(newBaseQualifications).Concat(Race.Qualifications);
            foreach (var newMasterQualification in newMasterQualifications)
            {
                Qualifications.UpgradeOrAddQualification(newMasterQualification);
            }

        }
        var dexterityBasedPercentages = new List<Type> { typeof(Falling), typeof(Climbing), typeof(Jumping) };
		if (PercentQualifications.Count == 0)
		{
			PercentQualifications.AddRange([new Falling(0), new Climbing(0), new Jumping(0)]);
        }
        foreach (var percentQualification in PercentQualifications)
        {
			if (dexterityBasedPercentages.Contains(percentQualification.GetType()))
			{
                percentQualification.Percent += (byte)MathHelper.GetAboveAverageValue(Dexterity);
            }
        }

        OnPropertyChanged(nameof(Qualifications));
        OnPropertyChanged(nameof(PercentQualifications));
        OnPropertyChanged(nameof(SpecialQualification));
    }

	private void CalculateFightValues()
	{
        var fightModifiers = FightValues.Calculate(this);
		InitiatingValue = fightModifiers.InitiatingValue;
        AttackingValue = fightModifiers.AttackingValue;
        DefendingValue = fightModifiers.DefendingValue;
        AimingValue = fightModifiers.AimingValue;
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
		UnconsciousAstralMagicResistance += (short)((BaseClass.Level - 1) * (doubledPainToleranceBase?.ExtraResistancePoints ?? 0));
	}

	private void CalculateUnconsciousMentalMagicResistance()
	{
        var doubledPainToleranceBase = Race.SpecialQualifications.GetSpeciality<ExtraMagicResistanceOnLevelUp>();
        UnconsciousMentalMagicResistance = MathHelper.GetAboveAverageValue(Willpower);
        UnconsciousMentalMagicResistance += (short)((BaseClass.Level - 1) * (doubledPainToleranceBase?.ExtraResistancePoints ?? 0));
	}

	private void CalculatePsiPoints()
    {
        var psiAttributes = GameSystem.PsiPoints.Calculate(this);
		Psi = psiAttributes.Psi;
		PsiPoints = psiAttributes.PsiPoints;
        MaxPsiPoints = psiAttributes.PsiPoints;
        PsiPointsModifier = psiAttributes.PsiPointsModifier;
    }

	private void CalculateManaPoints()
	{
		var sorceryAttributes = GameSystem.ManaPoints.Calculate(this);
		Sorcery = sorceryAttributes.Sorcery;
        ManaPoints = sorceryAttributes.ManaPoints;
		MaxManaPoints = sorceryAttributes.ManaPoints;
		MaxManaPointsPerLevel = sorceryAttributes.MaxManaPointsPerLevel;
    }

    public void LevelUp()
    {
		CalculateManaPoints();
    }

	public void Buy(Thing thing)
	{
		Money -= thing.Price;
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
}
