using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Elf : Race, IUseRangedWeapons
{
    public override sbyte Strength => -2;

    public override sbyte Quickness => 1;

    public override sbyte Dexterity => 1;

    public override sbyte Stamina => -1;

    public override sbyte Beauty => 1;

    public override QualificationList Qualifications =>
    [
        new Running(QualificationLevel.Master),
        new ForestSurvival(QualificationLevel.Master),
        new AnimalTraining(QualificationLevel.Master),
        new HuntingAndFishing(QualificationLevel.Master),
        new TrackingConcealment(QualificationLevel.Master)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new KeenHearing(2),
        new KeenSight(2.5),
        new Infravision(50),
        new ResistanceToNecromancy(-8),
        new GoodArcher(20)
    ];
}
