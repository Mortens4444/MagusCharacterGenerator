using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class StolenRecordsTervin : Quest
{
    public override string Name => "The Missing Ledger";

    public override string Description => "Tervin's tax office is missing a full year's collection ledger, and without it nobody can prove who's actually paid up and who hasn't - the clerk suspects it was deliberately misfiled, not just lost.";

    public override string Objective => "Search Tervin's tax office for the missing ledger.";

    public override City City => City.Tervin;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Tervin;

    public override int SearchDifficulty => 85;
}
