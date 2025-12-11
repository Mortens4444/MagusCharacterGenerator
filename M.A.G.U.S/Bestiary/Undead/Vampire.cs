using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Things.Weapons;
using M.A.G.U.S.Things.Weapons.CrushingWeapons;
using M.A.G.U.S.Things.Weapons.RangedWeapons;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;
using System.ComponentModel;

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
        AttackModes =
        [
            //new MeleeAttack(new BodyPart("Tooth1", GetDamage), AttackValue),
            new MeleeAttack(new BodyPart("Tooth", ThrowType._1D6), AttackValue),
            //new MeleeAttack("Tooth3", AttackValue, () => GetDamage()),
            new MeleeAttack(new Longsword(), AttackValue)
        ];
        HealthPoints = 40;
        AstralMagicResistance = Byte.MaxValue;
        MentalMagicResistance = Byte.MaxValue;
        PoisonResistance = Byte.MaxValue;
        Intelligence = Enums.Intelligence.High;
        Alignment = Enums.Alignment.ChaosDeath;
        ExperiencePoints = 4000;
        NecrographyDepartment = NecrographyDepartment.BloodDrinkingUndead;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override int GetNumberAppearing() => 1;
}
