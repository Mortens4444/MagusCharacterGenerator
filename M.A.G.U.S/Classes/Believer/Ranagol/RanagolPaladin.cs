using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Classes.Believer.Ranagol;

public class RanagolPaladin(byte level = 1) : Paladin(level)
{
    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new WeaponThrowing(),
                new WeaponBreaking(),
                new Backstab()
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
                new PoisoningAndNeutralization(level: 3),
                new Backstab(QualificationLevel.Master, 6)
            ]);
            return result;
        }
    }

    public override string Name => "Paladin of Ranagol";
}
