using CommunityToolkit.Mvvm.ComponentModel;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using Mtf.Extensions;
using Mtf.LanguageService;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CharacterViewModel : ObservableObject
{
    private string selectedCombatValueModifier;
    private Character? character;

    public CharacterViewModel()
    {
        selectedCombatValueModifier = AvailableCombatValueModifiers.First();
    }

    public IEnumerable<Alignment> Alignments => [.. Enum.GetValues<Alignment>()];

    public ObservableCollection<string> AvailableCombatValueModifiers { get; } = ["Base", "With primary weapon", "With secondary weapon"];

    public string SelectedCombatValueModifier
    {
        get => selectedCombatValueModifier;
        set
        {
            SetProperty(ref selectedCombatValueModifier, value);
        }
    }

    public Character? Character
    {
        get => character;
        protected set
        {
            if (character == value)
            {
                return;
            }

            SetProperty(ref character, value);
        }
    }
}
