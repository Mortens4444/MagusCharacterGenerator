using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Attributes;
using MAGUS.Models;
using MAGUS.Things.Weapons;

namespace MAGUS.Bestiary.Animals;

public sealed class Ymorre : Creature
{
    public Ymorre()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;
        Country = GameSystem.Places.Country.Tarin;
        PlacesOfOccurrence = TerrainType.Cave | TerrainType.Mountains;

        AttackValue = 35;
        DefenseValue = 80;
        InitiateValue = 15;
        AimValue = 28;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D3), AttackValue)
            // A köpés speciális támadás, szabálylogikában külön kezelendő lehet.
        ];

        HealthPoints = 3;
        PainTolerancePoints = 15;

        PoisonResistance = 7;

        Intelligence = Enums.Intelligence.Animal;
        ExperiencePoints = 18;
    }

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    [DiceThrow(ThrowType._3D10)]
    public override int GetNumberAppearing() => DiceThrow._3D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 90)];
}