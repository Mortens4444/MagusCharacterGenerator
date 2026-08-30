using MAGUS.Classes.Believer.Sogron;
using MAGUS.Classes.NonPlayableCharacters;
using MAGUS.Classes.Sorcerer;
using MAGUS.Enums;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Languages;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;
using MAGUS.Races;

namespace MAGUS.Test;

[TestFixture]
public class FireMageSpecializationBehaviorTests
{
    private static Character CreateFireMage(int level, FireMageSpecialization specialization = FireMageSpecialization.None)
    {
        var fireMage = new FireMage(level, false) { Specialization = specialization };
        return new Character(new Settings(true), "Test", new Human(), fireMage);
    }

    [Test]
    public void GetCombatValueModifierForLevel_DestructiveFireBelowLevel5_ReturnsBaseRate()
    {
        var fireMage = new FireMage(1, false) { Specialization = FireMageSpecialization.DestructiveFire };

        Assert.That(fireMage.GetCombatValueModifierForLevel(4), Is.EqualTo(8));
    }

    [Test]
    public void GetCombatValueModifierForLevel_DestructiveFireAtOrAboveLevel5_ReturnsIncreasedRate()
    {
        var fireMage = new FireMage(1, false) { Specialization = FireMageSpecialization.DestructiveFire };

        Assert.That(fireMage.GetCombatValueModifierForLevel(5), Is.EqualTo(9));
        Assert.That(fireMage.GetCombatValueModifierForLevel(6), Is.EqualTo(9));
    }

    [Test]
    public void GetCombatValueModifierForLevel_LightOrNone_ReturnsBaseRateEvenAboveLevel5()
    {
        var light = new FireMage(1, false) { Specialization = FireMageSpecialization.Light };
        var none = new FireMage(1, false);

        Assert.That(light.GetCombatValueModifierForLevel(6), Is.EqualTo(8));
        Assert.That(none.GetCombatValueModifierForLevel(6), Is.EqualTo(8));
    }

    [Test]
    public void GetPainToleranceModifierFormula_DestructiveFireAtLevel5_UsesPlusThree()
    {
        var fireMage = new FireMage(1, false) { Specialization = FireMageSpecialization.DestructiveFire };

        var formula = fireMage.GetPainToleranceModifierFormula(5);

        Assert.That(formula, Is.Not.Null);
        Assert.That(formula!.Formula, Is.EqualTo("1D6"));
        Assert.That(formula.Modifier, Is.EqualTo(3));
    }

    [Test]
    public void GetPainToleranceModifierFormula_BelowLevel5_UsesPlusOne()
    {
        var fireMage = new FireMage(1, false) { Specialization = FireMageSpecialization.DestructiveFire };

        var formula = fireMage.GetPainToleranceModifierFormula(4);

        Assert.That(formula!.Modifier, Is.EqualTo(1));
    }

    [Test]
    public void CalculateCombatValueModifier_DestructiveFireAtLevel8_SplitsRateAtLevel5()
    {
        var character = CreateFireMage(8, FireMageSpecialization.DestructiveFire);
        var plainCharacter = CreateFireMage(8);

        // Levels 1-4 at 8/level, 5-8 at 9/level - not the old bug's flat 8 levels * 9/level (=72).
        Assert.That(character.TotalCombatValueModifier, Is.EqualTo((4 * 8) + (4 * 9)));
        Assert.That(plainCharacter.TotalCombatValueModifier, Is.EqualTo(8 * 8));
    }

    [Test]
    public void FutureQualifications_DestructiveFireAtLevel11_GrantsAllThreeLevelBands()
    {
        var character = CreateFireMage(11, FireMageSpecialization.DestructiveFire);

        Assert.That(character.Qualifications.OfType<HistoryLore>().Any(q => q.QualificationLevel == QualificationLevel.Base), Is.True);
        Assert.That(character.Qualifications.OfType<Leadership>().Any(q => q.QualificationLevel == QualificationLevel.Master), Is.True);
        Assert.That(character.Qualifications.OfType<MilitaryFormation>().Any(q => q.QualificationLevel == QualificationLevel.Master), Is.True);
        Assert.That(character.Qualifications.OfType<WeaponUse>().Any(q => q.QualificationLevel == QualificationLevel.Master), Is.True);
    }

