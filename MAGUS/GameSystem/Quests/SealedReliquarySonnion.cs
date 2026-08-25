using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Sonnion is a ruined, uninhabited amund city, so like LostTextSonnion this has no city NPC to hand it out - the reliquary is simply what a careful search of the ruins turns up.</summary>
public sealed class SealedReliquarySonnion : Quest
{
    public override string Name => "Older Than the Ruins";

    public override string Description => "Half-buried in Sonnion's collapsed colonnades, a small reliquary bears a temple mark you recognize - not amund at all, but Talasean, centuries out of place and clearly not meant to be here.";

    public override string Objective => "Recover the reliquary from Sonnion's ruins and return it to the temple in Talasea.";

    public override City City => City.Sonnion;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? SearchLocation => City.Sonnion;

    public override City? DeliveryDestination => City.Talasea;

    public override string DeliveryItemName => "the reliquary";
}
