using MAGUS.Assistant.Services;
using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class CharacterDetailsPage : NotifierPage
{
    private readonly CharacterService characterService;

    public CharacterDetailsPage(CharacterDetailsViewModel characterDetailsViewModel, CharacterService characterService)
    {
        this.characterService = characterService;
        InitializeComponent();
        BindingContext = characterDetailsViewModel;
        Title = characterDetailsViewModel.Name;
    }

    protected override void OnDisappearing()
    {
        if (BindingContext is CharacterViewModel characterViewModel && characterViewModel.Character != null)
        {
            // OnDisappearing cannot be awaited, but navigation continues immediately after it
            // returns (e.g. the characters list reloads from the database in its own OnAppearing),
            // so a fire-and-forget save here races the reload and can lose the last-made change.
            // Block until the save completes to guarantee it's persisted before the page leaves.
            Task.Run(() => characterService.SaveAsync(characterViewModel.Character)).GetAwaiter().GetResult();
        }

        base.OnDisappearing();
    }
}
