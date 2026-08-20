namespace MAGUS.GameSystem;

public partial class Character
{
    /// <summary>
    /// 100 = well-rested, 0 = exhausted. Decays by a fixed amount every background game-time tick
    /// (see GameEventService.ApplySleepTickAsync) - more slowly than HungerPercent, since a
    /// character needs to sleep less often than they need to eat. Below the same critical threshold
    /// hunger uses, it starts costing Fájdalomtűrés/HP each tick too.
    /// </summary>
    public double SleepPercent { get; set; } = 100;
}
