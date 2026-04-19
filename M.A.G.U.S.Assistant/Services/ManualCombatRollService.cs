using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Views;
using M.A.G.U.S.Enums;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Assistant.Services;

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