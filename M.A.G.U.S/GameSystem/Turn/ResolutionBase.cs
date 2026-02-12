using M.A.G.U.S.Enums;

namespace M.A.G.U.S.GameSystem.Turn;

public abstract class ResolutionBase
{
    protected int? damage;

    public required Attack Attack { get; init; }

    public int RollValue { get; init; }

    public bool IsSuccessful { get; init; }

    public int Damage
    {
        get
        {
            var currentDamage = damage ?? GetDamage();
            damage = currentDamage;
            return currentDamage;
        }
    }

    public void ReduceDamge(int armorClass)
    {
        // Only reduce damage if the armor protects the area where the attack hits (HitLocation, HitSubLocation)
        damage -= armorClass;
        if (damage < 0)
        {
            damage = 0;
        }
    }

    private int GetDamage()
    {
        return Math.Max(0, Attack.GetDamage());
    }
    
    public bool IsHpDamage { get; init; }

    public AttackDirection Direction { get; init; }

    public required string HitLocation { get; init; }

    public string? HitSubLocation { get; init; }

    public AttackImpact Impact => RollValue == 100 ? AttackImpact.Critical : RollValue == 1 ? AttackImpact.Fatal : AttackImpact.Normal;
}
