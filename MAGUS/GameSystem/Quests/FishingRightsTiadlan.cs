using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class FishingRightsTiadlan : Quest
{
    public override string Name => "Troubled Waters";

    public override string Description => "Two fishing families in Tiadlan are one cut net away from open violence over who owns a stretch of river, and the harbor elders would rather pay a stranger to sort it out than pick a side.";

    public override string Objective => "Settle the dispute between the two fishing families - negotiate with them in Tiadlan.";

    public override City City => City.Tiadlan;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var elderConfirms = new DialogueNode
            {
                Text = "An elder who watched the original charter get drawn up two generations ago confirms the line was meant to run down the center channel - close to, but not exactly, an even split.",
                Options =
                [
                    new DialogueOption { Text = "Mark the boundary exactly where the elder remembers the charter placing it.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Split the stretch evenly instead - close enough to the elder's memory to satisfy both families.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Thank the elder but tell the families to work it out themselves anyway.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the elder of misremembering to favor one family.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var pressForHalves = new DialogueNode
            {
                Text = "Both patriarchs cross their arms at the same moment - an old habit from arguing with each other, probably.",
                Options =
                [
                    new DialogueOption { Text = "Ask if anyone still living remembers exactly where the original line was meant to run.", Outcome = DialogueOutcome.Continue, NextNode = elderConfirms },
                    new DialogueOption { Text = "Suggest alternating the stretch by the week instead.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them to figure it out themselves, then, and turn to leave.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Point out one family's nets are already cutting into the other's water as you speak.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var charterCheck = new DialogueNode
            {
                Text = "The charter exists, brittle and half-illegible - it names the channel as the boundary, but the ink describing which side belongs to whom has worn away entirely.",
                Options =
                [
                    new DialogueOption { Text = "Ask if anyone still living remembers reading the charter while the ink was fresh.", Outcome = DialogueOutcome.Continue, NextNode = elderConfirms },
                    new DialogueOption { Text = "Rule by the surviving text alone, best guess at the missing part.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say the charter is useless without the missing line and set it aside.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse one family of deliberately wearing away the ink.", Outcome = DialogueOutcome.Danger }
                ]
            };

            return new DialogueNode
            {
                Text = "The two families glare at each other across the dock, nets already half-mended into weapons. \"Well?\" one elder demands. \"Whose side are you on?\"",
                Options =
                [
                    new DialogueOption { Text = "Propose splitting the stretch of river evenly between them.", Outcome = DialogueOutcome.Continue, NextNode = pressForHalves },
                    new DialogueOption { Text = "Ask to see whatever old charter first granted the fishing rights.", Outcome = DialogueOutcome.Continue, NextNode = charterCheck },
                    new DialogueOption { Text = "Declare that neither family deserves it and the harbor should take it back.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Side loudly with whichever family looks angrier.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Offer to pay for a season's worth of new nets for both, out of your own pocket.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
