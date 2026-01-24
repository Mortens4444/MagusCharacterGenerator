using M.A.G.U.S.Assistant.Models;
using System.Collections.ObjectModel;
using System.Reflection;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class ObjectObserverViewModel : BaseViewModel
{
    private readonly List<string> forbiddenData = ["Source", "Character", "DefaultImage", "Enabled"];
    private readonly Dictionary<string, string> manipulatedName = new()
    {
        { "Key", "Sign" },
        { "Title", "Name" },
        { "Subtitle", "Equivalent" },
        { "RightText", "Meaning" }
    };

    public ObservableCollection<PropertyItem> Properties { get; } = [];

    public object? InspectedObject
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
            {
                LoadProperties();
            }
        }
    }

    private void LoadProperties()
    {
        Properties.Clear();
        if (InspectedObject == null)
        {
            return;
        }

        var type = InspectedObject.GetType();
        var displayItem = InspectedObject as DisplayItem;
        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (prop.CanRead)
            {
                if (displayItem == null || !forbiddenData.Contains(prop.Name))
                {
                    var propertyName = manipulatedName.ContainsKey(prop.Name) ? manipulatedName[prop.Name] : prop.Name;
                    var value = prop.GetValue(InspectedObject);
                    Properties.Add(new PropertyItem(propertyName, value));
                }
            }
        }
    }
}
