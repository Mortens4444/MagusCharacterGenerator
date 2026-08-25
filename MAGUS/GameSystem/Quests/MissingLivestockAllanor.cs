using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingLivestockAllanor : Quest
{
    public override string Name => "Something in the Pens";

    public override string Description => "Farms around Allanor have lost livestock to something that leaves the fences intact and no tracks at all - not a predator the local hunters recognize, and not thieves either.";

    public override string Objective => "Find out what's taking the livestock around Allanor.";

    public override City City => City.Allanor;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override string? TargetCreatureName => "Wolf";
}
