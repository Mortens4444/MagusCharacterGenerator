using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Qualifications;
using M.A.G.U.S.Qualifications.Scientific.Psi;
using M.A.G.U.S.Qualifications.Specialities;
using Mtf.Extensions.Services;
using System.Text;

namespace M.A.G.U.S.Races;

public class Jann : Race
{
    public override sbyte Intelligence => 2;

    public override QualificationList Qualifications =>
    [
        new PsiPyarron(QualificationLevel.Master)
    ];

    public override SpecialQualificationList SpecialQualifications =>
    [
        new ExtraPsiPointOnLevelUp(1),
        new UseWizardMentalMosaicAsPsi()
    ];
    
    public override string GenerateCharacterName()
    {
        var start = new[] { "Ala", "Ira", "Sari", "Taba", "Nabi", "Kari", "Zira", "El" };
        var middle = new[] { "al", "ir", "ah", "ra", "im", "as", "bar", "har" };
        var end = new[] { "a", "ah", "im", "ar", "ir", "al" };

        var result = new StringBuilder();
        result.Append(start[random.Next(start.Length)]);

        var count = RandomProvider.GetSecureRandomShort(0, 2);
        for (var i = 0; i < count; i++)
        {
            result.Append(middle[random.Next(middle.Length)]);
        }

        result.Append(end[random.Next(end.Length)]);

        var name = result.ToString();
        return Char.ToUpperInvariant(name[0]) + name[1..];
    }
}
