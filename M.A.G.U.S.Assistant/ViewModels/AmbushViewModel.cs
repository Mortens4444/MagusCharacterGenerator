using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal sealed partial class AmbushViewModel : ObservableObject
{
    public event EventHandler<bool>? Resolved;

    public string CreatureName { get; }
    public string CharacterName { get; }
    public string Message { get; }
    public string CreatureImage { get; }

    public AmbushViewModel(string creatureName, string characterName, string message, string creatureImage)
    {
        CreatureName = creatureName;
        CharacterName = characterName;
        Message = message;
        CreatureImage = creatureImage;
    }

    [RelayCommand]
    private void Fight() => Resolved?.Invoke(this, true);

    [RelayCommand]
    private void Flee() => Resolved?.Invoke(this, false);
}
