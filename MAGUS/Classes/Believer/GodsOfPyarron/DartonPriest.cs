using MAGUS.Enums;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Underworld;

namespace MAGUS.Classes.Believer.GodsOfPyarron;

public class DartonPriest : Priest
{
    public DartonPriest() : base() { }

    public DartonPriest(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new WeaponUse(),
                new WeaponUse(),
                new WeaponThrowing(),
                new MagicLore() { Note = "Necromancy" },
                new Healing(),
                new Physiology(),
                new Embalming(),
                new SingingAndMakingMusic()
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
                new Backstab(level: 3),
                new Embalming(QualificationLevel.Master, 5),
                new MagicLore(QualificationLevel.Master, 9) { Note = "Necromancy" }
            ]);
            return BuildQualifications(result);
        }
    }

    public override string Name => "Priest of Darton";

    public override Deity Deity { get; set; } = Deity.Darton;
}
