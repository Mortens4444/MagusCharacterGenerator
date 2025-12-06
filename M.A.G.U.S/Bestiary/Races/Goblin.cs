using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Things.Weapons.CrushingWeapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Goblin : Creature
{
    public Goblin()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Small;
        Speed = 65;
        AttackValue = 25;
        DefenseValue = 60;
        InitiatingValue = 10;
        AimingValue = 0;
        AttackModes =
        [
            new MeleeAttack(new CarvedClub(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            new RangeAttack(new Shortbow(), AimingValue.Value)
        ];
        HealthPoints = 7;
        PainTolerancePoints = 12;
        PoisonResistance = 3;
        Intelligence = Intelligence.Low;
        Alignment = Enums.Alignment.Chaos;
        ExperiencePoints = 10;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._10D10)]
    public override int GetNumberAppearing() => DiceThrow._10D10();
}
