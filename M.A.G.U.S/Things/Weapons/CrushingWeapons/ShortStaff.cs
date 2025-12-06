using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class ShortStaff : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public int InitiatingValue => 9;

    public int AttackingValue => 9;

    public int DefendingValue => 17;

    public override double Weight => 0.7;

    public override Money Price => new(0, 0, 30);

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    public override string Name => "Short staff";

    public override string Description => "A shorter, easily concealed staff of wood or heavy iron. Good for quick defensive work and close-quarters fighting.";
}