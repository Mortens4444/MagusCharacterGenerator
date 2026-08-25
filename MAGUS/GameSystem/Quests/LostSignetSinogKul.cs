using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class LostSignetSinogKul : Quest
{
    public override string Name => "The Notary's Seal";

    public override string Description => "Sinog Kul's town notary lost his official signet ring somewhere between the records hall and the riverside market - without it, nothing gets stamped, and half the town's paperwork is stalled.";

    public override string Objective => "Search Sinog Kul for the notary's missing signet ring.";

    public override City City => City.SinogKul;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.SinogKul;
}
