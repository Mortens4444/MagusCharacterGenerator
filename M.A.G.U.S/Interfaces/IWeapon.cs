using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Interfaces;

public interface IWeapon
{
    string Name { get; }

    double AttacksPerRound { get; }

    int InitiatingValue { get; }

    double Weight { get; }

    Money Price { get; }

    int GetDamage();
}
