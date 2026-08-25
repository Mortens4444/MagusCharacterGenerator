using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class FundingDisputeErion : Quest
{
    public override string Name => "The College's Purse";

    public override string Description => "Two department heads at Erion's college are both certain this year's limited funding belongs to their research alone, and the dean has decided an outsider's opinion might actually end the argument.";

    public override string Objective => "Help settle the funding dispute between the two departments - negotiate with them in Erion.";

    public override City City => City.Erion;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var altFunding = new DialogueNode
            {
                Text = "It turns out a merchant guild grant exists for exactly this kind of case - but someone has to actually draft and submit the application before the college's own deadline passes.",
                Options =
                [
                    new DialogueOption { Text = "Help draft the joint application yourself, so both departments get funded from the outside grant instead of fighting over the college's purse.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Point the departments toward the grant and let them apply on their own.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say chasing outside funding isn't your job and leave them to the original dispute.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse one department of having already secretly applied for the grant behind the other's back.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var spending = new DialogueNode
            {
                Text = "One department needs it for fieldwork travel; the other for rare texts that won't be available again for years.",
                Options =
                [
                    new DialogueOption { Text = "Ask if there's any other funding source - a private donor, a guild grant - that could cover part of this.", Outcome = DialogueOutcome.Continue, NextNode = altFunding },
                    new DialogueOption { Text = "Suggest splitting it by urgency - whichever opportunity expires first gets priority this year.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Rule in favor of the fieldwork, since it's ongoing.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Rule in favor of the rare texts, since they won't come again.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Tell the fieldwork department their research matters less.", Outcome = DialogueOutcome.Danger }
                ]
            };

            return new DialogueNode
            {
                Text = "Both department heads have brought their own ledgers, and both ledgers somehow prove they deserve the larger share.",
                Options =
                [
                    new DialogueOption { Text = "Ask each to explain what the funding would actually be spent on.", Outcome = DialogueOutcome.Continue, NextNode = spending },
                    new DialogueOption { Text = "Suggest splitting the funding evenly regardless of department size.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Recommend the dean simply decide, formally, and be done with it.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them research funding shouldn't matter this much to grown scholars.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse one department of padding their proposed budget.", Outcome = DialogueOutcome.Danger }
                ]
            };
        }
    }
}
