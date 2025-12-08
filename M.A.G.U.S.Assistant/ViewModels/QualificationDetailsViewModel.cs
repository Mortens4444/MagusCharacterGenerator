using CommunityToolkit.Mvvm.ComponentModel;
using M.A.G.U.S.Assistant.CustomEventArgs;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Extensions;
using System.Reflection;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class QualificationDetailsViewModel : ObservableObject
{
    public Qualification Qualification { get; }
    public Character? Character { get; }

    public QualificationDetailsViewModel(Character? character, Qualification qualification)
    {
        Qualification = qualification ?? throw new ArgumentNullException(nameof(qualification));
        Character = character;

        AvailableLevels = [ QualificationLevel.Base, QualificationLevel.Master ];
        SelectedLevel = qualification.QualificationLevel;

        Name = Lng.Elem(Qualification.Name);
        Category = qualification.Category;
        Description = Qualification.Description;
        ImageName = qualification.Name.ToImageName();

        LearnCommand = new RelayCommand(_ => Learn(), _ => CanLearn);
        CloseCommand = new RelayCommand(_ => OnClosed());

        UpdateDerived();
    }

    public QualificationLevel[] AvailableLevels { get; }

    private QualificationLevel selectedLevel;
    public QualificationLevel SelectedLevel
    {
        get => selectedLevel;
        set
        {
            if (selectedLevel == value)
            {
                return;
            }

            selectedLevel = value;
            OnPropertyChanged(nameof(SelectedLevel));
            UpdateDerived();
        }
    }

    public string Name { get; } = String.Empty;
    public string Category { get; } = String.Empty;
    public string Description { get; } = String.Empty;
    public string ImageName { get; } = String.Empty;

    public int RequiredSp => SelectedLevel == QualificationLevel.Base ? Qualification.QpToBaseQualification : Qualification.QpToMasterQualification;

    public string RequiredSpText => RequiredSp > 0 ? $"{RequiredSp} {Lng.Elem("SP")}" : Lng.Elem("Not learnable");

    public string LearnButtonText => RequiredSp <= (Character?.QualificationPoints ?? 0) ? Lng.Elem("Learn") : Lng.Elem("Unavailable");

    public bool CanLearn
    {
        get
        {
            if (Character == null)
            {
                return false;
            }

            if (RequiredSp < 0)
            {
                return false;
            }

            if (Character.QualificationPoints < RequiredSp)
            {
                return false;
            }

            var hasMaster = Character.Qualifications.Any(q => q.Name == Qualification.Name && q.QualificationLevel == QualificationLevel.Master);
            if (hasMaster)
            {
                return false;
            }

            var hasBase = Character.Qualifications.Any(q => q.Name == Qualification.Name && q.QualificationLevel == QualificationLevel.Base);
            return SelectedLevel != QualificationLevel.Base || !hasBase;
        }
    }
    public ICommand LearnCommand { get; }
    public ICommand CloseCommand { get; }

    public event EventHandler<QualificationLearnedEventArgs>? Learned;
    public event EventHandler? Closed;

    private void UpdateDerived()
    {
        OnPropertyChanged(nameof(RequiredSp));
        OnPropertyChanged(nameof(RequiredSpText));
        OnPropertyChanged(nameof(CanLearn));
        (LearnCommand as RelayCommand)?.RaiseCanExecuteChanged();
    }

    private void Learn()
    {
        if (!CanLearn || Character == null)
        {
            return;
        }

        Learned?.Invoke(this, new QualificationLearnedEventArgs(Qualification, SelectedLevel));
        UpdateDerived();
    }

    protected virtual void OnClosed()
    {
        Closed?.Invoke(this, EventArgs.Empty);
    }
}
