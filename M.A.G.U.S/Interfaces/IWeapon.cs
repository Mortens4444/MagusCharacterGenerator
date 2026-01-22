using M.A.G.U.S.GameSystem.Valuables;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Interfaces;

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
