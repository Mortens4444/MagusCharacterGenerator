using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class ArelPriest : Priest
{
    public ArelPriest() : base() { }

    public ArelPriest(int level) : base(level) { }

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
				new WeaponLore(),
				new LanguageLore(4),
				new LanguageLore(3),
				new LanguageLore(2),
				new WeatherDivination(),
				new Herbalism(),
				new Healing(),
				new AnimalTraining(),
				new ForestSurvival(QualificationLevel.Master),
				new HuntingAndFishing(QualificationLevel.Master),
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
				new TavernBrawling(level: 2),
				new LegendLore(level: 3),
				new TrapSetting(level: 4),
				new TrackingConcealment(level: 5),
				new WeaponUse(QualificationLevel.Master, 9),
			]);
			return BuildQualifications(result);
		}
	}

    public override string Name => "Priest of Arel";
}
