using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Qualifications.Underworld;

namespace MAGUS.Qualifications;

public static class QualificationLearner
{
    public static QualificationList Get() =>
    [
        new Riding(),
        new Swimming(),
        new HuntingAndFishing(),
        new EscapeBonds(),
        new ShieldUse(),
        new WeaponUse(qualificationLevel: QualificationLevel.Master),
        new Healing(),
        new TrackingConcealment(),
        new CamouflageOrDisguise(),
        new ReadingAndWriting(),
        new TwoHandedCombat(),
        new TrapSetting(),
        new ForestSurvival(),
        new Herbalism(),
        new Cartography(),
        new MountainSurvival(),
        new SwampSurvival(),
        new ArticSurvival(),
        new SteppeSurvival(),
        new PsiPyarron(qualificationLevel: QualificationLevel.Master)
    ];
}
