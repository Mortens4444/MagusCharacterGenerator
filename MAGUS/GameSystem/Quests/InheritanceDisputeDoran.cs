using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class InheritanceDisputeDoran : Quest
{
    public override string Name => "A Question of Blood";

    public override string Description => "A minor Doranian house is locked in a bitter inheritance dispute, and the younger sibling believes the elder forged the late lord's final will. She needs proof, not swords.";

    public override string Objective => "Find evidence of whether the will was forged - negotiate with the elder sibling in Doran.";

    public override City City => City.Doran;

    public override Money MoneyReward => new(0, 5, 0);

    public override ulong ExperienceReward => 35;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var pressPriest = new DialogueNode
            {
                Text = "\"Just the family priest,\" he says, too quickly. \"He's since retired. Traveled south, I believe.\"",
                Options =
                [
                    new DialogueOption { Text = "A priest doesn't simply vanish after witnessing a lord's will. Press him for the priest's actual whereabouts.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Offer to keep his secret quiet if he privately admits it now.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Let it go for now and thank him.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Threaten to report him to the magistrate regardless.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var compareLetters = new DialogueNode
            {
                Text = "He hesitates - just a moment - then produces a stack of old correspondence. \"Compare away,\" he says, knuckles white on the desk.",
                Options =
                [
                    new DialogueOption { Text = "Point out the signature's flourish doesn't match the older letters - and stop there.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Press further: ask who else was in the room when the will was signed.", Outcome = DialogueOutcome.Continue, NextNode = pressPriest },
                    new DialogueOption { Text = "Accept the letters without really examining them, and thank him.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Demand he hand over the will itself for a wizard to examine.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var watchHisHands = new DialogueNode
            {
                Text = "He talks at length about his father's final days, his hands steady the whole time - either innocent, or very good at this.",
                Options =
                [
                    new DialogueOption { Text = "Ask directly whether he had anything to do with the will's wording, then push into the letters.", Outcome = DialogueOutcome.Continue, NextNode = compareLetters },
                    new DialogueOption { Text = "Thank him and leave, satisfied he's telling the truth.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Search the study for ink and quill while he's distracted, and leave it at that.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };

            return new DialogueNode
            {
                Text = "The elder sibling receives you in the manor's study, the disputed will laid flat on the desk. \"I don't know why my sister sent you. The will is exactly as our father wrote it.\"",
                Options =
                [
                    new DialogueOption { Text = "Accuse him outright of forging his father's signature.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Ask calmly to compare the will against an older letter in his hand.", Outcome = DialogueOutcome.Continue, NextNode = compareLetters },
                    new DialogueOption { Text = "Offer to keep quiet about your suspicions - for a cut of the inheritance.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Mention, casually, that you've already spoken with the notary who witnessed the real will - and watch him flinch.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say nothing, and study his hands as he speaks.", Outcome = DialogueOutcome.Continue, NextNode = watchHisHands }
                ]
            };
        }
    }
}
