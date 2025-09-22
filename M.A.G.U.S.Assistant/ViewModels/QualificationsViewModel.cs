using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Qualifications;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

public class QualificationsViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Qualification> Qualifications { get; } = [];
    public ObservableCollection<Qualification> FilteredQualifications { get; } = [];

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
            .OrderBy(q => q.Name);

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
            query = query.Where(q => q.Name?.IndexOf(st, StringComparison.CurrentCultureIgnoreCase) >= 0)
                .OrderBy(q => q.Name);
        }

        FilteredQualifications.Clear();
        foreach (var q in query)
        {
            FilteredQualifications.Add(q);
        }
    }

    private void ClearFilter()
    {
        SearchText = String.Empty;
        ApplyFilter();
    }

    private void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
