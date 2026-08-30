using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Magic.Spells.Priest;
using MAGUS.Races;
using MAGUS.Things.Food;

namespace MAGUS.Test;

[TestFixture]
public class CreateFoodSpellTests
{
    private static Character CreateCharacter() => new(new Settings(true), "Test", new Human(), new Craftsman());

    [Test]
    public void OnHit_AddsLunchDinnerToTargetEquipment()
    {
        var caster = CreateCharacter();
        var target = CreateCharacter();
        var spell = new CreateFood();

        spell.OnHit(caster, target);

        Assert.That(target.Equipment.OfType<LunchDinner>().Count(), Is.EqualTo(1));
    }

    [Test]
    public void OnHit_TargetingSelf_AddsLunchDinnerOnce()
    {
        var caster = CreateCharacter();
        var spell = new CreateFood();

        spell.OnHit(caster, caster);

        Assert.That(caster.Equipment.OfType<LunchDinner>().Count(), Is.EqualTo(1));
    }

    [Test]
    public void GetDamage_IsZero()
    {
        Assert.That(new CreateFood().GetDamage(), Is.EqualTo(0));
    }
}
