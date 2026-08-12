using MAGUS.GameSystem.Languages;

namespace MAGUS.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class OfficialLanguageAttribute(Language officialLanguage) : Attribute
{
    public Language OfficialLanguage { get; init; } = officialLanguage;
}
