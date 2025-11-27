using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

internal partial class CharacterDetailsPage : NotifierPage
{
    private readonly CharacterService characterService;

    public CharacterDetailsPage(CharacterDetailsViewModel characterDetailsViewModel, CharacterService characterService)
    {
        this.characterService = characterService;
        InitializeComponent();
        BindingContext = characterDetailsViewModel;
        Title = Lng.Elem(characterDetailsViewModel.CharacterName);
    }

    protected override void OnDisappearing()
    {
        if (BindingContext is CharacterDetailsViewModel characterDetailsViewModel && characterDetailsViewModel.Character != null)
        {
            characterService.SaveAsync(characterDetailsViewModel.Character);
        }

        base.OnDisappearing();
    }
}
