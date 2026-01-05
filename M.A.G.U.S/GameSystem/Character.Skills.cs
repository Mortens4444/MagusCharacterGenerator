using M.A.G.U.S.Races;
using System.Text.Json.Serialization;

namespace M.A.G.U.S.GameSystem;

public partial class Character
{
    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int strength;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int stamina;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int speed;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int dexterity;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int health;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int willpower;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int intelligence;

    [NonSerialized, JsonIgnore, Newtonsoft.Json.JsonIgnore]
    private int astral;

    public int Strength
    {
        get => strength;
        set
        {
            if (value != strength)
            {
                strength = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AttackValue));
            }
        }
    }

    public int Quickness
    {
        get => speed;
        set
        {
            if (value != speed)
            {
                speed = value;
                OnPropertyChanged(nameof(InitiateValue));
                OnPropertyChanged(nameof(AttackValue));
                OnPropertyChanged(nameof(DefenseValue));
                OnPropertyChanged();
            }
        }
    }

    public int Dexterity
    {
        get => dexterity;
        set
        {
            if (value != dexterity)
            {
                dexterity = value;
                if (!isDeserializing)
                {
                    CalculateQualificationPoints(settings);
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(InitiateValue));
                OnPropertyChanged(nameof(AimValue));
                OnPropertyChanged(nameof(DefenseValue));
            }
        }
    }

    public int Stamina
    {
        get => stamina;
        set
        {
            if (value != stamina)
            {
                stamina = value;
                if (!isDeserializing)
                {
                    CalculatePainTolerancePoints(settings);
                }
                OnPropertyChanged();
            }
        }
    }

    public int Health
    {
        get => health;
        set
        {
            if (value != health)
            {
                health = value;
                if (!isDeserializing)
                {
                    CalculateLifePoints();
                }
                OnPropertyChanged();
            }
        }
    }

    public int Beauty { get; set; }

    public int Intelligence
    {
        get => intelligence;
        set
        {
            if (value != intelligence)
            {
                intelligence = value;
                if (!isDeserializing)
                {
                    CalculatePsiPoints(Race is Jann, settings);
                    CalculateManaPoints(settings);
                    CalculateQualificationPoints(settings);
                }
                OnPropertyChanged();
            }
        }
    }

    public int Willpower
    {
        get => willpower;
        set
        {
            if (value != willpower)
            {
                willpower = value;
                if (!isDeserializing)
                {
                    CalculatePainTolerancePoints(settings);
                    CalculateUnconsciousMentalMagicResistance();
                }
                OnPropertyChanged();
            }
        }
    }

    public int Astral
    {
        get => astral;
        set
        {
            if (value != astral)
            {
                astral = value;
                if (!isDeserializing)
                {
                    CalculateUnconsciousAstralMagicResistance();
                }
                OnPropertyChanged();
            }
        }
    }

    public int Bravery { get; set; }

    public int Erudition { get; set; }

    public int Detection { get; set; }

    private void GenerateAbilities()
    {
        Strength = BaseClass.Strength + Race.Strength;
        Quickness = BaseClass.Quickness + Race.Quickness;
        Dexterity = BaseClass.Dexterity + Race.Dexterity;
        Stamina = BaseClass.Stamina + Race.Stamina;
        Health = BaseClass.Health + Race.Health;
        Beauty = BaseClass.Beauty + Race.Beauty;
        Intelligence = BaseClass.Intelligence + Race.Intelligence;
        Willpower = BaseClass.Willpower + Race.Willpower;
        Astral = BaseClass.Astral + Race.Astral;
        Bravery = BaseClass.Bravery;
        Erudition = BaseClass.Erudition;
        Detection = BaseClass.Detection;
    }
}
