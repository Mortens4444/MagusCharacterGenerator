using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class LostSurveyMarksOrdan : Quest
{
    public override string Name => "The Surveyor's Marks";

    public override string Description => "A land surveyor mapping new claims above Ordan vanished along with his instruments and notes, and the claims office refuses to certify anything until his marks are found.";

    public override string Objective => "Search the hills above Ordan for the missing surveyor's instruments and notes.";

    public override City City => City.Ordan;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.Ordan;
}
