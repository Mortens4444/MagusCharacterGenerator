﻿using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Laical;
using M.A.G.U.S.Qualifications.Scientific;

namespace M.A.G.U.S.Classes.Believer.GodsOfPyarron;

public class KradPaladin(byte level = 1) : Paladin(level)
{
    public override QualificationList Qualifications
    {
        get
        {
            var result = base.Qualifications;
            result.AddRange(
            [
                new LanguageLore(3),
                new LanguageLore(3),
                new LanguageLore(3),
                new LanguageLore(3),
                new Herbalism(),
                new LegendLore(),
                new HistoryLore(),
                new ForestSurvival(),
                new Cartography(),
                new Swimming()
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
                new LegendLore(QualificationLevel.Master, 5),
                new HistoryLore(QualificationLevel.Master, 5),
            ]);
            return result;
        }
    }

    public override string Name => "Paladin of Krad";
}
