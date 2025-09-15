using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Battle;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class ArelPriest(byte level = 1) : Priest(level)
{
    public override QualificationList Qualifications
	{
		get
		{
			var result = base.Qualifications;
			result.AddRange(
			[
				new WeaponUsage(),
				new WeaponUsage(),
				new WeaponUsage(),
				new WeaponThrowing(),
				new WeaponKnowledge(),
				new LanguageKnowledge(4),
				new LanguageKnowledge(3),
				new LanguageKnowledge(2),
				new WeatherForecast(),
				new Herbalism(),
				new WoundHealing(),
				new DressageTraining(),
				new Forestry(QualificationLevel.Master),
				new FishingAndHunting(QualificationLevel.Master),
				new Riding()
			]);
			return result;
		}
	}

	public override QualificationList FutureQualifications
	{
		get
		{
			var result = base.FutureQualifications;
			result.AddRange(
			[
				new PubFighting(level: 2),
				new LegendKnowledge(level: 3),
				new TrapSetup(level: 4),
				new TrackReadingAndHiding(level: 5),
				new WeaponUsage(QualificationLevel.Master, 9),
			]);
			return result;
		}
	}

    public override string ClassName => "Arel Priest";
}
