using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ObjectObserverPage : NotifierPage
{
    public ObjectObserverPage(ObjectObserverViewModel viewModel, object obj)
    {
        InitializeComponent();
        BindingContext = viewModel;
        if (BindingContext is ObjectObserverViewModel vm)
        {
            vm.InspectedObject = obj;
        }
    }
}