using M.A.G.U.S.Classes.Fighter;
using M.A.G.U.S.Classes.Rogue;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Utils;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Bestiary.Mythical;

public sealed class Hilvar : Creature
{
    public Hilvar()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        var classes = new[] { typeof(Warrior), typeof(Thief), typeof(Assassin) };
        var classSelector = RandomProvider.GetSecureRandomInt(0, 3);
        var level = RandomProvider.GetSecureRandomInt(10, 15);
        var @class = ClassCreator.GetClass(classes[classSelector], level, false);

        AttackValue = @class.AttackBaseValue + 15;
        DefenseValue = @class.DefenseBaseValue + 20;
        InitiateValue = @class.InitiateBaseValue + 10;
        AimValue = @class.AimBaseValue + 10;

        AttacksPerRound = 2;

        HealthPoints = @class.Health + 7;
        PainTolerancePoints = @class.BasePainTolerancePoints + 27;

        AstralMagicResistance = @class.AstralMagicResistance + 15;
        MentalMagicResistance = @class.MentalMagicResistance + 15;
        PoisonResistance = Int32.MaxValue;

        //if (@class.Qualifications.Has)
        //{
        //    Psi = selectedPsi;
        //    PsiPoints = psiPoints;
        //}

        Intelligence = Enums.Intelligence.High;
        Alignment = @class.Alignment;
        ExperiencePoints = 10000;
    }

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 140)];
}