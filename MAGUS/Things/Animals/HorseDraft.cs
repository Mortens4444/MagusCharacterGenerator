using MAGUS.Enums;
using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Animals;

public class HorseDraft : Horse
{
    public HorseDraft() : this(ThrowType._2D10) { }

    public HorseDraft(ThrowType qualityRollMode) : base(qualityRollMode) { }

    public override string Name => "Horse, draft";

	public override Money Price => new(0, 8, 0);

    public override string Description => "A sturdy draught horse, specifically trained and broken to wear the yoke for pulling plows or massive waggons. Not bred for speed or grace, but for enduring labour.";
}
