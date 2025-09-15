using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Battle;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class KyelPriest(byte level = 1) : Priest(level)
{
    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new WeaponUsage(),
                new WeaponUsage(),
                new WeaponUsage(),
                new ShieldUsing(),
                new HeavyArmorWearing(),
                new WeaponKnowledge(),
                new Leadership(),
                new LanguageKnowledge(3),
                new LanguageKnowledge(3),
                new LanguageKnowledge(2),
                new Etiquette(QualificationLevel.Master),
                new WoundHealing(),
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
                new WoundHealing(QualificationLevel.Master, 4),
                new Herbalism(QualificationLevel.Master, 5),
                new Physiology(level: 6),
                new Disarmament(QualificationLevel.Master, 7),
            ]);
            return result;
        }
    }

    public override string ClassName => "Kiel Priest";
}
