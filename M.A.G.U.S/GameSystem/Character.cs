using M.A.G.U.S.Classes.NonPlayableCharacters;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.FightModifiers;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;
using System.ComponentModel;

namespace M.A.G.U.S.GameSystem;

public partial class Character : Attacker, IFightModifier, ILiving, IAbilities, INotifyPropertyChanged
{
    private bool calculateChanges;

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

    public void CalculateChanges()
    {
        calculateChanges = true;
        primaryWeapon = ResolveWeaponById(PrimaryWeaponId);
        secondaryWeapon = ResolveWeaponById(SecondaryWeaponId);
    }

    private void EnsureSubscriptions()
    {
        Equipment.CollectionChanged += EquipmentOnCollectionChanged;
        Qualifications.CollectionChanged += Qualifications_CollectionChanged;
    }

    public static Character Load(string fullPath, ISettings settings)
    {
        var result = ObjectSerializer.LoadFile<Character>(fullPath);
        result.CalculateChanges();
        result.RecalculateFightValues(settings);
        return result;
    }

    private void CreateFirstLevel()
    {
        GenerateAbilities();
        CalculateQualificationPoints(settings);
        GetQualifications();
        CalculateFightValues(settings);

        CalculateLifePoints();
        CalculatePainTolerancePoints(settings);

        CalculateManaPoints(settings);
        CalculatePsiPoints(settings);

        CalculateUnconsciousAstralMagicResistance();
        CalculateUnconsciousMentalMagicResistance();

        CalculateGold();
    }
}
