using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Travelling;

public class Ferryman : Thing
{
	public override Money Price => new(0, 0, 20);

    public override string Description => "The skilled boatman who owns and operates the ferry. He holds the vital power to grant or deny passage across a waterway, and always expects his due coin.";
}
