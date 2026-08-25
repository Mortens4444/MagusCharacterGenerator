using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WhatWaitsInTheOasisPoolAlidax : Quest
{
    public override string Name => "What Waits in the Oasis Pool";

    public override string Description => "The deep pool at the heart of Alidax's oasis has claimed a goat, a dog, and nearly a child in the space of a week - something is living in the water that wasn't there before the last flood season.";

    public override string Objective => "Deal with the creature lurking in Alidax's oasis pool.";

    public override City City => City.Alidax;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "Crocodile";
}
