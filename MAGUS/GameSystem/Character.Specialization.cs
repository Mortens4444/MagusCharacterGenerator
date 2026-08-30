using MAGUS.Classes.Believer.Sogron;
using MAGUS.Classes.Sorcerer;
using MAGUS.Enums;

namespace MAGUS.GameSystem;

public partial class Character
{
    /// <summary>
    /// Applies the level-5 Fire Mage specialization the player picked (Második Törvénykönyv, "A
    /// tűzvarázslók három Útja") - see CharacterViewModel.CheckPendingFireMageSpecializationAsync,
    /// which is what actually prompts for this. Destructive Fire and Light stay FireMage (their
    /// per-level rate/qualification changes are on FireMage itself); Sogron performs a real class
    /// switch to SogronPriest, keeping the character's level, XP and every qualification already
    /// learned as a Fire Mage, and adding Priest's base qualifications on top. Either way, any
    /// FutureQualifications already unlocked at the character's current level are granted
    /// immediately - covers both "picked exactly at level 5" and "picked late, already level 11".
    /// </summary>
    public void ApplyFireMageSpecialization(FireMageSpecialization specialization)
    {
        if (BaseClass is not FireMage fireMage || fireMage.Specialization != FireMageSpecialization.None)
        {
            throw new InvalidOperationException("This character has no pending Fire Mage specialization choice.");
        }

        if (specialization == FireMageSpecialization.None)
        {
            throw new ArgumentOutOfRangeException(nameof(specialization));
        }

        fireMage.Specialization = specialization;

        if (specialization == FireMageSpecialization.Sogron)
        {
            var sogronPriest = new SogronPriest(fireMage.Level, false)
            {
                ExperiencePoints = fireMage.ExperiencePoints,
                // Mirror every raw ability score from the old Class instance (not from Character's
                // own Strength/Willpower/etc, which already include a race bonus) - BuildQualifications'
                // Psi/AntisWalking gating reads the Class instance's own race-free scores, so this
                // preserves whatever gating outcome the character already had (e.g. Priest.Qualifications'
                // PsiPyarron(Master) grant depends on it).
                Strength = fireMage.Strength,
                Quickness = fireMage.Quickness,
                Dexterity = fireMage.Dexterity,
                Stamina = fireMage.Stamina,
                Health = fireMage.Health,
                Beauty = fireMage.Beauty,
                Intelligence = fireMage.Intelligence,
                Willpower = fireMage.Willpower,
                Astral = fireMage.Astral,
                Bravery = fireMage.Bravery,
                Erudition = fireMage.Erudition,
                Detection = fireMage.Detection,
                Gold = fireMage.Gold
            };

            BaseClass = sogronPriest;
            if (Classes.Length > 0)
            {
                Classes[0] = sogronPriest;
            }

            Deity = Deity.Sogron;

            // Additive: the character keeps everything learned as a Fire Mage, and gains Priest's
            // base qualification list on top - same UpgradeOrAddQualification path AddFrom already
            // uses for a class's base Qualifications at character creation.
            foreach (var qualification in sogronPriest.Qualifications)
            {
                Qualifications.UpgradeOrAddQualification(qualification);
            }
        }

        foreach (var qualification in BaseClass.FutureQualifications.Where(f => f.ActualLevel <= BaseClass.Level))
        {
            Qualifications.UpgradeOrAddQualification(qualification);
        }

        OnPropertyChanged(nameof(Qualifications));
        OnPropertyChanged(nameof(Class));
    }
}
