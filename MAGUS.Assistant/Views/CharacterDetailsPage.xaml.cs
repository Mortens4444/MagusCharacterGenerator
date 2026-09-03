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

        // Unloaded (not OnDisappearing) fires only once the page is actually removed from the
        // navigation stack, not when merely covered by a modal - see EncounterPage.OnAppearing
        // for why OnDisappearing can't be trusted for this. Page/ViewModel are transient (a fresh
        // instance per navigation), so it's safe to dispose here without affecting a reused instance.
        Unloaded += (_, _) => (BindingContext as IDisposable)?.Dispose();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Covers a character created directly at level 5+ (never went through LevelUpAsync's own
        // check), or an older save from before Fire Mage specializations existed.
        if (BindingContext is CharacterViewModel characterViewModel)
        {
            await characterViewModel.CheckPendingFireMageSpecializationAsync().ConfigureAwait(true);
        }
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
