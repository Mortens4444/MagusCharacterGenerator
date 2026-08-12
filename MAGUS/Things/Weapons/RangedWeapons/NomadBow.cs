using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.RangedWeapons;

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