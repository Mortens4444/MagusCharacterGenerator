using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class DockworkersWageDisputeRiegoy : Quest
{
    public override string Name => "A Fair Day's Wage";

    public override string Description => "Riegoy's dockworkers have stopped unloading ships entirely, certain the harbor master is skimming their wages, while the harbor master swears the shortfall is coming from somewhere else.";

    public override string Objective => "Get to the bottom of the wage dispute and settle it - negotiate in Riegoy.";

    public override City City => City.Riegoy;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var traceGap = new DialogueNode
            {
                Text = "The gap traces back to a single set of scales at the far pier - underweighing every load by the same small amount, day after day, for months. Nobody's stealing; the scale itself is just broken.",
                Options =
                [
                    new DialogueOption { Text = "Get the scale fixed and back-pay the dockworkers for the shortfall.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Just fix the scale going forward and let the past shortfall go.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Blame whoever was assigned to that scale, without asking if they even knew.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Accuse the harbor master of knowing about the broken scale all along.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Decide it's too much effort to trace further and drop it.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var ledgerCheck = new DialogueNode
            {
                Text = "The ledgers and the coin box don't match - but the gap is small, consistent, and looks more like a counting error than theft.",
                Options =
                [
                    new DialogueOption { Text = "Trace the discrepancy back to whichever pier or scale it's actually coming from.", Outcome = DialogueOutcome.Continue, NextNode = traceGap },
                    new DialogueOption { Text = "Point out it's likely an honest counting error, not theft.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Insist it's theft regardless, and demand the harbor master pay it back.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Suggest hiring a proper clerk to keep the books going forward.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say the gap is too small to matter and drop it.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "The dock foreman folds his arms; the harbor master spreads his ledgers out like proof of nothing wrong at all.",
                Options =
                [
                    new DialogueOption { Text = "Ask to see the ledgers and the actual coin paid out, side by side.", Outcome = DialogueOutcome.Continue, NextNode = ledgerCheck },
                    new DialogueOption { Text = "Suggest an independent tally for the next month's wages, to settle it fairly.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell the dockworkers to trust the harbor master and get back to work.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the harbor master of skimming, to his face, in front of his own dockworkers.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to cover the disputed wages yourself, out of pocket, to end it.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
