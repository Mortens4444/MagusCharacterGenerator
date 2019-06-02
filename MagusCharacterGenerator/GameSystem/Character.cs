using MagusCharacterGenerator.Castes;
using MagusCharacterGenerator.Castes.Rogue;
using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.FightModifier;
using MagusCharacterGenerator.GameSystem.Magic;
using MagusCharacterGenerator.GameSystem.Psi;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Specialities;
using MagusCharacterGenerator.Races;
using Mtf.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MagusCharacterGenerator.GameSystem
{
	public class Character : IFightModifier, ILiving, IAbilities, INotifyPropertyChanged
	{
		private short health;
		private short lifePoints;
		private short painTolerancePoints;
		private short stamina;
		private short willPower;
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
		private ushort manaPoints;
		private ushort qualificationPoints;
		private bool calculateChanges;

		// TODO: Pass the correct method to count
		private readonly MultiCasteMode multiCasteMode = MultiCasteMode.Normal_Or_SwitchedCaste;

		public event PropertyChangedEventHandler PropertyChanged;

		public Character() { }

		public Character(string name, IRace race, params ICaste[] castes)
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

		public IEnumerable<CharacterImage> Images { get; private set; }

		public string Name { get; private set; }

		public ICaste BaseCaste { get; private set; }

		public ICaste[] Castes { get; private set; }

		public IRace Race { get; private set; }

		public ushort PercentQualificationPoints { get; private set; }

		public ushort QualificationPoints
		{
			get => qualificationPoints;
			private set
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
			private set
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
			private set
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
			private set
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
			private set
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
			private set
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
			private set
			{
				if (value != aimingValue)
				{
					aimingValue = value;
					NotifyPropertyChanged();
				}
			}
		}

		public short LifePoints
		{
			get => lifePoints;
			private set
			{
				if (value != lifePoints)
				{
					lifePoints = value;
					NotifyPropertyChanged();
				}
			}
		}

		public short PainTolerancePoints
		{
			get => painTolerancePoints;
			private set
			{
				if (value != painTolerancePoints)
				{
					painTolerancePoints = value;
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
				}
			}
		}

		public short Beauty { get; private set; }

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
				}
			}
		}

		public short WillPower
		{
			get => willPower;
			set
			{
				if (value != willPower)
				{
					willPower = value;
					if (calculateChanges)
					{
						CalculatePainTolerancePoints();
						CalculateUnconsciousMentalMagicResistance();
					}
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
				}
			}
		}

		public short Gold { get; private set; }

		public short Bravery { get; private set; }

		public short Erudition { get; private set; }

		public Sorcery Sorcery { get; private set; }

		public IPsi Psi { get; private set; }

		public ushort ManaPoints
		{
			get => manaPoints;
			private set
			{
				if (value != manaPoints)
				{
					manaPoints = value;
					NotifyPropertyChanged();
				}
			}
		}

		public ushort PsiPoints
		{
			get => psiPoints;
			private set
			{
				if (value != psiPoints)
				{
					psiPoints = value;
					NotifyPropertyChanged();
				}
			}
		}

		public byte PsiPointsModifier { get; private set; }

		public QualificationList Qualifications { get; private set; } = new QualificationList();

		public List<PercentQualification> PercentQualifications { get; private set; } = new List<PercentQualification>();

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

		public void Save(string fullPath, IEnumerable<CharacterImage> characterImages)
		{
			var destinationFolder = Path.GetDirectoryName(fullPath);
			var images = new List<CharacterImage>();
			foreach (var characterImage in characterImages)
			{
				var destinationFile = Path.Combine(destinationFolder, Path.GetFileName(characterImage.ImageFile));
				File.Copy(characterImage.ImageFile, destinationFile, true);
				images.Add(new CharacterImage
				{
					ImageFile = destinationFile,
					SizeMode = characterImage.SizeMode
				});
			}

			Images = images;
			ObjectSerializer.SaveFile(fullPath, this);
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
			WillPower = (short)(BaseCaste.WillPower + Race.WillPower);
			Astral = (short)(BaseCaste.Astral + Race.Astral);
			Bravery = BaseCaste.Bravery;
			Bravery = BaseCaste.Erudition;
		}

		private void CalculateQualificationPoints()
		{
			if (multiCasteMode == MultiCasteMode.Normal_Or_SwitchedCaste)
			{
				QualificationPoints = BaseCaste.BaseQualificationPoints;
				QualificationPoints += (ushort)MathHelper.GetAboveAvarageValue(Intelligence);
				QualificationPoints += (ushort)MathHelper.GetAboveAvarageValue(Dexterity);
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
			foreach (var caste in Castes)
			{
				Qualifications.AddRange(caste.Qualifications);
				PercentQualifications.AddRange(caste.PercentQualifications);
			}
		}

		private void CalculateFightValues()
		{
			var initiatorRace = Race.SpecialQualifications.GetSpeciality<GoodInitiator>();
			
			InitiatingValue = initiatorRace != null ? initiatorRace.InitiatingBase : BaseCaste.InitiatingBaseValue;
			InitiatingValue += MathHelper.GetAboveAvarageValue(Speed);
			InitiatingValue += MathHelper.GetAboveAvarageValue(Dexterity);

			AttackingValue = BaseCaste.AttackingBaseValue;
			AttackingValue += MathHelper.GetAboveAvarageValue(Strength);
			AttackingValue += MathHelper.GetAboveAvarageValue(Speed);
			AttackingValue += MathHelper.GetAboveAvarageValue(Dexterity);

			DefendingValue = BaseCaste.DefendingBaseValue;
			DefendingValue += MathHelper.GetAboveAvarageValue(Speed);
			DefendingValue += MathHelper.GetAboveAvarageValue(Dexterity);

			var archerCaste = BaseCaste.SpecialQualifications.FirstOrDefault(specialQualification => specialQualification is GoodArcher) as GoodArcher;
			var archerRace = Race.SpecialQualifications.GetSpeciality<GoodArcher>();

			try
			{
				AimingValue = archerCaste != null ? archerCaste.AimingBase :
					archerRace != null ? archerRace.AimingBase : BaseCaste.AimingBaseValue;
				AimingValue += MathHelper.GetAboveAvarageValue(Dexterity);
			}
			catch (InvalidOperationException)
			{
				AimingValue = 0;
			}

			var (attackPercentage, defensePercentage, aimingPercentage) = DistributionProvider.Get(BaseCaste, Race);
			DistributeAttackModifierPoints(attackPercentage, defensePercentage, aimingPercentage);
		}

		private void CalculateLifePoints()
		{
			var additionalLifePoints = Race.SpecialQualifications.GetSpeciality<AdditionalLifePoints>();
			LifePoints = BaseCaste.BaseLifePoints;
			if (additionalLifePoints != null)
			{
				LifePoints = additionalLifePoints.ExtraLifePoints;
			}
			LifePoints += MathHelper.GetAboveAvarageValue(Health);
		}

		private void CalculatePainTolerancePoints()
		{
			var doubledPainToleranceBase = Race.SpecialQualifications.GetSpeciality<DoubledPainToleranceBase>();
			if (multiCasteMode == MultiCasteMode.Normal_Or_SwitchedCaste)
			{
				PainTolerancePoints = doubledPainToleranceBase != null ? (byte)(2 * BaseCaste.BasePainTolerancePoints) : BaseCaste.BasePainTolerancePoints;
				PainTolerancePoints += MathHelper.GetAboveAvarageValue(Stamina);
				PainTolerancePoints += MathHelper.GetAboveAvarageValue(WillPower);
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
		}

		private void CalculateUnconsciousAstralMagicResistance()
		{
			UnconsciousAstralMagicResistance = MathHelper.GetAboveAvarageValue(Astral);
		}

		private void CalculateUnconsciousMentalMagicResistance()
		{
			UnconsciousMentalMagicResistance = MathHelper.GetAboveAvarageValue(WillPower);
		}

		private void CalculatePsiPoints()
		{
			var caste = BaseCaste;
			//PsiPoints = 0;
			//foreach (var caste in Castes)
			{
				(IPsi psi, ushort psiPoints, byte psiPointsModifier) = PsiPointCalculator.Calculate(Qualifications, Intelligence, caste.Level);

				//if (PsiPoints < psiPoints)
				{
					Psi = psi;
					PsiPoints = psiPoints;
					PsiPointsModifier = psiPointsModifier;
				}
			}
		}

		private void CalculateManaPoints()
		{
			ManaPoints = 0;
			foreach (var caste in Castes)
			{
				var sorcery = caste.SpecialQualifications.FirstOrDefault(specialQualification => specialQualification is Sorcery) as Sorcery;
				if (BaseCaste is Bard)
				{
					sorcery.ManaPoints = (ushort)MathHelper.GetAboveAvarageValue(Intelligence);
				}
				var manaPoints = sorcery != null ? sorcery.ManaPoints : (ushort)0;

				for (int i = 1; i < caste.Level; i++)
				{
					manaPoints += sorcery != null ? sorcery.GetManaPointsModifier() : (ushort)0;
				}

				if (ManaPoints < manaPoints)
				{
					Sorcery = sorcery;
					ManaPoints = manaPoints;
				}
			}
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

		private void DistributeAttackModifierPoints(byte attackPercentage, byte defensePercentage, byte aimingPercentage)
		{
			foreach (var caste in Castes)
			{
				var fightValues = (caste.AddFightValueOnFirstLevel ? caste.Level : caste.Level - 1) * caste.FightValueModifier;
				var attackPoints = MathHelper.GetModifier(fightValues, attackPercentage);
				var defensePoints = MathHelper.GetModifier(fightValues, defensePercentage);
				var aimingPoints = MathHelper.GetModifier(fightValues, aimingPercentage);
				var initiatorPoints = (short)(fightValues - attackPoints - defensePoints - aimingPoints);
				if (initiatorPoints < 0)
				{
					throw new InvalidOperationException("The amount of the percentages should be under 100");
				}

				InitiatingValue += initiatorPoints;
				AttackingValue += attackPoints;
				DefendingValue += defensePoints;
				AimingValue += aimingPoints;
			}
		}
	}
}
