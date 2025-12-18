using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons;

public class BreathWeaponcs(string name, ThrowType throwType, int modifier = 0) : IRangedWeapon
{
    public int AimValue => 0;

    public string Name => name;

    public virtual double AttacksPerRound => 1;

    public int InitiateValue => 0;

    public double Weight => 0;

    public Money Price => Money.Free;

    public ThrowType ThrowType => throwType;

    public int Modifier => modifier;

    public int Distance => 0;

    public int GetDamage()
    {
        var diceThrow = new DiceThrow();
        return diceThrow.Throw(throwType, modifier);
    }
}
