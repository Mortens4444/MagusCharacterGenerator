using M.A.G.U.S.Assistant.Services;

namespace M.A.G.U.S.Assistant.ViewModels;

[QueryProperty(nameof(CharacterName), "name")]
internal partial class CharacterDetailsViewModel : CharacterViewModel
{
    private readonly CharacterService characterService;
    private string characterName = String.Empty;

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

    private async Task LoadCharacterAsync(string name)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            return;
        }

        Character = await characterService.GetByNameAsync(name).ConfigureAwait(false);
    }
}
