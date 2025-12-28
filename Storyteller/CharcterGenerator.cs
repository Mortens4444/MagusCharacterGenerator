using FontAwesome.Sharp;
using M.A.G.U.S.Classes.Believer.GodsOfPyarron;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;
using Mtf.Extensions;
using Mtf.LanguageService;
using Mtf.LanguageService.Windows.Forms;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Enums;
using Mtf.Windows.Forms.Extensions.Services;
using System.ComponentModel;
using System.Reflection;

namespace Storyteller;

public partial class CharcterGenerator : Form
{
	private readonly Dictionary<string, Type> races = [];
	private readonly Dictionary<string, Type> classes = [];

	private Type selectedRace = typeof(Amund);
	private Type selectedClass = typeof(ArelPriest);
	private Type selectedSecondaryClass;
	private Character character;
	private readonly List<CharacterImage> images = [];
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
		Translator.Translate(this);
		cbImageSizeMode.SelectedIndex = 1;
	}

	public void LoadCharacter(Character character, string imageToLoad)
	{
		this.character = character;
		FillFromCharacter();

        //var image = character.Images.FirstOrDefault();
        //var image = character.Images.FirstOrDefault(img => img == imageToLoad);
        //var image = character.Images.FirstOrDefault(img => img.ImageFile == imageToLoad);
        //if (image.ImageFile == null && character.Images.Any())
        //{
        //	image = character.Images.First();
        //}
        LoadImageFromPath(pbCharacter, imageToLoad);
	}

    public static void LoadImageFromPath(PictureBox pictureBox, string imagePath)
    {
        try
        {
            if (imagePath == null)
            {
                pictureBox.Image = null;
            }
            else
            {
                pictureBox.Image = Image.FromFile(imagePath);
                pictureBox.Image.Tag = imagePath;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        catch
        {
            pictureBox.Image = null;
        }
    }

    private void CharcterGenerator_Load(object sender, EventArgs e)
	{
		var magusCharacterGeneratorTypes = Assembly.Load("M.A.G.U.S.").GetTypes();

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

		var classesWithTypes = magusCharacterGeneratorTypes
			.Where(type => !type.IsAbstract && typeof(IClass).IsAssignableFrom(type))
            .Select(classType => (Class: Activator.CreateInstance(classType, 1), Type: classType))
			.OrderBy(classWithType => classWithType.Class.ToString());

		foreach (var classWithTypes in classesWithTypes)
		{
			var className = Lng.Elem(classWithTypes.Class.ToString());
			classes.Add(className, classWithTypes.Type);
			cbClass.Items.Add(className);
			cbSecondaryClass.Items.Add(className);
		}
		cbClass.SelectedIndex = 0;
		cbSecondaryClass.SelectedIndex = 0;

		Generate();
	}

	private void BtnGenerate_Click(object sender, EventArgs e)
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
			var characterName = !String.IsNullOrEmpty(tbName.Text) ? tbName.Text : NameGenerator.Get(null).ToName();
			tbName.Text = characterName;

			var race = (IRace)Activator.CreateInstance(selectedRace);
			var @class = (IClass)Activator.CreateInstance(selectedClass, (int)nudLevel.Value);
			if (selectedSecondaryClass != null && chkBoxSecondaryClass.Checked)
			{
				var secondaryClass = (IClass)Activator.CreateInstance(selectedSecondaryClass, (int)nudSecondaryClassLevel.Value);
				var created = Activator.CreateInstance(typeof(Character), characterName, race, @class, secondaryClass);
				if (created is not Character c)
                {
                    throw new InvalidOperationException("Failed to create Character instance.");
                }

                character = c;
			}
			else
			{
				character = (Character)Activator.CreateInstance(typeof(Character), characterName, race, @class);
			}
			character.PropertyChanged += Character_PropertyChanged;
			character.SetWeapons();
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

		nudLevel.Value = character.Classes[0].Level;
		cbClass.Text = character.Classes[0].ToString();

		chkBoxSecondaryClass.Checked = character.Classes.Length > 1;
		if (chkBoxSecondaryClass.Checked)
		{
			nudSecondaryClassLevel.Value = character.Classes[1].Level;
			cbSecondaryClass.Text = character.Classes[1].ToString();
		}

		LoadCharacterProperties();

		SetInitiateValue();
		SetAttackValue();
		SetDefenseValue();
		SetAimingValue();
		SetHealthPoints();
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
			var text = $"{Lng.Elem(qualification.Name)} ({Lng.Elem(qualification.QualificationLevel.GetDescription())})";
			var endIndex = text.LastIndexOf(' ');
			var name = text[..endIndex];
			var item = new ListViewItem(name);
			if (i++ % 2 == 0)
			{
				item.BackColor = Color.LightBlue;
			}
			item.SubItems.Add(text[(endIndex + 1)..]);
			lvQualifications.Items.Add(item);
		}

		//character.PercentQualifications
	}

	private void LoadCharacterProperties()
	{
		nudStrength.Value = character.Strength;
		nudSpeed.Value = character.Quickness;
		nudDexterity.Value = character.Dexterity;
		nudStamina.Value = character.Stamina;
		nudHealth.Value = character.Health;
		nudBeauty.Value = character.Beauty;
		nudWillpower.Value = character.Willpower;
		nudIntelligence.Value = character.Intelligence;
		nudAstral.Value = character.Astral;
		nudGold.Value = character.Money.Gold;
		nudBravery.Value = character.Bravery;
		nudErudition.Value = character.Erudition;
	}

	private void Character_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
			case nameof(character.MaxHealthPoints):
				SetHealthPoints();
				break;
			case nameof(character.MaxPainTolerancePoints):
				SetPaintTolerancePoints();
				break;
			case nameof(character.InitiateValue):
				SetInitiateValue();
				break;
			case nameof(character.AttackValue):
				SetAttackValue();
				break;
			case nameof(character.DefenseValue):
				SetDefenseValue();
				break;
			case nameof(character.AimValue):
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

	private void SetHealthPoints()
	{
		nudLifePoints.Value = character.MaxHealthPoints;
	}

	private void SetPaintTolerancePoints()
	{
		nudPainTolerancePoints.Value = character.MaxPainTolerancePoints;
	}

	private void SetAimingValue()
	{
		nudAimV.Value = character.AimValue;
	}

	private void SetPsiPoints()
	{
		nudPsiPoints.Value = character.PsiPoints;
	}

	private void SetDefenseValue()
	{
		nudDV.Value = character.DefenseValue;
	}

	private void SetAttackValue()
	{
		nudAV.Value = character.AttackValue;
	}

	private void SetInitiateValue()
	{
		nudIV.Value = character.InitiateValue;
	}

	#endregion

	private void CbRace_SelectedIndexChanged(object sender, EventArgs e)
	{
		selectedRace = races[cbRace.SelectedItem.ToString()];
		SetDiceThrowLabel();
	}

	private void CbClass_SelectedIndexChanged(object sender, EventArgs e)
	{
		selectedClass = classes[cbClass.SelectedItem.ToString()];
		SetDiceThrowLabel();
	}

	private void SetDiceThrowLabel()
	{
		if ((selectedClass == null) || (selectedClass == null))
		{
			return;
		}

		var @class = (IClass)Activator.CreateInstance(selectedClass, (int)nudLevel.Value);
		var race = (IRace)Activator.CreateInstance(selectedRace);
        SetDiceThrowLabel(@class, race, nameof(@class.Strength), lblStrengthDiceThrow);
        SetDiceThrowLabel(@class, race, nameof(@class.Quickness), lblSpeedDiceThrow);
        SetDiceThrowLabel(@class, race, nameof(@class.Dexterity), lblDexterityDiceThrow);
        SetDiceThrowLabel(@class, race, nameof(@class.Stamina), lblStaminaDiceThrow);
        SetDiceThrowLabel(@class, race, nameof(@class.Health), lblHealthDiceThrow);
        SetDiceThrowLabel(@class, race, nameof(@class.Beauty), lblBeautyDiceThrow);
        SetDiceThrowLabel(@class, race, nameof(@class.Willpower), lblWillpowerDiceThrow);
        SetDiceThrowLabel(@class, race, nameof(@class.Intelligence), lblIntelligenceDiceThrow);
        SetDiceThrowLabel(@class, race, nameof(@class.Astral), lblAstralDiceThrow);
        SetDiceThrowLabel(@class, race, nameof(@class.Gold), lblGoldDiceThrow);
        SetDiceThrowLabel(@class, race, nameof(@class.Bravery), lblBraveryDiceThrow);
        SetDiceThrowLabel(@class, race, nameof(@class.Erudition), lblEruditionDiceThrow);
	}

	private static void SetDiceThrowLabel(IClass @class, IRace race, string propertyName, Label label)
	{
		var classAttributes = @class.GetCustomAttributes(propertyName);
		var diceThrow = classAttributes?.GetAttribute<DiceThrowAttribute>();
        var diceThrowModifier = classAttributes?.GetAttribute<DiceThrowModifierAttribute>();
		var specialTrainingAttribute = classAttributes?.GetAttribute<SpecialTrainingAttribute>();
		label.Text = Lng.Elem(diceThrow?.DiceThrowType.GetDescription()) ?? String.Empty;
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
		var raceModifier = race.GetIntPropertyValue(propertyName);
		if (raceModifier != 0)
		{
			label.Text += raceModifier < 0 ? $" - {Math.Abs(raceModifier)}" : $" + {raceModifier}";
		}
	}

	private void CbSecondaryClass_SelectedIndexChanged(object sender, EventArgs e)
	{
		selectedSecondaryClass = classes[cbSecondaryClass.SelectedItem.ToString()];
	}

	private void BtnDone_Click(object sender, EventArgs e)
	{
		var charactersDirectory = Path.Combine(PathProvider.Characters, tbName.Text);
		bool createCharacter = !Directory.Exists(charactersDirectory) || ConfirmBox.Show(Lng.Elem("Confirmation"), Lng.Elem("Character already exists, do you want to owerwrite it?"), Decide.No) == DialogResult.Yes;
		if (createCharacter)
		{
			DirectoryUtils.CreateIfNotExists(charactersDirectory);
			Save(character, Path.Combine(charactersDirectory, String.Concat("character", ExtensionProvider.CharacterSheetExtension)), images);
		}
	}

	public void Save(Character character, string fullPath, IEnumerable<CharacterImage> characterImages)
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
		
        //character.Images = images.Select(i => Image.FromFile(i.ImageFile)).ToList();

        ObjectSerializer.SaveFile(fullPath, this);
	}

	private CharacterImage CreateCharacterImage()
	{
		return new CharacterImage
		{
			ImageFile = pbCharacter.Image?.Tag as string ?? String.Empty,
			SizeMode = GetSizeModeFromComboBoxSelection()
		};
	}

	private PictureBoxSizeMode GetSizeModeFromComboBoxSelection()
	{
		return (PictureBoxSizeMode)cbImageSizeMode.SelectedIndex;
	}

	private void NudHealth_ValueChanged(object sender, EventArgs e)
	{
		character.Health = (int)nudHealth.Value;
	}

	private void NudStamina_ValueChanged(object sender, EventArgs e)
	{
		character.Stamina = (int)nudStamina.Value;
	}

	private void NudWillpower_ValueChanged(object sender, EventArgs e)
	{
		character.Willpower = (int)nudWillpower.Value;
	}

	private void NudStrength_ValueChanged(object sender, EventArgs e)
	{
		character.Strength = (int)nudStrength.Value;
	}

	private void NudSpeed_ValueChanged(object sender, EventArgs e)
	{
		character.Quickness = (int)nudSpeed.Value;
	}

	private void NudDexterity_ValueChanged(object sender, EventArgs e)
	{
		character.Dexterity = (int)nudDexterity.Value;
	}

	private void NudAstral_ValueChanged(object sender, EventArgs e)
	{
		character.Astral = (int)nudAstral.Value;
	}

	private void NudIntelligence_ValueChanged(object sender, EventArgs e)
	{
		character.Intelligence = (int)nudIntelligence.Value;
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

	private void ChkBoxSecondaryClass_CheckedChanged(object sender, EventArgs e)
	{
		cbSecondaryClass.Enabled = chkBoxSecondaryClass.Checked;
		nudSecondaryClassLevel.Enabled = chkBoxSecondaryClass.Checked;
	}

	private void BtnAdd_Click(object sender, EventArgs e)
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

	private void BtnRemove_Click(object sender, EventArgs e)
	{
		if (pbCharacter.Image == null)
		{
			return;
		}

		var currentImage = CreateCharacterImage();
        images.Remove(currentImage);
        shownImageIndex = 0;
		SetAddRemoveButtonState();
	}

	private void SetAddRemoveButtonState()
	{
		btnPrevious.Enabled = images.Count > 1 && shownImageIndex > 0;
		btnNext.Enabled = images.Count > 1 && shownImageIndex < images.Count - 1;
	}

	private void BtnPrevious_Click(object sender, EventArgs e)
	{
		if (shownImageIndex > 0)
		{
			shownImageIndex--;
            LoadImageFromPath(pbCharacter, images[shownImageIndex].ImageFile);
		}
		SetAddRemoveButtonState();
	}

	private void BtnNext_Click(object sender, EventArgs e)
	{
		if (shownImageIndex < images.Count - 1)
		{
			shownImageIndex++;
            LoadImageFromPath(pbCharacter, images[shownImageIndex].ImageFile);
		}
		SetAddRemoveButtonState();
	}
}
