using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class YerseniaHunter : Creature
{
    public YerseniaHunter()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 35;
        DefenseValue = 60;
        InitiateValue = 12;

        // A leírás szerint alakváltó vadászok, tipikusan apró farkas- vagy humanoid formában támadnak.
        // A sebzés változó, általában k6 körüli.
        AttackModes =
        [
            new MeleeAttack(new BodyPart("Primary attack", ThrowType._1D6), AttackValue)
        ];

        MinHealthPoints = 3;
        MaxHealthPoints = 5;
        PainTolerancePoints = 6;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Low;
        Alignment = Alignment.Death;
        ExperiencePoints = 10;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._3D6)]
    public override int GetNumberAppearing() => DiceThrow._3D6();

    public override string Name => "Yersenia hunter";

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 40)];
}