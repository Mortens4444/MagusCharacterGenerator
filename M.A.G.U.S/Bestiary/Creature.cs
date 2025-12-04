using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Psi;

namespace M.A.G.U.S.Bestiary;

public abstract class Creature
{
    public Occurrence Occurrence { get; protected set; }
    
    public Intelligence Intelligence { get; protected set; }
    
    public Size Size { get; protected set; }

    public byte ArmorClass { get; protected set; }

    public byte Speed { get; protected set; }

    public byte AttackValue { get; protected set; }

    public byte DefenseValue { get; protected set; }

    public byte InitiatingValue { get; protected set; }

    public byte? AimingValue { get; protected set; }

    public byte? AstralMagicResistance { get; protected set; }

    public byte? MentalMagicResistance { get; protected set; }

    public byte? PoisonResistance { get; protected set; }

    public byte? HealthPoints { get; protected set; }

    public byte? PainTolerancePoints { get; protected set; }

    public uint ExperiencePoints { get; protected set; }

    public double AttacksPerRound { get; protected set; } = 1;

    public string Description { get; protected set; }

    public virtual string[] Images => [ $"{Name.Replace(" ", "_").ToLower()}.png" ];

    public virtual string[] Sounds => [ $"{Name.Replace(" ", "_").ToLower()}" ];

    public Alignment? Alignment { get; set; }
    
    public IPsi Psi { get; set; }

    public byte PsiPoints { get; set; }

    public byte ManaPoints { get; set; }

    protected readonly DiceThrow DiceThrow = new();

    protected Creature() { }

    public abstract byte GetDamage();

    public int GetInitiate()
    {
        var roll = DiceThrow._1D10();
        return InitiatingValue + roll;
    }
    
    public (AttackImpact impact, int value) GetAttack()
    {
        var roll = DiceThrow._1D100();
        var impact = roll == 100 ? AttackImpact.Critical : roll == 1 ? AttackImpact.Fatal : AttackImpact.Normal;
        return (impact, AttackValue + roll);
    }

    public abstract byte GetNumberAppearing();

    public virtual string Name => GetType().Name;
}
