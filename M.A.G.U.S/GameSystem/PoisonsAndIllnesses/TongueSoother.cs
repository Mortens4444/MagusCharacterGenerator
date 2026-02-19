using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.GameSystem.PoisonsAndIllnesses;

public class TongueSoother : Poison
{
    public override string Name => "Tongue Soother";

    public override Money Price => new(2);

    public override string Description => "Level 7 weapon poison, meaning it takes effect upon entering the bloodstream, but it affects the nervous system (II.). It causes nausea or a peculiar stupor. Its effect is rapid and lasts for a medium duration. The victim is not completely incapacitated—they remain aware of the outside world, and their Combat Values are only reduced by the penalties described under \"Stupor\"—however, they almost entirely lose their Willpower (-10). Under these circumstances, they will reveal almost anything their interrogators desire. Originally used by Kráni agents throughout Ynev, it was one of their most dreaded tools. Over the years, the secret of the recipe leaked, and today every reputable poison-master knows it.";

    public override PoisonDuration PoisonDuration => PoisonDuration.MediumDuration;

    public override PoisonOnsetTime PoisonOnsetTime => PoisonOnsetTime.Fast;

    public override PoisonType PoisonType => PoisonType.NervousSystem;

    public override IReadOnlyList<PoisonEffect> PoisonEffects => [PoisonEffect.Nausea, PoisonEffect.Stupor];

    public override int Level => 7;
}
