using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;
using MAGUS.GameSystem.Quests;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class DialoguePage : NotifierPage
{
    private readonly TaskCompletionSource<DialogueOutcome> tcs = new();
    private bool isClosing;

    public DialoguePage(DialogueNode root)
    {
        InitializeComponent();

        var viewModel = new DialogueViewModel(root);
        viewModel.Resolved += OnResolved;
        BindingContext = viewModel;
    }

    public Task<DialogueOutcome> ResultTask => tcs.Task;

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Translator.Translate(this);
    }

    private async void OnResolved(object? sender, DialogueOutcome outcome)
    {
        if (isClosing)
        {
            return;
        }

        isClosing = true;

        try
        {
            await ShellNavigationService.CloseModalPageAsync().ConfigureAwait(true);
        }
        finally
        {
            tcs.TrySetResult(outcome);
        }
    }
}
