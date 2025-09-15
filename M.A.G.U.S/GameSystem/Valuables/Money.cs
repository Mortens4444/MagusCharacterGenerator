namespace M.A.G.U.S.GameSystem.Valuables;

public class Money(uint gold, uint silver = 0, uint copper = 0)
{
    public static readonly Money Free = new(0);

    public uint Mithrill { get; set; }

    public uint Gold { get; set; } = gold;

    public uint Silver { get; set; } = silver;

    public uint Copper { get; set; } = copper;
}
