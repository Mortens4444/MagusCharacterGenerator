using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.GameSystem;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CharacterListLoaderViewModel(CharacterService characterService) : BaseViewModel
{
    protected readonly CharacterService characterService = characterService;
    private bool isLoading;
    private bool isEmpty;

    public ObservableCollection<Character> AvailableCharacters { get; } = [];

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
            var list = await characterService.GetAllAsync().ConfigureAwait(false);

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                AvailableCharacters.Clear();
                foreach (var character in list.OrderBy(c => c.Name))
                {
                    AvailableCharacters.Add(character);
                }
                IsEmpty = AvailableCharacters.Count == 0;
            }).ConfigureAwait(false);

            IsEmpty = AvailableCharacters.Count == 0;
        }
        catch (Exception ex)
        {
            await ShellNavigationService.DisplayAlertAsync("Error", $"Failed to load characters: {ex.Message}", "OK").ConfigureAwait(false);
        }
        finally
        {
            IsLoading = false;
        }
    }
}