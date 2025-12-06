namespace M.A.G.U.S.Interfaces;

internal interface IFighter : IAttacker, ILiving
{
    double AttacksPerRound { get; }

    int GetDamage();

    ulong ExperiencePoints { get; }
}
