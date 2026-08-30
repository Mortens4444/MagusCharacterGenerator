using MAGUS.Enums;
using MAGUS.GameSystem.Experience;
using MAGUS.Models;
using MAGUS.Qualifications;
using MAGUS.Things;

namespace MAGUS.Interfaces;

public interface IClass : IAttacker, IAbilities
{
    string Name { get; }

    int Gold { get; }

    int Level { get; set; }

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

    List<Thing> StartingEquipment { get; set; }

    QualificationList Qualifications { get; }

    QualificationList FutureQualifications { get; }

    PercentQualificationList PercentQualifications { get; }

    SpecialQualificationList SpecialQualifications { get; }

    int GetPainToleranceModifier();

    DiceThrowFormula? GetPainToleranceModifierFormula();

    /// <summary>Combat-value-modifier rate for a specific level - defaults to CombatValueModifierPerLevel for every class, but lets one (e.g. FireMage's Destructive Fire path) vary its rate from a given level onward. See Class's default implementation.</summary>
    int GetCombatValueModifierForLevel(int level);

    /// <summary>Qualification-points rate for a specific level - see GetCombatValueModifierForLevel.</summary>
    int GetQualificationPointsModifierForLevel(int level);

    /// <summary>Pain-tolerance roll for a specific level - see GetCombatValueModifierForLevel.</summary>
    int GetPainToleranceModifier(int level);

    /// <summary>Pain-tolerance roll formula (for the manual-roll UI) for a specific level - see GetCombatValueModifierForLevel.</summary>
    DiceThrowFormula? GetPainToleranceModifierFormula(int level);

    ulong ExperiencePoints { get; set; }

    Alignment Alignment { get; }

    Deity Deity { get; }

    ulong GetExperiencePointsForLevel(int level);

    int GetLevelByExperiencePoints(ulong experiencePoints);

    string DefaultImage { get; }

    bool CanUpgrade { get; }

    List<LevelRequirement> ExperienceLevels { get; }

    ulong ExpPerLevelAfter12 { get; }
}
