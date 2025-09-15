using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Battle;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class UwelPaladin(byte level = 1) : Paladin(level)
{
    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new HeavyArmorWearing(),
                new ShieldUsing(),
                new WeaponBreaking(),
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
                new TrackReadingAndHiding(QualificationLevel.Master, 3),
                new Herbalism(level: 5),
                new WoundHealing(QualificationLevel.Master, 5),
                new HeavyArmorWearing(QualificationLevel.Master, 6)
            ]);
            return result;
        }
    }

    public override string ClassName => "Uwel Paladin";
}
