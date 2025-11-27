using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class BootsRiding : Thing
{
	public override string Name => "Boots, riding";

	public override Money Price => new(0, 2, 0);

    public override string Description => "Tall, heavy leather boots that reach near the knee. Designed to protect the legs from chafing whilst astride a horse and built to withstand the rigours of the saddle.";
}
