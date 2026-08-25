using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Sonnion is a ruined, uninhabited amund city, so like LostTextSonnion this has no city NPC to hand it out - the missing looter is simply who you find (or become) while working the ruins.</summary>
public sealed class WhatTheDiggerBecameSonnion : Quest
{
    public override string Name => "Not Alone Down Here";

    public override string Description => "A looter who went missing in Sonnion weeks ago left blood and claw marks on the walls of a side passage - and something is still moving down there, breathing wrong for anything human.";

    public override string Objective => "Find and put down whatever the missing looter became.";

    public override City City => City.Sonnion;

    public override Money MoneyReward => new(0, 9, 0);

    public override ulong ExperienceReward => 95;

    public override int MinLevel => 4;

    public override int MaxLevel => 6;

    public override string? TargetCreatureName => "Werewolf";
}
