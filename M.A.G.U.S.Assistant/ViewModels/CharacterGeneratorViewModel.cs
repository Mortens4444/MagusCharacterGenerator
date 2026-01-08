using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.Assistant.Views;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Versioning;

namespace M.A.G.U.S.Assistant.ViewModels;

[SupportedOSPlatform("windows10.0.17763.0")]
internal partial class CharacterGeneratorViewModel : CharacterViewModel
{
    private readonly SettingsService settingsService;
    private readonly CharacterService characterService;
    private readonly ISoundPlayer soundPlayer;
    private readonly IShakeService shakeService;

    private int baseClassLevel = 1;

    public CharacterGeneratorViewModel(SettingsService settingsService, CharacterService characterService, ISoundPlayer soundPlayer, IShakeService shakeService)
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

    public int BaseClassLevel
    {
        get => baseClassLevel;
        set
        {
            SetProperty(ref baseClassLevel, value);
        }
    }

    private IRace? selectedRace;
    public IRace? SelectedRace
    {
        get => selectedRace;
        set
        {
            SetProperty(ref selectedRace, value);
        }
    }

    private IClass? selectedClass;
    public IClass? SelectedClass
    {
        get => selectedClass;
        set
        {
            SetProperty(ref selectedClass, value);
        }
    }

    [RelayCommand]
    public async Task GenerateCharacter()
    {
        if (selectedRace == null)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage("No race selected!"));
            return;
        }

        if (selectedClass == null)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage("No class selected!"));
            return;
        }

        try
        {
            var classType = selectedClass.GetType();
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
                    var rollFormula = new Models.RollFormula(propertyInfo, $"{Lng.Elem("Create character")} - {propertyInfo?.Name}");
                    var page = new RollFormulaPage(soundPlayer, shakeService, rollFormula);
                    await ShellNavigationService.ShowPage(page).ConfigureAwait(true);
                    var result = await page.ResultTask.ConfigureAwait(true);
                    propertyInfo!.SetValue(instanceClass, result);
                }
            }

            Character = new Character(settingsService, NameGenerator.Get(selectedRace), selectedRace, instanceClass);
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
        WeakReferenceMessenger.Default.Send(new ShowInfoMessage("Character saved", String.Format("Successfully saved {0}", Character.Name)));
    }

    [RelayCommand]
    public void GenerateNewName()
    {
        if (Character != null)
        {
            Character.Name = NameGenerator.Get(Character.Race).ToName();
        }
    }

    private void LoadAvailableTypes()
    {
        var raceNamespacePrefix = "M.A.G.U.S.Races";
        var classNamespacePrefix = "M.A.G.U.S.Classes";

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var asm in assemblies)
        {
            foreach (var t in GetLoadableTypes(asm))
            {
                if (t == null || !t.IsClass || t.IsAbstract)
                {
                    continue;
                }

                // Races
                if (!String.IsNullOrEmpty(t.Namespace) && t.Namespace.StartsWith(raceNamespacePrefix, StringComparison.Ordinal))
                {
                    if (typeof(IRace).IsAssignableFrom(t))
                    {
                        try
                        {
                            if (Activator.CreateInstance(t) is IRace instRace)
                            {
                                AvailableRaces.Add(instRace);
                            }
                        }
                        catch (Exception ex)
                        {
                            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
                        }
                    }
                }

                // Classes
                if (!String.IsNullOrEmpty(t.Namespace) && t.Namespace.StartsWith(classNamespacePrefix, StringComparison.Ordinal))
                {
                    if (typeof(IClass).IsAssignableFrom(t))
                    {
                        try
                        {
                            var instanceClass = InstanceClass(t);
                            if (instanceClass != null)
                            {
                                AvailableClasses.Add(instanceClass);
                            }
                        }
                        catch (Exception ex)
                        {
                            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
                        }
                    }
                }
            }
        }

        var sortedRaces = AvailableRaces.OrderBy(r => Lng.Elem(r.Name)).ToArray();
        AvailableRaces.Clear();
        foreach (var r in sortedRaces)
        {
            AvailableRaces.Add(r);
        }

        var sortedClasses = AvailableClasses.OrderBy(c => Lng.Elem(c.Name)).ToArray();
        AvailableClasses.Clear();
        foreach (var c in sortedClasses)
        {
            AvailableClasses.Add(c);
        }
    }

    private static IClass? InstanceClass(Type classType)
    {
        try
        {
            if (Activator.CreateInstance(classType) is IClass instanceClass)
            {
                return instanceClass;
            }
        }
        catch (TargetInvocationException ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.InnerException ?? ex));
        }

        return null;
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
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.InnerException ?? ex));
        }

        return null;
    }

    private static Type[] GetLoadableTypes(Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException e)
        {
            return [.. e.Types.Where(static t => t != null)];
        }
        catch
        {
            return [];
        }
    }
}
