using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Qualifications;

namespace M.A.G.U.S.Classes;

public interface IClass : IAbilities
{
    string ClassName { get; }

    short Gold { get; }

    byte Bravery { get; }

    byte Erudition { get; }

    byte Level { get; }

    byte InitiatingBaseValue { get; }

    byte AttackingBaseValue { get; }

    byte DefendingBaseValue { get; }

    byte AimingBaseValue { get; }

    byte FightValueModifier { get; }

    byte BaseQualificationPoints { get; }

    byte QualificationPointsModifier { get; }

    byte PercentQualificationModifier { get; }

    byte BaseLifePoints { get; }

    byte BasePainTolerancePoints { get; }

    bool AddFightValueOnFirstLevel { get; }

    bool AddPainToleranceOnFirstLevel { get; }

    bool AddQualificationPointsOnFirstLevel { get; }

    QualificationList Qualifications { get; }

    QualificationList FutureQualifications { get; }

    List<PercentQualification> PercentQualifications { get; }

    SpecialQualificationList SpecialQualifications { get; }

    byte GetPainToleranceModifier();
}
