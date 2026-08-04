using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.GameSystem;
using Mtf.LanguageService;
using System.Globalization;

namespace M.A.G.U.S.Assistant.ViewModels;

internal sealed partial class CharactersViewModel(CharacterService characterService, SettingsService settingsService) : CharacterListLoaderViewModel(characterService)
{
    private string? defaultCharacterName = settingsService.DefaultCharacterName;

    public string? DefaultCharacterName
    {
        get => defaultCharacterName;
        private set => SetProperty(ref defaultCharacterName, value);
    }

    [RelayCommand]
    private async Task SetDefaultCharacterAsync(Character character)
    {
        if (character == null)
        {
            return;
        }

        var newDefaultName = DefaultCharacterName == character.Name ? null : character.Name;
        await settingsService.SetDefaultCharacterNameAsync(newDefaultName).ConfigureAwait(true);
        DefaultCharacterName = newDefaultName;
    }

    [RelayCommand]
    private async Task SleepAsync(Character character)
    {
        if (character == null)
        {
            return;
        }

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

        await characterService.SaveAsync(character).ConfigureAwait(false);

        await ShellNavigationService.DisplayAlertAsync(
            "Sleep",
            String.Format(Lng.Elem("{0} slept and feels refreshed."), character.Name)).ConfigureAwait(true);
    }

    [RelayCommand]
    private async Task EatAsync(Character character)
    {
        if (character == null)
        {
            return;
        }

        var foodItem = character.Equipment.FirstOrDefault(item => item.IsFood());
        if (foodItem == null)
        {
            await ShellNavigationService.DisplayAlertAsync(
                "Eat",
                String.Format(Lng.Elem("{0} has no food to eat."), character.Name)).ConfigureAwait(true);
            return;
        }

        character.RemoveEquipment(foodItem);
        character.IsHungry = false;
        await characterService.SaveAsync(character).ConfigureAwait(false);

        await ShellNavigationService.DisplayAlertAsync(
            "Eat",
            String.Format(Lng.Elem("{0} eats the {1} and feels much better."), character.Name, Lng.Elem(foodItem.Name))).ConfigureAwait(true);
    }

    [RelayCommand]
    private async Task DeleteAllCharacterAsync()
    {
        var confirm = await ShellNavigationService.DisplayAlertAsync(
            "Delete Character",
            "Are you sure you want to delete all characters? This cannot be undone.",
            "Delete",
            "Cancel").ConfigureAwait(true);

        if (confirm)
        {
            await characterService.DeleteAllAsync().ConfigureAwait(false);
            AvailableCharacters.Clear();
            IsEmpty = AvailableCharacters.Count == 0;

            if (DefaultCharacterName != null)
            {
                await settingsService.SetDefaultCharacterNameAsync(null).ConfigureAwait(true);
                DefaultCharacterName = null;
            }
        }
    }

    [RelayCommand]
    private async Task DeleteCharacterAsync(Character character)
    {
        if (character == null)
        {
            return;
        }

        bool confirm = await ShellNavigationService.DisplayAlertAsync(
            "Delete Character",
            String.Format(Lng.Elem("Are you sure you want to delete '{0}'? This cannot be undone."), character.Name),
            "Delete",
            "Cancel").ConfigureAwait(true);

        if (confirm)
        {
            await characterService.DeleteAsync(character.Name).ConfigureAwait(false);
            AvailableCharacters.Remove(character);
            IsEmpty = AvailableCharacters.Count == 0;

            if (DefaultCharacterName == character.Name)
            {
                await settingsService.SetDefaultCharacterNameAsync(null).ConfigureAwait(true);
                DefaultCharacterName = null;
            }
        }
    }

    [RelayCommand]
    private static async Task OpenDetailsAsync(Character character)
    {
        if (character == null)
        {
            return;
        }

        await ShellNavigationService.NavigateToAsync($"CharacterDetailsPage?name={character.Name}").ConfigureAwait(true);
    }
}