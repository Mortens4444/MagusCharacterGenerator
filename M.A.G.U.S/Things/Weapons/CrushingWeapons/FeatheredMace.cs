using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.CrushingWeapons;

public class FeatheredMace : Weapon, IMeleeWeapon
{
    public double AttacksPerRound => 1;

    public byte InitiatingValue => 7;

    public byte AttackingValue => 12;

    public byte DefendingValue => 13;

    public override double Weight => 2;

    public override Money Price => new(1, 1);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public byte GetDamage() => (byte)(DiceThrow._1D6() + 1);

    public override string Name => "Flail (thresher)";

    public override string Description => "A heavy, headed weapon bearing several flat, sharp flanges radiating from the centre. Designed to pierce and rend heavy plate armour with repeated blows.";
}