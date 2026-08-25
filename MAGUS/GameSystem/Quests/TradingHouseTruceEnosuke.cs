using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class TradingHouseTruceEnosuke : Quest
{
    public override string Name => "Neither House Blinks First";

    public override string Description => "Two of Enosuke's oldest trading houses have let a decades-old grudge over dock priority boil into something uglier this season, and the harbor council wants it settled before it costs them all a season's trade.";

    public override string Objective => "Broker a truce between the two trading houses - negotiate with them in Enosuke.";

    public override City City => City.Enosuke;

    public override Money MoneyReward => new(0, 4, 0);

    public override ulong ExperienceReward => 25;

    public override int MinLevel => 1;

    public override int MaxLevel => 3;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var scheduleDetails = new DialogueNode
            {
                Text = "Agreeing the old grudge doesn't matter is one thing - agreeing on an actual dock schedule going forward is another argument entirely.",
                Options =
                [
                    new DialogueOption { Text = "Propose alternating priority by the tide, not the week, so neither house ever waits long.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Just split priority evenly by week and leave the details vague.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them to work out a schedule themselves now that they're talking.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Give the older house permanent priority since they raised it first.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Suggest the harbor council just assign berths randomly each morning.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var origin = new DialogueNode
            {
                Text = "The older factor finally admits it started over a shipment mix-up decades ago that nobody alive actually witnessed firsthand.",
                Options =
                [
                    new DialogueOption { Text = "Point out that whatever started it, neither of them was even there for it - and move on to fixing the schedule.", Outcome = DialogueOutcome.Continue, NextNode = scheduleDetails },
                    new DialogueOption { Text = "Suggest they both write off the old grudge and split priority evenly, without discussing details.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Ask the younger factor to apologize first, since they raised their voice last.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Declare the original mix-up must have been deliberate sabotage.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say some grudges just aren't worth solving and leave.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both factors sit at opposite ends of the same table, arms crossed, waiting for you to speak first so they don't have to.",
                Options =
                [
                    new DialogueOption { Text = "Ask what actually started the grudge in the first place.", Outcome = DialogueOutcome.Continue, NextNode = origin },
                    new DialogueOption { Text = "Suggest alternating dock priority week by week, without addressing the grudge itself.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them the harbor council will just revoke both houses' dock rights if they can't agree.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Side with whichever house seems wealthier.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Point out one factor is clearly still lying about last season's numbers.", Outcome = DialogueOutcome.Danger }
                ]
            };
        }
    }
}
