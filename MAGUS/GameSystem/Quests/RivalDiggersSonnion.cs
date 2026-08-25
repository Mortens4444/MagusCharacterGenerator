using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Sonnion is a ruined, uninhabited amund city, so like LostTextSonnion this has no city NPC to hand it out - the rival crew is simply who you run into while working the ruins.</summary>
public sealed class RivalDiggersSonnion : Quest
{
    public override string Name => "Two Sets of Footprints";

    public override string Description => "Someone else has been picking through Sonnion's ruins recently, and their tracks lead straight to a rival crew camped in the collapsed colonnade, eyeing the same buried vault you were sent to check.";

    public override string Objective => "Deal with the rival diggers camped in Sonnion's ruins - negotiate with them, if they'll listen.";

    public override City City => City.Sonnion;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 30;

    public override int MinLevel => 2;

    public override int MaxLevel => 3;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var workingOutTerms = new DialogueNode
            {
                Text = "The leader's willing to share, but haggles hard over the split - two-thirds for her crew, she says, for \"finding it first,\" pointing at scuff marks in the dust that could mean anything at all.",
                Options =
                [
                    new DialogueOption { Text = "Hold firm for an even fifty-fifty split - you got here the same time.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Concede to the two-thirds demand just to avoid a fight over it.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Walk away from the deal entirely rather than accept less than half.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Call her bluff about the scuff marks and accuse her of lying about finding it first.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var howFound = new DialogueNode
            {
                Text = "The leader shrugs. \"Same as you, probably. Old map, older rumor. Doesn't much matter now, does it.\"",
                Options =
                [
                    new DialogueOption { Text = "Suggest working the vault together, splitting the risk and the find - then hammer out the actual terms.", Outcome = DialogueOutcome.Continue, NextNode = workingOutTerms },
                    new DialogueOption { Text = "Accuse them of following you here specifically.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Ask them to just wait outside while you open it alone.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Agree it doesn't matter and propose a coin flip for who goes first.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say nothing and reach for the vault yourself.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "The rival crew doesn't reach for weapons yet - but their hands hover close, and their leader steps forward first.",
                Options =
                [
                    new DialogueOption { Text = "Propose splitting whatever the vault holds evenly between both crews.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Ask how they even found this ruin - Sonnion isn't exactly on any map.", Outcome = DialogueOutcome.Continue, NextNode = howFound },
                    new DialogueOption { Text = "Tell them to leave now, or else.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Offer to walk away and let them have the vault.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Point out the vault looks rigged to collapse if forced open by two crews fighting over it.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };
        }
    }
}
