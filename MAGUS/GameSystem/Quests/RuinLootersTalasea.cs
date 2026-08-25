using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RuinLootersTalasea : Quest
{
    public override string Name => "Picking the Bones";

    public override string Description => "A gang has moved into Talasea's outskirts to strip anything the archivists haven't already claimed, and they've made clear they'll defend their haul from anyone else who comes looking.";

    public override string Objective => "Deal with the looters operating in Talasea's ruins.";

    public override City City => City.Talasea;

    public override Money MoneyReward => new(0, 7, 0);

    public override ulong ExperienceReward => 65;

    public override int MinLevel => 3;

    public override int MaxLevel => 5;

    public override bool TargetIsGeneratedBandit => true;
}
