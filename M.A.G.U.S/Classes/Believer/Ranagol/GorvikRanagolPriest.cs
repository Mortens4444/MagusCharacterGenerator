using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Classes.Believer.Ranagol;

public class GorvikRanagolPriest : Priest
{
    public GorvikRanagolPriest() : base() { }

    public GorvikRanagolPriest(byte level) : base(level) { }

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new Backstab()
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
                new Spellcasting(level: 3),
                new Backstab(QualificationLevel.Master, 5),
                new Spellcasting(QualificationLevel.Master, 6)
            ]);
            return BuildQualifications(result);
        }
    }

    public override string Name => "Priest of Ranagol (Gorvik)";
}
