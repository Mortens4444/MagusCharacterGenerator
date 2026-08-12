using MAGUS.Enums;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Underworld;

namespace MAGUS.Classes.Believer.GodsOfPyarron;

public class DartonPaladin : Paladin
{
    public DartonPaladin() : base() { }

    public DartonPaladin(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

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
                new TavernBrawling(QualificationLevel.Master, 3),
                new AnimalTraining(level: 3),
                new CardSharping(QualificationLevel.Master, 4),
                new WeaponUse(QualificationLevel.Master, 4),
                new Backstab(level: 7)
            ]);
            return BuildQualifications(result);
        }
    }

    public override string Name => "Paladin of Darton";

    public override Deity Deity { get; set; } = Deity.Darton;
}
