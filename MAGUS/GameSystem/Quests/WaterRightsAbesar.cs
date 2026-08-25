using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class WaterRightsAbesar : Quest
{
    public override string Name => "The Last Cistern";

    public override string Description => "Two nomad clans camped near Abesar are close to bloodshed over a cistern that's barely enough for one of them, let alone both, this deep into the dry season.";

    public override string Objective => "Broker a peace between the two clans over the cistern - negotiate with them in Abesar.";

    public override City City => City.Abesar;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var securePrideIssue = new DialogueNode
            {
                Text = "The clan willing to use the eastern well will still need to save face in front of the other - pride runs deep out here, deep enough to restart the fight over nothing but appearances.",
                Options =
                [
                    new DialogueOption { Text = "Frame it as the stronger clan generously ceding the cistern, not the weaker one giving up.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Just tell them to get over their pride and go.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Offer to escort the relocating clan yourself, so it looks like your idea, not theirs.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Say nothing more and let the silence answer for you.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Call his pride foolish in front of both camps.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var askAboutOtherWells = new DialogueNode
            {
                Text = "\"There is another well,\" the elder admits slowly, \"a half-day's ride east. Brackish, but drinkable. We avoid it out of pride, not need.\"",
                Options =
                [
                    new DialogueOption { Text = "Suggest the weaker clan use the eastern well while the drought lasts - and ask how to make that acceptable to them.", Outcome = DialogueOutcome.Continue, NextNode = securePrideIssue },
                    new DialogueOption { Text = "Suggest the weaker clan use the eastern well immediately, without addressing the pride issue.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Call his pride foolish in front of both camps.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say nothing more and let the silence answer for you.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Insist both clans use the brackish well equally, cistern be damned.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both clan elders stand on opposite sides of the cistern, hands resting on their knife belts. \"There is not enough water for both,\" one says flatly. \"Choose.\"",
                Options =
                [
                    new DialogueOption { Text = "Ask if there's any other water source nearby, however poor.", Outcome = DialogueOutcome.Continue, NextNode = askAboutOtherWells },
                    new DialogueOption { Text = "Propose a strict rationing schedule shared between both camps.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them plainly that you refuse to choose a side.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to pay for a caravan to haul in water from Abesar itself.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Side with whichever clan arrived at the cistern first.", Outcome = DialogueOutcome.Failure }
                ]
            };
        }
    }
}
