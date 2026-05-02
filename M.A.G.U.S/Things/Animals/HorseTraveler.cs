using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class HorseTraveler : Horse
{
    public HorseTraveler() : this(ThrowType._2D10) { }

    public HorseTraveler(ThrowType qualityRollMode) : base(qualityRollMode) { }

    public override string Name => "Horse, traveler";

	public override Money Price => new(1, 0, 0);

    public override string Description => "A common road horse, bred for speed and endurance over long distances. Suitable for messengers, scouts, and merchants who must reach their destination swiftly.";
}
