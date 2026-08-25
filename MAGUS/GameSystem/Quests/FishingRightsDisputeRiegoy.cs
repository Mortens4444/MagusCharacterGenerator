using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class FishingRightsDisputeRiegoy : Quest
{
    public override string Name => "Whose Waters";

    public override string Description => "Two fishing fleets working out of Riegoy have started cutting each other's lines over the same stretch of good water, and the harbor master would rather pay a stranger to sort it out than pick a side twice in one bay.";

    public override string Objective => "Settle the dispute between the two fishing fleets - negotiate with them in Riegoy.";

    public override City City => City.Riegoy;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var formalize = new DialogueNode
            {
                Text = "The harbor master is willing to make the old courtesy line official policy - but wants both captains to sign it in front of witnesses, so it can't be disputed again.",
                Options =
                [
                    new DialogueOption { Text = "Get both captains to sign the harbor master's formal boundary agreement, on the record.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Get a verbal agreement between the captains instead and skip the paperwork.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Leave it to the harbor master to sort the paperwork out alone.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the harbor master of favoring one fleet in how the line gets drawn.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var oldSplit = new DialogueNode
            {
                Text = "It turns out the water was never formally divided - just an old habit both captains' fathers kept out of courtesy, not law.",
                Options =
                [
                    new DialogueOption { Text = "Ask the harbor master to formalize the old boundary and enforce it going forward.", Outcome = DialogueOutcome.Continue, NextNode = formalize },
                    new DialogueOption { Text = "Suggest writing the old habit down between the two captains, no harbor master involved.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say habit isn't law and whoever's faster gets the water.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Tell them the lack of a real rule means anyone can fish anywhere.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Shrug and leave them to work it out the old way.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both fleet captains have their boats crowded at the dock, crews watching to see whose side you take.",
                Options =
                [
                    new DialogueOption { Text = "Ask how the water was split before this season's dispute started.", Outcome = DialogueOutcome.Continue, NextNode = oldSplit },
                    new DialogueOption { Text = "Suggest alternating the good water week by week.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them to draw straws for it right now, in front of everyone.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Point out one fleet's nets are already crossing into the other's water.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to mark a new boundary buoy yourself.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
