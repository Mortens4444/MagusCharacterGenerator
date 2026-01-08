using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class DreinaPaladin : Paladin
{
    public DreinaPaladin() : base() { }

    public DreinaPaladin(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new HistoryLore(),
                new Leadership(),
                new Cartography(),
                new Heraldry()
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
                new Cartography(level: 4)
            ]);
            return BuildQualifications(result);
        }
    }

    public override string Name => "Paladin of Dreina";
}
