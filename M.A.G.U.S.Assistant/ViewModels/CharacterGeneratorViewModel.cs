using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Messages;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Races;
using M.A.G.U.S.Utils;
using Mtf.LanguageService;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Versioning;

namespace M.A.G.U.S.Assistant.ViewModels;

[SupportedOSPlatform("windows10.0.17763.0")]
internal partial class CharacterGeneratorViewModel : ObservableObject
{
    private readonly SettingsService settingsService;
    private readonly CharacterService characterService;

    private Character character;
    private byte baseClassLevel = 1;

    public CharacterGeneratorViewModel(SettingsService settingsService, CharacterService characterService)
    {
        this.settingsService = settingsService;
        this.characterService = characterService;
        character = new Character(settingsService);

        LoadAvailableTypes();
        SelectedRace = AvailableRaces.FirstOrDefault();
        SelectedClass = AvailableClasses.FirstOrDefault();
    }

    public ObservableCollection<IRace?> AvailableRaces { get; } = [];

    public ObservableCollection<IClass?> AvailableClasses { get; } = [];

    public byte BaseClassLevel
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

    public Character Character
    {
        get => character;
        set => SetProperty(ref character, value);
    }

    [RelayCommand]
    public void GenerateCharacter()
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

        var instanceClass = InstanceClass(selectedClass.GetType(), baseClassLevel);
        if (instanceClass == null)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage("Class cannot be instantiated!"));
            return;
        }

        try
        {
            Character = new Character(settingsService, NameGenerator.Get(selectedRace), selectedRace, instanceClass);
            Character.LevelUp();
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    [RelayCommand]
    public void SaveCharacter()
    {
        characterService.SaveAsync(Character);
        WeakReferenceMessenger.Default.Send(new ShowInfoMessage("Character saved", String.Format("Successfully saved {0}", Character.Name)));
    }

    [RelayCommand]
    public void GenerateNewName()
    {
        if (Character == null)
        {
            GenerateCharacter();
        }
        Character.Name = NameGenerator.Get(Character.Race).ToName();
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
                            var instanceClass = InstanceClass(t, 1);
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

    private static IClass? InstanceClass(Type classType, byte level)
    {
        if (Activator.CreateInstance(classType, level) is IClass instanceClass)
        {
            return instanceClass;
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
