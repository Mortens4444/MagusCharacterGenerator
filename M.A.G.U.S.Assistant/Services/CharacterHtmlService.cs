using M.A.G.U.S.Assistant.Extensions;
using M.A.G.U.S.GameSystem;
using M.A.G.U.S.Interfaces;
using Mtf.Extensions;
using Mtf.LanguageService.MAUI;
using System.Globalization;
using System.Linq;
using System.Text;

namespace M.A.G.U.S.Assistant.Services;

internal class CharacterHtmlService
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<Pending>")]
    public string GenerateCharacterHtml(ICharacter character)
    {
        ArgumentNullException.ThrowIfNull(character);
        var sb = new StringBuilder();
        var cultureInfo = CultureInfo.InvariantCulture;
        var formula = character.BaseClass?.GetPainToleranceModifierFormula();
        var prpPerLevel = formula?.GetDisplayFormula() ?? String.Empty;
        var manaPerLevelFormula = character?.MaxManaPointsPerLevelFormula;
        var manaPerLevel = manaPerLevelFormula != null ? manaPerLevelFormula.GetDisplayFormula() : (character?.MaxManaPointsPerLevel ?? 0).ToString(CultureInfo.InvariantCulture);

        sb.Append("<html><head>")
            .Append(@"
                <style>
                    /* Minden elem méretezése tartalmazza a keretet és paddingot */
                    * { box-sizing: border-box; }

                    body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin: 20px; font-size: 12px; color: #000; }
                    .sheet-container { width: 100%; max-width: 800px; margin: auto; border: 2px solid #000; padding: 10px; }
        
                    .section { margin-bottom: 10px; border: 1px solid #333; width: 100%; overflow: hidden; }
                    .section-title { background: #eee; padding: 3px 8px; font-weight: bold; border-bottom: 1px solid #333; text-transform: uppercase; }
        
                    /* A row biztosítja, hogy a cellák egymás mellett maradjanak */
                    .row { display: flex; width: 100%; border-bottom: 1px solid #eee; }
                    .row:last-child { border-bottom: none; }

                    .cell { 
                        padding: 4px; 
                        border-right: 1px solid #eee; 
                        display: flex; 
                        flex-direction: column;
                        flex-grow: 1; /* Kitölti a rendelkezésre álló helyet */
                    }
                    .cell:last-child { border-right: none; }

                    .label { font-size: 8px; color: #555; text-transform: uppercase; font-weight: bold; margin-bottom: 2px; }
                    .value { font-size: 12px; font-weight: bold; min-height: 16px; }
        
                    .editable-value { border-bottom: 1px dashed #999; width: 100%; min-height: 14px; display: inline-block; }

                    @media print {
                        body { margin: 0; }
                        .sheet-container { border: none; width: 100%; }
                
                </style>")
            .Append("</head><body>")

            .Append("<div class='sheet-container'>")
            .Append($"<h1>{character.Name}</h1>")

            // Profile data (Race, Class, Level, Alignment)
            .Append("<div class='section'><div class='row'>")
            .Append(CreateCell(Lng.Elem("Race"), Lng.Elem(character.RaceName), "25%"))
            .Append(CreateCell(Lng.Elem("Class"), Lng.Elem(character.Class), "25%"))
            .Append(CreateCell(Lng.Elem("Level"), character.Level.ToString(), "15%"))
            .Append(CreateCell(Lng.Elem("Alignment"), Lng.Elem(Lng.Elem(character.Alignment.GetDescription())), "35%"))
            .Append("</div><div class='row'>")
            .Append(CreateCell(Lng.Elem("Birthplace"), character.Birthplace, "50%"))
            .Append(CreateCell(Lng.Elem("School"), character.School, "50%"))
            .Append("</div></div>")

            // Skills
            .Append($"<div class='section'><div class='section-title'>{Lng.Elem("Skills")}</div>")
            .Append("<div class='row' style='justify-content: space-around;'>")
            .Append(CreateCell(Lng.Elem("Strength"), character.Strength.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Quickness"), character.Quickness.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Dexterity"), character.Dexterity.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Stamina"), character.Stamina.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Health"), character.Health.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Beauty"), character.Beauty.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Intelligence"), character.Intelligence.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Willpower"), character.Willpower.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Astral"), character.Astral.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Erudition"), character.Erudition.ToString(cultureInfo)))
            .Append("</div></div>")

            .Append("<div class='row'>")
            
            // Health & Pain Resistance
            .Append("<div class='section' style='flex: 1; margin-right: 5px;'>")
            .Append($"<div class='section-title'>{Lng.Elem("Health & Pain Resistance")}</div>")
            .Append("<div class='row'>")
            .Append(CreateCell(Lng.Elem("Max. HP"), character.MaxHealthPoints.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Act. HP"), String.Empty, editable: true))
            .Append(CreateCell(Lng.Elem("Max. PRP"), character.MaxPainTolerancePoints.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Act. PRP"), String.Empty, editable: true))
            .Append(CreateCell(Lng.Elem("Max. PRP/level"), prpPerLevel))
            .Append("</div></div>")

            // ᛉ-points / Mana-points
            .Append("<div class='section' style='flex: 1;'>")
            .Append($"<div class='section-title'>{Lng.Elem("ᛉ-points")} & {Lng.Elem("Mana-points")}</div>")
            .Append("<div class='row'>")
            .Append(CreateCell(Lng.Elem("Max. ᛉp"), character.MaxPsiPoints.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Act. ᛉp"), String.Empty, editable: true))
            .Append(CreateCell("Max. ᛉp/level", character.PsiPointsModifier.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Max. Mp"), character.MaxManaPoints.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Act. Mp"), String.Empty, editable: true))
            .Append(CreateCell("Max. Mp/level", manaPerLevel))
            .Append("</div></div></div>")

            // Magic Resistance
            .Append("<div class='section'>")
            .Append($"<div class='section-title'>{Lng.Elem("Magic Resistance")}</div><div class='row'>")
            .Append(CreateCell(Lng.Elem("Unconscious Astral Magic Resistance"), character.UnconsciousAstralMagicResistance.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Unconscious Mental Magic Resistance"), character.UnconsciousMentalMagicResistance.ToString(cultureInfo)))
            .Append("</div><div class='row'>")
            .Append(CreateCell(Lng.Elem("Static Astral ᛉ-Shield"), String.Empty, editable: true))
            .Append(CreateCell(Lng.Elem("Dynamic Astral ᛉ-Shield"), String.Empty, editable: true))
            .Append(CreateCell(Lng.Elem("Static Mental ᛉ-Shield"), String.Empty, editable: true))
            .Append(CreateCell(Lng.Elem("Dynamic Mental ᛉ-Shield"), String.Empty, editable: true))
            .Append("</div></div></div>")

            // Combat values
            .Append($"<div class='section'><div class='section-title'>{Lng.Elem("Combat values")}</div>")
            .Append("<div class='row'>")
            .Append(CreateCell(Lng.Elem("Initiator value"), character.InitiateValue.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Attack value"), character.AttackValue.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Defense value"), character.DefenseValue.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Aim value"), character.AimValue.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("CM/level"), character.CombatValueModifierPerLevel.ToString(cultureInfo)))
            .Append("</div></div>")

            // Qualifications
            .Append($"<div class='section'><div class='section-title'>{Lng.Elem("Qualifications")}</div>")
            .Append($"<table><tr><th>{Lng.Elem("Name")}</th><th>{Lng.Elem("Level")}</th><th>{Lng.Elem("Name")}</th><th>{Lng.Elem("Level")}</th></tr>");

        var quals = character.Qualifications.ToList();
        for (int i = 0; i < quals.Count; i += 2)
        {
            var content = i + 1 < quals.Count ?
                $"<td>{Lng.Elem(quals[i + 1].Name)}</td><td>{Lng.Elem(quals[i + 1].QualificationLevel.GetDescription())}</td>" :
                "<td></td><td></td>";

            sb.Append("<tr>")
                .Append($"<td>{Lng.Elem(quals[i].Name)}</td><td>{Lng.Elem(quals[i].QualificationLevel.GetDescription())}</td>")
                .Append(content)
                .Append("</tr>");
        }
        sb.Append("</table></div>")
        
            .Append("<div style='break-after: page;'></div>")
            .Append($"<div class='section'><div class='section-title'>{Lng.Elem("Special qualifications")}</div><table>");
        foreach (var sq in character.SpecialQualifications)
        {
            _ = sb.Append($"<tr><td>{Lng.Elem(sq.Name)}</td></tr>");
        }

        sb.Append("</table></div>")

            .Append($"<div class='section'><div class='section-title'>{Lng.Elem("Percent qualifications")}</div><table>");
        foreach (var pq in character.PercentQualifications)
        {
            _ = sb.Append($"<tr><td>{Lng.Elem(pq.Name)}</td><td>{pq.Percent}%</td></tr>");
        }

        _ = sb.Append("</table></div></div></div>")

            // Money & Equipment
            .Append("<div class='section'><div class='section-title'>" + Lng.Elem("Money") + "</div><div class='row'>")
            .Append(CreateCell(Lng.Elem("Mithril"), character.Money.Mithril.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Gold"), character.Money.Gold.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Silver"), character.Money.Silver.ToString(cultureInfo)))
            .Append(CreateCell(Lng.Elem("Copper"), character.Money.Copper.ToString(cultureInfo)))
            .Append("</div></div>")

            .Append("<div class='section'><div class='section-title'>" + Lng.Elem("Equipment") + "</div>")
            .Append("<div style='padding: 5px;'>")
            .Append(String.Join(Environment.NewLine, character.Equipment.Select(e => Lng.Elem(e.Name))))
            .Append($"<br/><br/><b>{Lng.Elem("Total weight (kg)")}:</b> {character.TotalEquipmentWeight}")
            .Append("</div></div>")

            .Append("</div></body></html>");
        return sb.ToString();
    }

    private static string CreateCell(string label, string value, string width = "auto", bool editable = false)
    {
        var valDisplay = editable ? "<span class='editable-value'>&nbsp;&nbsp;&nbsp;</span>" : value;
        return $@"<div class='cell' style='width: {width}; min-width: 50px;'>
                    <span class='label'>{label}</span>
                    <span class='value'>{valDisplay}</span>
                  </div>";
    }
}
