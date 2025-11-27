using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.GameSystem;
using Mtf.LanguageService;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CharactersViewModel(CharacterService characterService) : ObservableObject
{
    private readonly CharacterService characterService = characterService;
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

    [RelayCommand]
    public async Task LoadCharactersAsync()
    {
        if (IsLoading)
        {
            return;
        }

        try
        {
            IsLoading = true;
            var list = await characterService.GetAllAsync().ConfigureAwait(false);

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Characters.Clear();
                foreach (var character in list)
                {
                    Characters.Add(character);
                }
                IsEmpty = Characters.Count == 0;
            }).ConfigureAwait(false);

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
            Lng.Elem("Delete Character"),
            Lng.Elem(String.Format("Are you sure you want to delete '{0}'? This cannot be undone.", character.Name)),
            "Delete",
            "Cancel").ConfigureAwait(false);

        if (confirm)
        {
            await characterService.DeleteAsync(character.Name).ConfigureAwait(false);
            Characters.Remove(character);
            IsEmpty = Characters.Count == 0;
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