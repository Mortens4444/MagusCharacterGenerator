using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;
using System.Collections.Specialized;

namespace M.A.G.U.S.Assistant.Views;

internal partial class EncounterPage : NotifierPage
{
    private bool firstRun = true;

    public EncounterPage(EncounterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (BindingContext is EncounterViewModel vm)
        {
            vm.SelectedTurnHistory.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null)
                {
                    var item = (TurnViewModel)e.NewItems[0];
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await Task.Delay(16);
                        var position = vm.Settings.AssignmentTurnHistoryNewestOnTop ? ScrollToPosition.Start : ScrollToPosition.End;
                        TurnHistoryView?.ScrollTo(item, position);
                    });
                }
            };
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (firstRun)
        {
            firstRun = false;

            if (BindingContext is EncounterViewModel vm)
            {
                _ = Task.Run(async () =>
                {
                    await vm.LoadCharactersAsync().ConfigureAwait(false);
                    await vm.LoadBestiaryAsync().ConfigureAwait(false);
                    vm.AddSingleCharacterToAssignments();

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        vm.SelectedCharacter = vm.AvailableCharacters.FirstOrDefault();
                        vm.PickRandomEnemyCommand.Execute(null);
                    });
                });
            }
        }
    }
}
