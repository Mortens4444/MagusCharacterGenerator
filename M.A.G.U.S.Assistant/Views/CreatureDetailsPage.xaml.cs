using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

internal partial class CreatureDetailsPage : NotifierPage
{
    public CreatureDetailsPage(CreatureDetailsViewModel creatureDetailsViewModel)
    {
        InitializeComponent();
        Title = Lng.Elem(creatureDetailsViewModel.Creature.Name);
        BindingContext = creatureDetailsViewModel;
    }
}
