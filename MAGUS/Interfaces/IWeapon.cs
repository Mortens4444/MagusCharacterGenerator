using MAGUS.GameSystem.Valuables;
using MAGUS.Models;

namespace MAGUS.Interfaces;

public interface IWeapon
{
    string Name { get; }

    double AttacksPerRound { get; }

    int InitiateValue { get; }

    double Weight { get; }

    Money Price { get; }

    DiceThrowFormula? DamageFormula { get; }

    int GetDamage();
}
