using MAGUS.Enums;
using MAGUS.GameSystem.Valuables;
using MAGUS.Models;
using MAGUS.Qualifications;
using MAGUS.Races;
using MAGUS.Things;
using System.Collections.ObjectModel;

namespace MAGUS.Interfaces;

public interface ICharacter
{
    string Name { get; }

    int CombatValueModifierPerLevel { get; }

    int RemainingCombatValueModifier { get; }

    int InitiateValue { get; }

    int AttackValue { get; }

    int DefenseValue { get; }

    int AimValue { get; }

    ObservableCollection<Thing> Equipment { get; init; }

    Money Money { get; }

    string TotalEquipmentWeight { get; }

    int MaxManaPointsPerLevel { get; }

    DiceThrowFormula? MaxManaPointsPerLevelFormula { get; }

    int ManaPoints { get; }

    int MaxManaPoints { get; }

    int UnconsciousAstralMagicResistance { get; }

    int UnconsciousMentalMagicResistance { get; }

    int StaticAstralPsiShield { get; }

    int StaticMentalPsiShield { get; }

    int DynamicAstralPsiShield { get; }

    int DynamicMentalPsiShield { get; }

    string Birthplace { get; set; }

    string School { get; set; }

    Alignment Alignment { get; set; }

    IClass BaseClass { get; set; }

    IClass[] Classes { get; set; }

    string RaceName { get; }

    string Class { get; }

    int Level { get; }

    MultiClassMode MultiClassMode { get; }

    IRace Race { get; }

    int PsiPointsModifier { get; set; }

    int PsiPoints { get; set; }

    int MaxPsiPoints { get; set; }

    QualificationList Qualifications { get; }

    SpecialQualificationList SpecialQualifications { get; }

    PercentQualificationList PercentQualifications { get; }

    int Strength { get; set; }

    int Quickness { get; set; }

    int Dexterity { get; set; }

    int Stamina { get; set; }

    int Health { get; set; }

    int Beauty { get; set; }

    int Intelligence { get; set; }

    int Willpower { get; set; }

    int Astral { get; set; }

    int Bravery { get; set; }

    int Erudition { get; set; }

    int Detection { get; set; }

    int ActualHealthPoints { get; set; }

    int? ActualPainTolerancePoints { get; set; }

    int MaxHealthPoints { get; set; }

    int? MaxPainTolerancePoints { get; set; }
}
