namespace M.A.G.U.S.GameSystem.Turn;

/// <summary>A lingering effect (e.g. a curse) that keeps ticking on its target for a number of rounds after a successful mystic attack.</summary>
public sealed class ActiveEffect(string name, Func<int> getTickDamage, bool isHpDamage, int remainingRounds)
{
    public string Name { get; } = name;

    public Func<int> GetTickDamage { get; } = getTickDamage;

    public bool IsHpDamage { get; } = isHpDamage;

    public int RemainingRounds { get; set; } = remainingRounds;
}
