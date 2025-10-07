using System.Collections.ObjectModel;
using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;

namespace M.A.G.U.S.Assistant.ViewModels
{
    public class ObjectInspectorViewModel : ObservableObject
    {
        public ObservableCollection<PropertyItem> Properties { get; } = new();

        object inspectedObject;
        public object InspectedObject
        {
            get => inspectedObject;
            set
            {
                if (SetProperty(ref inspectedObject, value))
                {
                    LoadProperties();
                }
            }
        }

        void LoadProperties()
        {
            Properties.Clear();
            if (inspectedObject == null)
                return;

            var type = inspectedObject.GetType();
            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (prop.CanRead)
                {
                    var value = prop.GetValue(inspectedObject);
                    Properties.Add(new PropertyItem(prop.Name, value));
                }
            }
        }
    }
}
