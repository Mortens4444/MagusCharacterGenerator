using MAGUS.Assistant.Database.Entities;
using SQLite;

namespace MAGUS.Assistant.Database;

internal sealed class DatabaseContext
{
    private const string DbName = "magus_data.db3";
    private SQLiteAsyncConnection? connection;

    public async Task<SQLiteAsyncConnection> GetConnectionAsync()
    {
        if (connection == null)
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, DbName);
            connection = new SQLiteAsyncConnection(dbPath);

            await connection.CreateTableAsync<SettingsEntity>().ConfigureAwait(false);
            await connection.CreateTableAsync<CharacterEntity>().ConfigureAwait(false);
            await connection.CreateTableAsync<DrawingEntity>().ConfigureAwait(false);
        }
        return connection;
    }
}