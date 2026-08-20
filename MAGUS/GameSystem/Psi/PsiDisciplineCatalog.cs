using MAGUS.GameSystem.Psi.Disciplines.General;
using MAGUS.GameSystem.Psi.Disciplines.Kyr;
using MAGUS.GameSystem.Psi.Disciplines.Slan;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi;

public static class PsiDisciplineCatalog
{
    // Rulebook (p.117): Slan-út and Kyr-módszer practitioners also get every Általános Diszciplína
    // (at master level from level 1), on top of whatever their own method adds. Every other named
    // school (AntientWay, Monk, Jann, Pyarron, Krannish) uses the Pyarroni módszer, i.e. only the
    // Általános Diszciplínák, just calibrated with different base values per school/culture — those
    // per-school numbers aren't sourced from the rulebook yet, so every school currently shares the
    // same General values until that research is done.
    private static readonly IReadOnlyList<IPsiDiscipline> General =
    [
        new PsiPush(),
        new PsiSiege(),
        new MemoryRecall(),
        new SelfWaking(),
        new SenseAlteration(),
        new PainRelief(),
        new SixthSense(),
        new AbilityEnhancement(),
        new Telekinesis(),
        new Telepathy(),
        new BodyTemperatureControl(),
        new StaticPsiShield(),
        new DynamicPsiShield()
    ];

    private static readonly IReadOnlyList<IPsiDiscipline> SlanOnly =
    [
        new DeathTouch(),
        new GoldenBell(),
        new InnerTime(),
        new ChiCombat(),
        new Imperceptibility(),
        new Insignificance(),
        new SlanLevitation(),
        new SlanStaticPsiShield(),
        new WeightChange(),
        new SuspendedAnimation()
    ];

    private static readonly IReadOnlyList<IPsiDiscipline> KyrOnly =
    [
        new Disruption(),
        new EnergyGathering(),
        new ForcedEnergyExtraction(),
        new KyrTrance(),
        new DetectInvisibilityKyr(),
        new AstralEye(),
        new MentalEye(),
        new AuraSense(),
        new MagicGaze(),
        new KyrPsiSiege()
    ];

    public static IEnumerable<IPsiDiscipline> GetAvailable(Character character)
    {
        if (character.Psi == null)
        {
            return [];
        }

        return character.Psi.PsiKind switch
        {
            PsiKind.Slan => [.. General, .. SlanOnly],
            PsiKind.Kyr => [.. General, .. KyrOnly],
            _ => General
        };
    }
}
