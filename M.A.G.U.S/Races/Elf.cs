using M.A.G.U.S.GameSystem.FightMode;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Specialities;

namespace M.A.G.U.S.Races;

public class Elf : Race, IUseRangedWeapons
{
    public override short Strength => -2;

    public override short Speed => 1;

    public override short Dexterity => 1;

    public override short Stamina => -1;

    public override short Beauty => 1;

    public override QualificationList Qualifications =>
    [
        new Running(QualificationLevel.Master),
        new Forestry(QualificationLevel.Master),
        new AnimalTraining(QualificationLevel.Master),
        new HuntingAndFishing(QualificationLevel.Master),
        new TrackingConcealment(QualificationLevel.Master)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new BetterHearing(2),
        new KeenSight(2.5),
        new Infravision(50),
        new ResistanceToNecromantia(-8),
        new GoodArcher(20)
    ];
}
