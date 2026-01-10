using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Qualifications;

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
