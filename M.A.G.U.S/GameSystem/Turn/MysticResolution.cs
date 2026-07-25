using M.A.G.U.S.Bestiary;
using M.A.G.U.S.Enums;
using M.A.G.U.S.Interfaces;
using Mtf.Extensions;

namespace M.A.G.U.S.GameSystem.Turn;

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

        var rollValue = await rollService.RollAsync(ThrowType._1D100, title);
        var total = attack.InitiateValue + rollValue;

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
