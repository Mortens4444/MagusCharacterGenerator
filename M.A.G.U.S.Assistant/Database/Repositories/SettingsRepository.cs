using M.A.G.U.S.Assistant.Database.Entities;
using System.Globalization;

namespace M.A.G.U.S.Assistant.Database.Repositories;

internal class SettingsRepository(DatabaseContext context)
{
    private readonly DatabaseContext context = context;

    public Task SaveBoolSettingAsync(string key, bool value) => SaveSettingAsync(key, value.ToString());

    public Task SaveInt32SettingAsync(string key, int value) => SaveSettingAsync(key, value.ToString(CultureInfo.InvariantCulture));

    public async Task<bool> GetBoolSettingAsync(string key, bool defaultValue = true)
    {
        var val = await GetSettingAsync(key).ConfigureAwait(false);
        return String.IsNullOrEmpty(val) ? defaultValue : Boolean.Parse(val);
    }

    public async Task<int> GetInt32SettingAsync(string key, int defaultValue = 0)
    {
        var val = await GetSettingAsync(key).ConfigureAwait(false);
        return String.IsNullOrEmpty(val) ? defaultValue : Int32.Parse(val, CultureInfo.InvariantCulture);
    }

    public async Task SaveSettingAsync(string key, string value)
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        var setting = new SettingsEntity { Name = key, Value = value };
        await connection.InsertOrReplaceAsync(setting).ConfigureAwait(false);
    }

    public async Task<string> GetSettingAsync(string key)
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        var setting = await connection.FindWithQueryAsync<SettingsEntity>("SELECT * FROM Settings WHERE Name = ?", key).ConfigureAwait(false);
        return setting?.Value ?? String.Empty;
    }
}