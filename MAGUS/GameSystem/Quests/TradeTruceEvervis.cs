using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class TradeTruceEvervis : Quest
{
    public override string Name => "A Generation of Grudges";

    public override string Description => "The two merchant houses feuding across Evervis have finally agreed to talk, mostly because both are losing money faster than they're hurting each other - but neither will be first to propose actual terms.";

    public override string Objective => "Help the two merchant houses agree on terms - negotiate with them in Evervis.";

    public override City City => City.Evervis;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var enforcement = new DialogueNode
            {
                Text = "Terms agreed on paper are one thing; neither house quite trusts the other not to quietly break them the moment you're gone.",
                Options =
                [
                    new DialogueOption { Text = "Suggest the harbor council itself witness and hold a copy of the agreement.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Have both heads shake hands in front of their own factors and call it settled.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them to just trust each other this time.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Warn both houses that you'll be watching them personally from now on.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Leave the enforcement question for them to sort out later.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var terms = new DialogueNode
            {
                Text = "One wants an apology and a public statement; the other wants the sabotaged shipments quietly compensated and nothing more said about it.",
                Options =
                [
                    new DialogueOption { Text = "Suggest both - private compensation, and a public statement that the matter is closed - then ask how it'll be kept.", Outcome = DialogueOutcome.Continue, NextNode = enforcement },
                    new DialogueOption { Text = "Push for the apology alone and let the compensation go.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Push for the compensation alone and let the apology go.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them to just sign something, anything, so you can leave.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse whichever house wants public embarrassment of just wanting revenge.", Outcome = DialogueOutcome.Danger }
                ]
            };

            return new DialogueNode
            {
                Text = "Both merchant house heads have agreed to sit in the same room, which is apparently as far as either was willing to compromise before you arrived.",
                Options =
                [
                    new DialogueOption { Text = "Ask each what they'd actually need to call it settled.", Outcome = DialogueOutcome.Continue, NextNode = terms },
                    new DialogueOption { Text = "Suggest a formal truce, brokered and witnessed publicly, without asking what either side actually wants.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Point out that continuing to fight is bankrupting them both.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Side with whichever house has been in Evervis longer.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse one house's factor of sabotage to their face, unprompted.", Outcome = DialogueOutcome.Danger }
                ]
            };
        }
    }
}
