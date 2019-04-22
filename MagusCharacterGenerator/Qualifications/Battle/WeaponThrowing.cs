using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Battle
{
    class WeaponThrowing : Qualification, ICanHaveMany
	{
        public IWeapon Weapon { get; set; }

        public WeaponThrowing(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
            : base(qualificationLevel, level)
        {
        }

        public override string ToString() => Lng.Elem("Weapon throwing");
    }
}
