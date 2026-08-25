using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MissingCourtParcelPyarron : Quest
{
    public override string Name => "Sealed for the Court";

    public override string Description => "A parcel bound for the Pyarron court never arrived, and the courier who was meant to deliver it insists she left it exactly where instructed - on the Erigow road, with a contact who was supposed to carry it the rest of the way.";

    public override string Objective => "Find the missing court parcel along the Erigow road and deliver it to Pyarron.";

    public override City City => City.Pyarron;

    public override Money MoneyReward => new(0, 6, 0);

    public override ulong ExperienceReward => 50;

    public override int MinLevel => 2;

    public override int MaxLevel => 4;

    public override City? SearchLocation => City.Erigow;

    public override City? DeliveryDestination => City.Pyarron;

    public override string DeliveryItemName => "the sealed court parcel";
}
