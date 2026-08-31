using CommunityToolkit.Mvvm.Input;
using MAGUS.Assistant.Extensions;
using MAGUS.Assistant.Models;
using MAGUS.Assistant.Services;
using MAGUS.Interfaces;
using MAGUS.Qualifications;
using Mtf.LanguageService;
using System.Collections.ObjectModel;

namespace MAGUS.Assistant.ViewModels;

internal sealed partial class ClassesViewModel : BaseViewModel
{
    private string searchText = String.Empty;
    private IClass? selectedClass;
    private ObservableCollection<DiceStat> diceStats = [];
    private AsyncRelayCommand? previewImageCommand;

    public ClassesViewModel()
    {
        Classes = [.. PreloadService.Instance.Classes];
        ApplyFilter();
        SelectedClass = Classes.First();
    }

    public IList<IClass> Classes { get; private set; }

    public IEnumerable<ExperienceLevelDisplay> ExperienceLevels =>
        SelectedClass?.ExperienceLevels.Select(x => new ExperienceLevelDisplay
        {
            Level = x.Level,
            Min = x.MinExperience,
            Max = x.MaxExperience
        }) ?? [];

    public string ExperienceAfter12 => SelectedClass is null ? String.Empty : $"+{SelectedClass.ExpPerLevelAfter12:N0} {Lng.Elem("XP / level (12+)")}";

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

    /// <summary>
    /// Kept as one stable instance, mutated via Clear()/Add() - unlike an earlier version that
    /// assigned a brand-new ObservableCollection here on every ApplyFilter() call. That pattern broke
    /// the bound Picker's ItemsSource on some platforms after it had once observed an empty collection
    /// (a search with no matches): the Picker never picked up the next replacement instance, so
    /// results stayed stuck empty even once the search text matched something again. See
    /// RacesViewModel/LanguagesViewModel/ImagesViewModel's FilteredX collections for the same
    /// established, working pattern.
    /// </summary>
    public ObservableCollection<IClass> FilteredClasses { get; } = [];

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

                OnPropertyChanged(nameof(InitiateBaseValue));
                OnPropertyChanged(nameof(AttackBaseValue));
                OnPropertyChanged(nameof(DefenseBaseValue));
                OnPropertyChanged(nameof(AimBaseValue));
                OnPropertyChanged(nameof(CombatValueModifierPerLevel));

                OnPropertyChanged(nameof(Qualifications));
                OnPropertyChanged(nameof(PercentQualifications));
                OnPropertyChanged(nameof(SpecialQualifications));
                OnPropertyChanged(nameof(FutureQualifications));

                OnPropertyChanged(nameof(ExperienceLevels));
                OnPropertyChanged(nameof(ExperienceAfter12));
            }
        }
    }

    public int InitiateBaseValue => SelectedClass?.InitiateBaseValue ?? 0;
    public int AttackBaseValue => SelectedClass?.AttackBaseValue ?? 0;
    public int DefenseBaseValue => SelectedClass?.DefenseBaseValue ?? 0;
    public int AimBaseValue => SelectedClass?.AimBaseValue ?? 0;
    public int CombatValueModifierPerLevel => SelectedClass?.CombatValueModifierPerLevel ?? 0;
    public QualificationList Qualifications => SelectedClass?.Qualifications ?? [];
    public PercentQualificationList PercentQualifications => SelectedClass?.PercentQualifications ?? [];
    public SpecialQualificationList SpecialQualifications => SelectedClass?.SpecialQualifications ?? [];
    public QualificationList FutureQualifications => SelectedClass?.FutureQualifications ?? [];

    private void ApplyFilter()
    {
        var st = SearchText?.Trim();
        var query = String.IsNullOrWhiteSpace(st)
            ? Classes.AsEnumerable()
            : Classes.Where(c => Lng.Elem(c.Name).Contains(st, StringComparison.InvariantCultureIgnoreCase)).OrderBy(c => Lng.Elem(c.Name));

        FilteredClasses.Clear();
        foreach (var it in query)
        {
            FilteredClasses.Add(it);
        }
    }

    public IAsyncRelayCommand PreviewImageCommand => previewImageCommand ??= new AsyncRelayCommand(PreviewImage);

    private Task PreviewImage()
    {
        return ImagePreviewService.ShowAsync(SelectedClass?.DefaultImage);
    }

    [RelayCommand]
    private void SelectNextClass()
    {
        if (SelectedClass == null || FilteredClasses.Count <= 1)
        {
            return;
        }

        int currentIndex = FilteredClasses.IndexOf(SelectedClass);
        if (currentIndex < FilteredClasses.Count - 1)
        {
            SelectedClass = FilteredClasses[currentIndex + 1];
        }
    }

    [RelayCommand]
    private void SelectPreviousClass()
    {
        if (SelectedClass == null || FilteredClasses.Count <= 1)
        {
            return;
        }

        int currentIndex = FilteredClasses.IndexOf(SelectedClass);
        if (currentIndex > 0)
        {
            SelectedClass = FilteredClasses[currentIndex - 1];
        }
    }
}
