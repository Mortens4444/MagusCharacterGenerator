using M.A.G.U.S.GameSystem.Languages;

namespace M.A.G.U.S.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class OfficialLanguageAttribute(Language officialLanguage) : Attribute
{
    public Language OfficialLanguage { get; init; } = officialLanguage;
}
