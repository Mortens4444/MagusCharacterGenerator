using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class DreamOintment : Poison
{
    public override string Name => "Dream Ointment";

    public override Money Price => new(0, 3);

    public override string Description => "Level 4 substance causing nausea or stupor. It is best classified as a nerve poison (II.). In some regions, especially in Abasis, it is crafted from jimsonweed by witches. Its effect is rapid and short-lived. It is a contact poison, meaning it only needs to touch the skin, but it cannot be mixed into food or drink. It causes vivid dreams and visions, thus witches often use it for prophetic dreams. Frequent use can lead to drug addiction.";

    public override PoisonDuration PoisonDuration => PoisonDuration.ShortDuration;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Fast;

    public override PoisonType PoisonType => PoisonType.NervousSystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.Nausea, PoisonEffect.Stupor];

    public override int Level => 4;
}
