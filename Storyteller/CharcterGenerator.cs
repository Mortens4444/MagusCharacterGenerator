using FontAwesome.Sharp;
using MagusCharacterGenerator.Castes;
using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.Attributes;
using MagusCharacterGenerator.Races;
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
		private List<CharacterImage> images = new List<CharacterImage>();
		private int shownImageIndex = 0;

		public CharcterGenerator(bool canGenerate =  false)
		{
			InitializeComponent();

			btnDone.Visible = canGenerate;
			btnGenerate.Visible = canGenerate;
			btnDone.Enabled = canGenerate;
			btnGenerate.Enabled = canGenerate;

			if (!canGenerate)
			{
				nudAimV.ReadOnly = true;
			}

			Icon = IconCreator.Get(IconChar.UserCircle, Color.Maroon);
			Lng.Translate(this);
			cbImageSizeMode.SelectedIndex = 1;
		}

		public void LoadCharacter(Character character, string imageToLoad)
		{
			this.character = character;
			FillFromCharacter();

			var image = character.Images.FirstOrDefault(img => img.ImageFile == imageToLoad);
			if (image.ImageFile == null && character.Images.Any())
			{
				image = character.Images.First();
			}
			image.Load(pbCharacter);
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

			try
			{
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
				character.CalculateChanges();
				FillFromCharacter();
			}
			catch
			{
				Generate();
			}
		}

		private void FillFromCharacter()
		{
			cbRace.Text = character.Race.ToString();
			tbName.Text = character.Name;

			nudLevel.Value = character.Castes[0].Level;
			cbCaste.Text = character.Castes[0].ToString();

			chkBoxSecondaryCaste.Checked = character.Castes.Length > 1;
			if (chkBoxSecondaryCaste.Checked)
			{
				nudSecondaryCasteLevel.Value = character.Castes[1].Level;
				cbSecondaryCaste.Text = character.Castes[1].ToString();
			}

			LoadCharacterProperties();

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

		private void LoadCharacterProperties()
		{
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
			SetDiceThrowLabel();
		}

		private void cbCaste_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedCaste = castes[cbCaste.SelectedItem.ToString()];
			SetDiceThrowLabel();
		}

		private void SetDiceThrowLabel()
		{
			if ((selectedCaste == null) || (selectedCaste == null))
			{
				return;
			}

			var caste = (ICaste)Activator.CreateInstance(selectedCaste, (byte)nudLevel.Value);
			var race = (IRace)Activator.CreateInstance(selectedRace);
			SetDiceThrowLabel(caste, race, nameof(caste.Strength), lblStrengthDiceThrow);
			SetDiceThrowLabel(caste, race, nameof(caste.Speed), lblSpeedDiceThrow);
			SetDiceThrowLabel(caste, race, nameof(caste.Dexterity), lblDexterityDiceThrow);
			SetDiceThrowLabel(caste, race, nameof(caste.Stamina), lblStaminaDiceThrow);
			SetDiceThrowLabel(caste, race, nameof(caste.Health), lblHealthDiceThrow);
			SetDiceThrowLabel(caste, race, nameof(caste.Beauty), lblBeautyDiceThrow);
			SetDiceThrowLabel(caste, race, nameof(caste.WillPower), lblWillPowerDiceThrow);
			SetDiceThrowLabel(caste, race, nameof(caste.Intelligence), lblIntelligenceDiceThrow);
			SetDiceThrowLabel(caste, race, nameof(caste.Astral), lblAstralDiceThrow);
			SetDiceThrowLabel(caste, race, nameof(caste.Gold), lblGoldDiceThrow);
			SetDiceThrowLabel(caste, race, nameof(caste.Bravery), lblBraveryDiceThrow);
			SetDiceThrowLabel(caste, race, nameof(caste.Erudition), lblEruditionDiceThrow);
		}

		private void SetDiceThrowLabel(ICaste caste, IRace race, string propertyName, Label label)
		{
			var casteAttributes = caste.GetCustomAttributes(propertyName);
			var diceThrow = AttributeUtils.GetAttribute<DiceThrowAttribute>(casteAttributes);
			var diceThrowModifier = AttributeUtils.GetAttribute<DiceThrowModifierAttribute>(casteAttributes);
			var specialTrainingAttribute = AttributeUtils.GetAttribute<SpecialTrainingAttribute>(casteAttributes);
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
			var raceModifier = race.GetPropertyShortValue(propertyName);
			if (raceModifier != 0)
			{
				label.Text += raceModifier < 0 ? $" - {Math.Abs(raceModifier)}" : $" + {raceModifier}";
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
				character.Save(Path.Combine(charactersDirectory, String.Concat("character", ExtensionProvider.CharacterSheetExtension)), images);
			}
		}

		private CharacterImage CreateCharacterImage()
		{
			return new CharacterImage
			{
				ImageFile = (string)pbCharacter.Image.Tag,
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
				pbCharacter.Image.Tag = ofdCharacterImage.FileName;
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

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (pbCharacter.Image == null)
			{
				return;
			}

			var currentImage = CreateCharacterImage();
			if (!images.Contains(currentImage))
			{
				images.Add(currentImage);
			}
			shownImageIndex = images.Count - 1;
			SetAddRemoveButtonState();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (pbCharacter.Image == null)
			{
				return;
			}

			var currentImage = CreateCharacterImage();
			if (images.Contains(currentImage))
			{
				images.Remove(currentImage);
			}
			shownImageIndex = 0;
			SetAddRemoveButtonState();
		}

		private void SetAddRemoveButtonState()
		{
			btnPrevious.Enabled = images.Count > 1 && shownImageIndex > 0;
			btnNext.Enabled = images.Count > 1 && shownImageIndex < images.Count - 1;
		}

		private void btnPrevious_Click(object sender, EventArgs e)
		{
			if (shownImageIndex > 0)
			{
				shownImageIndex--;
				images[shownImageIndex].Load(pbCharacter);
			}
			SetAddRemoveButtonState();
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (shownImageIndex < images.Count - 1)
			{
				shownImageIndex++;
				images[shownImageIndex].Load(pbCharacter);
			}
			SetAddRemoveButtonState();
		}
	}
}
