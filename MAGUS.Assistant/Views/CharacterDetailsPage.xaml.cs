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
            characterService.SaveAsync(characterViewModel.Character);
        }

        base.OnDisappearing();
    }
}
