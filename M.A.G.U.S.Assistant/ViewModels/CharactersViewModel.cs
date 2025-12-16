using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.GameSystem;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CharactersViewModel : CharacterListLoaderViewModel
{
    public CharactersViewModel(CharacterService characterService) : base(characterService)
    {
    }

    [RelayCommand]
    private async Task DeleteAllCharacterAsync()
    {
        bool confirm = await Shell.Current.DisplayAlert(
            Lng.Elem("Delete Character"),
            Lng.Elem("Are you sure you want to delete all characters? This cannot be undone."),
            Lng.Elem("Delete"),
            Lng.Elem("Cancel")).ConfigureAwait(false);

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

        bool confirm = await Shell.Current.DisplayAlert(
            Lng.Elem("Delete Character"),
            String.Format(Lng.Elem("Are you sure you want to delete '{0}'? This cannot be undone."), character.Name),
            Lng.Elem("Delete"),
            Lng.Elem("Cancel")).ConfigureAwait(false);

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

        await Shell.Current.GoToAsync($"CharacterDetailsPage?name={character.Name}").ConfigureAwait(false);

        // Alternatively, for now, just show an alert if the page doesn't exist yet:
        // await Shell.Current.DisplayAlert("Info", $"Selected: {character.Name}", "OK");
    }
}