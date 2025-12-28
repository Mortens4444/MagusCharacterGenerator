using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Werewolf : LivingDead
{
    public Werewolf()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        AttackValue = 60;
        DefenseValue = 75;
        InitiateValue = 25;
        PainTolerancePoints = 44;
        AstralMagicResistance = byte.MaxValue;
        MentalMagicResistance = byte.MaxValue;
        PoisonResistance = byte.MaxValue;
        Intelligence = Enums.Intelligence.High;
        Alignment = Enums.Alignment.ChaosDeath;
        ExperiencePoints = 300;
        NecrographyDepartment = NecrographyDepartment.WanderingCorpse;
    }

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override int GetNumberAppearing() => 1;

    public override string[] Sounds => ["werewolf_howl"];

    public override List<Speed> Speeds => [new Speed(TravelMode.InTheAir, 20), new Speed(TravelMode.OnLand, description: "Possessed body")];
}
