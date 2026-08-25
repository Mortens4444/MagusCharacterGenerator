using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ConscriptionDisputeShadon : Quest
{
    public override string Name => "Not Enough Sons Left";

    public override string Description => "A border village near Shadon is refusing the garrison's latest conscription quota, insisting they've already given more sons to the wall than any three other villages combined - and they're not wrong.";

    public override string Objective => "Settle the conscription dispute between the garrison and the village - negotiate near Shadon.";

    public override City City => City.Shadon;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var musterRolls = new DialogueNode
            {
                Text = "The garrison's own muster rolls back up the elder's claim - this village really has sent nearly three times its fair share over the years, while at least one neighboring village hasn't sent anyone in over a decade.",
                Options =
                [
                    new DialogueOption { Text = "Present the muster rolls to the commander and demand a formal quota review.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Just tell the recruiter informally to ease off this village.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Report the imbalance and leave it to the commander to act on, or not.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Accuse the recruiter of falsifying records to hide the imbalance.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Decide the records are too much trouble to chase down.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var quotaElsewhere = new DialogueNode
            {
                Text = "The recruiter admits, reluctantly, that two neighboring villages have given far fewer sons than they should have.",
                Options =
                [
                    new DialogueOption { Text = "Ask to see the muster rolls proving it, in writing.", Outcome = DialogueOutcome.Continue, NextNode = musterRolls },
                    new DialogueOption { Text = "Suggest shifting the shortfall onto those two villages instead.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell the recruiter to just take the names from wherever's easiest, including here.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say it's not your place to reassign anyone's quota.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Suggest the village pay coin instead of sons, if the garrison allows it.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };

            return new DialogueNode
            {
                Text = "The village elder lays out a list of names - sons already sent to the wall - before the garrison recruiter can even finish his demand.",
                Options =
                [
                    new DialogueOption { Text = "Ask the recruiter if the quota can be met from elsewhere instead.", Outcome = DialogueOutcome.Continue, NextNode = quotaElsewhere },
                    new DialogueOption { Text = "Suggest the village's next quota be reduced to match what they've already given.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell the elder the quota is the quota, and there's nothing to discuss.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Side immediately with the village without hearing the recruiter out.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Offer to serve in place of the next name on the list yourself.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
