using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WhoseHarvestAbasis : Quest
{
    public override string Name => "Whose Harvest Is It";

    public override string Description => "Two tenant farmers outside Abasis have been feuding over a hedge that shifted a few feet during last spring's flood, and now both are claiming the same strip of ripening grain.";

    public override string Objective => "Settle the boundary dispute between the two farmers - negotiate with them near Abasis.";

    public override City City => City.Abasis;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var thisYearsCrop = new DialogueNode
            {
                Text = "The stones settle where the hedge belongs going forward - but this year's grain already grew on the disputed strip, real and ready for harvest, regardless of what old stones say.",
                Options =
                [
                    new DialogueOption { Text = "Split this year's already-grown grain evenly, then replant the hedge on the true line for next year.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Give this year's grain to whichever farmer's claim was closer to the stones.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say the stones settle everything, including this year's harvest, no exceptions.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Tell both farmers to fight over the grain themselves now that the line is clear.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Leave before the harvest question comes up at all.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var oldMarkers = new DialogueNode
            {
                Text = "Buried under the hedge roots, you find a row of old boundary stones - just not quite where either farmer said they'd be.",
                Options =
                [
                    new DialogueOption { Text = "Show both farmers the stones, and raise what happens to this year's grain.", Outcome = DialogueOutcome.Continue, NextNode = thisYearsCrop },
                    new DialogueOption { Text = "Quietly move one stone before showing them, to favor whoever seems poorer.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Declare the stones settle it and refuse to discuss it further.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Suggest replanting the hedge exactly on the old stone line, without mentioning this year's crop.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say the stones could mean anything after all these years.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both farmers stand at the hedge line with scythes in hand, not raised yet, but not set down either.",
                Options =
                [
                    new DialogueOption { Text = "Ask if there are any old boundary markers still buried under the hedge.", Outcome = DialogueOutcome.Continue, NextNode = oldMarkers },
                    new DialogueOption { Text = "Suggest splitting this year's disputed strip evenly, whatever the true line is.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them to take it to the granary master for a formal ruling.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Accuse one farmer of moving the hedge on purpose during the flood.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say the grain will rot before you sort out whose it is and leave.", Outcome = DialogueOutcome.Failure }
                ]
            };
        }
    }
}
