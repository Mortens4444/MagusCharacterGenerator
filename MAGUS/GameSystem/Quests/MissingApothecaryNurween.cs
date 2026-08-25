using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingApothecaryNurween : Quest
{
    public override string Name => "The Apothecary's Satchel";

    public override string Description => "Nurween's only apothecary lost her satchel of prepared remedies somewhere between the herb terraces and the market square, and half the town is waiting on what's inside it.";

    public override string Objective => "Search Nurween for the apothecary's missing satchel.";

    public override City City => City.Nurween;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Nurween;
}
