using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.Enums;
using MAGUS.Interfaces;
using MAGUS.Models;
using MAGUS.Races;
using MAGUS.Utils;
using Mtf.Extensions;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MAGUS.GameSystem;

public partial class Character : Attacker, ICombatModifier, ILiving, IAbilities, INotifyPropertyChanged
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private bool isDeserializing;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private readonly ISettings? settings;

    public bool PlayerCharacter { get; set; }

    public override List<Speed> Speeds => Race.Speeds;

    public Character() : this(null) { }

    public Character(ISettings? settings)
    {
        this.settings = settings;
        race = new Human();
        BaseClass = new Craftsman();
        Alignment = Alignment.Order;
        Size = race.Size;
        EnsureSubscriptions();
    }

    public override Size Size { get; protected set; }

    public Character(ISettings? settings, string name, IRace race, params IClass[] classes)
    {
        this.settings = settings;
        this.race = race;
        Name = name;
        BaseClass = classes.First();
        Alignment = race.Alignment ?? BaseClass.Alignment;
        Deity = BaseClass.Deity;
        Classes = classes;

        foreach (var @class in classes)
        {
            Equipment.AddRange(@class.StartingEquipment);
        }

        CreateSpecifiedLevel();
        EnsureSubscriptions();
    }

    public static Character Load(string fullPath, ISettings settings)
    {
        var result = ObjectSerializer.LoadFile<Character>(fullPath);
        result.SetWeapons();
        return result;
    }

    private void CreateSpecifiedLevel()
    {
        GenerateAbilities();
        CalculateQualificationPoints(settings);
        GetQualifications();
        CalculateCombatValueModifier(settings);

        CalculateLifePoints();
        CalculatePainTolerancePoints(settings);

        CalculateManaPoints(settings);
        CalculatePsiPoints(Race is Jann, settings);

        CalculateUnconsciousAstralMagicResistance();
        CalculateUnconsciousMentalMagicResistance();

        CalculateGold();

        BaseClass.ExperiencePoints = BaseClass.GetExperiencePointsForLevel(BaseClass.Level);
    }

    private void EnsureSubscriptions()
    {
        UnsubscribeFromCollections();
        if (Equipment != null)
        {
            Equipment.CollectionChanged += EquipmentOnCollectionChanged;
        }

        if (Qualifications != null)
        {
            Qualifications.CollectionChanged += Qualifications_CollectionChanged;
        }

        Died += OnDied;
    }

    private void UnsubscribeFromCollections()
    {
        if (Equipment != null)
        {
            Equipment.CollectionChanged -= EquipmentOnCollectionChanged;
        }
        if (Qualifications != null)
        {
            Qualifications.CollectionChanged -= Qualifications_CollectionChanged;
        }

        Died -= OnDied;
    }

    [OnDeserializing]
    private void OnDeserializing(StreamingContext context)
    {
        isDeserializing = true;
    }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        isDeserializing = false;
        EnsureSubscriptions();
        SetWeapons();
        SetOriginalCombatValues();
    }

    public void SetMaxValues()
    {
        ActualHealthPoints = MaxHealthPoints;
        ActualPainTolerancePoints = MaxPainTolerancePoints;
        ManaPoints = MaxManaPoints;
        PsiPoints = MaxPsiPoints;
    }

}
