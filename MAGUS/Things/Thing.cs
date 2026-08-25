using MAGUS.GameSystem.Valuables;
using MAGUS.Models;

namespace MAGUS.Things;

public abstract class Thing : ImageOwner
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public virtual Money Price => new(1);

    public double PriceMultiplier { get; set; } = 1;

    public virtual Money MultipliedPrice => Price * PriceMultiplier;

    public virtual string Description => "";

    /// <summary>
    /// Hunger percentage points restored when eaten (see CharacterCareActions.EatAsync). Meaningful
    /// only for items in the MAGUS.Things.Food namespace (see ThingExtensions.IsFood); 0 for everything else.
    /// Split across PortionCount servings - each Eat gives HungerValue / PortionCount and consumes
    /// one portion, rather than the whole item at once (nobody eats a dozen eggs or a kilo of
    /// butter in one sitting).
    /// </summary>
    public virtual int HungerValue => 0;

    /// <summary>
    /// How many separate servings this item provides before it's used up. 1 (the default) means it's
    /// eaten whole in a single Eat action, as before; override for bulk items like a dozen eggs or a
    /// kilo of butter that realistically last several meals.
    /// </summary>
    public virtual int PortionCount => 1;

    /// <summary>
    /// True for an item that fully restores ActualHealthPoints/ActualPainTolerancePoints when used on
    /// a target (see Character.Revive and CharacterCareActions.UseHealingItemAsync). Meaningful only
    /// for items in the MAGUS.Things.MagicalObjects namespace (see ThingExtensions.IsHealingItem);
    /// false for everything else.
    /// </summary>
    public virtual bool HealsFully => false;

    /// <summary>
    /// True for an item that can bring a dead target back (see Character.Revive), in addition to
    /// whatever healing HealsFully already grants. Meaningful only alongside HealsFully; false for
    /// everything else.
    /// </summary>
    public virtual bool Resurrects => false;

    private int? remainingPortions;

    /// <summary>Portions left before this item is fully consumed and removed from Equipment - see CharacterCareActions.EatAsync.</summary>
    public int RemainingPortions
    {
        get => remainingPortions ??= PortionCount;
        set => remainingPortions = value;
    }

    /// <summary>
    /// Full weight in kilograms, as a fresh/unconsumed item - a catalog/shop figure. For the actual
    /// weight still being carried (which shrinks as a portioned item like a kilo of butter gets eaten
    /// down), see EffectiveWeight.
    /// Use double for performance; switch to decimal if you need exact decimal arithmetic.
    /// </summary>
    public virtual double Weight { get; protected set; } = 0.0;

    /// <summary>
    /// Current carried weight in kilograms: Weight scaled down by how much of the item is left
    /// (RemainingPortions out of PortionCount) - a half-eaten kilo of butter weighs about half a
    /// kilo. Items with PortionCount == 1 (the overwhelming majority - weapons, armor, single-serving
    /// food, ...) have nothing partial to subtract, so this is just Weight for them.
    /// </summary>
    public double EffectiveWeight => PortionCount <= 1 ? Weight : Weight * RemainingPortions / PortionCount;
}
