using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Kyr;

/// <summary>
/// Transz (Kyr metódus, p.126). Lets the wizard enter a trance after 10 minutes of motionless
/// meditation; required for several magical practices (e.g. Jelmágia) and for the Meditációs
/// formula method of Energiagyűjtés. While in trance, movement/speech/writing/spellcasting-gestures
/// are possible but only slowly — no quick moves or melee. Only Fp or Ép damage ("zavarás") can
/// break it early; otherwise it lasts as long as the wizard wishes (approximated as a long but
/// finite value). Bodily functions slow enough to survive 5× longer without food, drink, or air.
/// Named `KyrTrance` to avoid colliding with the unrelated Witch-school `WitchTrance` spell class.
/// </summary>
public sealed class KyrTrance : IPsiDiscipline
{
    public string Name => "Trance (Kyr)";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 600;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
