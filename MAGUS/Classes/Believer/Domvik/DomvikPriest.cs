using MAGUS.Enums;
using MAGUS.GameSystem.Languages;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Qualifications;
using MAGUS.Qualifications.Combat;
using MAGUS.Qualifications.Laical;
using MAGUS.Qualifications.Scientific;

namespace MAGUS.Classes.Believer.Domvik;

public class DomvikPriest : Priest
{
    public DomvikPriest() : base() { }

    public DomvikPriest(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    public override QualificationList Qualifications
	{
		get
		{
			var result = base.Qualifications;
			result.AddRange(
			[
				new WeaponUse(),
				new ShieldUse(),
				new AncientTongueLore(AntientLanguage.LinguaDomini),
				new Healing(),
				new PoisoningAndNeutralization(),
				new Heraldry(),
				new Riding()
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
				new ReadingAndWriting(QualificationLevel.Master),
				new AncientTongueLore(AntientLanguage.LinguaDomini, QualificationLevel.Master, 3),
				new PoisoningAndNeutralization(QualificationLevel.Master, 3),
			]);
			return BuildQualifications(result);
		}
	}

    public override string Name => "Priest of Domvik";

    public override Deity Deity { get; set; } = Deity.Domvik;
}
