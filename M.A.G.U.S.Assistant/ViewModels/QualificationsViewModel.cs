using M.A.G.U.S.Qualifications;
using Mtf.Extensions;
using Mtf.LanguageService;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class QualificationsViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Qualification> Qualifications { get; } = [];
    public ObservableCollection<Qualification> FilteredQualifications { get; } = [];
    public ObservableCollection<GroupedQualifications> GroupedQualifications
    {
        get => groupedQualifications;
        set
        {
            if (groupedQualifications == value)
            {
                return;
            }

            groupedQualifications = value;
            OnPropertyChanged(nameof(GroupedQualifications));
        }
    }
    string _searchText = String.Empty;
    private ObservableCollection<GroupedQualifications> groupedQualifications = [];

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

    public ICommand ApplyFilterCommand { get; }
    public ICommand ClearFilterCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public QualificationsViewModel()
    {
        ApplyFilterCommand = new RelayCommand(_ => ApplyFilter());
        ClearFilterCommand = new RelayCommand(_ => ClearFilter());

        Seed();
        ApplyFilter();
    }

    private void Seed()
    {
        var qualifications = "M.A.G.U.S.Qualifications".CreateInstancesFromNamespace<Qualification>()
            .OrderBy(c => c.Category.Equals("Other", StringComparison.OrdinalIgnoreCase))
            .ThenBy(q => Lng.Elem(q.Name));

        Qualifications.Clear();
        foreach (var q in qualifications)
        {
            Qualifications.Add(q);
        }
    }

    private void ApplyFilter()
    {
        var query = Qualifications.AsEnumerable();

        var st = SearchText?.Trim();
        if (!String.IsNullOrWhiteSpace(st))
        {
            query = query.Where(q => Lng.Elem(q.Name)?.IndexOf(st, StringComparison.InvariantCultureIgnoreCase) >= 0)
                .OrderBy(c => c.Category.Equals("Other", StringComparison.OrdinalIgnoreCase))
                .ThenBy(c => Lng.Elem(c.Name));
        }

        var grouped = query
            .GroupBy(q => q.Category)
            .OrderBy(c => c.Key.Equals("Other", StringComparison.OrdinalIgnoreCase))
            .ThenBy(c => Lng.Elem(c.Key))
            .Select(g => new GroupedQualifications(Lng.Elem(g.Key), g));

        MainThread.BeginInvokeOnMainThread(() =>
        {
            GroupedQualifications = new ObservableCollection<GroupedQualifications>(grouped);
        });
    }

    private void ClearFilter()
    {
        SearchText = String.Empty;
        ApplyFilter();
    }

    private void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
