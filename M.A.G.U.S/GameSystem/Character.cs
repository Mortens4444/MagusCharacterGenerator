using M.A.G.U.S.Classes.Fighter;
using M.A.G.U.S.Classes.Rogue;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.FightModifier;
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
using System.ComponentModel;
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

    // TODO: Pass the correct method to count
    private readonly MultiClassMode multiClassMode = MultiClassMode.Normal_Or_SwitchedClass;

	public event PropertyChangedEventHandler? PropertyChanged;

	public Character()
	{
		name = "Nobody";
		race = new Human();
		BaseClass = new Warrior();
	}

	public Character(string name, IRace race, params IClass[] classes)
	{
		this.name = name;
        this.race = race;
		BaseClass = classes.First();
		Classes = classes;
		CreateFirstLevel();
	}

	#region Properties

	public void CalculateChanges()
	{
		calculateChanges = true;
	}

	//public IEnumerable<Image> Images { get; set; }

    public string Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
				NotifyPropertyChanged(nameof(money.Summa));
			}
        }
    }

    public ushort PercentQualificationPoints { get; set; }

	public ushort QualificationPoints
	{
		get => qualificationPoints;
		set
		{
			if (value != qualificationPoints)
			{
				qualificationPoints = value;
				NotifyPropertyChanged();
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
				NotifyPropertyChanged();
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
				NotifyPropertyChanged();
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
				NotifyPropertyChanged();
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
				NotifyPropertyChanged();
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
				NotifyPropertyChanged();
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
				NotifyPropertyChanged();
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
				NotifyPropertyChanged();
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
				NotifyPropertyChanged();
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
				NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
            }
		}
	}

	public sbyte Speed
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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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
            NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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

	public IPsi Psi { get; set; }

	public ushort ManaPoints
	{
		get => manaPoints;
		set
		{
			if (value != manaPoints)
			{
				manaPoints = value;
				NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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
				NotifyPropertyChanged();
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
                NotifyPropertyChanged();
            }
        }
    }

    public byte PsiPointsModifier { get; set; }

	public QualificationList Qualifications { get; private set; } = [];

	public SpecialQualificationList SpecialQualifications { get; private set; } = [];

    public ObservableCollection<PercentQualification> PercentQualifications { get; private set; } = [];

    public ObservableCollection<Thing> Equipment { get; private set; } = [];

    #endregion

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
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
		Speed = (sbyte)(BaseClass.Speed + Race.Speed);
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

	private void CalculateQualificationPoints()
	{
		if (multiClassMode == MultiClassMode.Normal_Or_SwitchedClass)
		{
			QualificationPoints = BaseClass.BaseQualificationPoints;
			QualificationPoints += (ushort)MathHelper.GetAboveAverageValue(Intelligence);
			QualificationPoints += (ushort)MathHelper.GetAboveAverageValue(Dexterity);
			if (BaseClass.AddQualificationPointsOnFirstLevel)
			{
				QualificationPoints += BaseClass.QualificationPointsModifier;
			}
			for (int i = 1; i < BaseClass.Level; i++)
			{
				QualificationPoints += BaseClass.QualificationPointsModifier;
				PercentQualificationPoints += BaseClass.PercentQualificationModifier;
			}
		}
		else
		{
			// TwinClass
			// When it got the new class?
			throw new NotImplementedException();
		}
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

        NotifyPropertyChanged(nameof(Qualifications));
        NotifyPropertyChanged(nameof(PercentQualifications));
        NotifyPropertyChanged(nameof(SpecialQualification));
    }

	private void CalculateFightValues()
	{
		var initiatorRace = Race.SpecialQualifications.GetSpeciality<GoodInitiator>();
		
		InitiatingValue = initiatorRace != null ? initiatorRace.InitiatingBase : BaseClass.InitiatingBaseValue;
		InitiatingValue += MathHelper.GetAboveAverageValue(Speed);
		InitiatingValue += MathHelper.GetAboveAverageValue(Dexterity);

		AttackingValue = BaseClass.AttackingBaseValue;
		AttackingValue += MathHelper.GetAboveAverageValue(Strength);
		AttackingValue += MathHelper.GetAboveAverageValue(Speed);
		AttackingValue += MathHelper.GetAboveAverageValue(Dexterity);

		DefendingValue = BaseClass.DefendingBaseValue;
		DefendingValue += MathHelper.GetAboveAverageValue(Speed);
		DefendingValue += MathHelper.GetAboveAverageValue(Dexterity);

		var archerClass = BaseClass.SpecialQualifications.FirstOrDefault(specialQualification => specialQualification is GoodArcher) as GoodArcher;
		var archerRace = Race.SpecialQualifications.GetSpeciality<GoodArcher>();

		try
		{
			AimingValue = archerClass != null ? archerClass.AimingBase :
				archerRace != null ? archerRace.AimingBase : BaseClass.AimingBaseValue;
			AimingValue += MathHelper.GetAboveAverageValue(Dexterity);
		}
		catch (InvalidOperationException)
		{
			AimingValue = 0;
		}

		var (attackPercentage, defencePercentage, aimingPercentage) = DistributionProvider.Get(BaseClass, Race);
		DistributeAttackModifierPoints(attackPercentage, defencePercentage, aimingPercentage);
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

	private void CalculatePainTolerancePoints()
	{
		var doubledPainToleranceBase = Race.SpecialQualifications.GetSpeciality<DoubledPainToleranceBase>();
		if (multiClassMode == MultiClassMode.Normal_Or_SwitchedClass)
		{
			PainTolerancePoints = doubledPainToleranceBase != null ? (byte)(2 * BaseClass.BasePainTolerancePoints) : BaseClass.BasePainTolerancePoints;
			PainTolerancePoints += MathHelper.GetAboveAverageValue(Stamina);
			PainTolerancePoints += MathHelper.GetAboveAverageValue(Willpower);
			if (BaseClass.AddPainToleranceOnFirstLevel)
			{
				PainTolerancePoints += BaseClass.GetPainToleranceModifier();
			}

			for (int i = 1; i < BaseClass.Level; i++)
			{
				PainTolerancePoints += BaseClass.GetPainToleranceModifier();
			}
		}
		else
		{
			throw new NotImplementedException();
		}

		MaxPainTolerancePoints = PainTolerancePoints;
		NotifyPropertyChanged(nameof(PainTolerancePoints));
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
        var kyrLore = Race.SpecialQualifications.GetSpeciality<KyrLore>();

        var @class = BaseClass;
        //PsiPoints = 0;
        //foreach (var @class in Classes)
        {
            (IPsi psi, ushort psiPoints, byte psiPointsModifier) = PsiPointCalculator.Calculate(Qualifications, Intelligence, @class.Level, kyrLore);
            
            //if (PsiPoints < psiPoints)
            {
				Psi = psi;
				PsiPoints = psiPoints;
				MaxPsiPoints = PsiPoints;
				PsiPointsModifier = psiPointsModifier;
			}
		}
	}

	private void CalculateManaPoints()
	{
        var kyrLore = Race.SpecialQualifications.GetSpeciality<KyrLore>();

        ManaPoints = 0;
		foreach (var @class in Classes)
		{
			var sorcery = @class.SpecialQualifications.FirstOrDefault(specialQualification => specialQualification is Sorcery) as Sorcery;
			if (sorcery != null)
			{
				if (BaseClass is Bard)
				{
					sorcery.ManaPoints = (ushort)MathHelper.GetAboveAverageValue(Intelligence);
				}
				var manaPoints = sorcery.ManaPoints;
				if (kyrLore != null)
				{
					manaPoints += BaseClass.Level;
				}
				for (int i = 1; i < @class.Level; i++)
				{
					manaPoints += sorcery.GetManaPointsModifier();
				}
				MaxManaPointsPerLevel = sorcery.GetManaPointsModifier();
			}
			
            if (ManaPoints < manaPoints)
			{
				Sorcery = sorcery;
				ManaPoints = manaPoints;
			}
		}
		MaxManaPoints = ManaPoints;
    }

	private void DistributeAttackModifierPoints(byte attackPercentage, byte defencePercentage, byte aimingPercentage)
	{
		foreach (var @class in Classes)
		{
			var fightValues = (@class.AddFightValueOnFirstLevel ? @class.Level : @class.Level - 1) * @class.FightValueModifier;
			var attackPoints = MathHelper.GetModifier(fightValues, attackPercentage);
			var defencePoints = MathHelper.GetModifier(fightValues, defencePercentage);
			var aimingPoints = MathHelper.GetModifier(fightValues, aimingPercentage);
			var initiatorPoints = (short)(fightValues - attackPoints - defencePoints - aimingPoints);
			if (initiatorPoints < 0)
			{
				throw new InvalidOperationException("The amount of the percentages should be under 100");
			}

			InitiatingValue += initiatorPoints;
			AttackingValue += attackPoints;
			DefendingValue += defencePoints;
			AimingValue += aimingPoints;
		}
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
		NotifyPropertyChanged(nameof(Money));
		NotifyPropertyChanged(nameof(Equipment));
    }
}
