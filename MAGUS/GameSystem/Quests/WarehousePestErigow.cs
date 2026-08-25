using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WarehousePestErigow : Quest
{
    public override string Name => "Something Small and Quick";

    public override string Description => "Small goods keep vanishing from a sealed warehouse in Erigow - coin pouches, tools, anything shiny - and the night watchman swears he's seen something too fast and too small to be a person darting between the crates.";

    public override string Objective => "Catch whatever is stealing from the warehouse in Erigow.";

    public override City City => City.Erigow;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 45;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override string? TargetCreatureName => "Buzzgoblin";
}
