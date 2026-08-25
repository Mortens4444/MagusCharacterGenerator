using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingSurveyorTagreosz : Quest
{
    public override string Name => "The Surveyor's Notes";

    public override string Description => "A land surveyor mapping the outskirts of Tagreosz for a new boundary claim never returned to file his report, and his notes - wherever they are - are the only proof the claim exists.";

    public override string Objective => "Search around Tagreosz for the missing surveyor's notes.";

    public override City City => City.Tagreosz;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Tagreosz;
}
