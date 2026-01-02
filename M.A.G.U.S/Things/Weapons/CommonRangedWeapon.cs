using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons;

public class CommonRangedWeapon(string name, int initiateValue, int aimValue, int distance, ThrowType throwType, int modifier = 0, bool isMagical = false, double attacksPerRound = 1) : Weapon, IRangedWeapon, INotForSale
{
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
