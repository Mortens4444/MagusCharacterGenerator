using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.GameSystem;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class QualificationsPage : NotifierPage
{
    public QualificationsPage(QualificationsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    public QualificationsPage(QualificationsViewModel viewModel, Character character)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.Character = character;
        Title = $"{character.Name} - {Lng.Elem("Qualifications")}";
    }
}