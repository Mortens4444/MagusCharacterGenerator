using System.Text.Json.Serialization;

namespace MAGUS.GameSystem.Turn;

/// <summary>A lingering effect (e.g. a curse) that keeps ticking on its target for a number of rounds after a successful mystic attack.</summary>
public sealed class ActiveEffect(string name, Func<int> getTickDamage, bool isHpDamage, int remainingRounds)
{
    public string Name { get; } = name;

    /// <summary>
    /// Re-rolls the tick's damage (e.g. the attack's own dice formula) each time it's called, rather
    /// than a fixed pre-rolled amount - not serializable (it closes over the originating attack), so
    /// it's excluded from persistence. A character saved (and later reloaded) with an active effect
    /// keeps the effect's Name/IsHpDamage/RemainingRounds, but this delegate comes back null - see
    /// CombatEngine.TickActiveEffects, which drops any effect it finds in that state instead of
    /// dereferencing it.
    /// </summary>
    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public Func<int> GetTickDamage { get; } = getTickDamage;

    public bool IsHpDamage { get; } = isHpDamage;

    public int RemainingRounds { get; set; } = remainingRounds;
}
