using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.CustomEventArgs;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Extensions;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class QualificationDetailsViewModel : ObservableObject
{
    private QualificationLevel selectedLevel;

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
                // Csak a SelectedLevel változásakor hívjuk meg az UpdateDerived()-t
                UpdateDerived();
            }
        }
    }

    private bool canLearn;
    public bool CanLearn // Ez a setter csak notifikációra szolgál, NEM HÍVJA AZ UpdateDerived()-t!
    {
        get => canLearn;
        set => SetProperty(ref canLearn, value);
    }

    private int requiredSp;
    public int RequiredSp // Ez a setter csak notifikációra szolgál, NEM HÍVJA AZ UpdateDerived()-t!
    {
        get => requiredSp;
        set => SetProperty(ref requiredSp, value);
    }

    private string requiredSpText;
    public string RequiredSpText // Ez a setter csak notifikációra szolgál, NEM HÍVJA AZ UpdateDerived()-t!
    {
        get => requiredSpText;
        set => SetProperty(ref requiredSpText, value);
    }

    public string LearnButtonText => RequiredSp <= (Character?.QualificationPoints ?? 0) ? Lng.Elem("Learn") : Lng.Elem("Unavailable");

    public event EventHandler<QualificationLearnedEventArgs>? Learned;
    public event EventHandler? Closed;

    private void UpdateDerived()
    {
        int requiredQp;
        bool learnable;

        if (Character != null)
        {
            // Változás 2: Kiszedjük a CanLearn kiszámítását
            learnable = Character.CanLearn(Qualification, SelectedLevel, out requiredQp);
        }
        else
        {
            // Változás 3: Kiszedjük a szükséges SP kiszámítását, ha nincs Character
            requiredQp = SelectedLevel == QualificationLevel.Base
                ? Qualification.QpToBaseQualification
                : Qualification.QpToMasterQualification;
            learnable = false; // Mivel nincs karakter, nem tanulható
        }

        // Változás 4: Most beállítjuk a tulajdonságokat az UpdateDerived()-ban.
        // Mivel a RequiredSp, CanLearn és RequiredSpText setterei már nem hívják az UpdateDerived()-t,
        // elkerüljük a rekurziót!

        requiredSp = requiredQp;
        canLearn = learnable;

        // Változás 5: A RequiredSpText-et is itt állítjuk be
        requiredSpText = RequiredSp >= 0
            ? $"{RequiredSp} {Lng.Elem("SP")}"
            : Lng.Elem("Not learnable");
        OnPropertyChanged(nameof(RequiredSp));
        OnPropertyChanged(nameof(RequiredSpText)); // **EZ GARANTÁLJA A FRISSÜLÉST**
        OnPropertyChanged(nameof(CanLearn));

        // Változás 6: Biztosítjuk, hogy a LearnButtonText is frissüljön
        OnPropertyChanged(nameof(LearnButtonText));

        // Változás 7: Frissítjük a parancsot, ami a CanLearn-től függ
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
