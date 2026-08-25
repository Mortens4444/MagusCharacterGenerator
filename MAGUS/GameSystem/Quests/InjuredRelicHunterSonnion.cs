using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Sonnion is a ruined, uninhabited amund city, so like LostTextSonnion this has no city NPC to hand it out - the injured relic hunter is simply who you find while working the ruins yourself.</summary>
public sealed class InjuredRelicHunterSonnion : Quest
{
    public override string Name => "Not Built to Carry a Stretcher";

    public override string Description => "A fellow relic hunter working Sonnion's ruins alone took a bad fall down a collapsed stairwell, and the nearest healer worth trusting is a hard two days off in Talasea.";

    public override string Objective => "Escort the injured relic hunter safely to Talasea.";

    public override City City => City.Sonnion;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 60;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override City? EscortDestination => City.Talasea;
}
