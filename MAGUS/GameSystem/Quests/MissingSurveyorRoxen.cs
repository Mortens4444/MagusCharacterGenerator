using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingSurveyorRoxen : Quest
{
    public override string Name => "The Surveyor's Notes";

    public override string Description => "A land surveyor working just outside Roxen hasn't reported back in days, and all that's left of his camp is a scattered tent and a satchel of half-finished notes.";

    public override string Objective => "Search the surveyor's abandoned camp near Roxen for clues.";

    public override City City => City.Roxen;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Roxen;

    public override int SearchDangerChance => 30;
}
