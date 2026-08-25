using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingFiddlerAllanor : Quest
{
    public override string Name => "The Missing Fiddler";

    public override string Description => "The fiddler booked to open Allanor's harvest fair never showed up for the final rehearsal, and the innkeeper who last saw him swears he simply walked out mid-tune without a word.";

    public override string Objective => "Search Allanor for the missing fiddler.";

    public override City City => City.Allanor;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override City? SearchLocation => City.Allanor;
}
