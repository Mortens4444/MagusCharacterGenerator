using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.BreedModifiers;

public class Cirnecos : IBreedModifier
{
    public int InitiateValue => 0;

    public int AttackValue => -5;

    public int DefenseValue => 0;

    public int AimValue => 0;

    public int ExtraDamage => -2;

    public int ExtraHealtPoints => -2;

    public int ExtraPainTolerancePoints => -2;

    public int ExtraExperiancePoints => -1;
}
