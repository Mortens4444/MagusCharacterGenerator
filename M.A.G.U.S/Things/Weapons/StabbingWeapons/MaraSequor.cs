using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class MaraSequor : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public override int InitiateValue => 7;

    public int AttackValue => 16;

    public int DefenseValue => 14;

    public override double Weight => 1;

    public override Money Price => new(2);

    [DiceThrow(ThrowType._2D6)]
    [DiceThrowModifier(2)]
    public override int GetDamage() => DiceThrow._2D6() + 2;

    public override string Name => "Mara-sequor";

    public override string Description => "A specialized, heavy cutting sword with a broad, curved blade, often associated with gladiatorial combat or the brutal legions of Mara.";
}