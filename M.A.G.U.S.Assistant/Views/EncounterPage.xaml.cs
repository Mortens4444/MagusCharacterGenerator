using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;
using Mtf.Maui.Controls.Messages;
using System.Collections.Specialized;

namespace M.A.G.U.S.Assistant.Views;

internal partial class EncounterPage : NotifierPage
{
    private bool firstRun = true;
    private EncounterViewModel? viewModel;

    public EncounterPage(EncounterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

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
        if (e.Action != NotifyCollectionChangedAction.Add ||
            e.NewItems is null ||
            e.NewItems.Count == 0 ||
            e.NewItems[0] is not TurnViewModel item)
        {
            return;
        }

        _ = ScrollToTurnSafelyAsync(item);
    }

    private async Task ScrollToTurnSafelyAsync(TurnViewModel item)
    {
        try
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                if (viewModel is null || TurnHistoryView is null)
                {
                    return;
                }

                await Task.Delay(100).ConfigureAwait(true);

                if (!viewModel.SelectedTurnHistory.Contains(item))
                {
                    return;
                }

                var position = viewModel.Settings.AssignmentTurnHistoryNewestOnTop
                    ? ScrollToPosition.Start
                    : ScrollToPosition.End;

                TurnHistoryView.ScrollTo(item, position, animate: false);
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

        if (!firstRun)
        {
            return;
        }

        firstRun = false;
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