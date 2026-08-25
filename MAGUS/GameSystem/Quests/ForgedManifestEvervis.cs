using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ForgedManifestEvervis : Quest
{
    public override string Name => "Numbers That Don't Add Up";

    public override string Description => "A customs clerk in Evervis is certain one merchant house has been quietly falsifying shipment weights for months, but the proof - if it exists - is buried somewhere in a warehouse full of ordinary-looking paperwork.";

    public override string Objective => "Search Evervis for proof of the falsified shipment records.";

    public override City City => City.Evervis;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Evervis;
}
