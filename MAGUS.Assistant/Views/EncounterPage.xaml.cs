using CommunityToolkit.Mvvm.Messaging;
using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;
using Mtf.Maui.Controls.Messages;
using System.Collections.Specialized;

namespace MAGUS.Assistant.Views;

internal sealed partial class EncounterPage : NotifierPage
{
    private bool firstRun = true;
    private EncounterViewModel? viewModel;
    private Dictionary<object, string>? originalTextElements;

    public EncounterPage(EncounterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    /// <summary>
    /// When true, skips the normal OnAppearing auto-setup (random character/enemy pick) so a
    /// pre-seeded encounter (e.g. a background-rolled ambush) isn't immediately overwritten.
    /// </summary>
    public bool SuppressAutoInitialize { get; set; }

    protected override void OnBindingContextChanged()
    {
        if (viewModel is not null)
        {
            viewModel.SelectedTurnHistory.CollectionChanged -= OnSelectedTurnHistoryChanged;
        }

        base.OnBindingContextChanged();

        viewModel = BindingContext as EncounterViewModel;

        if (viewModel is not null)
        {
            viewModel.SelectedTurnHistory.CollectionChanged += OnSelectedTurnHistoryChanged;
        }
    }

    private void OnSelectedTurnHistoryChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action != NotifyCollectionChangedAction.Add || e.NewItems is null || e.NewItems.Count == 0)
        {
            return;
        }

        _ = ScrollToNewestTurnSafelyAsync();
    }

    private async Task ScrollToNewestTurnSafelyAsync()
    {
        try
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                if (viewModel is null || TurnHistoryView is null)
                {
                    return;
                }

                // Target by index (always 0/Count-1, i.e. the newest) rather than a captured item
                // reference: bursts of rounds fire this handler repeatedly, and resolving the
                // target fresh each time means every attempt converges on the true latest state
                // regardless of execution order.
                await Task.Delay(50).ConfigureAwait(true);

                if (viewModel.SelectedTurnHistory.Count == 0)
                {
                    return;
                }

                var newestFirst = viewModel.Settings.AssignmentTurnHistoryNewestOnTop;
                var targetIndex = newestFirst ? 0 : viewModel.SelectedTurnHistory.Count - 1;
                var position = newestFirst ? ScrollToPosition.Start : ScrollToPosition.End;

                TurnHistoryView.ScrollTo(targetIndex, position: position, animate: false);
            }).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Re-translate every time, so the "Clash" title picks up a language change made on the
        // Settings page (this page's static text was never fed through the translator at all).
        if (originalTextElements == null)
        {
            originalTextElements = Translator.Translate(this);
        }
        else
        {
            Translator.SetOriginalTexts(originalTextElements);
            _ = Translator.Translate(this);
        }

        // OnDisappearing (below) unsubscribes unconditionally, including when this page is
        // merely covered by a modal (e.g. the enemy picker, or a manual-mode dice-roll dialog
        // fired per attack) rather than actually left. Without re-subscribing here, the first
        // such modal permanently kills round updates/auto-scroll for the rest of the encounter.
        if (viewModel is not null)
        {
            viewModel.SelectedTurnHistory.CollectionChanged -= OnSelectedTurnHistoryChanged;
            viewModel.SelectedTurnHistory.CollectionChanged += OnSelectedTurnHistoryChanged;
        }

        if (!firstRun)
        {
            return;
        }

        firstRun = false;

        if (SuppressAutoInitialize)
        {
            return;
        }

        _ = InitializeSafelyAsync();
    }

    private async Task InitializeSafelyAsync()
    {
        try
        {
            if (BindingContext is not EncounterViewModel vm)
            {
                return;
            }

            await vm.LoadCharactersAsync().ConfigureAwait(true);
            await vm.LoadBestiaryAsync().ConfigureAwait(true);

            vm.AddSingleCharacterToAssignments();

            vm.SelectedCharacter = vm.AvailableCharacters.FirstOrDefault();
            vm.PickRandomEnemyCommand.Execute(null);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    protected override void OnDisappearing()
    {
        if (viewModel is not null)
        {
            viewModel.SelectedTurnHistory.CollectionChanged -= OnSelectedTurnHistoryChanged;
        }

        base.OnDisappearing();
    }
}
