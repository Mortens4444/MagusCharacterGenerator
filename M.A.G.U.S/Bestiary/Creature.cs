using M.A.G.U.S.Enums;
using M.A.G.U.S.Extensions;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.Things.Weapons;
using System.Reflection;

namespace M.A.G.U.S.Bestiary;

public abstract class Creature : Attacker
{
    private const string PrimaryAttack = "Primary attack";
    private List<Attack>? attackModes;
    private int? painTolerancePoints;
    private int? healthPoints;

    protected Creature() { }

    public Occurrence Occurrence { get; protected set; }

    public Intelligence? Intelligence { get; protected set; }
    
    public Intelligence? MinIntelligence { get; protected set; }

    public Intelligence? MaxIntelligence { get; protected set; }

    public Size Size { get; protected set; }

    public override List<Attack> AttackModes
    {
        get
        {
            if (attackModes == null)
            {
                attackModes = [];

                var method = GetType().GetMethod(nameof(GetDamage));
                var throwAttr = method?.GetCustomAttribute<DiceThrowAttribute>();
                if (throwAttr == null)
                {
                    attackModes.Add(new MeleeAttack(PrimaryAttack, AttackValue, GetDamage));
                }
                else
                {
                    var modAttr = method?.GetCustomAttribute<DiceThrowModifierAttribute>();
                    var modifier = modAttr?.Modifier ?? 0;
                    attackModes.Add(new MeleeAttack(new BodyPart(PrimaryAttack, throwAttr.DiceThrowType, modifier), AttackValue));
                }
            }

            return attackModes;
        }
        protected set => attackModes = value;
    }

    public int? AstralMagicResistance { get; protected set; }

    public int? MentalMagicResistance { get; protected set; }

    public int? PoisonResistance { get; protected set; }

    public int? HealthPoints
    {
        get => healthPoints;
        set
        {
            if (value.HasValue)
            {
                ActualHealthPoints = value.Value;
            }
            healthPoints = value;
        }
    }

    public int? MinHealthPoints { get; protected set; }

    public int? MaxHealthPoints { get; protected set; }

    public override int ActualHealthPoints { get; set; }

    public override int ActualPainTolerancePoints { get; set; }

    public int? PainTolerancePoints
    {
        get => painTolerancePoints;
        set
        {
            if (value.HasValue)
            {
                ActualPainTolerancePoints = value.Value;
            }
            painTolerancePoints = value;
        }
    }

    public int? MinPainTolerancePoints { get; protected set; }

    public int? MaxPainTolerancePoints { get; protected set; }

    public ulong ExperiencePoints { get; protected set; }

    public string Description { get; protected set; }

    public virtual string[] Images => [ $"{Name.ToImageName()}.png" ];

    public virtual string[] Sounds => [ $"{Name.ToImageName()}" ];

    public Alignment? Alignment { get; set; }
    
    public IPsi Psi { get; set; }

    public int PsiPoints { get; set; }

    public bool ResistantToPsi { get; set; }

    public int ManaPoints { get; set; }

    protected readonly DiceThrow DiceThrow = new();

    public int GetInitiate()
    {
        var roll = DiceThrow._1D10();
        return InitiateValue + roll;
    }
    
    public abstract int GetNumberAppearing();

    public override string Name => GetType().Name;

    public string DisplayHealthPoints
    {
        get
        {
            if (MinHealthPoints.HasValue && MaxHealthPoints.HasValue)
            {
                return $"{MinHealthPoints.Value} - {MaxHealthPoints.Value}";
            }

            return HealthPoints?.ToString() ?? String.Empty;
        }
    }

    public string DisplayPainTolerancePoints
    {
        get
        {
            if (MinPainTolerancePoints.HasValue && MaxPainTolerancePoints.HasValue)
            {
                return $"{MinPainTolerancePoints.Value} - {MaxPainTolerancePoints.Value}";
            }

            return PainTolerancePoints?.ToString() ?? String.Empty;
        }
    }
}
