using System.Text.Json.Serialization;

namespace MAGUS.GameSystem;

public partial class Character
{
    /// <summary>
    /// 100 = well-rested, 0 = exhausted. Decays over real elapsed time (see ApplyElapsedSleepDecay,
    /// driven from LastSleepTickUtc) rather than a live timer, so it keeps moving whether or not any
    /// background service is running - more slowly than HungerPercent, since a character needs to
    /// sleep less often than they need to eat. GameEventService.ApplySleepTickAsync layers threshold
    /// warnings and (below the same critical threshold hunger uses) Fájdalomtűrés/HP damage on top.
    /// </summary>
    public double SleepPercent { get; set; } = 100;

    /// <summary>When sleep decay was last applied - see ApplyElapsedSleepDecay.</summary>
    public DateTime LastSleepTickUtc { get; set; } = DateTime.UtcNow;

    private const double SleepDecayPercentPerHour = 100.0 / 16; // 0% (exhausted) after 16 hours without sleep

    /// <summary>When the current sleep action started, in UTC. Null when not sleeping - see IsSleeping/CompleteSleepIfFinished.</summary>
    public DateTime? SleepStartUtc { get; set; }

    /// <summary>How many real hours the current sleep action takes to resolve - set once, at the moment sleep starts (CharacterCareActions.SleepAsync).</summary>
    public double SleepDurationHours { get; set; }

    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public bool IsSleeping => SleepStartUtc.HasValue;

    /// <summary>0 (just lay down) to 1 (woken up), based on how much of SleepDurationHours has elapsed in real time since SleepStartUtc.</summary>
    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public double SleepProgress
    {
        get
        {
            if (SleepStartUtc is not { } start || SleepDurationHours <= 0)
            {
                return 0;
            }

            var elapsedHours = (DateTime.UtcNow - start).TotalHours;
            return Math.Clamp(elapsedHours / SleepDurationHours, 0, 1);
        }
    }

    /// <summary>
    /// How many real hours have passed since SleepStartUtc, capped at SleepDurationHours (never more
    /// than what was actually planned/possible to sleep) - used to prorate restoration when a sleep
    /// is cut short before finishing naturally, whether by the player (CharacterViewModel.StopSleep)
    /// or by hunger becoming critical mid-sleep (CharacterViewModel.InterruptSleep). 0 when not
    /// currently sleeping.
    /// </summary>
    [JsonIgnore, Newtonsoft.Json.JsonIgnore]
    public double ElapsedSleepHours => SleepStartUtc is { } start
        ? Math.Min((DateTime.UtcNow - start).TotalHours, SleepDurationHours)
        : 0;

    /// <summary>
    /// Applies sleep decay for however much real time has passed since LastSleepTickUtc, then
    /// advances the checkpoint to now. Safe to call as often as convenient (e.g. whenever a
    /// character is loaded) - a second call right after a first is a no-op since no time has passed.
    /// Has no effect while IsSleeping - the character is actively resting, not growing more tired.
    /// </summary>
    public void ApplyElapsedSleepDecay()
    {
        if (IsSleeping)
        {
            return;
        }

        var now = DateTime.UtcNow;
        var elapsedHours = (now - LastSleepTickUtc).TotalHours;
        if (elapsedHours <= 0)
        {
            return;
        }

        SleepPercent = Math.Max(0, SleepPercent - (elapsedHours * SleepDecayPercentPerHour));
        LastSleepTickUtc = now;
    }

    /// <summary>
    /// Clears the sleep state once CharacterViewModel.CompleteSleep has finished applying the
    /// wake-up restoration (HP/PRP/Mana/Psi) - that math needs the settings-configured per-hour
    /// rates, which live at the Assistant layer (a deserialized Character's own settings reference is
    /// always null, unlike a freshly-generated one), so unlike CompleteTravelIfArrived this can't be
    /// resolved entirely inside Character itself.
    /// </summary>
    public void ClearSleepState()
    {
        SleepPercent = 100;
        LastSleepTickUtc = DateTime.UtcNow;
        SleepStartUtc = null;
        SleepDurationHours = 0;
    }
}
