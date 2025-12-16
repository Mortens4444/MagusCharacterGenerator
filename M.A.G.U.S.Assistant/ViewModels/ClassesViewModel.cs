using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class ClassesViewModel : BaseViewModel
{
    private string searchText = String.Empty;
    private IClass? selectedClass;
    private ObservableCollection<IClass> filteredClasses = [];
    private ObservableCollection<DiceStat> diceStats = [];

    public ClassesViewModel()
    {
        Classes = [.. "M.A.G.U.S.Classes".CreateInstancesFromNamespace<IClass>().OrderBy(c => Lng.Elem(c.Name))];
        ApplyFilter();
        SelectedClass = Classes.First();
    }

    public IList<IClass> Classes { get; private set; }

    public ObservableCollection<DiceStat> DiceStats
    {
        get => diceStats;
        private set
        {
            if (SetProperty(ref diceStats, value ?? []))
            {
                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<IClass> FilteredClasses
    {
        get => filteredClasses;
        private set
        {
            if (SetProperty(ref filteredClasses, value ?? []))
            {
                OnPropertyChanged();
            }
        }
    }

    public string SearchText
    {
        get => searchText;
        set
        {
            if (SetProperty(ref searchText, value ?? String.Empty))
            {
                OnPropertyChanged();
                ApplyFilter();
            }
        }
    }

    public IClass? SelectedClass
    {
        get => selectedClass;
        set
        {
            if (SetProperty(ref selectedClass, value))
            {
                DiceStats = new ObservableCollection<DiceStat>(selectedClass?.GetDiceStats() ?? []);
                OnPropertyChanged();
            }
        }
    }

    public int InitiatingBaseValue => SelectedClass?.InitiatingBaseValue ?? 0;
    public int AttackingBaseValue => SelectedClass?.AttackingBaseValue ?? 0;
    public int DefendingBaseValue => SelectedClass?.DefendingBaseValue ?? 0;
    public int AimingBaseValue => SelectedClass?.AimingBaseValue ?? 0;
    public int FightValueModifier => SelectedClass?.FightValueModifier ?? 0;
    public QualificationList Qualifications => SelectedClass?.Qualifications ?? [];
    public List<PercentQualification> PercentQualifications => SelectedClass?.PercentQualifications ?? [];
    public SpecialQualificationList SpecialQualifications => SelectedClass?.SpecialQualifications ?? [];
    public QualificationList FutureQualifications => SelectedClass?.FutureQualifications ?? [];

    private void ApplyFilter()
    {
        var st = SearchText?.Trim();
        if (!String.IsNullOrWhiteSpace(st))
        {
            FilteredClasses = new ObservableCollection<IClass>(Classes.Where(c =>
                Lng.Elem(c.Name).Contains(st, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(c => Lng.Elem(c.Name)));
        }
        else
        {
            FilteredClasses = new ObservableCollection<IClass>(Classes);
        }
    }
}
