using MagusCharacterGenerator.GameSystem.Valuables;
using MagusCharacterGenerator.GameSystem.Weapons;
using Mtf.Languages;

namespace MagusCharacterGenerator.Things.Weapons.AimingWeapons
{
    class ElvishBow : Weapon, IRangedWeapon
    {
        public double AttacksPerRound => 2;

        public byte InitiatingValue => 6;

        public byte AimingValue => 10;

        public ushort Distance => 120;

        public double Weight => 0.7;

        public Money Price => new Money(120);

        public byte GetDamage() => (byte)DiceThrow._2K6_RangedAttack();

        public override string ToString() => Lng.Elem("Elvish bow");
    }
}