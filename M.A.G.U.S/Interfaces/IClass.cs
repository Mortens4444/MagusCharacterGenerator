using M.A.G.U.S.Enums;
using M.A.G.U.S.Qualifications;

namespace M.A.G.U.S.Interfaces;

public interface IClass : IAttacker, IAbilities
{
    string Name { get; }

    int Gold { get; }

    int Level { get; }

    int CombatValueModifierPerLevel { get; }

    int BaseQualificationPoints { get; }

    int QualificationPointsModifier { get; }

    int PercentQualificationModifier { get; }

    int BaseLifePoints { get; }

    int AstralMagicResistance { get; }

    int MentalMagicResistance { get; }

    int BasePainTolerancePoints { get; }

    bool AddFightValueOnFirstLevel { get; }

    bool AddPainToleranceOnFirstLevel { get; }

    bool AddQualificationPointsOnFirstLevel { get; }

    QualificationList Qualifications { get; }

    QualificationList FutureQualifications { get; }

    List<PercentQualification> PercentQualifications { get; }

    SpecialQualificationList SpecialQualifications { get; }

    int GetPainToleranceModifier();

    ulong ExperiencePoints { get; }

    Alignment Alignment { get; }
}
