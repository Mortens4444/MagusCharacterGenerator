using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Interfaces;
using Mtf.Extensions;
using Mtf.LanguageService;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class ClassesViewModel : INotifyPropertyChanged
{
    public IList<IClass> classes;

    public event PropertyChangedEventHandler? PropertyChanged;

    private string searchText = String.Empty;
    private IClass selectedClass;
    private ObservableCollection<IClass> filteredClasses = [];

    public ObservableCollection<IClass> FilteredClasses
    {
        get => filteredClasses;
        private set
        {
            if (filteredClasses == value)
            {
                return;
            }
            filteredClasses = value ?? [];
            OnPropertyChanged(nameof(FilteredClasses));
        }
    }

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
            SetDiceStats();
        }
    }

    private void SetDiceStats()
    {
        var stats = selectedClass?.GetDiceStats() ?? [];
        diceStats.Clear();
        foreach (var stat in stats)
        {
            diceStats.Add(stat);
        }
    }

    private readonly ObservableCollection<DiceStat> diceStats = [];
    public ObservableCollection<DiceStat> DiceStats => diceStats;

    public ClassesViewModel()
    {
        classes = [.. "M.A.G.U.S.Classes".CreateInstancesFromNamespace<IClass>().OrderBy(c => Lng.Elem(c.Name))];
        ApplyFilter();
        SelectedClass = classes.First();
    }

    private void ApplyFilter()
    {
        var st = SearchText?.Trim();
        if (!String.IsNullOrWhiteSpace(st))
        {
            FilteredClasses = new ObservableCollection<IClass>(classes.Where(c =>
                Lng.Elem(c.Name).Contains(st, StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(c => Lng.Elem(c.Name)));
        }
        else
        {
            FilteredClasses = new ObservableCollection<IClass>(classes);
        }
    }

    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
