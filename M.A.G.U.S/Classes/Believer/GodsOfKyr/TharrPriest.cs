using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Combat;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Classes.Believer.GodsOfKyr;

public class TharrPriest : Priest
{
    public TharrPriest() : base() { }

    public TharrPriest(int level) : base(level) { }

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
}
