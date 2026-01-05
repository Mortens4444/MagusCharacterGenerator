using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;
using M.A.G.U.S.Qualifications.Underworld;
using M.A.G.U.S.Races;

namespace M.A.G.U.S.Classes.Believer.Ranagol;

public class GalrajaPriest : Priest
{
    public GalrajaPriest() : base() { }

    public GalrajaPriest(int level) : base(level) { }

    public override QualificationList Qualifications => BuildQualifications(
    [
        new Fistfight(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponUse(),
        new WeaponThrowing(),
        new ReadingAndWriting(),
        new LanguageLore(Language.Jad, 4),
        new LanguageLore(Language.Pyarronian, 3),
        new LanguageLore(Language.Shadonian, 3),
        new LanguageLore(Language.Erven, 2),
        new LanguageLore(Language.Tiadlanian, 1),
        new LanguageLore(Language.Ilanorian, 1),
        new WeatherDivination(),
        new Cartography(QualificationLevel.Master),
        new LegendLore(),
        new HistoryLore(),
        new ReligionLore(QualificationLevel.Master),
        new Herbalism(),
        new Healing(),
        new PsiPyarron(QualificationLevel.Master),
        new TrackingConcealment(),
        new Riding(),
        new SingingAndMakingMusic(),
        new Running()
    ]);

    public override QualificationList FutureQualifications
    {
        get
        {
            var result = new QualificationList();
            result.AddRange(
            [
                new WeatherDivination(QualificationLevel.Master, 3),
                new LegendLore(QualificationLevel.Master, 4),
                new Riding(QualificationLevel.Master, 5),
                new HistoryLore(QualificationLevel.Master, 5),
                new Healing(QualificationLevel.Master, 5),
                new Running(QualificationLevel.Master, 6),
            ]);
            return BuildQualifications(result);
        }
    }

    public override SpecialQualificationList SpecialQualifications
    {
        get
        {
            var result = new SpecialQualificationList();
            result.AddRange(
            [
                new AdditionalLanguageLearningQualificationPointOnLevelUp()
            ]);
            return result;
        }
    }

    public override IRace[] AllowedRaces => [new Human(), new Jann()];

    public override string Name => "Priest of Galraja";

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(5)]
    public override int GetPainToleranceModifier() => DiceThrow._1D6() + 5;

}
