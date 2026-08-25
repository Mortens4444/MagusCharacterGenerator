using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class DisputedBetrothalDoran : Quest
{
    public override string Name => "The Disputed Betrothal";

    public override string Description => "Two Doran merchant families arranged a marriage between their children years ago, and now that the wedding date has finally come, one family wants out and the other wants the dowry paid regardless.";

    public override string Objective => "Settle the dispute between the two families - negotiate with them in Doran.";

    public override City City => City.Doran;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var hiddenMatch = new DialogueNode
            {
                Text = "Pressed further, it turns out the family trying to back out has quietly arranged a far wealthier match for their child elsewhere - the children's own reluctance was real, but it isn't the only reason.",
                Options =
                [
                    new DialogueOption { Text = "Confront the family about the hidden second match, plainly.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Let the children's wishes stand and say nothing about the second match.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Decide the second match changes nothing and stay quiet about it.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Announce the hidden match to both families at once.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Decide this is too tangled and step back entirely.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var askChildren = new DialogueNode
            {
                Text = "Neither of the two actually being married wanted this in the first place - they admit it quietly, separately, the moment their parents step out of the room.",
                Options =
                [
                    new DialogueOption { Text = "Ask gently why they really don't want this marriage.", Outcome = DialogueOutcome.Continue, NextNode = hiddenMatch },
                    new DialogueOption { Text = "Tell both families the marriage should be called off, plainly.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Keep what the children said to yourself and let the parents decide anyway.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Announce what the children told you in front of both families at once.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say it isn't your place to get involved in a marriage contract.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both family heads have the old betrothal contract spread on the table, each reading a different clause aloud over the other.",
                Options =
                [
                    new DialogueOption { Text = "Ask to speak with the two who are actually meant to be married.", Outcome = DialogueOutcome.Continue, NextNode = askChildren },
                    new DialogueOption { Text = "Suggest renegotiating the dowry to something both families can accept.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Read the contract yourself and rule on the clause in question.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Accuse one family of trying to back out purely for money.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say marriage contracts are none of your business and leave.", Outcome = DialogueOutcome.Failure }
                ]
            };
        }
    }
}
