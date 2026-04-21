using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.BreedModifiers;

public class Aeternam : IBreedModifier
{
    public int InitiateValue => 3;

    public int AttackValue => 0;

    public int DefenseValue => 5;

    public int AimValue => 0;

    public int ExtraDamage => -1;

    public int ExtraHealtPoints => -1;

    public int ExtraPainTolerancePoints => -3;

    public int ExtraExperiancePoints => 2;
}
