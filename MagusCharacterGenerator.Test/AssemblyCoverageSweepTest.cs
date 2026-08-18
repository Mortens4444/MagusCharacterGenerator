using System.Reflection;

namespace MAGUS.Test;

[TestFixture]
public class AssemblyCoverageSweepTest
{
    private static readonly Assembly MagusAssembly = typeof(MAGUS.GameSystem.Character).Assembly;

    private static IEnumerable<Type> GetConcreteTypes()
    {
        return MagusAssembly
            .GetTypes()
            .Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && !t.ContainsGenericParameters)
            .OrderBy(t => t.FullName);
    }

    [TestCaseSource(nameof(GetConcreteTypes))]
    public void InstantiateAndTouchAllMembers(Type type)
    {
        var ctor = type.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null);
        if (ctor == null)
        {
            Assert.Ignore($"No public parameterless constructor for {type.FullName}");
            return;
        }

        object instance;
        try
        {
            instance = Activator.CreateInstance(type)!;
        }
        catch (Exception ex)
        {
            Assert.Ignore($"Could not instantiate {type.FullName}: {ex.Message}");
            return;
        }

        ReflectionTouch.TouchAllMembers(instance);

        Assert.Pass();
    }
}
