using M.A.G.U.S.Assistant.ViewModels;
using M.A.G.U.S.GameSystem;
using Mtf.LanguageService.Core;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal sealed partial class QualificationsPage : NotifierPage
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