using MAGUS.GameSystem;
using MAGUS.Interfaces;
using MAGUS.Utils;
using Mtf.Extensions.Services;
using System.Linq;

namespace MAGUS.Assistant.Services;

/// <summary>
/// Spawns a throwaway, unsaved "bandit" Character - random race and class, auto-generated skills, no
/// UI interaction - to serve as the opponent for combat quests that have no dedicated Bestiary class
/// (see Quest.TargetIsGeneratedBandit and EncounterViewModel.CompleteMatchingQuests).
/// </summary>
internal static class BanditGenerator
{
    /// <summary>
    /// MAGUS.Classes.NonPlayableCharacters (excluding its own Fighter/Jad subfolders, which are
    /// combat-flavored NPCs) is all civilian flavor roles - Craftsman, Guard, GuardOfficer, Healer,
    /// Merchant, Noble, Peasant, Soldier, Wiseman - with a BaseLifePoints of only 3-5, roughly half a
    /// real combat class's 6-8. A bandit drawn from that pool ended up with ~3 HP: one hit from
    /// virtually any player attack killed or knocked it out before its own already-queued attack for
    /// the round could ever be processed (see CombatEngine.ProcessInitiativeAsync's early return for a
    /// dead/unconscious attacker), which looked like "the bandit's attacks never show up in the
    /// EncounterPage turn log" even though the fight was otherwise resolving normally.
    /// </summary>
    private static bool IsCombatCapable(IClass instance) => instance.GetType().Namespace != "MAGUS.Classes.NonPlayableCharacters";

    public static Character CreateRandomBandit(ISettings settings)
    {
        var races = PreloadService.Instance.Races;
        var classes = PreloadService.Instance.Classes.Where(IsCombatCapable).ToList();

        var race = races[RandomProvider.GetSecureRandomInt(0, races.Count)];
        var classType = classes[RandomProvider.GetSecureRandomInt(0, classes.Count)].GetType();
        var instanceClass = (IClass)Activator.CreateInstance(classType, 1, true)!;

        var bandit = new Character(settings, NameGenerator.Get(race), race, instanceClass)
        {
            IsGeneratedEnemy = true,
            // Unlike a saved Character, this one never goes through CharacterPortraitPickerViewModel,
            // so Images would otherwise stay empty - which broke rendering of this bandit's own rows
            // (attacks, death) in the EncounterPage turn log entirely, not just leaving them without a
            // picture. Race.Images (from ImageOwner) is always non-empty by naming convention, so it's
            // a safe generic portrait to fall back on.
            Images = [race.DefaultImage]
        };
        bandit.SetMaxValues();

        return bandit;
    }
}
