using M.A.G.U.S.Assistant.ViewModels;

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
}