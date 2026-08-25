using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class GrazingLineAbesar : Quest
{
    public override string Name => "The Grazing Line";

    public override string Description => "Two nomad clans camped near Abesar can't agree where one's grazing rights end and the other's begin now that the dry season has shrunk the good ground to almost nothing.";

    public override string Objective => "Settle the grazing dispute between the two clans - negotiate with them near Abesar.";

    public override City City => City.Abesar;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var findWell = new DialogueNode
            {
                Text = "Scouts confirm it: a half-forgotten spring lies two days' ride out, unused by either clan - reviving it would ease the shortage for good, if both clans are willing to dig it out together.",
                Options =
                [
                    new DialogueOption { Text = "Organize both clans to jointly dig out and share the old spring.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Point out the spring and let the clans work out who gets to use it first on their own.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say a two-day ride is too far to matter and drop the idea.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse one clan of already knowing about the spring and hiding it.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var oldAgreement = new DialogueNode
            {
                Text = "An elder from the smaller clan finally admits there was an old agreement, once - marked by a ring of stones neither clan has bothered to maintain in years.",
                Options =
                [
                    new DialogueOption { Text = "Now that the old line's settled, ask if there's any way to expand the usable ground itself.", Outcome = DialogueOutcome.Continue, NextNode = findWell },
                    new DialogueOption { Text = "Suggest both clans re-mark the old stone ring together, as a shared task.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Rule that the larger clan's herds simply get priority from now on.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say the old agreement is meaningless now and propose a new line yourself.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them to sort out the details themselves and walk away.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both clan leaders sit across the fire from you, herds already grumbling in the dusk behind them, patience thinner than the season's grass.",
                Options =
                [
                    new DialogueOption { Text = "Ask if there was ever a formal grazing agreement between the two clans.", Outcome = DialogueOutcome.Continue, NextNode = oldAgreement },
                    new DialogueOption { Text = "Propose splitting the remaining good ground into alternating weeks.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Suggest driving part of both herds toward a distant well instead.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell the smaller clan to simply yield the ground.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Say the dry season isn't your problem and leave both clans to it.", Outcome = DialogueOutcome.Failure }
                ]
            };
        }
    }
}
