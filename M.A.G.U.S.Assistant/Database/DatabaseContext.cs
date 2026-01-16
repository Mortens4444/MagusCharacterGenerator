using M.A.G.U.S.Assistant.Database.Entities;
using SQLite;

namespace M.A.G.U.S.Assistant.Database;

internal class DatabaseContext
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