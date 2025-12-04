using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Vampire : LivingDead
{
    public Vampire()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        Speed = 100;
        AttackValue = 80;
        DefenseValue = 120;
        InitiatingValue = 32;
        AttacksPerRound = 2;
        HealthPoints = 40;
        AstralMagicResistance = Byte.MaxValue;
        MentalMagicResistance = Byte.MaxValue;
        PoisonResistance = Byte.MaxValue;
        Intelligence = Intelligence.High;
        Alignment = Enums.Alignment.ChaosDeath;
        ExperiencePoints = 4000;
        NecrographyDepartment = NecrographyDepartment.BloodDrinkingUndead;
    }

    [DiceThrow(ThrowType._1D6)]
    public override byte GetDamage() => (byte)DiceThrow._1D6();

    public override byte GetNumberAppearing() => 1;
}
