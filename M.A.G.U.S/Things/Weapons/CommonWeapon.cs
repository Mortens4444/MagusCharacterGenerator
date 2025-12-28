using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons;

public class CommonWeapon(string name, int initiateValue, int attackValue, int defenseValue, ThrowType throwType, int modifier = 0, bool isMagical = false) : IMeleeWeapon
{
    public int AttackValue => attackValue;

    public int DefenseValue => defenseValue;

    public string Name => name;

    public virtual double AttacksPerRound => 1;

    public int InitiateValue => initiateValue;

    public double Weight => 0;

    public Money Price => Money.Free;

    public bool IsMagical => isMagical;

    public ThrowType ThrowType => throwType;

    public int Modifier => modifier;

    public int GetDamage()
    {
        var diceThrow = new DiceThrow();
        return diceThrow.Throw(throwType, modifier);
    }
}
