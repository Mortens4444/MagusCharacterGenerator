using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class TheOutridersOfElya : Quest
{
    public override string Name => "The Outriders of Elya";

    public override string Description => "A pack of mounted raiders has been striking Elya's grazing herds at the treeline and vanishing before anyone can organize a response.";

    public override string Objective => "Track down and deal with the raiders harassing Elya's herds.";

    public override City City => City.Elya;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override bool TargetIsGeneratedBandit => true;
}
