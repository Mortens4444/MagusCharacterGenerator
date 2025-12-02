using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.Domvik;

public class DomvikPaladin : Paladin
{
    public DomvikPaladin() : base() { }

    public DomvikPaladin(byte level) : base(level) { }

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
                new AncientTongueLore(AntientLanguage.LinguaDomini, QualificationLevel.Master, 4),
            ]);
            return BuildQualifications(result);
        }
    }

    public override string Name => "Paladin of Domvik";
}
