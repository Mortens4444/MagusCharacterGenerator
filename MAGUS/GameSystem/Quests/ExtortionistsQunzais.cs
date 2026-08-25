using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ExtortionistsQunzais : Quest
{
    public override string Name => "Protection, Uninvited";

    public override string Description => "A rough crew has started leaning on Qunzais's smaller stallholders for 'protection money', and the ones who refuse to pay have started finding their goods wrecked overnight.";

    public override string Objective => "Deal with the crew shaking down Qunzais's market stalls.";

    public override City City => City.Qunzais;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override bool TargetIsGeneratedBandit => true;
}
