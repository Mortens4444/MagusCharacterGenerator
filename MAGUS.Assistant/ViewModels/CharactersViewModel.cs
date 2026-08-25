using CommunityToolkit.Mvvm.Input;
using MAGUS.Assistant.Extensions;
using MAGUS.Assistant.Services;
using MAGUS.GameSystem;
using Mtf.LanguageService;
using System.Globalization;

namespace MAGUS.Assistant.ViewModels;

internal sealed partial class CharactersViewModel(CharacterService characterService, SettingsService settingsService, GameEventService gameEventService) : CharacterListLoaderViewModel(characterService)
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

        await CharacterCareActions.SleepAsync(character, characterService, gameEventService).ConfigureAwait(true);
    }

    [RelayCommand]
    private async Task EatAsync(Character character)
    {
        if (character == null)
        {
            return;
        }

        await CharacterCareActions.EatAsync(character, characterService).ConfigureAwait(true);
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