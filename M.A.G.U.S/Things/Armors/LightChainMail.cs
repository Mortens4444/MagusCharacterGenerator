using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class LightChainMail : Armor
{
	public override string Name => "Light chainmail";

	public override Money Price => new(10, 0, 0);

	public override int ArmorCheckPenalty => -1;

	public override int ArmorClass => 2;

	public override double Weight => 20;

    public override string Description => "A hauberk of smaller, lighter rings than standard chainmail, or mail made of less sturdy wire. It offers decent protection against slicing while preserving greater speed and agility.";
}
