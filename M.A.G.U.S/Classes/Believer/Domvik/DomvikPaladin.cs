using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.Domvik;

public class DomvikPaladin(byte level = 1) : Paladin(level)
{
    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new AncientTongueLore(AntientLanguage.LinguaDomini),
                new Healing(),
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
                new AncientTongueLore(AntientLanguage.LinguaDomini, QualificationLevel.Master, 4),
            ]);
            return result;
        }
    }

    public override string Name => "Paladin of Domvik";
}
