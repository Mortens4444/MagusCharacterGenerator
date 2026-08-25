using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class StallPricingDisputeToron : Quest
{
    public override string Name => "Undercutting the Row";

    public override string Description => "A newly arrived vendor in Toron's market is selling below every established stallholder's price, and the row's older merchants suspect the goods are stolen, not just cheap.";

    public override string Objective => "Settle the pricing dispute in Toron's market - negotiate with the vendors.";

    public override City City => City.Toron;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var handleTheRow = new DialogueNode
            {
                Text = "Whatever the truth about the supplier, the row's older merchants are still waiting for you to tell them what happens next.",
                Options =
                [
                    new DialogueOption { Text = "Tell the row the supplier checks out, and undercutting isn't against any actual rule.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Ask the newcomer to raise prices slightly as a goodwill gesture, without forcing it.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell the row to just get used to it and walk away.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Announce to the whole row that the newcomer is clearly in the right, loudly, in front of everyone.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Suggest the row simply lower their own prices instead.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var source = new DialogueNode
            {
                Text = "The newcomer hesitates just half a second too long before naming a supplier nobody in Toron has ever heard of.",
                Options =
                [
                    new DialogueOption { Text = "Press for the supplier's actual name and location, then bring the answer back to the row.", Outcome = DialogueOutcome.Continue, NextNode = handleTheRow },
                    new DialogueOption { Text = "Let the hesitation go and accept the answer as given.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Announce to the whole row that the newcomer is clearly lying.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to verify the supplier quietly, without making a scene, then report back honestly.", Outcome = DialogueOutcome.Continue, NextNode = handleTheRow },
                    new DialogueOption { Text = "Tell the older merchants their suspicions are probably right and walk away.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "The row's older merchants have formed a loose half-circle around the newcomer's stall, arms crossed, waiting for someone to say what they're all thinking.",
                Options =
                [
                    new DialogueOption { Text = "Ask the newcomer where their goods actually came from.", Outcome = DialogueOutcome.Continue, NextNode = source },
                    new DialogueOption { Text = "Suggest the older merchants simply lower their own prices to compete.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Tell the newcomer to raise their prices to match the row, or move on.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the newcomer outright of selling stolen goods.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Point out that undercutting isn't illegal, whatever the row thinks of it, without checking the supplier at all.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
