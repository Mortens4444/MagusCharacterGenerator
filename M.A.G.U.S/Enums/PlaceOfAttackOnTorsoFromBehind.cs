using M.A.G.U.S.Races;
using System;
using System.ComponentModel;

namespace M.A.G.U.S.Enums;

[Flags]
public enum PlaceOfAttackOnTorso
{
    None = 0,
    [Description("Right collarbone")]
    RightCollarbone = 1 << 0,
    [Description("Left collarbone")]
    LeftCollarbone = 1 << 1,
    Sternum = 1 << 2,
    [Description("Left side of chest")]
    LeftSideOfChest = 1 << 3,
    [Description("Right side of chest")]
    RightSideOfChest = 1 << 4,
    [Description("Solar plexus")]
    SolarPlexus = 1 << 5,
    Groin = 1 << 6,
    [Description("Right side of abdomen")]
    RightSideOfAbdomen = 1 << 7,
    [Description("Left side of abdomen")]
    LeftSideOfAbdomen = 1 << 8,

    Everywhere = RightCollarbone | LeftCollarbone | Sternum | LeftSideOfChest | RightSideOfChest | SolarPlexus | Groin | RightSideOfAbdomen | LeftSideOfAbdomen
}
