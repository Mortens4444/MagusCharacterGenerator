using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Kyr;

/// <summary>
/// Kisajtolás (Kyr metódus, Energiagyűjtés's black-magic variant, p.126-127). Forcibly wrings Mana
/// out of the surroundings (1 Pp = 5 Mp) in a 20-meter zone around the caster; every full 20 Mp
/// extracted withers nearby plants (above 20 Mp) and inflicts 1D6 Fp of pain on every creature in
/// the zone (never Ép). Doc note: the Mana-point conversion itself isn't modeled (Attacker has no
/// generic Mana-points setter); only the 1D6 Fp/20-Mp-tier pain is represented, and only as a
/// single target's damage rather than a true zone effect affecting everyone present.
/// </summary>
public sealed class ForcedEnergyExtraction : IPsiDiscipline
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Forced energy extraction";

    public int? Power => null;

    public int PsiPointCost => 4;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
