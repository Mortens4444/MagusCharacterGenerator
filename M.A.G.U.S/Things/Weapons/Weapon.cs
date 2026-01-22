using M.A.G.U.S.Extensions;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Things.Weapons;

public abstract class Weapon : Thing, IWeapon
{
    protected readonly DiceThrow DiceThrow = new();

    public abstract double AttacksPerRound { get; }

    public abstract int InitiateValue { get; }

    public abstract int GetDamage();

    public DiceThrowFormula? DamageFormula
    {
        get
        {
            var customAttributes = GetType().GetMethod(nameof(GetDamage))?.GetCustomAttributes(false);
            return customAttributes.GetDiceThrowFormula();
        }
    }
}