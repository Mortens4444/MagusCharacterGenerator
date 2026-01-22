using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Things.Shields;

public abstract class Shield : Weapon
{
    public abstract int DefenseValue { get; }

    public abstract int MovementObstructiveFactor { get; }

}
