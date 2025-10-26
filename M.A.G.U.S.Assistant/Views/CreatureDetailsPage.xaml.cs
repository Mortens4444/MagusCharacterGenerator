using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.Bestiary;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

public partial class CreatureDetailsPage : NotifierPage
{
    //public CreatureDetailsPage() => InitializeComponent();

    public CreatureDetailsPage(Creature creature)
    {
        ArgumentNullException.ThrowIfNull(creature);
        InitializeComponent();
        Title = Lng.Elem(creature.Name);
        BindingContext = new CreatureDetailsViewModel(creature);
    }
}
