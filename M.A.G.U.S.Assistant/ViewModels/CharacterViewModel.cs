using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CharacterViewModel : ObservableObject
{
    private string selectedCombatValueModifier;

    public ObservableCollection<string> AvailableCombatValueModifiers { get; } = ["Base", "With primary weapon", "With secondary weapon"];

    public string SelectedCombatValueModifier
    {
        get => selectedCombatValueModifier;
        set
        {
            SetProperty(ref selectedCombatValueModifier, value);
        }
    }
}
