using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.RangedWeapons;

public class NomadBow : Weapon, IRangedWeapon
{
    public override double AttacksPerRound => 2;

    public override int InitiateValue => 3;

    public int AimValue => 8;

    public int Distance => 180;

    public override double Weight => 0.7;

    public override Money Price => new(25);

    [DiceThrow(ThrowType._1D10_Ranged)]
    public override int GetDamage() => DiceThrow._1D10_RangedAttack();

    public override string Name => "Recurve bow";

    public override string Description => "A short, powerful composite bow favoured by horse riders and desert tribes. Easily used from the saddle and capable of rapid firing.";
}