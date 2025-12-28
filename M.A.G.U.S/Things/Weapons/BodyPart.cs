using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons;

public class BodyPart(string name, ThrowType throwType, int modifier = 0) : Weapon, IMeleeWeapon
{
    public int AttackValue => 0;

    public int DefenseValue => 0;

    public override string Name => name;

    public override double AttacksPerRound => 1;

    public override int InitiateValue => 0;

    public override double Weight => 0;

    public override Money Price => Money.Free;

    public ThrowType ThrowType => throwType;

    public int Modifier => modifier;

    public override int GetDamage()
    {
        var diceThrow = new DiceThrow();
        return diceThrow.Throw(throwType, modifier);
    }
}
