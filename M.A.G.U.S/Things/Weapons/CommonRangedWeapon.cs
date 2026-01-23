using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons;

public class CommonRangedWeapon : Weapon, IRangedWeapon, INotForSale
{
    private readonly string name;
    private readonly int initiateValue;
    private readonly int aimValue;
    private readonly int distance;
    private readonly ThrowType throwType;
    private readonly int modifier;
    private readonly bool isMagical;
    private readonly double attacksPerRound;

    public CommonRangedWeapon() { }

    public CommonRangedWeapon(string name, int initiateValue, int aimValue, int distance, ThrowType throwType, int modifier = 0, bool isMagical = false, double attacksPerRound = 1)
    {
        this.name = name;
        this.initiateValue = initiateValue;
        this.aimValue = aimValue;
        this.distance = distance;
        this.throwType = throwType;
        this.modifier = modifier;
        this.isMagical = isMagical;
        this.attacksPerRound = attacksPerRound;
    }

    public int AimValue => aimValue;

    public int Distance => distance;

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
