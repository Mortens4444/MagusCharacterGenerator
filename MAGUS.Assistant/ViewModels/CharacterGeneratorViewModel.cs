using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MAGUS.Assistant.Interfaces;
using MAGUS.Assistant.Models;
using MAGUS.Assistant.Services;
using MAGUS.Assistant.Views;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Interfaces;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Races;
using MAGUS.Utils;
using Mtf.Extensions.Services;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Messages;
using System.Collections.ObjectModel;
using System.Reflection;
namespace MAGUS.Assistant.ViewModels;

internal sealed partial class CharacterGeneratorViewModel : CharacterViewModel
{
    private readonly ISettings settings;
    private readonly ISoundPlayer soundPlayer;
    private readonly IShakeService shakeService;

    private int baseClassLevel = 1;
    private bool isCharacterGenerated;

    public CharacterGeneratorViewModel(CharacterService characterService, ISoundPlayer soundPlayer, IShakeService shakeService, ISettings settings, IPrintService printService, SettingsService settingsService, IRuneTranslator runeTranslator, GameEventService gameEventService)
         : base(printService, soundPlayer, shakeService, settings, characterService, settingsService, runeTranslator, gameEventService)
    {
        this.settings = settings;
        this.soundPlayer = soundPlayer;
        this.shakeService = shakeService;
        Character = new Character(settings);

        LoadAvailableTypes();

        // Pick the class first, then the race from whatever FilterAvailableRaces (below) leaves in
        // AvailableRaces for it - otherwise a fully independent random pick could just as easily land
        // on a race that class doesn't allow, the same problem UseRaceClassRestrictions exists to
        // prevent when the player picks manually.
        int classIndex = RandomProvider.GetSecureRandomInt(0, AvailableClasses.Count);
        SelectedClass = AvailableClasses[classIndex];

        int raceIndex = RandomProvider.GetSecureRandomInt(0, AvailableRaces.Count);
        SelectedRace = AvailableRaces[raceIndex];
    }

    public ObservableCollection<IRace?> AvailableRaces { get; } = [];

    public ObservableCollection<IClass?> AvailableClasses { get; } = [];

    public int BaseClassLevel { get => baseClassLevel; set => SetProperty(ref baseClassLevel, value); }

    private IRace? selectedRace;
    public IRace? SelectedRace { get => selectedRace; set => SetProperty(ref selectedRace, value); }

    private IClass? selectedClass;
    public IClass? SelectedClass
    {
        get => selectedClass;
        set
        {
            if (SetProperty(ref selectedClass, value))
            {
                FilterAvailableRaces();
            }
        }
    }

    /// <summary>
    /// Settings > Other "Use race/class restrictions" (UseRaceClassRestrictions) - when on, narrows
    /// AvailableRaces to SelectedClass.AllowedRaces so the race picker can't land on a combination the
    /// class doesn't actually support. An empty AllowedRaces is the established "no restriction"
    /// convention (see Class.AllowedRaces's default), so that - and the setting being off - both mean
    /// every race stays available.
    /// </summary>
    private void FilterAvailableRaces()
    {
        var allowedRaces = (selectedClass as MAGUS.Classes.Class)?.AllowedRaces ?? [];
        var restricted = settings.UseRaceClassRestrictions && allowedRaces.Length > 0;
        var allowedTypes = restricted ? allowedRaces.Select(r => r.GetType()).ToHashSet() : null;

        AvailableRaces.Clear();
        foreach (var race in PreloadService.Instance.Races)
        {
            if (allowedTypes is null || allowedTypes.Contains(race.GetType()))
            {
                AvailableRaces.Add(race);
            }
        }

        if (SelectedRace is null || !AvailableRaces.Contains(SelectedRace))
        {
            SelectedRace = AvailableRaces.FirstOrDefault();
        }
    }

    private bool isDirty;

    public bool IsDirty
    {
        get => isDirty;
        private set => SetProperty(ref isDirty, value);
    }

    public bool IsCharacterGenerated
    {
        get => isCharacterGenerated;
        set => SetProperty(ref isCharacterGenerated, value);
    }

    public override bool CanReviseQualificationSelection => true;

