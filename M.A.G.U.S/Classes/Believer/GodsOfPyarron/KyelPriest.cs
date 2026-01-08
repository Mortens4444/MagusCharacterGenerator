using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class KyelPriest : Priest
{
    public KyelPriest() : base() { }

    public KyelPriest(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new WeaponUse(),
                new WeaponUse(),
                new WeaponUse(),
                new ShieldUse(),
                new HeavyArmorWearing(),
                new WeaponLore(),
                new Leadership(),
                new LanguageLore(Language.Erven, 3),
                new LanguageLore(Language.Toronian, 3),
                new LanguageLore(Language.Doranian, 2),
                new Etiquette(QualificationLevel.Master),
                new Healing(),
                new Herbalism(),
                new Disarmament()
            ]);
            return BuildQualifications(result);
        }
    }

    public override QualificationList FutureQualifications
    {
        get
        {
            var result = base.FutureQualifications;
            result.AddRange(
            [
                new Cartography(level: 3),
                new Healing(QualificationLevel.Master, 4),
                new Herbalism(QualificationLevel.Master, 5),
                new Physiology(level: 6),
                new Disarmament(QualificationLevel.Master, 7),
            ]);
            return BuildQualifications(result);
        }
    }

    public override string Name => "Priest of Kyel";
}
