using MAGUS.Extensions;
using MAGUS.GameSystem;
using MAGUS.Interfaces;
using MAGUS.Models;

namespace MAGUS.Things.Weapons;

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