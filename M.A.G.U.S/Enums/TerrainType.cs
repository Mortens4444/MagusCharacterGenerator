namespace M.A.G.U.S.Enums;

[Flags]
public enum TerrainType
{
    None = 0,
    Plains = 1 << 0,
    Forest = 1 << 1,
    Hills = 1 << 2,
    Mountains = 1 << 3,
    Swamp = 1 << 4,
    Desert = 1 << 5,
    Urban = 1 << 6,
    Underground = 1 << 7,
    Water = 1 << 8
}