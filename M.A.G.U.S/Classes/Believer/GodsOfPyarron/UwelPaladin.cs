using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class UwelPaladin : Paladin
{
    public UwelPaladin() : base() { }

    public UwelPaladin(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new HeavyArmorWearing(),
                new ShieldUse(),
                new WeaponBreaking(),
                new Disarmament()
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
                new TrackingConcealment(QualificationLevel.Master, 3),
                new Herbalism(level: 5),
                new Healing(QualificationLevel.Master, 5),
                new HeavyArmorWearing(QualificationLevel.Master, 6)
            ]);
            return BuildQualifications(result);
        }
    }

    public override string Name => "Paladin of Uwel";
}
