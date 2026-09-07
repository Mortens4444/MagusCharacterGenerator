using MAGUS.Things.Weapons;

namespace MAGUS.Things.Shields;

public abstract class Shield : Weapon
{
    public abstract int DefenseValue { get; }

    public abstract int MovementObstructiveFactor { get; }

    // A shield occupies one hand/arm by design, regardless of AttacksPerRound (see
    // LargeShield's 0.5) - it never needs the other hand the way an actual two-handed weapon does.
    public override bool IsTwoHanded => false;
}
