using MAGUS.Bestiary;
using MAGUS.Enums;
using MAGUS.Interfaces;
using Mtf.Extensions;

namespace MAGUS.GameSystem.Turn;

public sealed class MysticResolution : ResolutionBase
{
    public override bool BypassesArmor => true;

    private MysticResolution() { }

    public static async Task<MysticResolution> CreateAsync(
        InitiativeEntry initiative,
        ICombatRollService rollService,
        string title,
        MysticAttack attack,
        AttackDirection attackDirection)
    {
        var target = initiative.Target.Source;

        if (attack is PsiAttack && target is Creature { ResistantToPsi: true })
        {
            return new MysticResolution
            {
                Attack = attack,
                RollValue = 0,
                IsSuccessful = false,
                IsHpDamage = true,
                Direction = attackDirection,
                HitLocation = PlaceOfAttack.None.GetDescription()
            };
        }

        // An attack with no Power (ISpell.Power/IPsiDiscipline.Power == null) bypasses the
        // magic-resistance roll entirely and always connects.
        if (attack.Power is null)
        {
            return new MysticResolution
            {
                Attack = attack,
                RollValue = 0,
                IsSuccessful = true,
                IsHpDamage = true,
                Direction = attackDirection,
                HitLocation = PlaceOfAttack.None.GetDescription()
            };
        }

        var rollValue = await rollService.RollAsync(ThrowType._1D100, title);

        // Empowering a spell with extra mana (Character.TryEmpowerSpell) only strengthens actual
        // spellcasting, not psi disciplines, which have their own separate psi-surge mechanic.
        var spellPowerBonus = attack is SpellAttack && initiative.Attacker.Source is Character caster
            ? caster.SpellPowerBonus
            : 0;
        var total = attack.Power.Value + spellPowerBonus + rollValue;

        var resistance = attack.ResistanceType == MagicResistanceType.Astral
            ? target.GetAstralMagicResistance()
            : target.GetMentalMagicResistance();

        var successful = total > resistance;

        return new MysticResolution
        {
            Attack = attack,
            RollValue = rollValue,
            IsSuccessful = successful,
            IsHpDamage = total - resistance >= OverHitValue,
            Direction = attackDirection,
            HitLocation = PlaceOfAttack.None.GetDescription()
        };
    }

    public static MysticResolution CreateOutOfPoints(MysticAttack attack, AttackDirection attackDirection)
    {
        return new MysticResolution
        {
            Attack = attack,
            RollValue = 0,
            IsSuccessful = false,
            IsHpDamage = true,
            Direction = attackDirection,
            HitLocation = PlaceOfAttack.None.GetDescription()
        };
    }
}
