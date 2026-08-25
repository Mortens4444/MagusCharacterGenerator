using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class StolenStrongboxToron : Quest
{
    public override string Name => "The Long Way Home";

    public override string Description => "A moneychanger's strongbox was lifted from his stall in Toron three nights ago, and word from a caravan guard puts it - unopened, so far - somewhere in the hills above Ordan.";

    public override string Objective => "Recover the stolen strongbox from the hills near Ordan and bring it back to its owner in Toron.";

    public override City City => City.Toron;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Ordan;

    public override City? DeliveryDestination => City.Toron;

    public override string DeliveryItemName => "the stolen strongbox";
}
