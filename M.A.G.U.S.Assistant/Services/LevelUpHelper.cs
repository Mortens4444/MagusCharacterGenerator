using M.A.G.U.S.GameSystem;

namespace M.A.G.U.S.Assistant.Services;

internal static class LevelUpHelper
{
    public static void ApplyExperience(Character character, int xpGain, CharacterService characterService)
    {
        character.BaseClass!.ExperiencePoints += (ulong)xpGain;

        while (character.BaseClass.ExperiencePoints >= (ulong)ExperienceForNextLevel(character))
        {
            character.BaseClass.ExperiencePoints -= (ulong)ExperienceForNextLevel(character);
            LevelUp(character);
            characterService.SaveAsync(character).ConfigureAwait(false);
        }
    }

    private static int ExperienceForNextLevel(Character character) => 1000 + (character.BaseClass.Level * 250);

    private static void LevelUp(Character character)
    {
//        character.BaseClass.Level++;
//        character.RecalculateDerivedStats();
        // UI notifikációt küldj (messenger)
    }
}
