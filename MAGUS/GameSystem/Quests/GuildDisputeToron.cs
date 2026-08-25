using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class GuildDisputeToron : Quest
{
    public override string Name => "A Question of Dues";

    public override string Description => "Two rival guild chapters in Toron's market district are refusing to pay each other's dues for a shared warehouse, each certain the other owes back rent going back years.";

    public override string Objective => "Settle the dues dispute between the guild chapters - negotiate with them in Toron.";

    public override City City => City.Toron;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var restitution = new DialogueNode
            {
                Text = "The chapter that benefited from the altered entry offers a partial repayment on the spot - a fraction of what the real numbers say they actually owe.",
                Options =
                [
                    new DialogueOption { Text = "Insist on the full amount the ledger shows, backed by the evidence you found.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Accept the partial repayment they're offering to end it quickly.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Let the two chapters negotiate the amount between themselves and step back.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the offering chapter of trying to lowball their way out of real guilt.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var ledger = new DialogueNode
            {
                Text = "The numbers match almost everywhere - except one entry, years back, that was clearly altered after the fact.",
                Options =
                [
                    new DialogueOption { Text = "Point out the altered entry and who benefits from it, and press for what's owed.", Outcome = DialogueOutcome.Continue, NextNode = restitution },
                    new DialogueOption { Text = "Accuse the chapter that benefits of forging it, loudly, in front of both crews.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Suggest writing off the old entry and starting the ledger fresh from today.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say the altered entry proves nothing and walk away.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Side with whichever chapter head seems more trustworthy.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both chapter heads have a ledger open, each insisting the other's numbers are the ones that are wrong.",
                Options =
                [
                    new DialogueOption { Text = "Ask to compare both ledgers, line by line.", Outcome = DialogueOutcome.Continue, NextNode = ledger },
                    new DialogueOption { Text = "Suggest splitting the warehouse rent down the middle going forward.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them the market wardens should audit both chapters instead.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Accuse one chapter of cooking their books outright.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say the dispute isn't worth your time and leave.", Outcome = DialogueOutcome.Failure }
                ]
            };
        }
    }
}
