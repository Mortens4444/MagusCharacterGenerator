using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class BestInShowAllanor : Quest
{
    public override string Name => "Best in Show";

    public override string Description => "Two farmers are both certain their pumpkin should have won Allanor's harvest contest, and the argument has gotten loud enough that the fair organizers would rather pay a stranger to referee than pick a side themselves.";

    public override string Objective => "Settle the dispute over the fair's judging - negotiate with the farmers in Allanor.";

    public override City City => City.Allanor;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var tiebreak = new DialogueNode
            {
                Text = "Reweighed properly, the two pumpkins come out within an ounce of each other - close enough that the fair's own rulebook has to settle it, not the scale.",
                Options =
                [
                    new DialogueOption { Text = "Dig up the fair's old rulebook for its actual tiebreak criterion.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Just flip a coin in front of both farmers.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Declare it a tie and split the prize.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Pick whichever pumpkin you personally like better.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say a near-tie is unjudgeable and declare no winner at all.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var reweigh = new DialogueNode
            {
                Text = "You find the fair's scale in a back tent - and one weight in the set is noticeably worn smoother than the others, as if it's been swapped in and out a lot.",
                Options =
                [
                    new DialogueOption { Text = "Reweigh both pumpkins yourself with a different, unworn weight set.", Outcome = DialogueOutcome.Continue, NextNode = tiebreak },
                    new DialogueOption { Text = "Accuse the judge of rigging the scale for a bribe.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Suggest the fair simply buy a new, sealed weight set for next year.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say a worn weight proves nothing and drop it.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Quietly pocket the worn weight so no one can check again.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both farmers have their pumpkins wheeled out on carts, each insisting the fair's scale must be wrong about the other's.",
                Options =
                [
                    new DialogueOption { Text = "Ask to inspect the fair's scale and weights yourself.", Outcome = DialogueOutcome.Continue, NextNode = reweigh },
                    new DialogueOption { Text = "Suggest declaring both pumpkins joint winners this year.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Propose a rematch next season with a fresh scale.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them a pumpkin isn't worth this much shouting.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse one farmer of hollowing his pumpkin out to cheat the weight.", Outcome = DialogueOutcome.Danger }
                ]
            };
        }
    }
}
