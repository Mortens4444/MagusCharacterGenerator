using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class ShortStaff : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 9;

    public int AttackValue => 9;

    public int DefenseValue => 17;

    public override double Weight => 0.7;

    public override Money Price => new(0, 0, 30);

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    public override string Name => "Short staff";

    public override string Description => "A shorter, easily concealed staff of wood or heavy iron. Good for quick defensive work and close-quarters fighting.";
}