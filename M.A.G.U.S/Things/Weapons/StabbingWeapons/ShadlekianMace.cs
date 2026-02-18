using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class ShadlekianMace : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 8;

    public int AttackValue => 13;

    public int DefenseValue => 14;

    public override double Weight => 1.8;

    public override Money Price => new(1, 3);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(1)]
    public override int GetDamage() => DiceThrow._1D6() + 1;

    public override string Name => "Shadlekian mace";

    public override string Description => "A unique, heavy mace originating from Shadlekia, often having an unusually large, multi-flanged head that concentrates force for deep impact.";
}