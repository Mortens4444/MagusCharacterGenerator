using MAGUS.GameSystem.FightMode;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Specialities;

namespace MAGUS.Races;

public class HalfElf : Race, IUseRangedWeapons
{
    public override int Strength => -1;

    public override int Quickness => 1;

    public override QualificationList Qualifications =>
    [
        new Riding(QualificationLevel.Master),
        new AnimalTraining(QualificationLevel.Master)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new KeenHearing(1.5),
        new KeenSight(2),
        new GoodRunner(),
        new Infravision(10),
        new ResistanceToNecromancy(-6),
        new GoodArcher(10)
    ];

    public override string Name => "Half-elf";
}
