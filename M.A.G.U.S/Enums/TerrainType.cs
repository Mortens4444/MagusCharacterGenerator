using System.ComponentModel;

namespace M.A.G.U.S.Enums;

[Flags]
public enum TerrainType : ulong
{
    [Description("Unknown")]
    Unknown = 0,

    [Description("Plains")]
    Plains = 1UL << 0,

    [Description("Jungle")]
    Jungle = 1UL << 1,

    [Description("Hills")]
    Hills = 1UL << 2,

    [Description("Mountains")]
    Mountains = 1UL << 3,

    [Description("Swamp")]
    Swamp = 1UL << 4,

    [Description("Desert")]
    Desert = 1UL << 5,

    [Description("Urban")]
    Urban = 1UL << 6,

    [Description("Water")]
    Water = 1UL << 7,

    [Description("Crevice")]
    Crevice = 1UL << 8,

    [Description("Tunnels")]
    Tunnels = 1UL << 9,

    [Description("Borderlands")]
    Borderlands = 1UL << 10,

    [Description("Riverbank")]
    Riverbank = 1UL << 11,

    [Description("Stronghold")]
    Stronghold = 1UL << 12,

    [Description("Cave")]
    Cave = 1UL << 13,

    [Description("Underground")]
    Underground = 1UL << 14,

    [Description("Arctic forest")]
    ArcticForest = 1UL << 15,

    [Description("Temperate forest")]
    TemperateForest = 1UL << 16,

    [Description("Austral cold region")]
    AustralColdRegion = 1UL << 17,

    [Description("Tropical river")]
    TropicalRiver = 1UL << 18,

    [Description("Tropical forest")]
    TropicalForest = 1UL << 19,

    [Description("Ice field")]
    Icefield = 1UL << 20,

    [Description("Abbit mines")]
    AbbitMines = 1UL << 21,

    [Description("Iron ore mines")]
    IronOreMines = 1UL << 22,

    [Description("Coal mines")]
    CoalMines = 1UL << 23,

    [Description("Gold mines")]
    GoldMines = 1UL << 24,

    [Description("Copper mines")]
    CopperMines = 1UL << 25,

    [Description("Silver mines")]
    SilverMines = 1UL << 26,

    [Description("Gemstone mines")]
    GemstoneMines = 1UL << 27,
    
    [Description("Cursed Land")]
    CursedLand = 1UL << 28,

    [Description("Inner Hall")]
    InnerHall = 1UL << 29,

    [Description("Volcanic shaft")]
    VolcanicShaft = 1UL << 30,

    [Description("Subterranean river")]
    SubterraneanRiver = 1UL << 31,

    [Description("Inner chamber")]
    InnerChamber = 1UL << 32,

    [Description("Coastal barren")]
    CoastalBarren = 1UL << 33,

    [Description("Coastal island")]
    CoastalIsland = 1UL << 34,

    [Description("Old, dilapidated building")]
    OldDilapidatedBuilding = 1UL << 35,

    [Description("Tree hollow")]
    TreeHollow = 1UL << 36,

    [Description("Southern snowfield")]
    SouthernSnowfield = 1UL << 37,

    [Description("Northern snowfield")]
    NorthernSnowfield = 1UL << 38,

    [Description("Grassland")]
    Grassland = 1UL << 39,

    [Description("Savanna")]
    Savanna = 1UL << 40,

    [Description("Volcano")]
    Volcano = 1UL << 41,

    [Description("Lava lake")]
    LavaLake = 1UL << 42,

    [Description("Geyser")]
    Geyser = 1UL << 43,

    [Description("Catacombs")]
    Catacombs = 1UL << 44,

    [Description("Sewer")]
    Sewer = 1UL << 45,

    [Description("Snowfield")]
    Snowfield = SouthernSnowfield | NorthernSnowfield,

    [Description("Deep underground")]
    DeepUnderground = Underground | Cave | Crevice | InnerHall | InnerChamber | VolcanicShaft | SubterraneanRiver,

    [Description("Forest")]
    Forest = ArcticForest | TemperateForest | TropicalForest,

    [Description("Mines")]
    Mines = AbbitMines | IronOreMines | CoalMines | GoldMines | CopperMines | SilverMines | GemstoneMines,

    [Description("Anywhere")]
    Anywhere = 1UL << 62
}