using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

public sealed class SmiteUnbeliever : ISpell
{
    private readonly DiceThrow diceThrow = new();

    /// <summary>Which priest sphere grants this spell. Not yet cross-checked against a deity (Character has no Deity field).</summary>
    public Sphere Sphere => Sphere.Destruction;

    public string Name => "Smite unbeliever";

    public MagicSchool School => MagicSchool.Priest;

    public int InitiateValue => 30;

    public int ManaCost => 5;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._2D6)]
    public int GetDamage() => diceThrow._2D6();
}
