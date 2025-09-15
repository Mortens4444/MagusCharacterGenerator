namespace M.A.G.U.S.Things;

public abstract class Thing
{
    public virtual string Name => GetType().Name;
}
