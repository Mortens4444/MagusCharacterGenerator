using System.ComponentModel;

namespace M.A.G.U.S.Enums;

[Flags]
public enum PlaceOfAttackOnHead
{
    None = 0,
    Skull = 1 << 0,
    Forehead = 1 << 1,
    Temple = 1 << 2,
    Face = 1 << 3,
    [Description("Neck / nape")]
    NeckOrNape = 1 << 4,
    
    EveryWhere = Skull | Forehead | Temple | NeckOrNape | Face
}
