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
                if (calculateChanges)
                {
                    CalculateFightValues(settings);
                }
                OnPropertyChanged();
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
                if (calculateChanges)
                {
                    CalculateFightValues(settings);
                }
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
                if (calculateChanges)
                {
                    CalculateFightValues(settings);
                    CalculateQualificationPoints(settings);
                }
                OnPropertyChanged();
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
                if (calculateChanges)
                {
                    CalculatePainTolerancePoints(settings);
                }
            }
            OnPropertyChanged();
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
                if (calculateChanges)
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
                if (calculateChanges)
                {
                    CalculatePsiPoints(settings);
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
                if (calculateChanges)
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
                if (calculateChanges)
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
