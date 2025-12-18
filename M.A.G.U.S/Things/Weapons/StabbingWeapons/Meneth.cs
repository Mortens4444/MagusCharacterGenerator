using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons.StabbingWeapons;

public class Meneth : Weapon, IMeleeWeapon
{
    public override double AttacksPerRound => 1;

    public int InitiateValue => 1;

    public int AttackValue => 4;

    public int DefenseValue => 5;

    public override double Weight => 1.2;

    public override Money Price => new(1, 5);

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(5)]
    public override int GetDamage() => DiceThrow._1D6() + 5;

    public override string Description => "The meneth is a distinctive, serrated sword used by the Amund. It is not designed primarily to kill, but to maim, tear, and cause painful, slow-healing wounds. Its broad blade resembles a short sword, made of thick, unsharpened steel, with sharp, pointed teeth along the edges. When it strikes, these teeth rip and shred flesh rather than cutting cleanly. While highly effective against lightly clothed or unarmored foes, the blade tends to catch in armor, making it dangerous for the wielder as well. Beyond its physical harm, the menes is a terrifying symbol within a culture that places great importance on bodily perfection.";
}