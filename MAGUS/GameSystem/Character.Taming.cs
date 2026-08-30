using MAGUS.Bestiary;
using MAGUS.Enums;
using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications.Laical;
using System.Collections.ObjectModel;

namespace MAGUS.GameSystem;

public partial class Character
{
    /// <summary>Creatures this character has successfully tamed - see TryTameCreature.</summary>
    public ObservableCollection<TamedCreature> TamedCreatures { get; init; } = [];

    /// <summary>
    /// Flat d100 success chance for TryTameCreature - Idomítás (Animal training)'s own rulebook page
    /// (Első Törvénykönyv p.107) describes training an already-owned animal for tasks/tricks, not a
    /// formula for subduing a hostile one mid-fight, so this app-level chance isn't sourced from a
    /// specific book number - chosen to feel about as risky as the app's other subtlety-style rolls
    /// (c.f. CharacterCareActions.SleepInTheOpenDangerChance).
    /// </summary>
    public const int TameChancePercent = 40;

    /// <summary>True if this character has Idomítás (Animal training) at Master level - gates whether "Tame" is offered at all, independent of whether a tameable enemy is currently present (see CanTame for that).</summary>
    public bool HasMasterAnimalTraining =>
        Qualifications.OfType<AnimalTraining>().Any(q => q.QualificationLevel == QualificationLevel.Master);

    /// <summary>
    /// True if this character could attempt to tame creature right now - requires Idomítás (Animal
    /// training) at Master level, and the creature has to be an animal (Bestiary Intelligence.Animal)
    /// that isn't exclusively aquatic (Ynev's taming lore is about beasts of burden/hunting companions,
    /// not fish - a creature with no non-InWater Speed is excluded).
    /// </summary>
    public bool CanTame(Creature? creature)
    {
        return HasMasterAnimalTraining
            && creature != null
            && creature.Intelligence == Enums.Intelligence.Animal
            && creature.Speeds.Any(s => s.TravelMode != TravelMode.InWater);
    }

    /// <summary>
    /// Attempts to tame creature instead of fighting it further - see CanTame for the precondition
    /// and EncounterViewModel.TryTameAsync for the UI, which removes creature from the encounter's
    /// enemy list on success. On success, creature is added to TamedCreatures with this character's
    /// CurrentLocation.
    /// </summary>
    public bool TryTameCreature(Creature creature)
    {
        if (!CanTame(creature))
        {
            return false;
        }

        var roll = new DiceThrow()._1D100();
        if (roll > TameChancePercent)
        {
            return false;
        }

        TamedCreatures.Add(new TamedCreature { Creature = creature, Location = CurrentLocation });
        return true;
    }
}
