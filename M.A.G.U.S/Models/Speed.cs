using M.A.G.U.S.Enums;

namespace M.A.G.U.S.Models;

public class Speed
{
    public Speed(TravelMode travelMode = TravelMode.OnLand, int? value = null, string description = "")
    {
        TravelMode = travelMode;
        Description = description;
        Value = value;
    }

    public TravelMode TravelMode { get; set; }

    public string Description { get; set; }

    public int? Value { get; set; }
}
