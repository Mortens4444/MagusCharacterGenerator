using MAGUS.Enums;

namespace MAGUS.Extensions;

public static class OccurrenceExtensions
{
    public static int GetWeight(this Occurrence occurrence)
    {
        return occurrence switch
        {
            Occurrence.Frequent => 80,
            Occurrence.Rare => 15,
            Occurrence.VeryRare => 5,
            _ => 0
        };
    }
}
