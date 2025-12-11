using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;

namespace M.A.G.U.S.Bestiary.Undead;

public sealed class Werewolf : LivingDead
{
    public Werewolf()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        Speed = 20;
        AttackValue = 60;
        DefenseValue = 75;
        InitiatingValue = 25;
        PainTolerancePoints = 44;
        AstralMagicResistance = Byte.MaxValue;
        MentalMagicResistance = Byte.MaxValue;
        PoisonResistance = Byte.MaxValue;
        Intelligence = Enums.Intelligence.High;
        Alignment = Enums.Alignment.ChaosDeath;
        ExperiencePoints = 300;
        NecrographyDepartment = NecrographyDepartment.WanderingCorpse;
    }

    [DiceThrow(ThrowType._1D10)]
    public override int GetDamage() => DiceThrow._1D10();

    public override int GetNumberAppearing() => 1;

    public override string[] Sounds => ["werewolf_howl"];
}
