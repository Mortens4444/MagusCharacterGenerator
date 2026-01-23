using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons;

public class CommonWeapon : Weapon, IMeleeWeapon, INotForSale
{
    private readonly string name;
    private readonly int initiateValue;
    private readonly int attackValue;
    private readonly int defenseValue;
    private readonly ThrowType throwType;
    private readonly int modifier;
    private readonly bool isMagical;
    private readonly double attacksPerRound;

    public CommonWeapon() { }

    public CommonWeapon(string name, int initiateValue, int attackValue, int defenseValue, ThrowType throwType, int modifier = 0, bool isMagical = false, double attacksPerRound = 1)
    {
        this.name = name;
        this.initiateValue = initiateValue;
        this.attackValue = attackValue;
        this.defenseValue = defenseValue;
        this.throwType = throwType;
        this.modifier = modifier;
        this.isMagical = isMagical;
        this.attacksPerRound = attacksPerRound;
    }

    public int AttackValue => attackValue;

    public int DefenseValue => defenseValue;

    public override string Name => name;

    public override double AttacksPerRound => attacksPerRound;

    public override int InitiateValue => initiateValue;

    public override double Weight => 0;

    public override Money Price => Money.Free;

    public bool IsMagical => isMagical;

    public ThrowType ThrowType => throwType;

    public int Modifier => modifier;

    public override int GetDamage()
    {
        var diceThrow = new DiceThrow();
        return diceThrow.Throw(throwType, modifier);
    }
}
