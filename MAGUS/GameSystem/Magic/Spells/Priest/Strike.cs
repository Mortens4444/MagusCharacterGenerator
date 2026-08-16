using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Priest;

/// <summary>
/// Csapás (Szférikus — Természet, Lélek, Halál). The rulebook's offensive mode is a force spear
/// dealing 2D6+1 damage (the defensive mode, a knockback wall, isn't modeled). No magic-resistance
/// roll applies (ME "–" in the rulebook), hence Power is null — it always connects, like a
/// guaranteed-hit force attack.
/// </summary>
public sealed class Strike : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Strike";

    public MagicSchool School => MagicSchool.Priest;

    public Sphere[] Spheres => [Sphere.Nature, Sphere.Soul, Sphere.Death];

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(1)]
    public int GetDamage() => diceThrow._2D6() + 1;
}
