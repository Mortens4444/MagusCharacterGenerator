using MAGUS.GameSystem.Attributes;

namespace MAGUS.Enums;

public enum WeatherCondition
{
    [DefenseHelper(0)]
    Clear,

    [DefenseHelper(10)]
    LightRain,

    [DefenseHelper(30)]
    Rain,

    [DefenseHelper(50)]
    FogOrStrongWind,

    [DefenseHelper(70)]
    HeavyFogOrStorm,

    [DefenseHelper(100)]
    Hurricane
}