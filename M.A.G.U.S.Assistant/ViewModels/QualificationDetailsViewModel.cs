using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.CustomEventArgs;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Languages;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Things.Weapons;
using Mtf.LanguageService.MAUI;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class QualificationDetailsViewModel : BaseViewModel
{
    private QualificationLevel selectedLevel;
    private bool canLearn;
    private int requiredSp;
    private AsyncRelayCommand? previewImageCommand;

    private Weapon? selectedWeapon;
    private IReadOnlyList<Weapon> availableWeapons = PreloadService.Instance.Weapons;

    private Language? selectedLanguage;
    private AntientLanguage? selectedAntientLanguage;
    private int selectedLanguageLevel = 1;
    private readonly IList<Language> availableLanguages = [.. Enum.GetValues<Language>()];
    private readonly IList<AntientLanguage> availableAntientLanguages = [.. Enum.GetValues<AntientLanguage>()];
    private readonly int[] availableLanguageLevels = [1, 2, 3, 4, 5];

    public IReadOnlyList<Weapon> AvailableWeapons
    {
        get => availableWeapons;
        private set => SetProperty(ref availableWeapons, value);
    }

    public Weapon? SelectedWeapon
    {
        get => selectedWeapon;
        set => SetProperty(ref selectedWeapon, value);
    }

    public IList<Language> AvailableLanguages => availableLanguages;
    public Language? SelectedLanguage
    {
        get => selectedLanguage;
        set => SetProperty(ref selectedLanguage, value);
    }

    public IList<AntientLanguage> AvailableAntientLanguages => availableAntientLanguages;
    public AntientLanguage? SelectedAntientLanguage
    {
        get => selectedAntientLanguage;
        set => SetProperty(ref selectedAntientLanguage, value);
    }

    public int[] AvailableLanguageLevels => availableLanguageLevels;
    public int SelectedLanguageLevel
    {
        get => selectedLanguageLevel;
        set => SetProperty(ref selectedLanguageLevel, value);
    }

    public bool IsWeaponQualification => Qualification is WeaponQualification;

    public bool IsLanguageLore => Qualification is LanguageLore;

    public bool IsAncientTongueLore => Qualification is AncientTongueLore;

    public QualificationDetailsViewModel(Character? character, Qualification qualification)
    {
        Qualification = qualification ?? throw new ArgumentNullException(nameof(qualification));
        Character = character;

        if (qualification is WeaponQualification wq && wq.Weapon != null)
        {
            SelectedWeapon = AvailableWeapons.FirstOrDefault(w => w.Id == wq.Weapon.Id) ?? wq.Weapon;
        }

        if (qualification is LanguageLore ll)
        {
            SelectedLanguage = ll.Language;
            SelectedLanguageLevel = Math.Clamp(ll.LanguageLevel, 1, 5);
        }

        if (qualification is AncientTongueLore atl && atl.Language.HasValue)
        {
            SelectedAntientLanguage = atl.Language.Value;
        }

        AvailableLevels = [ QualificationLevel.Base, QualificationLevel.Master ];
        SelectedLevel = qualification.QualificationLevel;

        Name = Lng.Elem(Qualification.Name);
        Category = qualification.Category;
        Description = Qualification.Description;
        DefaultImage = Qualification.DefaultImage;

        LearnCommand = new RelayCommand(Learn, () => CanLearn);
        CloseCommand = new RelayCommand(OnClosed);

        UpdateDerived();
    }

    public Qualification Qualification { get; }
    public Character? Character { get; }
    public string Name { get; } = String.Empty;
    public string Category { get; } = String.Empty;
    public string Description { get; } = String.Empty;
    public string DefaultImage { get; } = String.Empty;
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

        OnPropertyChanged(nameof(CanLearn));
        (LearnCommand as RelayCommand)?.NotifyCanExecuteChanged();
    }

    private void Learn()
    {
        if (!CanLearn)
        {
            return;
        }

        if (IsWeaponQualification && Qualification is WeaponQualification wq)
        {
            wq.Weapon = SelectedWeapon;
        }

        if (IsLanguageLore && Qualification is LanguageLore ll)
        {
            ll.Language = SelectedLanguage;
            ll.LanguageLevel = SelectedLanguageLevel;
        }

        if (IsAncientTongueLore && Qualification is AncientTongueLore atl && SelectedAntientLanguage.HasValue)
        {
            atl.Language = SelectedAntientLanguage.Value;
        }

        Learned?.Invoke(this, new QualificationLearnedEventArgs(Qualification, SelectedLevel));
        UpdateDerived();
    }

    protected virtual void OnClosed()
    {
        Closed?.Invoke(this, EventArgs.Empty);
    }

    public IAsyncRelayCommand PreviewImageCommand => previewImageCommand ??= new AsyncRelayCommand(PreviewImage);

    private Task PreviewImage()
    {
        return ImagePreviewService.ShowAsync(Qualification?.DefaultImage);
    }
}
