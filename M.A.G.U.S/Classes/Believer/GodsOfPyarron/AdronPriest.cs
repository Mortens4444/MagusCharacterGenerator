using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Attributes;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class AdronPriest : Priest
{
    public AdronPriest() : base() { }

    public AdronPriest(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    [DiceThrow(ThrowType._1D6)]
    [DiceThrowModifier(14)]
    public override int Astral { get; set; }

    public override Alignment Alignment => Alignment.ChaosLife;

    public override int InitiateBaseValue => 4;

    public override int AttackBaseValue => 15;

    public override int DefenseBaseValue => 70;

    public override int AimBaseValue => 0;

    public override int CombatValueModifierPerLevel => 6;

    public override QualificationList Qualifications
	{
		get
		{
			var result = base.Qualifications;
			result.AddRange(
			[
				new Alchemy(),
				new LegendLore(QualificationLevel.Master),
                new Spellcasting(),
                new Healing(QualificationLevel.Master),
				new AncientTongueLore()
            ]);
			return BuildQualifications(result);
		}
	}

    public override QualificationList FutureQualifications
	{
		get
		{
			var result = base.FutureQualifications;
			result.AddRange(
			[
				new Physiology(level: 2),
				new Spellcasting(QualificationLevel.Master, level: 2),
                new Herbalism(level: 4),
				new Alchemy(QualificationLevel.Master, level: 6),
				new AncientTongueLore(QualificationLevel.Master, 7)
			]);
			return BuildQualifications(result);
		}
	}

    public override string Name => "Priest of Adron";

    public override Deity Deity { get; set; } = Deity.Adron;
}
