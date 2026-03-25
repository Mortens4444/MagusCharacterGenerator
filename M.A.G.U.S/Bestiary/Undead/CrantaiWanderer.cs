using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Armors;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class CrantaiWanderer : LivingDead
{
    public CrantaiWanderer()
    {
        Armor = new NaturalArmor(6, 2); // Blacklurin pikkelyvért + Redlurin helmet
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 95;
        DefenseValue = 115;
        InitiateValue = 20;

        HealthPoints = 35;

        AstralMagicResistance = 6;
        MentalMagicResistance = 6;
        PoisonResistance = Int32.MaxValue;

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 950;
        NecrographyDepartment = NecrographyDepartment.NightMonster;

        Psi = new PsiPyarron();
        PsiPoints = 25;

        AttackModes =
        [
            new MeleeAttack(new CommonWeapon("Bluelurin longsword", 10, 20, 15, ThrowType._1D10, 4), AttackValue),
            //new MeleeAttack(new CommonWeapon("Redlurin dagger", 10, 20, 15, ThrowType._1D10, 4), AttackValue)
        ];
    }

    public override string Name => "Crantai Wanderer";

    [DiceThrow(ThrowType._2D6)]
    public override int GetNumberAppearing() => DiceThrow._2D6();

    public override int GetDamage() => DiceThrow._1D10() + 4;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}