using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ForgedSealErigow : Quest
{
    public override string Name => "The Wrong Seal";

    public override string Description => "A guild inspector in Erigow has found one warehouse's tax seals don't match the mold every other seal in the district was struck from, and wants proof before she accuses anyone of forgery outright.";

    public override string Objective => "Search Erigow for evidence of the forged tax seals.";

    public override City City => City.Erigow;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Erigow;
}
