using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Umich : Creature
{
    public Umich()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Strike I.", ThrowType._2D10), 95),
            new MeleeAttack(new BodyPart("Strike II.", ThrowType._2D10), 95),
            new MeleeAttack(new BodyPart("Strike III.", ThrowType._1D10), 95)
        ];
        AttackValue = 95;
        DefenseValue = 130;
        InitiateValue = 45;
        HealthPoints = 50;
        HealthPoints = 110;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = 11;
        ResistantToPsi = true;
        Intelligence = Enums.Intelligence.High;
        Alignment = Enums.Alignment.Chaos;
        ExperiencePoints = 350;
    }

    [DiceThrow(ThrowType._2D10)]
    public override int GetDamage() => DiceThrow._2D10();

    public override int GetNumberAppearing() => DiceThrow._1D2();

    public override string[] Images => ["umich.png", "umich_2.png"];

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 20)];
}
