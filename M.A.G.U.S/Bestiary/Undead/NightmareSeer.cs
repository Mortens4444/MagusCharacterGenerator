using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class NightmareSeer : LivingDead
{
    public NightmareSeer()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.None;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Average;

        ExperiencePoints = 10; // variable
        NecrographyDepartment = NecrographyDepartment.WanderingCorpse;
    }

    public override string Name => "Seer of Nightmares";

    public override string[] Images => ["nightmare_seer.png"];

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    [DiceThrowModifier(0)]
    public override int GetDamage() => 0;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 200)];
}