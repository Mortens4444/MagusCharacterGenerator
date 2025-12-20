using M.A.G.U.S.Classes.NonPlayableCharacters;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.CombatModifiers;
using M.A.G.U.S.Interfaces;
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

    public Character() : this(null) { }

    public Character(ISettings? settings)
    {
        this.settings = settings;
        race = new Human();
        BaseClass = new Craftsman();
        Alignment = Alignment.Order;
        EnsureSubscriptions();
    }

    public Character(ISettings? settings, string name, IRace race, params IClass[] classes)
    {
        this.settings = settings;
        this.race = race;
        Name = name;
        BaseClass = classes.First();
        Alignment = race.Alignment ?? BaseClass.Alignment;
        Classes = classes;
        CreateFirstLevel();
        EnsureSubscriptions();
    }

    public void SetWeapons()
    {
        primaryWeapon = ResolveWeaponById(PrimaryWeaponId);
        secondaryWeapon = ResolveWeaponById(SecondaryWeaponId);
    }

    public static Character Load(string fullPath, ISettings settings)
    {
        var result = ObjectSerializer.LoadFile<Character>(fullPath);
        result.SetWeapons();
        result.RecalculateCombatValues(settings);
        return result;
    }

    private void CreateFirstLevel()
    {
        GenerateAbilities();
        CalculateQualificationPoints(settings);
        GetQualifications();
        CalculateCombatValues(settings);

        CalculateLifePoints();
        CalculatePainTolerancePoints(settings);

        CalculateManaPoints(settings);
        CalculatePsiPoints(settings);

        CalculateUnconsciousAstralMagicResistance();
        CalculateUnconsciousMentalMagicResistance();

        CalculateGold();
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
        RecalculateCombatValues(settings);
    }
}
