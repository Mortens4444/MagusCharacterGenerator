namespace M.A.G.U.S.Things.Armors;

public abstract class Armor : Thing
{
    public virtual int ArmorCheckPenalty => 0;

    public virtual int ArmorClass => 0;
}
