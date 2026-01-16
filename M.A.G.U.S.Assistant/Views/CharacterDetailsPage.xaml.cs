using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class CharacterDetailsPage : NotifierPage
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
            characterService.SaveAsync(characterViewModel.Character);
        }

        base.OnDisappearing();
    }
}
