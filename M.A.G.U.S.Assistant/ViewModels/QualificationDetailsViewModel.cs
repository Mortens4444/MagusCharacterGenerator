using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.CustomEventArgs;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Extensions;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class QualificationDetailsViewModel : ObservableObject
{
    private QualificationLevel selectedLevel;
    private bool canLearn;
    private int requiredSp;

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

        LearnCommand = new RelayCommand(Learn, () => CanLearn);
        CloseCommand = new RelayCommand(OnClosed);

        UpdateDerived();
    }

    public Qualification Qualification { get; }
    public Character? Character { get; }
    public string Name { get; } = String.Empty;
    public string Category { get; } = String.Empty;
    public string Description { get; } = String.Empty;
    public string ImageName { get; } = String.Empty;
    public QualificationLevel[] AvailableLevels { get; }
    public ICommand LearnCommand { get; }
    public ICommand CloseCommand { get; }

    public QualificationLevel SelectedLevel
    {
        get => selectedLevel;
        set
        {
            if (SetProperty(ref selectedLevel, value))
            {
                UpdateDerived();
            }
        }
    }

    public bool CanLearn { get => canLearn; set => SetProperty(ref canLearn, value); }
    public int RequiredSp { get => requiredSp; set => SetProperty(ref requiredSp, value); }
    public string LearnButtonText => RequiredSp <= (Character?.QualificationPoints ?? 0) ? Lng.Elem("Learn") : Lng.Elem("Unavailable");

    public event EventHandler<QualificationLearnedEventArgs>? Learned;
    public event EventHandler? Closed;

    private void UpdateDerived()
    {
        bool learnable;
        int requiredQp;

        if (Character != null)
        {
            learnable = Character.CanLearn(Qualification, SelectedLevel, out requiredQp);
        }
        else
        {
            requiredQp = SelectedLevel == QualificationLevel.Base
                ? Qualification.QpToBaseQualification
                : Qualification.QpToMasterQualification;
            learnable = false;
        }
        RequiredSp = requiredQp;
        canLearn = learnable;

        //OnPropertyChanged(nameof(RequiredSp));
        OnPropertyChanged(nameof(CanLearn));
        OnPropertyChanged(nameof(LearnButtonText));

        (LearnCommand as RelayCommand)?.NotifyCanExecuteChanged();

    }

    private void Learn()
    {
        if (CanLearn)
        {
            Learned?.Invoke(this, new QualificationLearnedEventArgs(Qualification, SelectedLevel));
            UpdateDerived();
        }
    }

    protected virtual void OnClosed()
    {
        Closed?.Invoke(this, EventArgs.Empty);
    }
}
