using MAGUS.Bestiary;
using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Turn;
using MAGUS.Interfaces;
using MAGUS.Models;
using MAGUS.Services;

namespace MAGUS.Test;

[TestFixture]
public class MysticResolutionTest
{
    private sealed class TestCreature : Creature
    {
        public TestCreature(int? astralMagicResistance = null, int? mentalMagicResistance = null, bool resistantToPsi = false)
        {
            AstralMagicResistance = astralMagicResistance;
            MentalMagicResistance = mentalMagicResistance;
            ResistantToPsi = resistantToPsi;
        }

        public override int GetNumberAppearing() => 1;

        public override int GetDamage() => 0;

        public override List<Speed> Speeds => [new Speed(TravelMode.OnLand, 10)];
    }

    private sealed class TestDiscipline : IPsiDiscipline
    {
        public string Name => "Test discipline";
        public int? Power => 10;
        public int PsiPointCost => 1;
        public MagicResistanceType ResistanceType => MagicResistanceType.Mental;
        public int CastingTimeInSegments => 1;
        public int DurationInRounds => 1;
        public int GetDamage() => 1;
    }

    private static InitiativeEntry CreateInitiative(Attacker attacker, Attacker target, Attack attack) => new()
    {
        Attacker = new CombatantRef(attacker),
        Target = new CombatantRef(target),
        SelectedAttack = attack,
        BaseInitiative = 0,
        RolledValue = 0
    };

    [Test]
    public async Task CreateAsync_Succeeds_WhenInitiateValueFarExceedsResistance()
    {
        var attacker = new TestCreature();
        var target = new TestCreature(mentalMagicResistance: 10);
        var attack = new PsiAttack(new TestDiscipline());
        var initiative = CreateInitiative(attacker, target, attack);

        var resolution = await MysticResolution.CreateAsync(initiative, new AutoCombatRollService(), "test", attack, AttackDirection.Front);

        Assert.That(resolution.IsSuccessful, Is.True);
        Assert.That(resolution.BypassesArmor, Is.True);
    }

    [Test]
    public async Task CreateAsync_Fails_WhenResistanceFarExceedsInitiateValue()
    {
        var attacker = new TestCreature();
        var target = new TestCreature(mentalMagicResistance: 500);
        var attack = new PsiAttack(new TestDiscipline());
        var initiative = CreateInitiative(attacker, target, attack);

        var resolution = await MysticResolution.CreateAsync(initiative, new AutoCombatRollService(), "test", attack, AttackDirection.Front);

        Assert.That(resolution.IsSuccessful, Is.False);
    }

    [Test]
    public async Task CreateAsync_AutoFails_AgainstPsiResistantCreature()
    {
        var attacker = new TestCreature();
        var target = new TestCreature(mentalMagicResistance: 0, resistantToPsi: true);
        var attack = new PsiAttack(new TestDiscipline());
        var initiative = CreateInitiative(attacker, target, attack);

        var resolution = await MysticResolution.CreateAsync(initiative, new AutoCombatRollService(), "test", attack, AttackDirection.Front);

        Assert.That(resolution.IsSuccessful, Is.False);
        Assert.That(resolution.RollValue, Is.EqualTo(0));
    }

    [Test]
    public void CreateOutOfPoints_IsAlwaysUnsuccessful()
    {
        var attack = new PsiAttack(new TestDiscipline());

        var resolution = MysticResolution.CreateOutOfPoints(attack, AttackDirection.Front);

        Assert.That(resolution.IsSuccessful, Is.False);
        Assert.That(resolution.BypassesArmor, Is.True);
    }
}
