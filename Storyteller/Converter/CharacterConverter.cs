using System.Text;
using M.A.G.U.S.GameSystem;
using Mtf.Extensions;
using Mtf.LanguageService;

namespace Storyteller.Converter;

public static class CharacterConverter
{
	public static string ToString(Character character)
	{
		var result = new StringBuilder();

		result.AppendLine($"{Lng.Elem("Name")}: {character.Name}");

		var primaryCaste = character.Castes[0];
		result.AppendLine($"{Lng.Elem("Race")}: {character.Race}");
		result.AppendLine($"{primaryCaste} ({primaryCaste.Level}. {Lng.Elem("Level")})");
		if (character.Castes.Length > 1)
		{
			var secondaryCaste = character.Castes[1];
			result.AppendLine($"{secondaryCaste} ({secondaryCaste.Level}. {Lng.Elem("Level")})");
		}
		result.AppendLine();

		result.AppendLine($"{Lng.Elem("Skills")}");
		result.AppendLine("--------------------------------------");
		result.AppendLine($"{Lng.Elem("Strength")}: {character.Strength}");
		result.AppendLine($"{Lng.Elem("Speed")}: {character.Speed}");
		result.AppendLine($"{Lng.Elem("Dexterity")}: {character.Dexterity}");
		result.AppendLine($"{Lng.Elem("Stamina")}: {character.Stamina}");
		result.AppendLine($"{Lng.Elem("Health")}: {character.Health}");
		result.AppendLine($"{Lng.Elem("Beauty")}: {character.Beauty}");
		result.AppendLine($"{Lng.Elem("Intelligence")}: {character.Intelligence}");
		result.AppendLine($"{Lng.Elem("WillPower")}: {character.WillPower}");
		result.AppendLine($"{Lng.Elem("Astral")}: {character.Astral}");
		result.AppendLine($"{Lng.Elem("Bravery")}: {character.Bravery}");
		result.AppendLine($"{Lng.Elem("Erudition")}: {character.Erudition}");
		result.AppendLine();

		result.AppendLine($"{Lng.Elem("Fight values")}");
		result.AppendLine("--------------------------------------");
		result.AppendLine($"{Lng.Elem("IV")}: {character.InitiatingValue}");
		result.AppendLine($"{Lng.Elem("AV")}: {character.AttackingValue}");
		result.AppendLine($"{Lng.Elem("DV")}: {character.DefendingValue}");
		result.AppendLine($"{Lng.Elem("AimV")}: {character.AimingValue}");
		result.AppendLine();

		result.AppendLine($"{Lng.Elem("Vitality")}");
		result.AppendLine("--------------------------------------");
		result.AppendLine($"{Lng.Elem("Health points")}: {character.HealthPoints}");
		result.AppendLine($"{Lng.Elem("Pain tolerance points")}: {character.PainTolerancePoints}");
		result.AppendLine();

		result.AppendLine($"{Lng.Elem("Psi")}");
		result.AppendLine("--------------------------------------");
		result.AppendLine($"{Lng.Elem("Psi points")}: {character.PsiPoints}");
		result.AppendLine($"{Lng.Elem("Psi points/level")}: {character.PsiPointsModifier}");
		result.AppendLine();

		result.AppendLine($"{Lng.Elem("Magic")}");
		result.AppendLine("--------------------------------------");
		result.AppendLine($"{Lng.Elem("Mana points")}: {character.ManaPoints}");
		result.AppendLine($"{Lng.Elem("Unconscious astral magic resistance")}: {character.UnconsciousAstralMagicResistance}");
		result.AppendLine($"{Lng.Elem("Unconscious mental magic resistance")}: {character.UnconsciousMentalMagicResistance}");
		result.AppendLine();

		result.AppendLine($"{Lng.Elem("Race qualifications")}");
		result.AppendLine("--------------------------------------");
		foreach (var qualification in character.Race.Qualifications)
		{
			result.AppendLine($"{Lng.Elem(qualification.Name)} ({Lng.Elem(qualification.QualificationLevel.GetDescription())})");
		}
		result.AppendLine();

		result.AppendLine($"{Lng.Elem("Qualifications")}");
		result.AppendLine("--------------------------------------");
		foreach (var qualification in character.Qualifications)
		{
			result.AppendLine($"{Lng.Elem(qualification.Name)} ({Lng.Elem(qualification.QualificationLevel.GetDescription())})");
		}
		result.AppendLine();

		result.AppendLine($"{Lng.Elem("Percent qualifications")}");
		result.AppendLine("--------------------------------------");
		foreach (var qualification in character.PercentQualifications)
		{
			result.AppendLine($"{qualification.ToFullString()}");
		}
		result.AppendLine();
		return result.ToString();
	}
}
