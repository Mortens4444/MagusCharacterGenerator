using M.A.G.U.S.Classes.Believer;
using M.A.G.U.S.Classes.Believer.Ranagol;
using M.A.G.U.S.Classes.Fighter;
using M.A.G.U.S.Classes.Sorcerer;
using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Utils;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class ChaosSpawn : Creature
{
    public ChaosSpawn()
    {
        Occurrence = Occurrence.Rare;
        Size = Size.Human;
        PlacesOfOccurrence =
            TerrainType.CursedLand |
            TerrainType.Underground |
            TerrainType.InnerTerritory |
            TerrainType.OldDilapidatedBuilding;

        var classes = new[]
        {
            typeof(Warrior),
            typeof(Warrior),
            typeof(Warrior),
            typeof(Warrior),
            typeof(Assassin),
            typeof(Assassin),
            typeof(Knight),
            typeof(RanagolPaladin),
            typeof(Warlock),
            typeof(Wizard)
        };

        var classSelector = RandomProvider.GetSecureRandomInt(0, classes.Length);
        var level = RandomProvider.GetSecureRandomInt(6, 16);
        var @class = ClassCreator.GetClass(classes[classSelector], level, false);

        AttackValue = (@class.AttackBaseValue * 2) + 10;
        DefenseValue = (@class.DefenseBaseValue * 2) + 10;
        InitiateValue = (@class.InitiateBaseValue * 2) + 5;
        AimValue = @class.AimBaseValue > 0 ? (@class.AimBaseValue * 2) : 0;

        HealthPoints = @class.Health + 10;
        PainTolerancePoints = @class.BasePainTolerancePoints + 20;

        AstralMagicResistance = @class.AstralMagicResistance + 10;
        MentalMagicResistance = @class.MentalMagicResistance + 10;
        PoisonResistance = 10 + level;

        Psi = new PsiPyarron();
        PsiPoints = 40 + (level * 5);

        Intelligence = Enums.Intelligence.High;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = (ulong)level * 1000;
    }

    public override string Name => "Chaos Spawn";

    public override double AttacksPerRound => 2;

    [DiceThrow(ThrowType._1D3)]
    public override int GetDamage() => DiceThrow._1D3();

    [DiceThrowModifier(1)]
    public override int GetNumberAppearing() => 1;

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];
}