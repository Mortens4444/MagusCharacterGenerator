using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

internal partial class CharacterGeneratorPage : NotifierPage
{
    public CharacterGeneratorPage(CharacterGeneratorViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}