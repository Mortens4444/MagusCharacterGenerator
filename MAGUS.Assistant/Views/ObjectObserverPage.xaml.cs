using MAGUS.Assistant.ViewModels;
using Mtf.LanguageService.MAUI.Views;

namespace MAGUS.Assistant.Views;

internal sealed partial class ObjectObserverPage : NotifierPage
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