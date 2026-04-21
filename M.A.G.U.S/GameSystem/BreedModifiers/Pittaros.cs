using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.BreedModifiers;

public class Pittaros : IBreedModifier
{
    public int InitiateValue => -3;

    public int AttackValue => 10;

    public int DefenseValue => -7;

    public int AimValue => 0;

    public int ExtraDamage => 1;

    public int ExtraHealtPoints => 3;

    public int ExtraPainTolerancePoints => 6;

    public int ExtraExperiancePoints => 4;
}
