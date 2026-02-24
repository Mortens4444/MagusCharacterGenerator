using M.A.G.U.S.Enums;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class AstralVampire : Creature
{
    public AstralVampire()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Small;

        AttackValue = 0;
        DefenseValue = 0;
        InitiateValue = 0;
        AimValue = 0;

        AttackModes = [];

        HealthPoints = 0;
        PainTolerancePoints = 0;

        PoisonResistance = 0;
        AstralMagicResistance = 0;
        MentalMagicResistance = 0;

        Intelligence = Enums.Intelligence.Animal;

        ExperiencePoints = 300;

        Alignment = Alignment.None;
    }

    public override string Name => "Astral Vampire";

    public override int GetNumberAppearing() => 1;

    public override int GetDamage() => 0;

    public override List<Speed> Speeds =>
    [
        new Speed(TravelMode.InTheAir, 85)
    ];
}