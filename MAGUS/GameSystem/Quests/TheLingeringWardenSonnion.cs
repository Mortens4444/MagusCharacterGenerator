using MAGUS.GameSystem.Places;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.GameSystem.Quests;

/// <summary>Sonnion is a ruined, uninhabited amund city, so like RivalDiggersSonnion this negotiation isn't offered by a city NPC - it's whatever still speaks from the deepest chamber, encountered while working the ruins.</summary>
public sealed class TheLingeringWardenSonnion : Quest
{
    public override string Name => "It Still Remembers Being Asked";

    public override string Description => "Something bound into Sonnion's deepest chamber isn't quite alive and isn't quite a construct either - it speaks, in fragments, and seems to be waiting for someone to answer correctly before it decides whether you're a threat.";

    public override string Objective => "Answer the lingering warden's questions - carefully - to pass safely through Sonnion's deepest chamber.";

    public override City City => City.Sonnion;

    public override Money MoneyReward => new(0, 10, 0);

    public override ulong ExperienceReward => 100;

    public override int MinLevel => 4;

    public override int MaxLevel => 7;

    public override DialogueNode? DialogueRoot
    {
        get
        {
            var prove = new DialogueNode
            {
                Text = "\"Words are cheap,\" it murmurs, unconvinced. \"Prove you understand what waits beyond, or turn back now.\"",
                Options =
                [
                    new DialogueOption { Text = "Admit you don't fully understand, but ask it to guide your steps rather than judge them.", Outcome = DialogueOutcome.Success },
                    new DialogueOption { Text = "Claim confidently that you already understand everything within.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Say understanding isn't required, only the will to pass.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Tell it that its riddles have delayed you long enough.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Bow and wait silently for it to decide.", Outcome = DialogueOutcome.Failure }
                ]
            };

            var explain = new DialogueNode
            {
                Text = "\"The one who sealed this place is long dust,\" it says, almost patient. \"But you may yet answer for yourself. Why have you come?\"",
                Options =
                [
                    new DialogueOption { Text = "Say you came seeking knowledge, not plunder.", Outcome = DialogueOutcome.Continue, NextNode = prove },
                    new DialogueOption { Text = "Say you came for whatever treasure the chamber holds.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Say the dead have no claim on what the living need.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Ask what answer it actually wants to hear.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Offer to leave the chamber undisturbed if it lets you pass, without answering why you came at all.", Outcome = DialogueOutcome.PartialSuccess }
                ]
            };

            return new DialogueNode
            {
                Text = "A voice - dry, layered, not quite one voice at all - rises from the dark ahead. \"Name the one who sealed this place, or be judged an intruder.\"",
                Options =
                [
                    new DialogueOption { Text = "Answer honestly that you don't know, and ask it to explain instead.", Outcome = DialogueOutcome.Continue, NextNode = explain },
                    new DialogueOption { Text = "Recite the name of Sonnion itself, hoping the city's own name satisfies it.", Outcome = DialogueOutcome.PartialSuccess },
                    new DialogueOption { Text = "Guess a name at random.", Outcome = DialogueOutcome.Failure },
                    new DialogueOption { Text = "Draw your weapon and advance anyway.", Outcome = DialogueOutcome.Danger },
                    new DialogueOption { Text = "Stay silent and back away slowly.", Outcome = DialogueOutcome.Failure }
                ]
            };
        }
    }
}
