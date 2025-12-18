using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Shields;

public class MediumShield : Shield
{
    public override double AttacksPerRound => 1;

    public int InitiatingValue => 0;

    public int DefendingValue => 35;

    public int MovementObstructiveFactor => 1;

    public override double Weight => 3;

    public override Money Price => new(1, 6);

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Name => "Medium shield";

    public override string Description => "A common, round or kite-shaped shield, usually crafted from thick planking covered in hide and reinforced by a central boss of steel. It strikes a fine balance between protection and mobility, the standard defense for most foot soldiers.";
}