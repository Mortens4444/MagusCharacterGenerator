using M.A.G.U.S.Enums;
using M.A.G.U.S.Models;
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

    bool AddCombatModifierOnFirstLevel { get; }

    bool AddPainToleranceOnFirstLevel { get; }

    bool AddQualificationPointsOnFirstLevel { get; }

    QualificationList Qualifications { get; }

    QualificationList FutureQualifications { get; }

    PercentQualificationList PercentQualifications { get; }

    SpecialQualificationList SpecialQualifications { get; }

    int GetPainToleranceModifier();

    DiceThrowFormula? GetPainToleranceModifierFormula();

    ulong ExperiencePoints { get; }

    Alignment Alignment { get; }
}
