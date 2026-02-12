using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class EncounterPage : NotifierPage
{
    public EncounterPage(EncounterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
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
