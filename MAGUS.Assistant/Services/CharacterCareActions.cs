using MAGUS.Assistant.Extensions;
using MAGUS.GameSystem;
using Mtf.LanguageService;
using System.Globalization;

namespace MAGUS.Assistant.Services;

/// <summary>
/// Sleep/Eat logic shared by the character list's swipe-row icons (CharactersViewModel) and the
/// CharDetails "care" tab (CharacterViewModel), so both stay in sync with a single implementation.
/// Neither is gated on IsConscious - both are meant to work on an unconscious character too (e.g.
/// feeding someone who fainted from hunger).
/// </summary>
internal static class CharacterCareActions
{
    public static async Task SleepAsync(Character character, SettingsService settingsService, CharacterService characterService)
    {
        var hoursText = await ShellNavigationService.DisplayPromptAsync(
            "Sleep",
            String.Format(Lng.Elem("How many hours should {0} sleep?"), character.Name),
            "OK",
            "Cancel",
            "8").ConfigureAwait(true);

        if (String.IsNullOrWhiteSpace(hoursText) ||
            !Double.TryParse(hoursText, NumberStyles.Float, CultureInfo.InvariantCulture, out var hours) ||
            hours <= 0)
        {
            return;
        }

        var healthPointsToRestore = (int)Math.Round(hours * settingsService.RestoreHealthPointsPerHourOfSleep);
        var manaPointsToRestore = (int)Math.Round(hours * settingsService.RestoreManaPointsPerHourOfSleep);
        var psiPointsToRestore = (int)Math.Round(hours * settingsService.RestorePsiPointsPerHourOfSleep);

        character.ActualHealthPoints = Math.Min(character.MaxHealthPoints, character.ActualHealthPoints + healthPointsToRestore);
        character.ManaPoints = Math.Min(character.MaxManaPoints, character.ManaPoints + manaPointsToRestore);
        character.PsiPoints = Math.Min(character.MaxPsiPoints, character.PsiPoints + psiPointsToRestore);

        if (character.MaxPainTolerancePoints.HasValue)
        {
            var painTolerancePointsToRestore = (int)Math.Round(hours * settingsService.RestorePainTolerancePointsPerHourOfSleep);
            var currentPainTolerancePoints = character.ActualPainTolerancePoints ?? 0;
            character.ActualPainTolerancePoints = Math.Min(character.MaxPainTolerancePoints.Value, currentPainTolerancePoints + painTolerancePointsToRestore);
        }

        character.SleepPercent = 100;

        await characterService.SaveAsync(character).ConfigureAwait(false);

        await ShellNavigationService.DisplayAlertAsync(
            "Sleep",
            String.Format(Lng.Elem("{0} slept and feels refreshed."), character.Name)).ConfigureAwait(true);
    }

    public static async Task EatAsync(Character character, CharacterService characterService)
    {
        var foodItem = character.Equipment.FirstOrDefault(item => item.IsFood());
        if (foodItem == null)
        {
            await ShellNavigationService.DisplayAlertAsync(
                "Eat",
                String.Format(Lng.Elem("{0} has no food to eat."), character.Name)).ConfigureAwait(true);
            return;
        }

        character.RemoveEquipment(foodItem);
        character.HungerPercent = 100;
        await characterService.SaveAsync(character).ConfigureAwait(false);

        await ShellNavigationService.DisplayAlertAsync(
            "Eat",
            String.Format(Lng.Elem("{0} eats the {1} and feels much better."), character.Name, Lng.Elem(foodItem.Name))).ConfigureAwait(true);
    }
}
