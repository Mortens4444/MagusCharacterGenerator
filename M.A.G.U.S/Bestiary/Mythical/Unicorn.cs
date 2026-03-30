using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Unicorn : Creature
{
    public Unicorn()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Big;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 80;
        DefenseValue = 110;
        InitiateValue = 30;

        AttackModes =
        [
            new MeleeAttack(new BodyPart("Left forehoof", ThrowType._1D3), AttackValue),
            new MeleeAttack(new BodyPart("Right forehoof", ThrowType._1D3), AttackValue),
            new MeleeAttack(new BodyPart("Horn", ThrowType._1D10), AttackValue),
            new MeleeAttack(new BodyPart("Bite", ThrowType._1D6), AttackValue),
            new MeleeAttack(new BodyPart("Rear kick", ThrowType._1D6), AttackValue)
        ];

        HealthPoints = 30;
        PainTolerancePoints = 60;

        AstralMagicResistance = 15;
        MentalMagicResistance = 18;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.Average;
        Alignment = Alignment.Life;
        ExperiencePoints = 250;
    }

    public override double AttacksPerRound => 4; // 2

    [DiceThrow(ThrowType._1D6)]
    public override int GetNumberAppearing() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 150)];

    //public override string[] Sounds => ["horse_neigh", "unicorn_call"];

    public bool RequiresLifeAlignedOwner => true;

    public int ManaPointsRequiredPerDayWithoutFood => 20;

    public bool HasMagicalHorn => true;
}