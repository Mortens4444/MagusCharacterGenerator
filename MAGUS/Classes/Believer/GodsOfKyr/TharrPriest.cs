using MAGUS.Enums;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Underworld;

namespace MAGUS.Classes.Believer.GodsOfKyr;

public class TharrPriest : Priest
{
    public TharrPriest() : base() { }

    public TharrPriest(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    public override QualificationList Qualifications
	{
		get
		{
			var result = base.Qualifications;
			result.AddRange(
			[
				new WeaponUse(),
				new WeaponUse(),
				new WeaponUse(),
				new WeaponThrowing(),
				new AncientTongueLore(QualificationLevel.Master),
				new PoisoningAndNeutralization(),
				new Backstab(),
				new Alchemy(),
				new Demonology()
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
				new Alchemy(QualificationLevel.Master, 3),
				new Demonology(QualificationLevel.Master, 4),
				new RunicMagic(level: 6)
			]);
			return BuildQualifications(result);
		}
	}

    public override string Name => "Priest of Tharr";

    public override Deity Deity { get; set; } = Deity.Tharr;
}