    [RelayCommand]
    public async Task GenerateCharacter()
    {
        if (selectedRace == null)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage("No race selected!"));
            return;
        }

        if (SelectedClass == null)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage("No class selected!"));
            return;
        }

        try
        {
            var classType = SelectedClass.GetType();
            var instanceClass = InstanceClass(classType, BaseClassLevel, settings.AutoGenerateSkills);
            if (instanceClass == null)
            {
                //WeakReferenceMessenger.Default.Send(new ShowErrorMessage("Class cannot be instantiated!"));
                return;
            }
    
            if (!settings.AutoGenerateSkills)
            {
                string[] skillNames = [ nameof(instanceClass.Strength), nameof(instanceClass.Stamina), nameof(instanceClass.Quickness), nameof(instanceClass.Dexterity), nameof(instanceClass.Health), nameof(instanceClass.Beauty),
                    nameof(instanceClass.Intelligence), nameof(instanceClass.Willpower), nameof(instanceClass.Astral), nameof(instanceClass.Bravery), nameof(instanceClass.Erudition), nameof(instanceClass.Detection), nameof(instanceClass.Gold) ];

                var skillProperties = skillNames.Select(n => classType.GetProperty(n))
                    .OrderBy(pi => pi?.GetCustomAttribute<OrderAttibute>()?.Number ?? 0).ToList();

                foreach (var propertyInfo in skillProperties)
                {
                    var rollFormula = new LocalizedRollFormula(propertyInfo, $"{Lng.Elem("Create character")} - {Lng.Elem(propertyInfo!.Name)}");
                    var page = new RollFormulaPage(soundPlayer, shakeService, rollFormula);
                    await ShellNavigationService.ShowPageAsync(page).ConfigureAwait(true);
                    var result = await page.ResultTask.ConfigureAwait(true);
                    propertyInfo!.SetValue(instanceClass, result);
                }
            }
            Character = new Character(settings, NameGenerator.Get(selectedRace), selectedRace, instanceClass);
            IsCharacterGenerated = true;
            MarkDirty();
            if (!settings.AutoIncreasePainTolerance)
            {
                for (var level = Level; level <= Level; level++)
                {
                    var formula = Character?.BaseClass.GetPainToleranceModifierFormula(level);
                    var page = new RollFormulaPage(soundPlayer, shakeService, formula, $"{Lng.Elem("Create character")} - {Lng.Elem("PTP")} ({level}. {Lng.Elem("Level")})");
                    await ShellNavigationService.ShowPageAsync(page).ConfigureAwait(true);
                    var result = await page.ResultTask.ConfigureAwait(true);
                    Character.MaxPainTolerancePoints += result;
                }
            }

            // Priest-type classes (ClericalMagic) roll mana per level - CalculateManaPoints (called by
            // the Character constructor above) already skipped that roll when AutoIncreaseManaPoints is
            // off, so it's filled in here interactively instead, the same way Pain Tolerance is above.
            if (Character.Sorcery != null && !settings.AutoIncreaseManaPoints)
            {
                var manaFormula = Character.MaxManaPointsPerLevelFormula;
                if (!String.IsNullOrEmpty(manaFormula?.Formula))
                {
                    for (var level = Level; level <= Level; level++)
                    {
                        var page = new RollFormulaPage(soundPlayer, shakeService, manaFormula, $"{Lng.Elem("Create character")} - {Lng.Elem("Mana-points")} ({level}. {Lng.Elem("Level")})");
                        await ShellNavigationService.ShowPageAsync(page).ConfigureAwait(true);
                        var result = await page.ResultTask.ConfigureAwait(true);
                        Character.MaxManaPoints += result;
                        Character.ManaPoints += result;
                    }
                }
            }
            if (settings.AutoDistributeQualificationPoints)
            {
                var qualifications = QualificationLearner.Get();
                if (!Character.HasPsi() && Character.CanLearn(new PsiPyarron()))
                {
                    Character.Learn(new PsiPyarron(), QualificationLevel.Base);
                }
                foreach (var qualification in qualifications)
                {
                    if (!Character.HasQualification(qualification) && Character.CanLearn(qualification, qualification.QualificationLevel))
                    {
                        Character.Learn(qualification, qualification.QualificationLevel);
                    }
                }
                OnPropertyChanged(nameof(QualificationPoints));
                OnPropertyChanged(nameof(Qualifications));
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    [RelayCommand]
    public async Task SaveCharacter()
    {
        await characterService.SaveAsync(Character).ConfigureAwait(true);
        MarkClean();

        // CharacterGeneratorPage is reached via Mtf.Maui.Controls.MenuItem's raw
        // Navigation.PushAsync (bypassing Shell's registered-route navigation), while the page's own
        // back-navigation logic assumes Shell route navigation - that mismatch can leave more than one
        // NotifierPage-registered instance alive, so a WeakReferenceMessenger-based toast here can
        // render twice. DisplayAlertAsync talks directly to the current page instead of broadcasting,
        // so it can't double-fire the same way.
        await ShellNavigationService.DisplayAlertAsync(Lng.Elem("Character saved"), Lng.FormattedElem("Successfully saved {0}", 0, Character.Name)).ConfigureAwait(true);
    }

    [RelayCommand]
    public void GenerateNewName()
    {
        Character?.Name = NameGenerator.Get(Character.Race).ToName();
        MarkDirty();
    }

    [RelayCommand()]
    public Task BackAsync()
    {
        return ShellNavigationService.GoBackAsync();
    }

    public void MarkDirty()
    {
        if (!IsDirty)
        {
            IsDirty = true;
        }
    }

    public void MarkClean()
    {
        IsDirty = false;
    }

    private void LoadAvailableTypes()
    {
        AvailableRaces.Clear();
        AvailableClasses.Clear();

        foreach (var race in PreloadService.Instance.Races)
        {
            AvailableRaces.Add(race);
        }

        foreach (var cls in PreloadService.Instance.Classes)
        {
            AvailableClasses.Add(cls);
        }
    }

    private static IClass? InstanceClass(Type classType, int level, bool autoGenerateSkills)
    {
        try
        {
            if (Activator.CreateInstance(classType, level, autoGenerateSkills) is IClass instanceClass)
            {
                return instanceClass;
            }
        }
        catch (TargetInvocationException ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }

        return null;
    }
}
