using M.A.G.U.S.Classes;
using M.A.G.U.S.Classes.Rogue;
using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.FightModifier;
using M.A.G.U.S.GameSystem.Magic;
using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Percentages;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace M.A.G.U.S.GameSystem;

public class Character : IFightModifier, ILiving, IAbilities, INotifyPropertyChanged
{
	private short health;
	private short healthPoints;
	private short maxHealthPoints;
    private short painTolerancePoints;
	private short maxPainTolerancePoints;
    private short stamina;
	private short willpower;
	private short strength;
	private short speed;
	private short dexterity;
	private short initiatingValue;
	private short attackingValue;
	private short defendingValue;
	private short aimingValue;
	private short unconsciousAstralMagicResistance;
	private short unconsciousMentalMagicResistance;
	private short astral;
	private short intelligence;
	private ushort psiPoints;
	private ushort maxPsiPoints;
    private ushort manaPoints;
	private ushort maxManaPoints;
    private ushort qualificationPoints;
	private bool calculateChanges;

	// TODO: Pass the correct method to count
	private readonly MultiCasteMode multiCasteMode = MultiCasteMode.Normal_Or_SwitchedCaste;

	public event PropertyChangedEventHandler? PropertyChanged;

	public Character() { }

	public Character(string name, IRace race, params IClass[] castes)
	{
		Name = name;
		BaseCaste = castes.First();
		Castes = castes;
		Race = race;
		CreateFirstLevel();
	}

	#region Properties

	public void CalculateChanges()
	{
		calculateChanges = true;
	}

	//public IEnumerable<Image> Images { get; set; }

    private string name;
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
    public IClass BaseCaste { get; set; }

	public IClass[] Castes { get; set; }

    private IRace race;
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

    public short Strength
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

	public short Speed
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

	public short Dexterity
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

	public short Stamina
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

	public short Health
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

	public short Beauty { get; set; }

    public string Birthplace { get; set; }
    public string CasteNames { get; set; }
    public string ExperienceLevel { get; set; }
    public string InArmorInitiative { get; set; }
    public string School { get; set; }
    public string Alignment { get; set; }

    public short Intelligence
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

	public short Willpower
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

	public short Astral
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

	public short Gold { get; set; }

	public short Bravery { get; set; }

	public short Erudition { get; set; }

	public Sorcery Sorcery { get; set; }

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

    public List<PercentQualification> PercentQualifications { get; private set; } = [];

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
		CalculateCasteSpecificLevelUps();
		CalculatePsiPoints();

		CalculateUnconsciousAstralMagicResistance();
		CalculateUnconsciousMentalMagicResistance();

