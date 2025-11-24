using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Database.Repositories;
using M.A.G.U.S.GameSystem;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CharactersViewModel(CharacterRepository characterRepository) : ObservableObject
{
    private readonly CharacterRepository characterRepository = characterRepository;
    private bool isLoading;
    private bool isEmpty;

    public ObservableCollection<Character> Characters { get; } = [];

    public bool IsLoading
    {
        get => isLoading;
        set => SetProperty(ref isLoading, value);
    }

    public bool IsEmpty
    {
        get => isEmpty;
        set => SetProperty(ref isEmpty, value);
    }

    public async Task LoadCharactersAsync()
    {
        if (IsLoading)
        {
            return;
        }

        try
        {
            IsLoading = true;
            var list = await characterRepository.GetAllCharactersAsync().ConfigureAwait(false);

            Characters.Clear();
            foreach (var character in list)
            {
                Characters.Add(character);
            }

            IsEmpty = Characters.Count == 0;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", $"Failed to load characters: {ex.Message}", "OK").ConfigureAwait(false);
        }
        finally
        {
            IsLoading = false;
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
            "Delete Character",
            $"Are you sure you want to delete '{character.Name}'? This cannot be undone.",
            "Delete",
            "Cancel").ConfigureAwait(false);

        if (confirm)
        {
            await characterRepository.DeleteCharacterAsync(character.Name).ConfigureAwait(false);
            Characters.Remove(character);
            IsEmpty = Characters.Count == 0;
        }
    }

    [RelayCommand]
    private static async Task OpenDetailsAsync(Character character)
    {
        if (character == null) return;

        await Shell.Current.GoToAsync($"CharacterDetailsPage?name={character.Name}").ConfigureAwait(false);

        // Alternatively, for now, just show an alert if the page doesn't exist yet:
        // await Shell.Current.DisplayAlert("Info", $"Selected: {character.Name}", "OK");
    }
}