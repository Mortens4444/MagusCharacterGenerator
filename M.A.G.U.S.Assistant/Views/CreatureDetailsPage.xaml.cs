using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class CreatureDetailsPage : NotifierPage
{
    public CreatureDetailsPage(CreatureDetailsViewModel creatureDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = creatureDetailsViewModel;
    }
}
