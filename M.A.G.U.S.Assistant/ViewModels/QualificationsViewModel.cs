using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.CustomEventArgs;
using M.A.G.U.S.Assistant.Views;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Qualifications;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class QualificationsViewModel : BaseViewModel
{
    private Character? character;

    public QualificationsViewModel()
    {
        ApplyFilterCommand = new RelayCommand(() => ApplyFilter());
        ClearFilterCommand = new RelayCommand(() => ClearFilter());

        Seed();
        ApplyFilter();
    }

    public ICommand ApplyFilterCommand { get; }

    public ICommand ClearFilterCommand { get; }

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
            OnPropertyChanged();
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
            OnPropertyChanged();
            ApplyFilter();
        }
    }

    public Character? Character
    {
        get => character;
        set
        {
            if (character == value)
            {
                return;
            }

            character = value;
            OnPropertyChanged();
            ApplyFilter();
        }
    }

    private Qualification? selectedItem;
    public Qualification? SelectedItem
    {
        get => selectedItem;
        set
        {
            if (selectedItem == value)
            {
                return;
            }

            selectedItem = value;
            OnPropertyChanged();

            if (selectedItem != null)
            {
                _ = OpenDetailsAsync(selectedItem);
            }
        }
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
        if (Character != null)
        {
            query = query.Where(q => Character.CanLearn(q));
        }

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

    private async Task OpenDetailsAsync(Qualification selectedItem)
    {
        try
        {
            var mainPage = Application.Current != null && Application.Current.Windows.Count > 0 ? Application.Current.Windows[0].Page : null;
            if (mainPage?.Navigation != null)
            {
                var qualificationDetailsViewModel = new QualificationDetailsViewModel(Character, selectedItem);
                qualificationDetailsViewModel.Learned += LearnHandler;
                var page = new QualificationDetailsPage(qualificationDetailsViewModel);
                SelectedItem = null;
                await mainPage.Navigation.PushAsync(page).ConfigureAwait(true);
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private void LearnHandler(object? sender, QualificationLearnedEventArgs e)
    {
        try
        {
            Character?.Learn(e.Qualification, e.QualificationLevel);
            ApplyFilter();
            var mainPage = Application.Current != null && Application.Current.Windows.Count > 0 ? Application.Current.Windows[0].Page : null;
            mainPage?.Navigation.PopAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }
}
