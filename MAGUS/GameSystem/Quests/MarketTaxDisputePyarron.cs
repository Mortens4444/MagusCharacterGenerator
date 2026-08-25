using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class MarketTaxDisputePyarron : Quest
{
    public override string Name => "Whose Toll Is It";

    public override string Description => "Two noble houses in Pyarron both claim the right to collect toll on the same market gate, and the gate wardens have simply stopped collecting anything at all until someone in authority settles it.";

    public override string Objective => "Settle the dispute over the market gate toll - negotiate with the two houses in Pyarron.";

    public override City City => City.Pyarron;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var scribeReading = new DialogueNode
            {
                Text = "Days later the scribe returns with an authenticated reading - the founding name is neither house's. It belongs to a third family, extinct for a century, that neither steward has ever heard of.",
                Options =
                [
                    new DialogueOption { Text = "Present the finding honestly to both stewards and propose splitting the toll, since neither can claim sole right.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Announce the finding, but leave the houses to argue out the split themselves.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Suppress the finding since it favors neither house, and just rule for whichever steward seems more agreeable.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the scribe of being bought off by one of the houses.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var originalGrant = new DialogueNode
            {
                Text = "The grant is genuine, but so faded that the founding house's name could be read as either family's, depending on how you squint.",
                Options =
                [
                    new DialogueOption { Text = "Admit the grant settles nothing and suggest splitting the toll anyway, without proof either way.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Declare confidently which name it is, and hope you're right.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Send the grant to a scribe for a proper reading, and wait for the answer.", Outcome = DialogueOutcome.Continue, NextNode = scribeReading },
                    new DialogueOption { Text = "Say the ambiguity means neither house has the right to collect.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Let both stewards argue over the faded name themselves.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both stewards have their houses' old charters spread across the gatehouse table, each certain the ink favors them.",
                Options =
                [
                    new DialogueOption { Text = "Ask to see the original grant naming which house built the gate.", Outcome = DialogueOutcome.Continue, NextNode = originalGrant },
                    new DialogueOption { Text = "Suggest the toll be split evenly and collected jointly from now on.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell the gate wardens to collect nothing until the houses sort it out themselves.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse one steward of altering their house's charter.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to have the city chancellery rule on it formally instead.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
