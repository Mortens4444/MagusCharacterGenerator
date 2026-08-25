using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WhatElZashraForgot : Quest
{
    public override string Name => "What El Zashra Forgot";

    public override string Description => "A retired caravan master in El Zashra swears he buried a strongbox somewhere near the old waystation before his memory started slipping - he just can't quite recall where anymore.";

    public override string Objective => "Search near El Zashra's old waystation for the buried strongbox.";

    public override City City => City.ElZashra;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 40;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override City? SearchLocation => City.ElZashra;

    public override int SearchDifficulty => 92;
}
