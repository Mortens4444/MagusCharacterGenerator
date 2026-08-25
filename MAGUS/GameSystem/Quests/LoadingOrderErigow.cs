using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

public sealed class LoadingOrderErigow : Quest
{
    public override string Name => "First Come, First Loaded";

    public override string Description => "Two caravan masters have arrived at the same loading dock at the same hour, each with a signed slot from a different clerk, and neither is willing to wait out the season's best weather for the mountain roads.";

    public override string Objective => "Settle who loads first at the Erigow dock - negotiate with the caravan masters.";

    public override City City => City.Erigow;

    public override Money MoneyReward => new(0, 3, 0);

    public override ulong ExperienceReward => 20;

    public override int MinLevel => 1;

    public override int MaxLevel => 2;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var confirmArrivalWitness = new DialogueNode
            {
                Text = "The dock hands give conflicting accounts at first - two swear one caravan rolled in first, two swear the other - until you start comparing exactly when each crew started unloading.",
                Options =
                [
                    new DialogueOption { Text = "Cross-check both crews' accounts against the actual unloading times and settle it precisely.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Just believe whichever master seems more confident about it.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Give up trying to determine who arrived first.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse the dock hands of taking bribes to lie for one side.", Outcome = DialogueOutcome.Danger }
                ]
            };

            var slips = new DialogueNode
            {
                Text = "Both slips are genuine - two different clerks issued them without checking each other's ledgers first.",
                Options =
                [
                    new DialogueOption { Text = "Point out the mistake is the dockmaster's office, not either caravan's fault, and leave it there.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Suggest whichever caravan arrived at the dock first today loads first - and ask the dock crew to confirm which that was.", Outcome = DialogueOutcome.Continue, NextNode = confirmArrivalWitness },
                    new DialogueOption { Text = "Blame one of the caravan masters for not checking beforehand.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Insist both clerks be fired on the spot.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Say it's not your problem and walk away.", Outcome = DialogueOutcome.Failure }
                ]
            };

            return new DialogueNode
            {
                Text = "Both caravan masters have their signed dock slips out, waving them at you like proof of anything.",
                Options =
                [
                    new DialogueOption { Text = "Ask to see both slips and check which clerk actually issued them.", Outcome = DialogueOutcome.Continue, NextNode = slips },
                    new DialogueOption { Text = "Suggest loading both caravans simultaneously on opposite sides of the dock.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Flip a coin in front of both of them.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Tell them whoever complains loudest goes last, on principle.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Accuse one master of bribing the dockmaster for priority.", Outcome = DialogueOutcome.Danger }
                ]
            };
        }
    }
}
