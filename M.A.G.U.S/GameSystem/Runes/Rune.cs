namespace M.A.G.U.S.GameSystem.Runes;

public abstract class Rune
{
    public virtual char Sign { get; }
 
    public virtual string Name { get; }
    
    public virtual string Meaning { get; }

    public virtual string Equivalent { get; }
}
