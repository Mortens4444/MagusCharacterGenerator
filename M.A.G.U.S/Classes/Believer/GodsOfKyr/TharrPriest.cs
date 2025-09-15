﻿using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Battle;
using M.A.G.U.S.Qualifications.Scientific;
using M.A.G.U.S.Qualifications.Underworld;

namespace M.A.G.U.S.Classes.Believer.GodsOfKyr;

public class TharrPriest(byte level = 1) : Priest(level)
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
				new AntientLanguageKnowledge(QualificationLevel.Master),
				new PoisoningAndNeutralization(),
				new Backstab(),
				new Alchemy(),
				new Demonology()
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
				new Alchemy(QualificationLevel.Master, 3),
				new Demonology(QualificationLevel.Master, 4),
				new RuneMagic(level: 6)
			]);
			return result;
		}
	}

    public override string ClassName => "Tharr Priest";
}
