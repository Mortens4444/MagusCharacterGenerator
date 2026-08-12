using MAGUS.Enums;

namespace MAGUS.Models;

public class Speed
{
    public Speed(TravelMode travelMode = TravelMode.OnLand, int? value = null, string description = "", SpeedLevel speedLevel = SpeedLevel.Fastest)
    {
        TravelMode = travelMode;
        SpeedLevel = speedLevel;
        Description = description;
        Value = value;
    }

    public TravelMode TravelMode { get; set; }

    public SpeedLevel SpeedLevel { get; set; }

    public string Description { get; set; }

    public int? Value { get; set; }
}
