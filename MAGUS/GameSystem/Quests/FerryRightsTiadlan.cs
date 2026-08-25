using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class FerryRightsTiadlan : Quest
{
    public override string Name => "Two Boats, One Crossing";

    public override string Description => "A second ferry operator has started running the same crossing as Tiadlan's longtime ferryman, undercutting his price, and the two are one shove away from wrecking each other's boats out of spite.";

    public override string Objective => "Settle the dispute between the two ferry operators - negotiate with them in Tiadlan.";

    public override City City => City.Tiadlan;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var rootCause = new DialogueNode
            {
                Text = "Pressed further, the newcomer finally admits it: they took out a loan to buy the boat, and the payments won't wait - the undercutting isn't spite, it's survival.",
                Options =
                [
                    new DialogueOption { Text = "Propose the newcomer takes the busier early-morning crossings while the old ferryman keeps his usual afternoon trade at his own rate.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Suggest the newcomer simply raise prices and accept a slower path to paying off the loan.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell the newcomer the loan isn't the old ferryman's problem to solve.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the newcomer of inventing the loan to win sympathy.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var price = new DialogueNode
            {
                Text = "The newcomer shrugs. \"I charge what people will pay. If he can't compete, that's not my problem.\"",
                Options =
                [
                    new DialogueOption { Text = "Press further - there has to be a reason they need the volume this badly.", Outcome = DialogueOutcome.Continue, NextNode = rootCause },
                    new DialogueOption { Text = "Point out that a price war will sink them both before it settles anything.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell the newcomer to raise their price to match the old ferryman's, plainly.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Suggest the old ferryman lower his price instead, to compete properly.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Warn the newcomer that Tiadlan's dockhands won't be kind to an outsider who won't cooperate.", Outcome = DialogueOutcome.Danger }
                ]
            };

            return new DialogueNode
            {
                Text = "The old ferryman stands with his arms crossed on the dock, glaring at the newcomer's brightly painted boat tied up twenty feet from his own.",
                Options =
                [
                    new DialogueOption { Text = "Ask the newcomer how long they intend to keep undercutting the price.", Outcome = DialogueOutcome.Continue, NextNode = price },
                    new DialogueOption { Text = "Suggest they split the crossing by time of day instead of competing directly.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell the old ferryman that competition isn't against any law.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the newcomer of trying to run the old man out of business on purpose.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to set a fair minimum price both of them have to honor.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
