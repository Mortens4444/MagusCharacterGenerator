using Mtf.Extensions.Services;

namespace M.A.G.U.S.Assistant.Services;

internal static class EnemyProvider
{
    public static T? PickWeightedRandom<T>(IReadOnlyCollection<T> items, Func<T, int> weightSelector)
    {
        if (items == null || items.Count == 0)
        {
            return default;
        }
        
        var snapshot = items.ToList();

        var weightedItems = snapshot
            .Select(i => new { Item = i, Weight = weightSelector(i) })
            .Where(x => x.Weight > 0)
            .ToList();

        if (weightedItems.Count == 0)
        {
            return default;
        }

        var totalWeight = weightedItems.Sum(x => x.Weight);
        var roll = RandomProvider.GetSecureRandomInt(0, totalWeight);

        var cumulative = 0;

        foreach (var item in weightedItems)
        {
            cumulative += item.Weight;
            if (roll < cumulative)
            {
                return item.Item;
            }
        }

        return default;
    }
}
