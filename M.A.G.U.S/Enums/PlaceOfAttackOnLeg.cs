namespace M.A.G.U.S.Enums;

[Flags]
public enum PlaceOfAttackOnLeg
{
    None = 0,
    Thigh = 1 << 0,
    Knee = 1 << 1,
    Ankle = 1 << 2,
    Shin = 1 << 3,
    Foot = 1 << 4,

    Everywhere = Thigh | Knee | Shin | Ankle | Foot
}
