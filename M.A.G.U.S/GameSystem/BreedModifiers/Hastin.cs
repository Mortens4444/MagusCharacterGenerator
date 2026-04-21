using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.BreedModifiers;

public class Hastin : IBreedModifier
{
    public int InitiateValue => -2;

    public int AttackValue => 18;

    public int DefenseValue => -12;

    public int AimValue => 0;

    public int ExtraDamage => 2;

    public int ExtraHealtPoints => 5;

    public int ExtraPainTolerancePoints => 10;

    public int ExtraExperiancePoints => 8;
}
