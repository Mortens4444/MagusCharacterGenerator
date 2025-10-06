using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;

namespace M.A.G.U.S.Bestiary;

public abstract class Creature
{
    public Occurrence Occurrence { get; protected set; }
    
    public Intelligence Intelligence { get; protected set; }
    
    public Size Size { get; protected set; }

    public byte Speed { get; protected set; }

    public byte AttackValue { get; protected set; }

    public byte DefenseValue { get; protected set; }

    public byte InitiatingValue { get; protected set; }

    public byte? AimingValue { get; protected set; }

    public byte? AstralMagicResistance { get; protected set; }

    public byte? MentalMagicResistance { get; protected set; }

    public byte? PoisonResistance { get; protected set; }

    public byte MaxHealthPoints { get; protected set; }

    public byte HealthPoints { get; protected set; }

    public byte MaxPainTolerancePoints { get; protected set; }

    public byte PainTolerancePoints { get; protected set; }

    public uint ExperiencePoints { get; protected set; }

    public double AttacksPerRound { get; protected set; } = 1;

    public Alignment? Alignment { get; set; }

    protected readonly DiceThrow DiceThrow = new();

    protected Creature() { }

    public abstract byte GetDamage();

    public abstract byte GetNumberAppearing();

    public virtual string Name => GetType().Name;
}
