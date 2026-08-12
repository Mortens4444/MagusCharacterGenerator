using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class CreatureDetailsPage : NotifierPage
{
    public CreatureDetailsPage(CreatureDetailsViewModel creatureDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = creatureDetailsViewModel;
    }
}
