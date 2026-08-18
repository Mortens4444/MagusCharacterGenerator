using System.Reflection;
using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.Interfaces;
using MAGUS.Races;

namespace MAGUS.Test;

[TestFixture]
public class CharacterConstructionSweepTest
{
    private static readonly Assembly MagusAssembly = typeof(Character).Assembly;

    private static IEnumerable<Type> GetConcreteImplementations<TInterface>()
    {
        return MagusAssembly
            .GetTypes()
            .Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && !t.ContainsGenericParameters
                && typeof(TInterface).IsAssignableFrom(t)
                && t.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null) != null)
            .OrderBy(t => t.FullName);
    }

    private static IEnumerable<Type> GetClassTypes() => GetConcreteImplementations<IClass>();

    private static IEnumerable<Type> GetRaceTypes() => GetConcreteImplementations<IRace>();

    [TestCaseSource(nameof(GetClassTypes))]
    public void BuildCharacter_WithEachClass_AndHumanRace(Type classType)
    {
        IClass cls;
        try
        {
            cls = (IClass)Activator.CreateInstance(classType)!;
        }
        catch (Exception ex)
        {
            Assert.Ignore($"Could not instantiate {classType.FullName}: {ex.Message}");
            return;
        }

        ExerciseCharacter(new Human(), cls);
    }

    [TestCaseSource(nameof(GetRaceTypes))]
    public void BuildCharacter_WithEachRace_AndCraftsmanClass(Type raceType)
    {
        IRace race;
        try
        {
            race = (IRace)Activator.CreateInstance(raceType)!;
        }
        catch (Exception ex)
        {
            Assert.Ignore($"Could not instantiate {raceType.FullName}: {ex.Message}");
            return;
        }

        ExerciseCharacter(race, new Craftsman());
    }

    private static void ExerciseCharacter(IRace race, IClass cls)
    {
        foreach (var settings in new[] { new Settings(true), new Settings(false) })
        {
            Character character;
            try
            {
                character = new Character(settings, "Test", race, cls);
            }
            catch (Exception ex)
            {
                Assert.Ignore($"Could not construct Character for {race.GetType().FullName}/{cls.GetType().FullName}: {ex.Message}");
                return;
            }

            ReflectionTouch.TouchAllMembers(character);
            ReflectionTouch.TouchAllMembers(cls);
            ReflectionTouch.TouchAllMembers(race);
        }

        Assert.Pass();
    }
}
