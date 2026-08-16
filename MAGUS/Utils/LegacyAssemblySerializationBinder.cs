using Newtonsoft.Json.Serialization;

namespace MAGUS.Utils;

/// <summary>
/// Resolves $type references saved before the "M.A.G.U.S." / "M.A.G.U.S.Assistant" projects
/// were renamed to "MAGUS" / "MAGUS.Assistant", so old saved characters/drawings can still load.
/// </summary>
public class LegacyAssemblySerializationBinder : DefaultSerializationBinder
{
    public override Type BindToType(string? assemblyName, string typeName)
    {
        // The old core project file was literally "M.A.G.U.S.csproj" (note the trailing dot),
        // so the substring replace below leaves a stray "." that must be trimmed off.
        var mappedAssemblyName = assemblyName?.Replace("M.A.G.U.S", "MAGUS", StringComparison.Ordinal).TrimEnd('.');
        var mappedTypeName = typeName.Replace("M.A.G.U.S", "MAGUS", StringComparison.Ordinal);
        return base.BindToType(mappedAssemblyName, mappedTypeName);
    }
}
