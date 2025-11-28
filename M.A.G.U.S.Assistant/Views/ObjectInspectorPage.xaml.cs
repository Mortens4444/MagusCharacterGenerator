using M.A.G.U.S.Assistant.ViewModels;
using Mtf.LanguageService.MAUI;
using System.Diagnostics;

namespace M.A.G.U.S.Assistant.Views;

internal partial class ObjectInspectorPage : NotifierPage
{
    public ObjectInspectorPage(ObjectInspectorViewModel viewModel, object obj)
    {
        InitializeComponent();
        BindingContext = viewModel;
        if (BindingContext is ObjectInspectorViewModel vm)
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
            Debug.WriteLine($"Translate error: {ex}");
        }
    }
}