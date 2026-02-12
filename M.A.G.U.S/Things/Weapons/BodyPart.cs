using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons;

public class BodyPart : Weapon, IMeleeWeapon, INotForSale
{
    private readonly string name;
    private readonly ThrowType throwType;
    private readonly int modifier;
    private readonly double attacksPerRound;

    public BodyPart() { }

    public BodyPart(string name, ThrowType throwType, int modifier = 0, double attacksPerRound = 1)
    {
        this.name = name;
        this.throwType = throwType;
        this.modifier = modifier;
        this.attacksPerRound = attacksPerRound;
    }

    public int AttackValue => 0;

    public int DefenseValue => 0;

    public override string Name => name;

    public override double AttacksPerRound => attacksPerRound;

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
