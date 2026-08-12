using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.GameSystem.Valuables;
using MAGUS.Interfaces;

namespace MAGUS.Things.Weapons.CrushingWeapons;

public class OneHandedMace : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 7;

    public int AttackValue => 11;

    public int DefenseValue => 12;

    public override double Weight => 2;

    public override Money Price => new(0, 8);

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override string Name => "One-handed mace";

    public override string Description => "A stout, one-handed club with a weighted, often flanged, metal head. Excellent for denting helms and breaking bones, especially effective against armoured foes.";
}