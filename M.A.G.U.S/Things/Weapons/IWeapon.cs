using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Weapons;

public interface IWeapon
{
    double AttacksPerRound { get; }

    byte InitiatingValue { get; }

    double Weight { get; }

    Money Price { get; }

    byte GetDamage();
}
