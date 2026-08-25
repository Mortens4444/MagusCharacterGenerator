namespace MAGUS.GameSystem;

public partial class Character
{
    /// <summary>
    /// 100 = just fed, 0 = starving. Decays over real elapsed time (see ApplyElapsedHungerDecay,
    /// driven from LastHungerTickUtc) rather than a live timer, so it keeps moving whether or not
    /// any background service is running - GameEventService.ApplyHungerTickAsync layers threshold
    /// warnings and (below CriticalHungerThreshold) Fájdalomtűrés/HP damage on top of this.
    /// </summary>
    public double HungerPercent { get; set; } = 100;

    /// <summary>When hunger decay was last applied - see ApplyElapsedHungerDecay.</summary>
    public DateTime LastHungerTickUtc { get; set; } = DateTime.UtcNow;

    private const double HungerDecayPercentPerHour = 100.0 / 8; // 0% (fully starving) after 8 hours without food

    /// <summary>
    /// Applies hunger decay for however much real time has passed since LastHungerTickUtc, then
    /// advances the checkpoint to now. Safe to call as often as convenient (e.g. whenever a
    /// character is loaded) - a second call right after a first is a no-op since no time has passed.
    /// </summary>
    public void ApplyElapsedHungerDecay()
    {
        var now = DateTime.UtcNow;
        var elapsedHours = (now - LastHungerTickUtc).TotalHours;
        if (elapsedHours <= 0)
        {
            return;
        }

        HungerPercent = Math.Max(0, HungerPercent - (elapsedHours * HungerDecayPercentPerHour));
        LastHungerTickUtc = now;
    }
}
