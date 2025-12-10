using M.A.G.U.S.Enums;

namespace M.A.G.U.S.GameSystem.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class OfficialReligionAttribute(Deity deity) : Attribute
{
    public Deity Deity { get; init; } = deity;
}