		CalculateGold();
	}

	private void CalculateGold()
	{
		Gold = (short)Castes.Sum(caste => caste.Gold);
	}

	private void GenerateAbilities()
	{
		Strength = (short)(BaseCaste.Strength + Race.Strength);
		Speed = (short)(BaseCaste.Speed + Race.Speed);
        Dexterity = (short)(BaseCaste.Dexterity + Race.Dexterity);
		Stamina = (short)(BaseCaste.Stamina + Race.Stamina);
		Health = (short)(BaseCaste.Health + Race.Health);
		Beauty = (short)(BaseCaste.Beauty + Race.Beauty);
		Intelligence = (short)(BaseCaste.Intelligence + Race.Intelligence);
		Willpower = (short)(BaseCaste.Willpower + Race.Willpower);
		Astral = (short)(BaseCaste.Astral + Race.Astral);
		Bravery = BaseCaste.Bravery;
		Erudition = BaseCaste.Erudition;
	}

	private void CalculateQualificationPoints()
	{
		if (multiCasteMode == MultiCasteMode.Normal_Or_SwitchedCaste)
		{
			QualificationPoints = BaseCaste.BaseQualificationPoints;
			QualificationPoints += (ushort)MathHelper.GetAboveAverageValue(Intelligence);
			QualificationPoints += (ushort)MathHelper.GetAboveAverageValue(Dexterity);
			if (BaseCaste.AddQualificationPointsOnFirstLevel)
			{
				QualificationPoints += BaseCaste.QualificationPointsModifier;
			}
			for (int i = 1; i < BaseCaste.Level; i++)
			{
				QualificationPoints += BaseCaste.QualificationPointsModifier;
				PercentQualificationPoints += BaseCaste.PercentQualificationModifier;
			}
		}
		else
		{
			// TwinCaste
			// When it got the new caste?
			throw new NotImplementedException();
		}
	}

	private void GetQualifications()
	{
		SpecialQualifications.AddRange(Race.SpecialQualifications);

		foreach (var caste in Castes)
		{
			Qualifications.AddRange(caste.Qualifications);
			PercentQualifications.AddRange(caste.PercentQualifications);
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
		
		InitiatingValue = initiatorRace != null ? initiatorRace.InitiatingBase : BaseCaste.InitiatingBaseValue;
		InitiatingValue += MathHelper.GetAboveAverageValue(Speed);
		InitiatingValue += MathHelper.GetAboveAverageValue(Dexterity);

		AttackingValue = BaseCaste.AttackingBaseValue;
		AttackingValue += MathHelper.GetAboveAverageValue(Strength);
		AttackingValue += MathHelper.GetAboveAverageValue(Speed);
		AttackingValue += MathHelper.GetAboveAverageValue(Dexterity);

		DefendingValue = BaseCaste.DefendingBaseValue;
		DefendingValue += MathHelper.GetAboveAverageValue(Speed);
		DefendingValue += MathHelper.GetAboveAverageValue(Dexterity);

		var archerCaste = BaseCaste.SpecialQualifications.FirstOrDefault(specialQualification => specialQualification is GoodArcher) as GoodArcher;
		var archerRace = Race.SpecialQualifications.GetSpeciality<GoodArcher>();

		try
		{
			AimingValue = archerCaste != null ? archerCaste.AimingBase :
				archerRace != null ? archerRace.AimingBase : BaseCaste.AimingBaseValue;
			AimingValue += MathHelper.GetAboveAverageValue(Dexterity);
		}
		catch (InvalidOperationException)
		{
			AimingValue = 0;
		}

		var (attackPercentage, defencePercentage, aimingPercentage) = DistributionProvider.Get(BaseCaste, Race);
		DistributeAttackModifierPoints(attackPercentage, defencePercentage, aimingPercentage);
	}

	private void CalculateLifePoints()
	{
		var additionalLifePoints = Race.SpecialQualifications.GetSpeciality<AdditionalLifePoints>();
		HealthPoints = BaseCaste.BaseLifePoints;
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
		if (multiCasteMode == MultiCasteMode.Normal_Or_SwitchedCaste)
		{
			PainTolerancePoints = doubledPainToleranceBase != null ? (byte)(2 * BaseCaste.BasePainTolerancePoints) : BaseCaste.BasePainTolerancePoints;
			PainTolerancePoints += MathHelper.GetAboveAverageValue(Stamina);
			PainTolerancePoints += MathHelper.GetAboveAverageValue(Willpower);
			if (BaseCaste.AddPainToleranceOnFirstLevel)
			{
				PainTolerancePoints += BaseCaste.GetPainToleranceModifier();
			}

			for (int i = 1; i < BaseCaste.Level; i++)
			{
				PainTolerancePoints += BaseCaste.GetPainToleranceModifier();
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
		UnconsciousAstralMagicResistance += (short)((BaseCaste.Level - 1) * (doubledPainToleranceBase?.ExtraResistancePoints ?? 0));
	}

	private void CalculateUnconsciousMentalMagicResistance()
	{
        var doubledPainToleranceBase = Race.SpecialQualifications.GetSpeciality<ExtraMagicResistanceOnLevelUp>();
        UnconsciousMentalMagicResistance = MathHelper.GetAboveAverageValue(Willpower);
        UnconsciousMentalMagicResistance += (short)((BaseCaste.Level - 1) * (doubledPainToleranceBase?.ExtraResistancePoints ?? 0));
	}

	private void CalculatePsiPoints()
    {
        var kyrLore = Race.SpecialQualifications.GetSpeciality<KyrLore>();

        var caste = BaseCaste;
		//PsiPoints = 0;
		//foreach (var caste in Castes)
		{
			(IPsi psi, ushort psiPoints, byte psiPointsModifier) = PsiPointCalculator.Calculate(Qualifications, Intelligence, caste.Level, kyrLore);
            
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
		foreach (var caste in Castes)
		{
			var sorcery = caste.SpecialQualifications.FirstOrDefault(specialQualification => specialQualification is Sorcery) as Sorcery;
			if (BaseCaste is Bard)
			{
				sorcery.ManaPoints = (ushort)MathHelper.GetAboveAverageValue(Intelligence);
            }
			var manaPoints = sorcery != null ? sorcery.ManaPoints : (ushort)0;
			
			if (kyrLore != null)
			{
				manaPoints += BaseCaste.Level;
			}

            for (int i = 1; i < caste.Level; i++)
			{
				manaPoints += sorcery != null ? sorcery.GetManaPointsModifier() : (ushort)0;
            }

			MaxManaPointsPerLevel = sorcery != null ? sorcery.GetManaPointsModifier() : (ushort)0;

            if (ManaPoints < manaPoints)
			{
				Sorcery = sorcery;
				ManaPoints = manaPoints;
			}
		}
		MaxManaPoints = ManaPoints;
    }

	// FIXME: Multi-caste
	private void CalculateCasteSpecificLevelUps()
	{
		foreach (var caste in Castes)
		{
			var newQualifications = caste.FutureQualifications
				.Where(futureQualification => futureQualification.MasterQualificationLevel <= caste.Level);

			var newBaseQualifications = newQualifications
				.Where(futureQualification => futureQualification.QualificationLevel == QualificationLevel.Base);

			Qualifications.AddRange(newBaseQualifications);

			var newMasterQualifications = newQualifications.Except(newBaseQualifications).Concat(Race.Qualifications);
			foreach (var newMasterQualification in newMasterQualifications)
			{
				Qualifications.UpgradeOrAddQualification(newMasterQualification);
			}
		}
	}

	private void DistributeAttackModifierPoints(byte attackPercentage, byte defencePercentage, byte aimingPercentage)
	{
		foreach (var caste in Castes)
		{
			var fightValues = (caste.AddFightValueOnFirstLevel ? caste.Level : caste.Level - 1) * caste.FightValueModifier;
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
}
