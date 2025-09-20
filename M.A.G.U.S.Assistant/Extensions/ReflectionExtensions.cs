using System.Reflection;

namespace M.A.G.U.S.Assistant.Extensions;

public static class ReflectionExtensions
{
    public static List<T> CreateInstancesFromNamespace<T>(this string @namespace)
        where T : class
    {
        var result = new List<T>();

        if (String.IsNullOrWhiteSpace(@namespace))
        {
            return result;
        }

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var asm in assemblies)
        {
            Type[] types;
            try
            {
                types = asm.GetTypes();
            }
            catch (ReflectionTypeLoadException rex)
            {
                // ha betöltési hiba volt, vegyük az elérhető típusokat
                types = rex.Types.Where(t => t != null).ToArray();
            }

            foreach (var type in types)
            {
                if (type == null) continue;
                if (!type.IsClass) continue;
                if (type.IsAbstract) continue;
                if (type.Namespace == null) continue;

                // névtér egyezés: kezdődik az adott névtérrel (így az alkönyvtárakat is befogja)
                if (!type.Namespace.StartsWith(@namespace, StringComparison.Ordinal)) continue;

                // csak ha hozzárendelhető T-hez
                if (!typeof(T).IsAssignableFrom(type)) continue;

                // kell parameterless ctor
                if (type.GetConstructor(Type.EmptyTypes) == null) continue;

                try
                {
                    var obj = Activator.CreateInstance(type) as T;
                    if (obj != null) result.Add(obj);
                }
                catch
                {
                    // ha példányosítás közben baj van, kihagyjuk (seed-ben nem szabad törnie)
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Overload: egy konkrét assembly-ben keresi a névteret.
    /// </summary>
    public static List<T> CreateInstancesFromNamespace<T>(this Assembly assembly, string @namespace)
        where T : class
    {
        if (assembly == null) throw new ArgumentNullException(nameof(assembly));
        var result = new List<T>();

        var types = new Type[0];
        try { types = assembly.GetTypes(); }
        catch (ReflectionTypeLoadException rex) { types = rex.Types.Where(t => t != null).ToArray(); }

        foreach (var type in types)
        {
            if (type == null) continue;
            if (!type.IsClass || type.IsAbstract) continue;
            if (type.Namespace == null) continue;
            if (!type.Namespace.StartsWith(@namespace, StringComparison.Ordinal)) continue;
            if (!typeof(T).IsAssignableFrom(type)) continue;
            if (type.GetConstructor(Type.EmptyTypes) == null) continue;

            try
            {
                var obj = Activator.CreateInstance(type) as T;
                if (obj != null) result.Add(obj);
            }
            catch { }
        }

        return result;
    }
}
