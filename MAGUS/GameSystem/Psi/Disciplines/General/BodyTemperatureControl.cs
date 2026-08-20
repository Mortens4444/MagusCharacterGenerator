using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Testhőmérséklet Növelés (Hűtés) (Általános Diszciplína, p.121). Raises or lowers the user's own
/// body temperature (master level: another creature's) by 5°C per Psi point spent, for 1 hour per
/// point (doubling the point cost extends the hour count). Extreme swings are dangerous per the
/// book (fever above 50°C risks fainting and death; below 5°C is fatal) but that escalating harm
/// isn't modeled here — this is a flavor-only self-buff by default.
/// </summary>
public sealed class BodyTemperatureControl : IPsiDiscipline
{
    public string Name => "Body temperature control";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
