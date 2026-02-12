using M.A.G.U.S.Classes.NonPlayableCharacters;
using M.A.G.U.S.Enums;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Models;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.GameSystem;

public partial class Character : Attacker, ICombatModifier, ILiving, IAbilities, INotifyPropertyChanged
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private bool isDeserializing;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private readonly ISettings? settings;

    public bool PlayerCharacter { get; set; }

    public override List<Speed> Speeds { get; } = [
        new Speed(TravelMode.OnLand, 6, speedLevel: SpeedLevel.Slowest),   // Séta ~1.2 m/s
        new Speed(TravelMode.OnLand, 17, speedLevel: SpeedLevel.Slow),      // Gyors gyaloglás ~1.7 m/s
        new Speed(TravelMode.OnLand, 30, speedLevel: SpeedLevel.Normal),    // Kocogás ~3.0 m/s
        new Speed(TravelMode.OnLand, 45, speedLevel: SpeedLevel.Fast),      // Futás ~4.5 m/s
        new Speed(TravelMode.OnLand, 110, speedLevel: SpeedLevel.Fastest),  // Sprint ~11.0 m/s
        new Speed(TravelMode.InWater, 6, speedLevel: SpeedLevel.Slowest),   // Átlagos úszó ~0.6 m/s
        new Speed(TravelMode.InWater, 11, speedLevel: SpeedLevel.Slow),     // Jó úszó ~1.1 m/s
        new Speed(TravelMode.InWater, 21, speedLevel: SpeedLevel.Fast)      // Versenyúszó ~2.1 m/s
    ];

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
        Classes = classes;
        CreateSpecifiedLevel();
        EnsureSubscriptions();

        if (race is Feenhar || race is Draquon) // Speeds shoud be filled from races
        {
            Speeds.Add(new Speed(TravelMode.InTheAir, 60));
        }
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
}
