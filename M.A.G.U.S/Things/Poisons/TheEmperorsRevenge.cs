using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Poisons;

public class TheEmperorsRevenge : Poison
{
    public override string Name => "The Emperor's Revenge";

    public override Money Price => new(100);

    public override string Description => "Level 9, multi-component poison. It is prepared by the poison-masters of the Toronian Imperial Court, who jealously guard the secret of its creation. It can only be mixed into food. It is unavailable in commerce; its production cost is approximately 100 gold pieces. The Emperor has a small amount slipped into the food of every confidant of questionable loyalty. It affects the digestive system, is latent, and causes fainting or death unless the victim receives a specific antidote. If the person falls from grace, the Emperor lets them flee, knowing they cannot access the cure.";

    public override PoisonDuration PoisonDuration => PoisonDuration.SingleEffect;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Latent;

    public override PoisonType PoisonType => PoisonType.DigestiveSystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.Fainting, PoisonEffect.Death];

    public override int Level => 9;
}
