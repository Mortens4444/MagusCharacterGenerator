﻿using FontAwesome.Sharp;
using MagusCharacterGenerator.Castes;
using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.Race;
using Mtf.Helper;
using Mtf.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Storyteller
{
	public partial class CharcterGenerator : Form
	{
		private readonly Dictionary<string, Type> races = new Dictionary<string, Type>();
		private readonly Dictionary<string, Type> castes = new Dictionary<string, Type>();

		private Type selectedRace;
		private Type selectedCaste;
		private Type selectedSecondaryCaste;
		private Character character;

		public CharcterGenerator(bool canGenerate =  false)
		{
			InitializeComponent();

			btnDone.Visible = canGenerate;
			btnGenerate.Visible = canGenerate;
			btnDone.Enabled = canGenerate;
			btnGenerate.Enabled = canGenerate;

			Icon = IconCreator.Get(IconChar.UserCircle, Color.Maroon);
			Lng.Translate(this);
			cbImageSizeMode.SelectedIndex = 1;
		}

		private void CharcterGenerator_Load(object sender, EventArgs e)
		{
			var magusCharacterGeneratorTypes = Assembly.Load("MagusCharacterGenerator").GetTypes();

			var racesWithTypes = magusCharacterGeneratorTypes
				.Where(type => !type.IsInterface && !type.IsAbstract && typeof(IRace).IsAssignableFrom(type))
				.Select(raceType => (Race: Activator.CreateInstance(raceType), Type: raceType))
				.OrderBy(raceWithType => raceWithType.Race.ToString());

			foreach (var raceWithType in racesWithTypes)
			{
				var raceName = Lng.Elem(raceWithType.Race.ToString());
				races.Add(raceName, raceWithType.Type);
				cbRace.Items.Add(raceName);
			}
			cbRace.SelectedIndex = 0;

			var castesWithTypes = magusCharacterGeneratorTypes
				.Where(type => !type.IsAbstract && typeof(ICaste).IsAssignableFrom(type))
				.Select(casteType => (Caste: Activator.CreateInstance(casteType, (byte)1), Type: casteType))
				.OrderBy(casteWithType => casteWithType.Caste.ToString());

			foreach (var casteWithType in castesWithTypes)
			{
				var casteName = Lng.Elem(casteWithType.Caste.ToString());
				castes.Add(casteName, casteWithType.Type);
				cbCaste.Items.Add(casteName);
				cbSecondaryCaste.Items.Add(casteName);
			}
			cbCaste.SelectedIndex = 0;
			cbSecondaryCaste.SelectedIndex = 0;

			Generate();
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			Generate();
		}

		private void Generate()
		{
			if (!btnGenerate.Enabled)
			{
				return;
			}

			var characterName = !String.IsNullOrEmpty(tbName.Text) ? tbName.Text : NameGenerator.Get().ToName();
			tbName.Text = characterName;

			var race = (IRace)Activator.CreateInstance(selectedRace);
			var caste = (ICaste)Activator.CreateInstance(selectedCaste, (byte)nudLevel.Value);
			if (selectedSecondaryCaste != null && chkBoxSecondaryCaste.Checked)
			{
				var secondCaste = (ICaste)Activator.CreateInstance(selectedSecondaryCaste, (byte)nudSecondaryCasteLevel.Value);
				character = (Character)Activator.CreateInstance(typeof(Character), characterName, race, caste, secondCaste);
			}
			else
			{
				character = (Character)Activator.CreateInstance(typeof(Character), characterName, race, caste);
			}
			character.PropertyChanged += Character_PropertyChanged;

			nudStrength.Value = character.Strength;
			nudSpeed.Value = character.Speed;
			nudDexterity.Value = character.Dexterity;
			nudStamina.Value = character.Stamina;
			nudHealth.Value = character.Health;
			nudBeauty.Value = character.Beauty;
			nudWillPower.Value = character.WillPower;
			nudIntelligence.Value = character.Intelligence;
			nudAstral.Value = character.Astral;
			nudGold.Value = character.Gold;
			nudBravery.Value = character.Bravery;
			nudErudition.Value = character.Erudition;

			SetInitiatingValue();
			SetAttackingValue();
			SetDefendingValue();
			SetAimingValue();
			SetLifePoints();
			SetPaintTolerancePoints();

			SetPsiPoints();
			SetManaPoints();
			SetAstralMagicResistance();
			SetMentalMagicResistance();

			SetQualificationPoints();
			nudPercent.Value = character.PercentQualificationPoints;

			lvQualifications.Items.Clear();
			//character.Psi
			int i = 0;
			foreach (var qualification in character.Qualifications.OrderBy(qualification => qualification.ToString()))
			{
				//var item = new ListViewItem(qualification.ToString());
				//item.SubItems.Add();
				var text = qualification.ToFullString();
				var endIndex = text.LastIndexOf(' ');
				var name = text.Substring(0, endIndex);
				var item = new ListViewItem(name);
				if (i++ % 2 == 0)
				{
					item.BackColor = Color.LightBlue;
				}
				item.SubItems.Add(text.Substring(endIndex + 1));
				lvQualifications.Items.Add(item);
			}

			//character.PercentQualifications
		}

		private void Character_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(character.LifePoints):
					SetLifePoints();
					break;
				case nameof(character.PainTolerancePoints):
					SetPaintTolerancePoints();
					break;
				case nameof(character.InitiatingValue):
					SetInitiatingValue();
					break;
				case nameof(character.AttackingValue):
					SetAttackingValue();
					break;
				case nameof(character.DefendingValue):
					SetDefendingValue();
					break;
				case nameof(character.AimingValue):
					SetAimingValue();
					break;
				case nameof(character.UnconsciousAstralMagicResistance):
					SetAstralMagicResistance();
					break;
				case nameof(character.UnconsciousMentalMagicResistance):
					SetMentalMagicResistance();
					break;
				case nameof(character.PsiPoints):
					SetPsiPoints();
					break;
				case nameof(character.ManaPoints):
					SetManaPoints();
					break;
				case nameof(character.QualificationPoints):
					SetQualificationPoints();
					break;
			}
		}

		#region Set values

		private void SetQualificationPoints()
		{
			nudQP.Value = character.QualificationPoints;
		}

		private void SetManaPoints()
		{
			nudManaPoints.Value = character.ManaPoints;
		}

		private void SetMentalMagicResistance()
		{
			nudMentalMR.Value = character.UnconsciousMentalMagicResistance;
		}

		private void SetAstralMagicResistance()
		{
			nudAstralMR.Value = character.UnconsciousAstralMagicResistance;
		}

		private void SetLifePoints()
		{
			nudLifePoints.Value = character.LifePoints;
		}

		private void SetPaintTolerancePoints()
		{
			nudPainTolerancePoints.Value = character.PainTolerancePoints;
		}

		private void SetAimingValue()
		{
			nudAimV.Value = character.AimingValue;
		}

		private void SetPsiPoints()
		{
			nudPsiPoints.Value = character.PsiPoints;
		}

		private void SetDefendingValue()
		{
			nudDV.Value = character.DefendingValue;
		}

		private void SetAttackingValue()
		{
			nudAV.Value = character.AttackingValue;
		}

		private void SetInitiatingValue()
		{
			nudIV.Value = character.InitiatingValue;
		}

		#endregion

		private void cbRace_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedRace = races[cbRace.SelectedItem.ToString()];
		}

		private void cbCaste_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedCaste = castes[cbCaste.SelectedItem.ToString()];
			var caste = (ICaste)Activator.CreateInstance(selectedCaste, (byte)nudLevel.Value);
			SetDiceThrowLabel(caste, nameof(caste.Strength), lblStrengthDiceThrow);
			SetDiceThrowLabel(caste, nameof(caste.Speed), lblSpeedDiceThrow);
			SetDiceThrowLabel(caste, nameof(caste.Dexterity), lblDexterityDiceThrow);
			SetDiceThrowLabel(caste, nameof(caste.Stamina), lblStaminaDiceThrow);
			SetDiceThrowLabel(caste, nameof(caste.Health), lblHealthDiceThrow);
			SetDiceThrowLabel(caste, nameof(caste.Beauty), lblBeautyDiceThrow);
			SetDiceThrowLabel(caste, nameof(caste.WillPower), lblWillPowerDiceThrow);
			SetDiceThrowLabel(caste, nameof(caste.Intelligence), lblIntelligenceDiceThrow);
			SetDiceThrowLabel(caste, nameof(caste.Astral), lblAstralDiceThrow);
			SetDiceThrowLabel(caste, nameof(caste.Gold), lblGoldDiceThrow);
			SetDiceThrowLabel(caste, nameof(caste.Bravery), lblBraveryDiceThrow);
			SetDiceThrowLabel(caste, nameof(caste.Erudition), lblEruditionDiceThrow);
		}

		private void SetDiceThrowLabel(ICaste caste, string propertyName, Label label)
		{
			var attributes = AttributeUtils.GetAttributes(caste, propertyName);
			var diceThrow = AttributeUtils.GetAttribute<DiceThrowAttribute>(attributes);
			var diceThrowModifier = AttributeUtils.GetAttribute<DiceThrowModifierAttribute>(attributes);
			var specialTrainingAttribute = AttributeUtils.GetAttribute<SpecialTrainingAttribute>(attributes);
			label.Text = Lng.Elem(EnumUtils.GetDescription(diceThrow.DiceThrowType));
			if (diceThrowModifier != null)
			{
				label.Text += $" + {diceThrowModifier.Modifier}";
			}
			if (specialTrainingAttribute != null)
			{
				label.Text += $" + {Lng.Elem("St")}";
			}
			if (diceThrow.DiceThrowType.ToString().EndsWith("2_Times"))
			{
				label.Text += " (2x)";
			}
		}

		private void cbSecondaryCaste_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedSecondaryCaste = castes[cbSecondaryCaste.SelectedItem.ToString()];
		}

		private void btnDone_Click(object sender, EventArgs e)
		{
			var charactersDirectory = Path.Combine(PathProvider.Characters, tbName.Text);
			bool createCharacter = !Directory.Exists(charactersDirectory) || ConfirmBox.Show(Lng.Elem("Character already exists, do you want to owerwrite it?"));
			if (createCharacter)
			{
				DirectoryExtension.CreateIfNotExists(charactersDirectory);
				CharacterImage characterImage = GetCharacterImage();
				character.Save(Path.Combine(charactersDirectory, String.Concat("character", ExtensionProvider.CharacterSheetExtension)), characterImage);
			}
		}

		private CharacterImage GetCharacterImage()
		{
			return new CharacterImage
			{
				ImageFile = (string)pbCharacter.Tag,
				SizeMode = GetSizeModeFromComboBoxSelection()
			};
		}

		private PictureBoxSizeMode GetSizeModeFromComboBoxSelection()
		{
			return (PictureBoxSizeMode)cbImageSizeMode.SelectedIndex;
		}

		private void NudHealth_ValueChanged(object sender, EventArgs e)
		{
			character.Health = (short)nudHealth.Value;
		}

		private void NudStamina_ValueChanged(object sender, EventArgs e)
		{
			character.Stamina = (short)nudStamina.Value;
		}

		private void NudWillPower_ValueChanged(object sender, EventArgs e)
		{
			character.WillPower = (short)nudWillPower.Value;
		}

		private void NudStrength_ValueChanged(object sender, EventArgs e)
		{
			character.Strength = (short)nudStrength.Value;
		}

		private void NudSpeed_ValueChanged(object sender, EventArgs e)
		{
			character.Speed = (short)nudSpeed.Value;
		}

		private void NudDexterity_ValueChanged(object sender, EventArgs e)
		{
			character.Dexterity = (short)nudDexterity.Value;
		}

		private void NudAstral_ValueChanged(object sender, EventArgs e)
		{
			character.Astral = (short)nudAstral.Value;
		}

		private void NudIntelligence_ValueChanged(object sender, EventArgs e)
		{
			character.Intelligence = (short)nudIntelligence.Value;
		}

		private void BtnBrowse_Click(object sender, EventArgs e)
		{
			if (ofdCharacterImage.ShowDialog() == DialogResult.OK)
			{
				pbCharacter.Image = Image.FromFile(ofdCharacterImage.FileName);
				pbCharacter.Tag = ofdCharacterImage.FileName;
			}
		}

		private void CbImageSizeMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			pbCharacter.SizeMode = GetSizeModeFromComboBoxSelection();
		}

		private void chkBoxSecondaryCaste_CheckedChanged(object sender, EventArgs e)
		{
			cbSecondaryCaste.Enabled = chkBoxSecondaryCaste.Checked;
			nudSecondaryCasteLevel.Enabled = chkBoxSecondaryCaste.Checked;
		}
	}
}