    [Test]
    public void FutureQualifications_LightAtLevel11_GrantsAllLevelBands()
    {
        var character = CreateFireMage(11, FireMageSpecialization.Light);

        Assert.That(character.Qualifications.OfType<LegendLore>().Any(q => q.QualificationLevel == QualificationLevel.Base), Is.True);
        Assert.That(character.Qualifications.OfType<HistoryLore>().Any(q => q.QualificationLevel == QualificationLevel.Master), Is.True);
        Assert.That(character.Qualifications.OfType<AncientTongueLore>().Any(q => q.Language == AntientLanguage.OldGodonian && q.QualificationLevel == QualificationLevel.Master), Is.True);
    }

    [Test]
    public void ApplyFireMageSpecialization_Sogron_SwitchesClassAndKeepsExistingQualifications()
    {
        var character = CreateFireMage(5);
        character.BaseClass.ExperiencePoints = 1234;

        character.ApplyFireMageSpecialization(FireMageSpecialization.Sogron);

        Assert.That(character.BaseClass, Is.InstanceOf<SogronPriest>());
        Assert.That(character.BaseClass.Level, Is.EqualTo(5));
        Assert.That(character.BaseClass.ExperiencePoints, Is.EqualTo(1234UL));
        Assert.That(character.Deity, Is.EqualTo(Deity.Sogron));

        // Kept from Fire Mage...
        Assert.That(character.Qualifications.OfType<Sailing>().Any(), Is.True);
        // ...and gained from Priest.
        Assert.That(character.Qualifications.OfType<ReligionLore>().Any(q => q.QualificationLevel == QualificationLevel.Master), Is.True);
        Assert.That(character.Qualifications.OfType<SingingAndMakingMusic>().Any(), Is.True);
    }

    [Test]
    public void ApplyLevelUp_AfterSogronSwitch_GrantsSogronPriestFutureQualifications()
    {
        var character = CreateFireMage(5);
        character.ApplyFireMageSpecialization(FireMageSpecialization.Sogron);

        Assert.That(character.Qualifications.OfType<LegendLore>().Any(q => q.QualificationLevel == QualificationLevel.Master), Is.False);

        character.ApplyLevelUp(painToleranceIncrease: 0, manaIncrease: 0);

        Assert.That(character.Level, Is.EqualTo(6));
        Assert.That(character.Qualifications.OfType<LegendLore>().Any(q => q.QualificationLevel == QualificationLevel.Master), Is.True);
    }

    [Test]
    public void ApplyFireMageSpecialization_PickedLateAtLevel11_BackfillsEveryLevelBandAtOnce()
    {
        var character = CreateFireMage(11);

        character.ApplyFireMageSpecialization(FireMageSpecialization.DestructiveFire);

        Assert.That(character.Qualifications.OfType<HistoryLore>().Any(q => q.QualificationLevel == QualificationLevel.Base), Is.True);
        Assert.That(character.Qualifications.OfType<Leadership>().Any(q => q.QualificationLevel == QualificationLevel.Master), Is.True);
        Assert.That(character.Qualifications.OfType<MilitaryFormation>().Any(q => q.QualificationLevel == QualificationLevel.Master), Is.True);
    }

    [Test]
    public void ApplyFireMageSpecialization_CalledTwice_Throws()
    {
        var character = CreateFireMage(5, FireMageSpecialization.DestructiveFire);

        Assert.That(() => character.ApplyFireMageSpecialization(FireMageSpecialization.Light), Throws.InvalidOperationException);
    }

    [Test]
    public void ApplyFireMageSpecialization_NonFireMageCharacter_Throws()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new Craftsman());

        Assert.That(() => character.ApplyFireMageSpecialization(FireMageSpecialization.DestructiveFire), Throws.InvalidOperationException);
    }

    [Test]
    public void ApplyLevelUp_ExistingClassWithFutureQualifications_GrantsThemOnReachingTheGatedLevel()
    {
        // General regression test for the FutureQualifications-on-level-up fix - not FireMage-specific.
        var wizard = new Wizard(1, false);
        var character = new Character(new Settings(true), "Test", new Human(), wizard);

        Assert.That(character.Qualifications.OfType<Herbalism>().Any(), Is.False);

        character.ApplyLevelUp(0, 0);
        character.ApplyLevelUp(0, 0);
        character.ApplyLevelUp(0, 0);

        Assert.That(character.Level, Is.EqualTo(4));
        Assert.That(character.Qualifications.OfType<Herbalism>().Any(), Is.True);
    }
}
