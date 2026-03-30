using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.Models;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Things.Weapons.StabbingWeapons;

namespace M.A.G.U.S.Bestiary.Races;

public sealed class Successor : Creature
{
    public Successor()
    {
        Occurrence = Occurrence.VeryRare;
        Size = Size.Human;
        PlacesOfOccurrence = TerrainType.Anywhere;

        AttackValue = 20;
        DefenseValue = 60;
        InitiateValue = 8;
        AimValue = 0;

        AttackModes =
        [
            new MeleeAttack(new Dagger(), AttackValue),
            new MeleeAttack(new ShortSword(), AttackValue),
            //new RangedAttack(new Blowgun(), AimValue)
        ];

        //Armor = new ClothArmor();

        HealthPoints = 8;
        PainTolerancePoints = 18;

        AstralMagicResistance = 132;
        MentalMagicResistance = 144;
        PoisonResistance = 2;

        Psi = new PsiKyrMethod();
        PsiPoints = 120;
        ManaPoints = 100;

        Intelligence = Enums.Intelligence.Outstanding;
        Alignment = Alignment.ChaosDeath;
        ExperiencePoints = 5000;
    }

    public override double AttacksPerRound => 1;

    [DiceThrow(ThrowType._1D10)]
    public override int GetNumberAppearing() => DiceThrow._1D10();

    [DiceThrow(ThrowType._1D6)]
    public override int GetDamage() => DiceThrow._1D6();

    public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 100)];

    //public override int StealthChance => 75;

    //public override int HidingChance => 75;

    //public override string[] Sounds => ["successor_whisper", "successor_chant"];

    //public bool HasAquirPsiMethod => true;

    //public int PsiSkillLevel => 20;

    //public bool CanUseAquirMagic => true;
}
