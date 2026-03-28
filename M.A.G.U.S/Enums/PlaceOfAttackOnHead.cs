using System.ComponentModel;

namespace M.A.G.U.S.Enums;

[Flags]
public enum PlaceOfAttackOnHead
{
    [Description("None")]
    None = 0,

    [Description("Skull")]
    Skull = 1 << 0,

    [Description("Forehead")]
    Forehead = 1 << 1,

    [Description("Temple")]
    Temple = 1 << 2,

    [Description("Face")]
    Face = 1 << 3,

    [Description("Neck / nape")]
    NeckOrNape = 1 << 4,

    [Description("Everywhere")]
    Everywhere = Skull | Forehead | Temple | NeckOrNape | Face
}
