using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class RivalScholarErion : Quest
{
    public override string Name => "A Matter of Attribution";

    public override string Description => "Two scholars in Erion are accusing each other of stealing credit for the same minor discovery, and the college has asked a disinterested outsider to hear both sides before the argument spills into the lecture halls.";

    public override string Objective => "Hear out both scholars and settle the dispute - negotiate with them in Erion.";

    public override City City => City.Erion;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var decideOrder = new DialogueNode
            {
                Text = "Both agree, grudgingly, that both names belong on it - but now neither will budge on whose name goes first, which in Erion's halls carries real weight come the next round of funding.",
                Options =
                [
                    new DialogueOption { Text = "Propose alphabetical order, removing personal judgment from it entirely.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Just pick whichever scholar seems more senior and let it stand.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Refuse to weigh in on the order and leave them to fight it out.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Tell them the order doesn't matter and they're both being petty about it.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var contribution = new DialogueNode
            {
                Text = "The junior scholar did the fieldwork; the senior one wrote up the theory - and now each insists the other's part was the easy half.",
                Options =
                [
                    new DialogueOption { Text = "Point out both halves were necessary and both names belong on it - then settle whose comes first.", Outcome = DialogueOutcome.Continue, NextNode = decideOrder },
                    new DialogueOption { Text = "Rule in favor of whoever did the fieldwork.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Rule in favor of whoever wrote the theory.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Suggest the college archivist decide instead, formally.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell the junior scholar their work was clearly the lesser contribution.", Outcome = DialogueOutcome.Danger }
                ]
            };

            return new DialogueNode
            {
                Text = "Both scholars slap the same monograph down on the table between you, each insisting their name belongs on the cover alone.",
                Options =
                [
                    new DialogueOption { Text = "Ask each to explain, separately, exactly what they contributed.", Outcome = DialogueOutcome.Continue, NextNode = contribution },
                    new DialogueOption { Text = "Suggest listing both names, with the senior scholar first, without hearing them out.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them credit doesn't matter as much as they think it does.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse one of them of stealing the whole idea outright.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to read the original notes yourself before deciding, skipping the conversation entirely.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
