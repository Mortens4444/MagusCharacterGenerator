using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Services;

namespace M.A.G.U.S.Assistant.ViewModels;

[QueryProperty(nameof(Name), nameof(name))]
internal partial class CharacterDetailsViewModel : CharacterViewModel
{
    private readonly CharacterService characterService;
    private string name = String.Empty;

    public CharacterDetailsViewModel(CharacterService characterService, IPrintService printService)
        : base(printService)
    {
        this.characterService = characterService;
        SelectedCombatValueModifier = AvailableCombatValueModifiers.FirstOrDefault();
    }

    public string Name
    {
        get => name;
        set
        {
            if (SetProperty(ref name, value))
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
