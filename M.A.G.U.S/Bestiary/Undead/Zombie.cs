using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Zombie : LivingDead
{
    public Zombie()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        AttackValue = 10;
        DefenseValue = 40;
        InitiatingValue = 0;
        HealthPoints = 15;
        AstralMagicResistance = Byte.MaxValue;
        MentalMagicResistance = Byte.MaxValue;
        PoisonResistance = Byte.MaxValue;
        Intelligence = Enums.Intelligence.None;
        Alignment = Enums.Alignment.ChaosDeath;
        ExperiencePoints = 15;
        NecrographyDepartment = NecrographyDepartment.UnconsciousUndead;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D100)]
    public override int GetNumberAppearing() => DiceThrow._1D100(); // Should be "Variable" (change to string?)

    public override string[] Sounds => ["zombie", "zombie_2", "zombie_3", "zombie_4", "zombie_eating"];

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 20)];
}
