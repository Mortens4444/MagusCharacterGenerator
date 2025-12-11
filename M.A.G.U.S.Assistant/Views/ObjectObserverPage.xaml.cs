using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;
using Mtf.Maui.Controls.Messages;

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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            _ = Translator.Translate(this);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }
}