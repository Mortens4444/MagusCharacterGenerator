using MAGUS.Enums;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Animals;

public class HorseHeavyWar : Horse
{
    public HorseHeavyWar() : this(ThrowType._2D10) { }

    public HorseHeavyWar(ThrowType qualityRollMode) : base(qualityRollMode) { }

    public override string Name => "Horse, heavy war";

	public override Money Price => new(10, 0, 0);

    public override string Description => "The Charger of the Knight. A massive, powerfully muscled warhorse, heavily armoured and trained to ride into the thickest ranks of the enemy. Its weight and terrifying presence are its greatest weapons.";
}
