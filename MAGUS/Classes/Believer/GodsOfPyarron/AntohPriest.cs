using MAGUS.Enums;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;
using MAGUS.Qualifications.Underworld;

namespace MAGUS.Classes.Believer.GodsOfPyarron;

public class AntohPriest : Priest
{
    public AntohPriest() : base() { }

    public AntohPriest(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    public override Alignment Alignment => Alignment.ChaosLife;

    public override QualificationList Qualifications
	{
		get
		{
			var result = base.Qualifications;
			result.AddRange(
			[
				new WeaponUse(),
				new WeaponUse(),
				new WeatherDivination(QualificationLevel.Master),
				new Cartography(),
				new HuntingAndFishing(),
				new Swimming(QualificationLevel.Master),
				new Sailing(QualificationLevel.Master),
				new Knotting(),
				new SeaSurvival()
            ]);
			return BuildQualifications(result);
		}
	}

	public override PercentQualificationList PercentQualifications =>
    [
    ];

    public override QualificationList FutureQualifications
	{
		get
		{
			var result = base.FutureQualifications;
			result.AddRange(
			[
				new Knotting(QualificationLevel.Master, 3),
				new WeaponThrowing(level: 4),
				new Cartography(QualificationLevel.Master, 5),
				new SeaSurvival(QualificationLevel.Master, 6),
				new EscapeBonds(level: 7)
			]);
			return BuildQualifications(result);
		}
	}

    public override string Name => "Priest of Antoh";

    public override Deity Deity { get; set; } = Deity.Antoh;
}
