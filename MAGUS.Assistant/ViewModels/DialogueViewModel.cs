using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAGUS.GameSystem.Quests;

namespace MAGUS.Assistant.ViewModels;

/// <summary>Drives a single branching negotiation - see DialoguePage.xaml and Quest.DialogueRoot.</summary>
internal sealed partial class DialogueViewModel : ObservableObject
{
    public event EventHandler<DialogueOutcome>? Resolved;

    private string text;
    private IReadOnlyList<DialogueOption> options;

    public string Text
    {
        get => text;
        private set => SetProperty(ref text, value);
    }

    public IReadOnlyList<DialogueOption> Options
    {
        get => options;
        private set => SetProperty(ref options, value);
    }

    public DialogueViewModel(DialogueNode root)
    {
        text = root.Text;
        options = root.Options;
    }

    [RelayCommand]
    private void SelectOption(DialogueOption option)
    {
        if (option == null)
        {
            return;
        }

        if (option.Outcome == DialogueOutcome.Continue && option.NextNode is { } next)
        {
            Text = next.Text;
            Options = next.Options;
            return;
        }

        Resolved?.Invoke(this, option.Outcome);
    }
}
