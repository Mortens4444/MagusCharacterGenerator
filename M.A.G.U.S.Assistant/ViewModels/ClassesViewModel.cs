using global::M.A.G.U.S.Classes;
using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using Mtf.LanguageService;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace M.A.G.U.S.Assistant.ViewModels;

public class ClassesViewModel : INotifyPropertyChanged
{
    public ObservableCollection<IClass> Classes { get; } = [];
    public ObservableCollection<IClass> FilteredClasses { get; } = [];

    public event PropertyChangedEventHandler? PropertyChanged;

    private string searchText = String.Empty;
    private IClass selectedClass;

    public string SearchText
    {
        get => searchText;
        set
        {
            if (searchText == value)
            {
                return;
            }

            searchText = value ?? String.Empty;
            OnPropertyChanged(nameof(SearchText));
            ApplyFilter();
        }
    }

    public IClass SelectedClass
    {
        get => selectedClass;
        set
        {
            if (selectedClass == value)
            {
                return;
            }

            selectedClass = value;
            OnPropertyChanged(nameof(SelectedClass));
            OnPropertyChanged(nameof(OrderedQualifications));
        }
    }

    public ObservableCollection<Qualification> OrderedQualifications
    {
        get
        {
            return new ObservableCollection<Qualification>(SelectedClass?.Qualifications.OrderByLocalizedName() ?? []);
        }
    }

    public ClassesViewModel()
    {
        Seed();
        ApplyFilter();
        SelectedClass = Classes.First();
    }

    private void Seed()
    {
        var classes = "M.A.G.U.S.Classes".CreateInstancesFromNamespace<Class>()
            .OrderBy(c => Lng.Elem(c.Name));

        Classes.Clear();
        foreach (var cls in classes)
        {
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
                c.Name?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        query = query
            .OrderBy(c => Lng.Elem(c.Name));

        FilteredClasses.Clear();
        foreach (var it in query)
        {
            FilteredClasses.Add(it);
        }
    }

    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
