namespace MAGUS.GameSystem.Attributes;

/// <summary>Fixed daily travel distance in miles for a non-Walking TravelMode. See Places/TravelMode.cs.</summary>
[AttributeUsage(AttributeTargets.Field)]
public class DailyMilesAttribute(double dailyMiles) : Attribute
{
    public double DailyMiles { get; } = dailyMiles;
}
