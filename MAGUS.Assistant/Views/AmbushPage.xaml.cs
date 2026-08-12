using CommunityToolkit.Mvvm.Messaging;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;
using MAGUS.Bestiary;
using Mtf.LanguageService;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;
using Mtf.Maui.Controls.Messages;

namespace MAGUS.Assistant.Views;

internal sealed partial class AmbushPage : NotifierPage
{
    private readonly TaskCompletionSource<bool> tcs = new();
    private bool isClosing;

    public AmbushPage(Creature creature, string characterName, string message)
    {
        InitializeComponent();

        var viewModel = new AmbushViewModel(Lng.Elem(creature.Name), characterName, message, creature.RandomImage);
        viewModel.Resolved += OnResolved;
        BindingContext = viewModel;
    }

    public Task<bool> ResultTask => tcs.Task;

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Translator.Translate(this);
        _ = PlayEntranceAnimationAsync();
    }

    private async void OnResolved(object? sender, bool fight)
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
            tcs.TrySetResult(fight);
        }
    }

    private async Task PlayEntranceAnimationAsync()
    {
        try
        {
            CreatureImage.Scale = 0.4;
            CreatureImage.Opacity = 0;
            MessageLabel.Opacity = 0;

            await CreatureImage.FadeTo(1, 250).ConfigureAwait(true);
            await Task.WhenAll(
                CreatureImage.ScaleTo(1.08, 220, Easing.SpringOut),
                MessageLabel.FadeTo(1, 400)).ConfigureAwait(true);
            await CreatureImage.ScaleTo(1, 120).ConfigureAwait(true);

            _ = PulseWhileWaitingAsync();
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private async Task PulseWhileWaitingAsync()
    {
        try
        {
            while (!isClosing)
            {
                await CreatureImage.ScaleTo(1.04, 700, Easing.SinInOut).ConfigureAwait(true);
                if (isClosing)
                {
                    return;
                }

                await CreatureImage.ScaleTo(1.0, 700, Easing.SinInOut).ConfigureAwait(true);
            }
        }
        catch (Exception)
        {
            // best-effort ambient animation; safe to stop silently once the page is closing
        }
    }
}
