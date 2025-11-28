using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.GameSystem;

namespace M.A.G.U.S.Assistant.ViewModels;

[QueryProperty(nameof(CharacterName), "name")]
internal partial class CharacterDetailsViewModel : CharacterViewModel
{
    private readonly CharacterService characterService;
    private string characterName = String.Empty;
    private Character? character;

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

    private async Task LoadCharacterAsync(string name)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            return;
        }

        Character = await characterService.GetByNameAsync(name).ConfigureAwait(false);
    }
}
