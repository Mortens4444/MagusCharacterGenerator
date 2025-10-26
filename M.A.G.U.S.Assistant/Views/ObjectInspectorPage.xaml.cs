using M.A.G.U.S.Assistant.ViewModels;

namespace M.A.G.U.S.Assistant.Views;

public partial class ObjectInspectorPage : NotifierPage
{
    public ObjectInspectorPage(object obj)
    {
        InitializeComponent();
        if (BindingContext is ObjectInspectorViewModel vm)
        {
            vm.InspectedObject = obj;
        }
    }
}