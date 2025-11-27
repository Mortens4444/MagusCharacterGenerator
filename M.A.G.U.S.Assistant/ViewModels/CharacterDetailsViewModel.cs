using CommunityToolkit.Mvvm.ComponentModel;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.GameSystem;
using Mtf.LanguageService;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

[QueryProperty(nameof(CharacterName), "name")]
internal partial class CharacterDetailsViewModel : ObservableObject
{
    private readonly CharacterService characterService;
    private string characterName = String.Empty;
    private Character? character;
    private string selectedCombatValueModifier;

    public CharacterDetailsViewModel(CharacterService characterService)
    {
        this.characterService = characterService;
        SelectedCombatValueModifier = AvailableCombatValueModifiers.FirstOrDefault();
    }

    public string CharacterName
    {
        get => characterName;
        set
        {
            if (SetProperty(ref characterName, value))
            {
                _ = LoadCharacterAsync(value);
            }
        }
    }

    public Character? Character
    {
        get => character;
        private set => SetProperty(ref character, value);
    }

    public ObservableCollection<string> AvailableCombatValueModifiers { get; } = ["Base", "With primary weapon", "With secondary weapon"];

    public string SelectedCombatValueModifier
    {
        get => selectedCombatValueModifier;
        set
        {
            SetProperty(ref selectedCombatValueModifier, value);
        }
    }

    private async Task LoadCharacterAsync(string name)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            return;
        }

        Character = await characterService.GetByNameAsync(name).ConfigureAwait(false);
    }
}
