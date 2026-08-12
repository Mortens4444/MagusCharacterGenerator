using System.ComponentModel;

namespace MAGUS.Enums;

public enum TravelMode
{
    [Description("On land")]
    OnLand,

    [Description("In the air")]
    InTheAir,

    [Description("In water")]
    InWater,

    [Description("On walls")]
    OnWalls,

    [Description("Underground")]
    Underground
}
