using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Guardian : LivingDead
{
    public Guardian()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 110;
        DefenseValue = 120;
        InitiateValue = 25;
        AimValue = 20;

        HealthPoints = 35;

        AstralMagicResistance = Int32.MaxValue;
        MentalMagicResistance = Int32.MaxValue;
        PoisonResistance = Int32.MaxValue;

        Alignment = Alignment.Order;
        ExperiencePoints = 0;

        Psi = new PsiPyarron(); // Like in life
        Intelligence = Enums.Intelligence.High; // Like in life

        NecrographyDepartment = NecrographyDepartment.Ghost;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrow(ThrowType._1D8)]
    public override int GetNumberAppearing() => DiceThrow._1D8();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 120)];
}