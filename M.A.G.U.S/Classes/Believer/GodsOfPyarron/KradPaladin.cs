using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class KradPaladin(byte level = 1) : Paladin(level)
{
    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new LanguageKnowledge(3),
                new LanguageKnowledge(3),
                new LanguageKnowledge(3),
                new LanguageKnowledge(3),
                new Herbalism(),
                new LegendKnowledge(),
                new HistoryKnowledge(),
                new Forestry(),
                new Cartography(),
                new Swimming()
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
                new LegendKnowledge(QualificationLevel.Master, 5),
                new HistoryKnowledge(QualificationLevel.Master, 5),
            ]);
            return result;
        }
    }

    public override string ClassName => "Krad Paladin";
}
