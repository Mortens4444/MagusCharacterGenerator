using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class JudgmentAtTheTempleTierNanGorduin : Quest
{
    public override string Name => "Two Claims on One Well";

    public override string Description => "Two desert families have brought a water-rights dispute all the way to Darton's judges at TierNanGorduin, and the presiding priest - overloaded with graver cases - has asked an impartial outsider to hear both sides first.";

    public override string Objective => "Hear both families' claims and settle the dispute - negotiate with them at TierNanGorduin.";

    public override City City => City.TierNanGorduin;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var verifyGrant = new DialogueNode
            {
                Text = "The archivists disappear into the stacks for what feels like an hour before returning with a dusty ledger - the drought-year grant is real, but it names a different well entirely.",
                Options =
                [
                    new DialogueOption { Text = "Read the ledger's actual wording aloud to both families and rule by it.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Announce your verdict before the archivists finish explaining the ledger.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Grow impatient waiting and rule for the newer claimant anyway.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the archivists of stalling to protect one family.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var checkDeeds = new DialogueNode
            {
                Text = "One family's deed is generations old, its ink faded to brown. The other's is barely a year old, but it cites a drought-year emergency grant that would override the older claim entirely - if it's genuine.",
                Options =
                [
                    new DialogueOption { Text = "Ask the temple archivists to verify the emergency grant, and wait for their answer.", Outcome = DialogueOutcome.Continue, NextNode = verifyGrant },
                    new DialogueOption { Text = "Rule for the older deed - tradition should win.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Rule for the newer grant without checking it.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the newer claimant of forging the emergency grant, in front of everyone.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Propose the well is shared on alternating weeks until the archive can confirm either way.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };

            return new DialogueNode
            {
                Text = "Both families stand on opposite sides of the judgment hall, deeds in hand, each certain Darton's law is on their side.",
                Options =
                [
                    new DialogueOption { Text = "Ask to see both families' water deeds.", Outcome = DialogueOutcome.Continue, NextNode = checkDeeds },
                    new DialogueOption { Text = "Suggest splitting the well's water evenly, deeds aside.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them Darton's judges should decide, not you.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Declare one family is clearly lying and should be fined.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to dig a second well yourself, ending the dispute outright.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
