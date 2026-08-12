using MAGUS.Enums;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Underworld;

namespace MAGUS.Classes.Believer.Ranagol;

public class RanagolPaladin : Paladin
{
    public RanagolPaladin() : base() { }

    public RanagolPaladin(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

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
                new PoisoningAndNeutralization(level: 3),
                new Backstab(QualificationLevel.Master, 6)
            ]);
            return BuildQualifications(result);
        }
    }

    public override string Name => "Paladin of Ranagol";

    public override Deity Deity { get; set; } = Deity.Ranagol;
}
