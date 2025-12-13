using M.A.G.U.S.Classes.NonPlayableCharacters;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.FightModifiers;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace M.A.G.U.S.GameSystem;

public partial class Character : IFightModifier, ILiving, IAbilities, INotifyPropertyChanged
{
    private bool calculateChanges;

    private readonly ISettings? settings;

    public event PropertyChangedEventHandler? PropertyChanged;

    public Character() : this(null) { }

    public Character(ISettings? settings)
    {
        this.settings = settings;
        name = "Nobody";
        race = new Human();
        BaseClass = new Craftsman();
        Alignment = Alignment.Order;
        EnsureSubscriptions();
    }

    public Character(ISettings? settings, string name, IRace race, params IClass[] classes)
    {
        this.settings = settings;
        this.name = name;
        this.race = race;
        BaseClass = classes.First();
        Alignment = race.Alignment ?? BaseClass.Alignment;
        Classes = classes;
        CreateFirstLevel();
        EnsureSubscriptions();
    }

    public void CalculateChanges()
    {
        calculateChanges = true;
    }

    private void EnsureSubscriptions()
    {
        Equipment.CollectionChanged += EquipmentOnCollectionChanged;
        Qualifications.CollectionChanged += Qualifications_CollectionChanged;
    }

    public void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
