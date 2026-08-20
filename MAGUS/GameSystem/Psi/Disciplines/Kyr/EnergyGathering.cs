using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Kyr;

/// <summary>
/// Energiagyűjtés (Kyr metódus, p.126-127). The wizard's core discipline: converts Psi points into
/// Mana points, the base of all their spellcasting. The book gives three methods — Meditációs
/// formula (1 Pp = 10 Mp, needs a prepared Meditációs Varázskör and an hour-long trance),
/// Kivonás (1 Pp = 3 Mp, only 2 rounds, no preparation, drawing off ambient excess energy
/// harmlessly), and Kisajtolás (1 Pp = 5 Mp, 5 segments, black magic that forcibly wrings energy
/// from the surroundings and inflicts pain on nearby creatures — modeled separately as
/// `ForcedEnergyExtraction`). This class represents the cheap, no-preparation Kivonás method.
/// Converts Psi into Mana rather than dealing damage or resolving as a combat effect, so it's a
/// flavor-only catalog entry — Attacker has no generic Mana-points setter to apply the conversion
/// to (matching how the Warlock HarvestLifeForce class handles the same limitation).
/// </summary>
public sealed class EnergyGathering : IPsiDiscipline
{
    public string Name => "Energy gathering";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
