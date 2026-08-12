using MAGUS.Enums;

namespace MAGUS.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class OfficialReligionAttribute(Deity deity) : Attribute
{
    public Deity Deity { get; init; } = deity;
}
