using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SabotagedSuppliesShadon : Quest
{
    public override string Name => "Spoiled Before It Started";

    public override string Description => "An entire wagonload of grain meant for Shadon's garrison arrived spoiled, though it left the mill in good order - someone tampered with it somewhere along the way, and the quartermaster wants to know who.";

    public override string Objective => "Search Shadon for evidence of who spoiled the garrison's supplies.";

    public override City City => City.Shadon;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Shadon;
}
