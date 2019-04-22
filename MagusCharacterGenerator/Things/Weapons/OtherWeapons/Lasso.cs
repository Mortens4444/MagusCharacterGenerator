using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.OtherWeapons
{
    class Lasso : Weapon, IMeleeWeapon
    {
        public double AttacksPerRound => 1/3;

        public byte InitiatingValue => 0;

        public byte AttackingValue => 1;

        public byte DefendingValue => 0;

        public double Weight => 0.6;

        public Money Price => new Money(0, 0, 80);

        public byte GetDamage() => 0;

        public override string ToString() => Lng.Elem("Lasso");
    }
}