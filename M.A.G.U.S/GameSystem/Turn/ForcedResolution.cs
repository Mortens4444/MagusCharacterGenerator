namespace M.A.G.U.S.GameSystem.Turn;

public sealed class ForcedResolution : ResolutionBase
{
    public ForcedResolution(InitiativeEntry initiative, int damage) : base()
    {
        this.damage = damage;
        IsSuccessful = true;
        IsHpDamage = true;
    }
}