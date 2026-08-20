using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Slan;

/// <summary>
/// Levitáció (Slan-út, p.125). Lets the user hover 1 meter above the ground; 1 Psi point sustains
/// it for 1 hour, 2 for two hours, etc. — the height never increases, but the user can lift any
/// weight their body can otherwise bear. While active the user's body becomes unharmable by any
/// non-magical weapon. Requires continuous concentration; no physical attacks, other disciplines,
/// or spellcasting possible while sustaining it. Named `SlanLevitation` to avoid colliding with
/// the unrelated Witch-school `Levitate` spell class.
/// </summary>
public sealed class SlanLevitation : IPsiDiscipline
{
    public string Name => "Levitation (Slan)";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
