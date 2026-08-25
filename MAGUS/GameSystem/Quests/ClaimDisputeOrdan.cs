using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class ClaimDisputeOrdan : Quest
{
    public override string Name => "Whose Vein Is It";

    public override string Description => "Two prospecting crews above Ordan have staked overlapping claims on the same rich seam, and both are one wrong word away from settling it with pickaxes instead of paperwork.";

    public override string Objective => "Settle the claim dispute between the two prospecting crews - negotiate with them near Ordan.";

    public override City City => City.Ordan;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var stakes = new DialogueNode
            {
                Text = "Out at the vein itself, the boundary stakes tell a different story than either filing - one crew's stakes are weathered and lichen-covered, driven in seasons ago; the other's look freshly cut.",
                Options =
                [
                    new DialogueOption { Text = "Rule for the crew with the older, weathered stakes.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Split the vein's output evenly, stakes aside.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Recommend the claims office resurvey the whole area properly.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Accuse the fresh-stake crew of jumping the claim outright.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say stakes prove nothing on their own and give up.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var filings = new DialogueNode
            {
                Text = "One filing is dated three days before the other - but the ink on the boundary line itself looks newer than the rest of the page.",
                Options =
                [
                    new DialogueOption { Text = "Walk out to the vein and check the boundary stakes in person.", Outcome = DialogueOutcome.Continue, NextNode = stakes },
                    new DialogueOption { Text = "Send both filings to the claims office in Ordan for a formal ruling.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Rule for whichever filing is genuinely older, ink and all.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Accuse the earlier filer of redrawing their own boundary afterward.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say the paperwork is beyond you and leave it to them.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both crew foremen have their maps out already, jabbing fingers at the same inked boundary line.",
                Options =
                [
                    new DialogueOption { Text = "Ask to see both crews' original claim filings.", Outcome = DialogueOutcome.Continue, NextNode = filings },
                    new DialogueOption { Text = "Suggest splitting the vein's output evenly between both crews.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them whoever staked first keeps the vein, no argument.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Point out that one map's boundary line looks redrawn.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to mark a new, unclaimed boundary yourself, on the spot.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
