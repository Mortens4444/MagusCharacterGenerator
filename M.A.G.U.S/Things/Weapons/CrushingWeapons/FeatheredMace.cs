using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class FeatheredMace : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 7;

    public int AttackValue => 12;

    public int DefenseValue => 13;

    public override double Weight => 2;

    public override Money Price => new(1, 1);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    public override string Name => "Flail (thresher)";

    public override string Description => "A heavy, headed weapon bearing several flat, sharp flanges radiating from the centre. Designed to pierce and rend heavy plate armour with repeated blows.";
}