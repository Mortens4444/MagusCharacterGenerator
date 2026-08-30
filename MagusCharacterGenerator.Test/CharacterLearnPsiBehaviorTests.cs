using MAGUS.Classes.Fighter;
using MAGUS.GameSystem;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications.Scientific.Psi;
using MAGUS.Races;

namespace MAGUS.Test;

[TestFixture]
public class CharacterLearnPsiBehaviorTests
{
    // A class with no innate psi at all (SirenariForestRanger.SpecialQualifications/Qualifications
    // grant none) - any Psi points here can only come from later learning a discipline via QP.
    private static Character CreateRanger()
    {
        var character = new Character(new Settings(true), "Test", new Human(), new SirenariForestRanger(1, false));
        character.Intelligence = 15;
        character.Astral = 15;
        character.Willpower = 18;
        return character;
    }

    /// <summary>
    /// Regression test for a reported bug: a level-1 Sirenari Forest Ranger with Int 15/Astral 15/Will
    /// 18 learned Psi at Base level via the Qualifications page, but PsiPoints stayed 0. Root cause -
    /// PsiPoints/MaxPsiPoints are cached (Character.Psi.cs's CalculatePsiPoints) and were previously
    /// only ever refreshed from the Intelligence setter, never from Learn() - so a freshly learned Psi
    /// qualification never triggered a recalculation until something unrelated happened to touch
    /// Intelligence again.
    /// </summary>
    [Test]
    public void Learn_PsiQualificationAtBase_RecalculatesPsiPointsImmediately()
    {
        var character = CreateRanger();
        Assume.That(character.PsiPoints, Is.EqualTo(0), "Ranger should start with no psi at all.");

        // Mirrors QualificationDetailsViewModel.CreateQualificationToLearn(): a fresh instance via
        // the type's parameterless constructor, then Character.Learn with the player's chosen level.
        var fresh = (Qualification)Activator.CreateInstance(typeof(PsiPyarron))!;
        character.Learn(fresh, QualificationLevel.Base);

        Assert.That(character.PsiPoints, Is.GreaterThan(0));
        Assert.That(character.MaxPsiPoints, Is.EqualTo(character.PsiPoints));
        Assert.That(character.Psi, Is.SameAs(fresh));
    }

    [Test]
    public void Learn_NonPsiQualification_DoesNotAffectPsiPoints()
    {
        var character = CreateRanger();

        var fresh = (Qualification)Activator.CreateInstance(typeof(PsiPyarron))!;
        character.Learn(fresh, QualificationLevel.Base);
        var afterPsiLearn = character.PsiPoints;

        character.Qualifications.Add(new MAGUS.Qualifications.Laical.Swimming());

        Assert.That(character.PsiPoints, Is.EqualTo(afterPsiLearn));
    }

    /// <summary>
    /// Documents a separate, narrower defect (not fixed here): PsiKyrMethod/PsiMonk/PsiSlanWay's
    /// parameterless constructor is hardcoded to Qualification(QualificationLevel.Master, 1) - used
    /// intentionally by the classes that grant one of these intrinsically at Master from level 1
    /// (Wizard/Monk/Blademaster/MartialArtist/Varjen) - but that same hardcoded ctor is also what
    /// Activator.CreateInstance(type) produces for the QP "Learn" flow, so "learning" one of these at
    /// Base via the Qualifications page actually still grants full Master-level psi points, since
    /// BaseQualificationLevel (private-set, only assignable from the constructor) never becomes
    /// nonzero and MasterQualificationLevel is left at 1 by Character.Learn. Left as-is: fixing the
    /// constructors risks changing the intended level-1-Master behavior for those five classes.
    /// </summary>
    [Test]
    public void Learn_PsiKyrMethodAtBase_StillGrantsMasterLevelPsiPoints()
    {
        var character = CreateRanger();

        var fresh = (Qualification)Activator.CreateInstance(typeof(PsiKyrMethod))!;
        Assert.That(fresh.BaseQualificationLevel, Is.EqualTo(0));
        Assert.That(fresh.MasterQualificationLevel, Is.EqualTo(1));

        character.Learn(fresh, QualificationLevel.Base);

        Assert.That(fresh.QualificationLevel, Is.EqualTo(QualificationLevel.Base));
        Assert.That(fresh.BaseQualificationLevel, Is.EqualTo(0));
        Assert.That(fresh.MasterQualificationLevel, Is.EqualTo(1));
        Assert.That(character.PsiPoints, Is.GreaterThan(0));
    }
}
