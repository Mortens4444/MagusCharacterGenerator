using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class AttributionRightsTalasea : Quest
{
    public override string Name => "Whose Discovery";

    public override string Description => "Two academics both claim they were first to identify the awakening magic in Talasea's walls, and the college won't fund either one's follow-up study until someone settles who gets the credit.";

    public override string Objective => "Hear out both academics and settle who gets credit for the discovery.";

    public override City City => City.Talasea;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 2;

    public override int MaxLevel => 3;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var fieldwork = new DialogueNode
            {
                Text = "Digging further, it turns out neither academic was actually present when the wall first hummed - a groundskeeper noticed it days before either of them wrote a word down, and never thought to mention it to anyone important.",
                Options =
                [
                    new DialogueOption { Text = "Insist the groundskeeper gets named alongside both academics.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Let the academics keep the credit and quietly thank the groundskeeper yourself.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Decide the groundskeeper doesn't count since she isn't a scholar.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Announce loudly that both academics have been chasing credit that isn't even theirs.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say this has gotten too complicated and walk away.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var dates = new DialogueNode
            {
                Text = "One set of notes is dated two days before the other - but the handwriting on the earlier pages looks suspiciously similar to the later academic's.",
                Options =
                [
                    new DialogueOption { Text = "Ask around the college for anyone else who might have noticed the wall first.", Outcome = DialogueOutcome.Continue, NextNode = fieldwork },
                    new DialogueOption { Text = "Suggest sending both sets to a neutral archivist for verification.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Accuse the earlier academic of forging their dates.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Rule in favor of whoever's notes are dated first, no further questions.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Say you can't tell and leave the matter unresolved.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both academics arrived at once, each producing what they insist is the definitive first observation notes.",
                Options =
                [
                    new DialogueOption { Text = "Ask to see both sets of notes and compare their dates.", Outcome = DialogueOutcome.Continue, NextNode = dates },
                    new DialogueOption { Text = "Suggest they publish jointly, crediting the discovery to both.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them the college can decide, and it isn't your concern.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Point out that one set of notes looks copied from the other.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to write up a neutral account yourself, crediting neither by name.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
