using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService;

namespace M.A.G.U.S.Assistant.Views;

internal partial class QualificationDetailsPage : NotifierPage
{
    public QualificationDetailsPage(QualificationDetailsViewModel vm)
    {
        InitializeComponent();
        Title = Lng.Elem(vm.Qualification.Name);
        BindingContext = vm;
    }
}