using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class SwordSheathOrnate : Thing
{
	public override string Name => "Sword sheath, ornate";

	public override Money Price => new(0, 6, 0);

    public override string Description => "A lavish scabbard, often covered in embossed leather, velvet, or inlaid with precious metals. A mark of a wealthy or esteemed warrior.";
}
