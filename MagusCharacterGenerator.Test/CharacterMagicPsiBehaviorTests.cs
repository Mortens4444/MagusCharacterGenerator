using MAGUS.Classes.Fighter;
using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.Classes.Sorcerer;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Magic;
using MAGUS.Races;

namespace MAGUS.Test;

[TestFixture]
public class CharacterMagicBehaviorTests
{
    [Test]
    public void TryEmpowerSpell_WithoutSorcery_ReturnsFalse()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        var spell = SpellCatalog.All[0];

        Assert.That(character.TryEmpowerSpell(spell, 1), Is.False);
    }

    [Test]
    public void TryEmpowerSpell_WithSorcery_SpendsManaAndBanksPower()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Wizard());
        if (character.Sorcery == null || character.ManaPoints <= 0)
        {
            Assert.Ignore("Generated wizard has no mana this run.");
            return;
        }

        var spell = SpellCatalog.All.First(s => s.School == character.Sorcery.School);
        var before = character.ManaPoints;

        var result = character.TryEmpowerSpell(spell, 1);

        Assert.That(result, Is.True);
        Assert.That(character.ManaPoints, Is.EqualTo(before - 1));
        Assert.That(character.SpellPowerBonus, Is.GreaterThan(0));

        character.ClearSpellPower();
        Assert.That(character.SpellPowerBonus, Is.EqualTo(0));
    }

    [Test]
    public void TryEmpowerSpell_InvalidAmounts_ReturnsFalse()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Wizard());
        var spell = SpellCatalog.All[0];

        Assert.That(character.TryEmpowerSpell(spell, 0), Is.False);
        Assert.That(character.TryEmpowerSpell(spell, -1), Is.False);
        Assert.That(character.TryEmpowerSpell(spell, Int32.MaxValue), Is.False);
    }
}

[TestFixture]
public class CharacterPsiBehaviorTests
{
    [Test]
    public void TryUsePsiSurge_WithoutPsi_ReturnsFalse()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());
        Assert.That(character.TryUsePsiSurge(1), Is.False);
    }

    [Test]
    public void TryUsePsiSurge_WithPsi_SpendsPointsAndBanksBonus()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Assassin());
        if (character.Psi == null || character.PsiPoints <= 0)
        {
            Assert.Ignore("Generated assassin has no psi points this run.");
            return;
        }

        var before = character.PsiPoints;
        var result = character.TryUsePsiSurge(1);

        Assert.That(result, Is.True);
        Assert.That(character.PsiPoints, Is.EqualTo(before - 1));
        Assert.That(character.PsiSurgeAttackBonus, Is.EqualTo(Character.PsiSurgeAttackValuePerPoint));

        character.ClearPsiSurge();
        Assert.That(character.PsiSurgeAttackBonus, Is.EqualTo(0));
    }

    [Test]
    public void TryUsePsiSurge_InvalidAmounts_ReturnsFalse()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Assassin());
        Assert.That(character.TryUsePsiSurge(0), Is.False);
        Assert.That(character.TryUsePsiSurge(-1), Is.False);
        Assert.That(character.TryUsePsiSurge(Int32.MaxValue), Is.False);
    }
}
