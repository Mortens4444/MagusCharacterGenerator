using M.A.G.U.S.Qualifications;

namespace M.A.G.U.S.Interfaces;

public interface IClass : IAttacker, IAbilities
{
    string Name { get; }

    short Gold { get; }

    byte Bravery { get; }

    byte Erudition { get; }

    byte Level { get; }

    byte FightValueModifier { get; }

    byte BaseQualificationPoints { get; }

    byte QualificationPointsModifier { get; }

    byte PercentQualificationModifier { get; }

    byte BaseLifePoints { get; }

    byte AstralMagicResistance { get; }

    byte MentalMagicResistance { get; }

    byte BasePainTolerancePoints { get; }

    bool AddFightValueOnFirstLevel { get; }

    bool AddPainToleranceOnFirstLevel { get; }

    bool AddQualificationPointsOnFirstLevel { get; }

    QualificationList Qualifications { get; }

    QualificationList FutureQualifications { get; }

    List<PercentQualification> PercentQualifications { get; }

    SpecialQualificationList SpecialQualifications { get; }

    byte GetPainToleranceModifier();

    ulong ExperiencePoints { get; }
}
