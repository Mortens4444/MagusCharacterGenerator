using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.Views;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;
using System.Collections.ObjectModel;
using System.Reflection;
namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class CharacterGeneratorViewModel : CharacterViewModel
{
    private readonly SettingsService settingsService;
    private readonly CharacterService characterService;
    private readonly ISoundPlayer soundPlayer;
    private readonly IShakeService shakeService;

    private int baseClassLevel = 1;

    public CharacterGeneratorViewModel(SettingsService settingsService, CharacterService characterService, ISoundPlayer soundPlayer, IShakeService shakeService, IPrintService printService)
         : base(printService)
    {
        this.settingsService = settingsService;
        this.characterService = characterService;
        this.soundPlayer = soundPlayer;
        this.shakeService = shakeService;
        Character = new Character(settingsService);

        LoadAvailableTypes();
        SelectedRace = AvailableRaces.FirstOrDefault();
        SelectedClass = AvailableClasses.FirstOrDefault();
    }

    public ObservableCollection<IRace?> AvailableRaces { get; } = [];

    public ObservableCollection<IClass?> AvailableClasses { get; } = [];

    public int BaseClassLevel { get => baseClassLevel; set => SetProperty(ref baseClassLevel, value); }

    private IRace? selectedRace;
    public IRace? SelectedRace { get => selectedRace; set => SetProperty(ref selectedRace, value); }

    private IClass? selectedClass;
    public IClass? SelectedClass { get => selectedClass; set => SetProperty(ref selectedClass, value); }

    private bool isDirty;

    public bool IsDirty
    {
        get => isDirty;
        private set => SetProperty(ref isDirty, value);
    }


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
            var instanceClass = InstanceClass(classType, BaseClassLevel, settingsService.AutoGenerateSkills);
            if (instanceClass == null)
            {
                //WeakReferenceMessenger.Default.Send(new ShowErrorMessage("Class cannot be instantiated!"));
                return;
            }
    
            if (!settingsService.AutoGenerateSkills)
            {
                string[] skillNames = [ nameof(instanceClass.Strength), nameof(instanceClass.Stamina), nameof(instanceClass.Quickness), nameof(instanceClass.Dexterity), nameof(instanceClass.Health), nameof(instanceClass.Beauty),
                    nameof(instanceClass.Intelligence), nameof(instanceClass.Willpower), nameof(instanceClass.Astral), nameof(instanceClass.Bravery), nameof(instanceClass.Erudition), nameof(instanceClass.Detection), nameof(instanceClass.Gold) ];

                var skillProperties = skillNames.Select(n => classType.GetProperty(n))
                    .OrderBy(pi => pi?.GetCustomAttribute<OrderAttibute>()?.Number ?? 0).ToList();

                foreach (var propertyInfo in skillProperties)
                {
                    var rollFormula = new RollFormula(propertyInfo, $"{Lng.Elem("Create character")} - {Lng.Elem(propertyInfo!.Name)}");
                    var page = new RollFormulaPage(soundPlayer, shakeService, rollFormula);
                    await ShellNavigationService.ShowPageAsync(page).ConfigureAwait(true);
                    var result = await page.ResultTask.ConfigureAwait(true);
                    propertyInfo!.SetValue(instanceClass, result);
                }
            }
            Character = new Character(settingsService, NameGenerator.Get(selectedRace), selectedRace, instanceClass);
            MarkDirty();
            if (!settingsService.AutoIncreasePainTolerance)
            {
                var formula = Character?.BaseClass.GetPainToleranceModifierFormula();
                for (var level = Level; level <= Level; level++)
                {
                    var page = new RollFormulaPage(soundPlayer, shakeService, formula, $"{Lng.Elem("Create character")} - {Lng.Elem("PTP")} ({level}. {Lng.Elem("Level")})");
                    await ShellNavigationService.ShowPageAsync(page).ConfigureAwait(true);
                    var result = await page.ResultTask.ConfigureAwait(true);
                    Character.MaxPainTolerancePoints += result;
                }
            }
            if (settingsService.AutoDistributeQualificationPoints)
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
        await characterService.SaveAsync(Character).ConfigureAwait(false);
        MarkClean();
        WeakReferenceMessenger.Default.Send(new ShowInfoMessage("Character saved", String.Format("Successfully saved {0}", Character.Name)));
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
