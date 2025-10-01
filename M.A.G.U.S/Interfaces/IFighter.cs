namespace M.A.G.U.S.Interfaces;

internal interface IFighter : IAttacker, ILiving
{
    double AttacksPerRound { get; }

    byte GetDamage();

    ulong ExperiencePoints { get; }
}
