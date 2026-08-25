using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class DockSpaceGorvik : Quest
{
    public override string Name => "The Last Good Berth";

    public override string Description => "Two fishing crews in Gorvik both claim the last sheltered berth before winter ice closes the outer harbor, and the harbormaster would rather pay a stranger to settle it than pick a side himself.";

    public override string Objective => "Settle the dock-space dispute between the two fishing crews - negotiate with them in Gorvik.";

    public override City City => City.Gorvik;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var condition = new DialogueNode
            {
                Text = "Walking the two boats, one is patched together with more resin than hull at this point - it wouldn't survive open winter mooring even a week, storm damage or not.",
                Options =
                [
                    new DialogueOption { Text = "Give the damaged boat's crew the sheltered berth, history aside.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Split the season anyway, ignoring the boat's real condition.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Suggest the fragile boat's crew borrow coin for repairs first.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell the fragile boat's crew that's their own bad luck.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say you can't judge boats and step back entirely.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var history = new DialogueNode
            {
                Text = "One crew has used the berth for three winters running; the other lost their usual spot to storm damage just this year.",
                Options =
                [
                    new DialogueOption { Text = "Go look at the actual condition of both boats yourself.", Outcome = DialogueOutcome.Continue, NextNode = condition },
                    new DialogueOption { Text = "Suggest the storm-damaged crew gets priority this one winter, given the circumstances.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Rule for whichever crew used it longest, tradition first.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Tell the storm-damaged crew that's not really Gorvik's problem to solve.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Suggest the harbormaster formally reassign berths for everyone, not just these two.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };

            return new DialogueNode
            {
                Text = "Both crew captains stand shoulder to shoulder at the disputed berth, neither willing to be the one who backs their boat out first.",
                Options =
                [
                    new DialogueOption { Text = "Ask how each crew has used the berth in past winters.", Outcome = DialogueOutcome.Continue, NextNode = history },
                    new DialogueOption { Text = "Suggest splitting the season - one crew gets it this winter, the other next.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them whoever's boat is smaller can find somewhere else.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse one captain of moving their boat in before the other arrived, deliberately.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say you can't decide and leave it to them.", Outcome = DialogueOutcome.Failure }
                ]
            };
        }
    }
}
