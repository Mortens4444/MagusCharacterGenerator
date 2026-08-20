using MAGUS.Assistant.Interfaces;
using MAGUS.Assistant.Services;
using MAGUS.Interfaces;

namespace MAGUS.Assistant.ViewModels;

[QueryProperty(nameof(Name), nameof(name))]
internal sealed partial class CharacterDetailsViewModel : CharacterViewModel
{
    private string name = String.Empty;

    public CharacterDetailsViewModel(CharacterService characterService, ISoundPlayer soundPlayer, IShakeService shakeService, ISettings settings, IPrintService printService, SettingsService settingsService)
        : base(printService, soundPlayer, shakeService, settings, characterService, settingsService)
    {
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
