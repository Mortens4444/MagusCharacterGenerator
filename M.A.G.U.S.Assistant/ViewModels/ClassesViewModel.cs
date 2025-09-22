using global::M.A.G.U.S.Classes;
using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

public class ClassesViewModel : INotifyPropertyChanged
{
    public ObservableCollection<IClass> Classes { get; } = [];
    public ObservableCollection<IClass> FilteredClasses { get; } = [];

    string _searchText = String.Empty;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText == value)
            {
                return;
            }

            _searchText = value ?? String.Empty;
            OnPropertyChanged(nameof(SearchText));
            ApplyFilter();
        }
    }

    IClass _selectedClass;
    public IClass SelectedClass
    {
        get => _selectedClass;
        set
        {
            if (_selectedClass == value)
            {
                return;
            }

            _selectedClass = value;
            OnPropertyChanged(nameof(SelectedClass));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ClassesViewModel()
    {
        Seed();
        ApplyFilter();
    }

    private void Seed()
    {
        var classes = "M.A.G.U.S.Classes".CreateInstancesFromNamespace<Class>()
            .OrderBy(c => c.ClassName);

        Classes.Clear();
        foreach (var cls in classes)
        {
            // név/set defaultok
            if (String.IsNullOrEmpty(cls.Name))
            {
                cls.Name = cls.ClassName;
            }

            Classes.Add(cls);
        }
    }

    private void ApplyFilter()
    {
        var query = Classes.AsEnumerable();
        var st = SearchText?.Trim();
        if (!String.IsNullOrWhiteSpace(st))
        {
            query = query.Where(c =>
                c.ClassName?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0)
                .OrderBy(c => c.ClassName);
        }

        FilteredClasses.Clear();
        foreach (var it in query)
        {
            FilteredClasses.Add(it);
        }
    }

    void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
