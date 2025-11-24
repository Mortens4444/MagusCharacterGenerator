using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class KyelPriest : Priest
{
    public KyelPriest() : base(1) { }

    public KyelPriest(byte level) : base(level) { }

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
                new LanguageLore(3),
                new LanguageLore(3),
                new LanguageLore(2),
                new Etiquette(QualificationLevel.Master),
                new Healing(),
                new Herbalism(),
                new Disarmament()
            ]);
            return result;
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
            return result;
        }
    }

    public override string Name => "Priest of Kyel";
}
