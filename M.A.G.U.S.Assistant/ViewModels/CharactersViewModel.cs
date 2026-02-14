using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.GameSystem;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CharactersViewModel(CharacterService characterService) : CharacterListLoaderViewModel(characterService)
{
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