using MAGUS.Assistant.Interfaces;
using MAGUS.Assistant.Models;
using MAGUS.Assistant.Views;
using MAGUS.Enums;
using MAGUS.Interfaces;
using MAGUS.Models;

namespace MAGUS.Assistant.Services;

internal sealed class ManualCombatRollService(ISoundPlayer soundPlayer, IShakeService shakeService) : ICombatRollService
{
    private readonly ISoundPlayer soundPlayer = soundPlayer;
    private readonly IShakeService shakeService = shakeService;

    public async Task<int> RollAsync(RollFormula formula, string title = "")
    {
        var locailzedRollFormula = formula is LocalizedRollFormula localizedFormula ? localizedFormula : new LocalizedRollFormula(formula, title);
        var page = new RollFormulaPage(soundPlayer, shakeService, locailzedRollFormula);
        await ShellNavigationService.ShowModalPageAsync(page).ConfigureAwait(true);
        await Task.Yield();
        return await page.ResultTask.ConfigureAwait(true);
    }

    public async Task<int> RollAsync(DiceThrowFormula formula, string title)
    {
        var page = new RollFormulaPage(soundPlayer, shakeService, formula, title);
        await ShellNavigationService.ShowModalPageAsync(page).ConfigureAwait(true);
        await Task.Yield();
        return await page.ResultTask.ConfigureAwait(true);
    }

    public Task<int> RollAsync(ThrowType throwType, string title = "")
    {
        var locailzedRollFormula = new LocalizedRollFormula(throwType, 0, false, title);
        return RollAsync(locailzedRollFormula);
    }
}