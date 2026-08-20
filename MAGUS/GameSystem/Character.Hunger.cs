namespace MAGUS.GameSystem;

public partial class Character
{
    /// <summary>
    /// 100 = just fed, 0 = starving. Decays by a fixed amount every background game-time tick (see
    /// GameEventService.ApplyHungerTickAsync); below CriticalHungerThreshold it starts costing
    /// Fájdalomtűrés/HP each tick instead of just being a warning.
    /// </summary>
    public double HungerPercent { get; set; } = 100;
}
