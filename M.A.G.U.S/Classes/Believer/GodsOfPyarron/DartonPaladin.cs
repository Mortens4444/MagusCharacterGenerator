using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Battle;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class DartonPaladin(byte level = 1) : Paladin(level)
{
    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new Wrestling(),
                new WeaponBreaking(),
                new PoisoningAndNeutralization(),
                new TrapSetting(),
                new TavernBrawling(),
                new CardSharping()
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
                new TavernBrawling(QualificationLevel.Master, 3),
                new AnimalTraining(level: 3),
                new CardSharping(QualificationLevel.Master, 4),
                new WeaponUse(QualificationLevel.Master, 4),
                new Backstab(level: 7)
            ]);
            return result;
        }
    }

    public override string ClassName => "Darton Paladin";
}
