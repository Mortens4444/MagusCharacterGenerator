using M.A.G.U.S.Enums;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Other;
using M.A.G.U.S.Qualifications.Scientific;
using Mtf.Extensions.Services;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class AlbornePriest : Priest
{
    public AlbornePriest() : base() { }

    public AlbornePriest(int level, bool autoGenerateSkills) : base(level, autoGenerateSkills) { }

    public override Alignment Alignment => Alignment.Life;

    public override QualificationList Qualifications
	{
		get
		{
			var result = base.Qualifications;
			result.AddRange(ArtQualifications);
            result.AddRange(
			[
				new WeaponUse(),
				new LanguageLore(3),
				new LanguageLore(2),
                new HistoryLore(QualificationLevel.Master),
                new LegendLore(),
                new Herbalism(),
				new SexualCulture(),
				new SingingAndMakingMusic(),
                new ArtHistory(QualificationLevel.Master)
            ]);
			return BuildQualifications(result);
		}
	}

    public static QualificationList ArtQualifications
	{
		get
		{
			var random = RandomProvider.GetSecureRandomInt(0, 6);
            return random switch
            {
                0 => [new Architecture(QualificationLevel.Master), new Sculptury(QualificationLevel.Master)],
                1 => [new LanguageLore(6), new Literature(QualificationLevel.Master)],
                2 => [new LanguageLore(6), new Acting(QualificationLevel.Master)],
                3 => [//new Jumping(50),
                      new Dancing(QualificationLevel.Master)],
                4 => [new Painting(QualificationLevel.Master), new Drawing(QualificationLevel.Master)],
                5 => [new Blacksmith(QualificationLevel.Master), new Jeweler(QualificationLevel.Master)],
                _ => throw new NotImplementedException(),
            };
        }
    }

    public override QualificationList FutureQualifications
	{
		get
		{
			var result = base.FutureQualifications;
			result.AddRange(
			[
				new SingingAndMakingMusic(QualificationLevel.Master, 3),
                new Disarmament(level: 4),
				new Herbalism(QualificationLevel.Master, 5)
			]);
			return BuildQualifications(result);
		}
	}

    public override string Name => "Priest of Alborne";

    public override Deity Deity { get; set; } = Deity.Alborne;
}
