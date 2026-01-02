using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Mummy : LivingDead
{
    public Mummy()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        AttackValue = 70;
        DefenseValue = 110;
        InitiateValue = 20;
        HealthPoints = 18;
        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;
        Intelligence = Enums.Intelligence.High;
        Alignment = Enums.Alignment.ChaosDeath;
        //Psi = as in life
        ExperiencePoints = 3000; // For a 10th level priest
        NecrographyDepartment = NecrographyDepartment.NightMonster;
    }

    public override string Name => "Mummy (Muliphein)";

    public override string[] Images => ["mummy.png"];

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 60)];
}
