using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Views;
using M.A.G.U.S.Interfaces;
using M.A.G.U.S.Models;

namespace M.A.G.U.S.Assistant.Services;

internal sealed class ManualCombatRollService(ISoundPlayer soundPlayer, IShakeService shakeService) : ICombatRollService
{
    private readonly ISoundPlayer soundPlayer = soundPlayer;
    private readonly IShakeService shakeService = shakeService;

    public async Task<int> RollAsync(DiceThrowFormula formula, string title)
    {
        var page = new RollFormulaPage(soundPlayer, shakeService, formula, title);
        await ShellNavigationService.ShowPageAsync(page).ConfigureAwait(true);
        return await page.ResultTask.ConfigureAwait(true);
    }
}