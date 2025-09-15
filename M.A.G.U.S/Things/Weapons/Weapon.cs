using M.A.G.U.S.GameSystem;

namespace M.A.G.U.S.Things.Weapons;

public abstract class Weapon : Thing
{
    protected readonly DiceThrow DiceThrow = new();
}