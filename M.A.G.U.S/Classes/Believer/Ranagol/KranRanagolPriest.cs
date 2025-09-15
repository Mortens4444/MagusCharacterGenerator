using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Magic;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.Ranagol;

public class KranRanagolPriest(byte level = 1) : Priest(level)
{
    public override QualificationList FutureQualifications
    {
        get
        {
            var result = base.FutureQualifications;
            result.AddRange(
            [
                new MagicUsage(level: 3),
                new AntientLanguageKnowledge(AntientLanguage.Aquir, level: 5),
                new MagicUsage(QualificationLevel.Master, 6),
                new AntientLanguageKnowledge(AntientLanguage.Aquir, QualificationLevel.Master, 11)
            ]);
            return result;
        }
    }

    public override string ClassName => "Ranagol Priest (Kran)";
}
