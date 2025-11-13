using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class HalfElf : Race, IUseRangedWeapons
{
    public override sbyte Strength => -1;

    public override sbyte Quickness => 1;

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
