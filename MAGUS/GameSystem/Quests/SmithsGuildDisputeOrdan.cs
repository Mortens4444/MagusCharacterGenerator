using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class SmithsGuildDisputeOrdan : Quest
{
    public override string Name => "Ore Before Iron";

    public override string Description => "Ordan's smiths' guild and the miners' consortium are at an impasse over who sets the price of raw ore first, and the whole forge district has gone quiet while both sides wait each other out.";

    public override string Objective => "Broker a deal between the smiths' guild and the miners' consortium - negotiate with them in Ordan.";

    public override City City => City.Ordan;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var lockInMechanism = new DialogueNode
            {
                Text = "With the real gap laid bare - smaller than either side admitted - the question turns to how to keep the peace once the ore starts moving again.",
                Options =
                [
                    new DialogueOption { Text = "Propose a price tied to the season's yield, anchored at the midpoint you found.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Lock in the midpoint as a flat price for one season, to be revisited later.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Just announce the midpoint and leave the details for them to work out.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Tell the miners their number was clearly the fairer one.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Suggest they keep negotiating without you now that they've heard each other.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var privateNumbers = new DialogueNode
            {
                Text = "Both numbers, whispered separately, are closer together than either side let on in public.",
                Options =
                [
                    new DialogueOption { Text = "Tell them the real gap is smaller than they think, and open the question of how to lock it in.", Outcome = DialogueOutcome.Continue, NextNode = lockInMechanism },
                    new DialogueOption { Text = "Keep the numbers to yourself and just declare a deal is possible.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Repeat one side's number to the other, to speed things up.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Suggest a short trial price for one season, revisited later, without mentioning the numbers at all.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say you can't help if neither will move first.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "The guild master and the consortium foreman stand on opposite sides of the same anvil, neither willing to name a price first.",
                Options =
                [
                    new DialogueOption { Text = "Ask each side to name their real minimum, privately, before you repeat anything.", Outcome = DialogueOutcome.Continue, NextNode = privateNumbers },
                    new DialogueOption { Text = "Suggest a price tied to the season's yield instead of a flat number, without knowing either side's real numbers.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them to just split the difference between their last two offers.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Point out the smiths could simply buy ore from Toron instead.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to set the price yourself, take it or leave it.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
