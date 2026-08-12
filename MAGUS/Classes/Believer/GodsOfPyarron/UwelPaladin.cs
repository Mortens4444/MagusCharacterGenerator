using MAGUS.Enums;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;

namespace MAGUS.Classes.Believer.GodsOfPyarron;

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

    public override Deity Deity { get; set; } = Deity.Uwel;
}
