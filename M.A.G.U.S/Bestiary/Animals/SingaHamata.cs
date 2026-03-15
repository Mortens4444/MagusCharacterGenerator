using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Animals;

public sealed class SingaHamata : Creature
{
    public SingaHamata()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;

        PlacesOfOccurrence = TerrainType.Desert;

        AttackValue = 45;
        DefenseValue = 60;
        InitiateValue = 30;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Venomous bite", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 8;
        PainTolerancePoints = 17;

        PoisonResistance = 8;

        Intelligence = Enums.Intelligence.Animal;

        ExperiencePoints = 25;
    }

    [DiceThrowModifier(0)]
    public override int GetNumberAppearing() => 1;

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6(); // + poison

    public override string Name => "Singa hamata (Giant sand crawler spider)";

    public override string[] Images => ["singa_hamata.png"];

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.OnLand, 160)
    ];
}
