using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RightOfTheShadeAlidax : Quest
{
    public override string Name => "Right of the Shade";

    public override string Description => "Two caravan masters have pulled into the same Alidax waystation on the same brutal afternoon, and only one patch of real shade is big enough for either of their trains - not both.";

    public override string Objective => "Settle the dispute over the shaded rest spot - negotiate with the caravan masters in Alidax.";

    public override City City => City.Alidax;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var confirmWithWellKeeper = new DialogueNode
            {
                Text = "The old well-keeper has watched every caravan pass through this waystation for thirty years. She squints at both masters and says it plainly: wagons count, not outriders sent ahead scouting - that's how it's always been settled here.",
                Options =
                [
                    new DialogueOption { Text = "Rule by the well-keeper's account and the waystation's own tradition.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Thank her, but rule your own way anyway.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Dismiss her as too old to remember clearly.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse her of favoring the caravan master she knows better.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var checkOrder = new DialogueNode
            {
                Text = "One caravan master insists he arrived first; the other swears his outriders reached the well an hour earlier and that should count.",
                Options =
                [
                    new DialogueOption { Text = "Rule on your own that whichever wagons arrived counts, not the outriders.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Ask the well-keeper, who's watched this waystation for decades, to settle which counts.", Outcome = DialogueOutcome.Continue, NextNode = confirmWithWellKeeper },
                    new DialogueOption { Text = "Accuse the outriders of lying to win the argument.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say arrival order doesn't matter and refuse to rule on it.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Side with whichever caravan master offers you a better cut.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both caravan masters stand under the shade's edge already, wagons idling, animals suffering in the sun behind them.",
                Options =
                [
                    new DialogueOption { Text = "Ask exactly when each train actually arrived at the waystation.", Outcome = DialogueOutcome.Continue, NextNode = checkOrder },
                    new DialogueOption { Text = "Suggest rotating the animals through the shade in shifts.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Propose rigging a second awning from spare canvas, together.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them to draw straws for it, right now.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Point out one master's wagons look overloaded enough to explain the delay.", Outcome = DialogueOutcome.Danger }
                ]
            };
        }
    }
}
