using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class FairStallDisputeAllanor : Quest
{
    public override string Name => "Best Stall in the Row";

    public override string Description => "Two vendors at Allanor's harvest fair have both set up in the same prime spot by the gate, each waving a different permit, and neither will move an inch before the fair opens tomorrow.";

    public override string Objective => "Settle the dispute over the fair stall - negotiate with the vendors in Allanor.";

    public override City City => City.Allanor;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var verifyRecord = new DialogueNode
            {
                Text = "The organizer digs out the fair's own registry - the gate-side spot was formally assigned to the older vendor weeks ago; the newer permit was never logged at all.",
                Options =
                [
                    new DialogueOption { Text = "Show the registry to both vendors and rule for the older permit-holder, on the record.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Quietly tell the newer vendor to move, without airing it in front of the whole fair.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Let the organizer make the announcement and step out of it yourself.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the organizer of being bribed by one side to falsify the registry.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var checkPermits = new DialogueNode
            {
                Text = "One permit is dated last spring, the other from just this week - and the ink on the newer one is still faintly damp.",
                Options =
                [
                    new DialogueOption { Text = "Ask a fair organizer to check the newer permit against the fair's own registry.", Outcome = DialogueOutcome.Continue, NextNode = verifyRecord },
                    new DialogueOption { Text = "Point out the newer permit is clearly the forgery, right to the forger's face.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Suggest reissuing both permits fresh, so nobody has to admit fault.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say you can't tell the difference and walk away.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the older vendor of forging their own instead.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both vendors talk over each other at once, each pointing to a scrap of parchment they call proof of the spot being theirs.",
                Options =
                [
                    new DialogueOption { Text = "Ask to see both permits side by side.", Outcome = DialogueOutcome.Continue, NextNode = checkPermits },
                    new DialogueOption { Text = "Suggest splitting the stall space down the middle for the fair's opening day.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them the gatekeeper who issued both permits should sort it out, not you.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Point out loudly that one permit looks freshly forged.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to buy out one vendor's spot yourself, on the spot.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
