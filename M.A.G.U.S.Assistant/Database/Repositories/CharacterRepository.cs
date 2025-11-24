using M.A.G.U.S.Assistant.Database.Entities;
using M.A.G.U.S.GameSystem;
using Newtonsoft.Json;
using System.Diagnostics;

namespace M.A.G.U.S.Assistant.Database.Repositories;

internal class CharacterRepository(DatabaseContext context)
{
    private readonly DatabaseContext context = context;

    private readonly JsonSerializerSettings jsonSettings = new()
    {
        TypeNameHandling = TypeNameHandling.Auto,
        Formatting = Formatting.None,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    };

    public async Task SaveCharacterAsync(Character character)
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        string json = JsonConvert.SerializeObject(character, jsonSettings);

        var existing = await connection.Table<CharacterEntity>().FirstOrDefaultAsync(c => c.Name == character.Name).ConfigureAwait(false);

        var entity = existing ?? new CharacterEntity();
        entity.Name = character.Name;
        entity.RaceName = character.Race?.ToString() ?? "Unknown";
        entity.ClassName = character.BaseClass?.ToString() ?? "Unknown";
        entity.LastModified = DateTime.Now;
        entity.JsonData = json;

        if (entity.Id != 0)
        {
            await connection.UpdateAsync(entity).ConfigureAwait(false);
        }
        else
        {
            await connection.InsertAsync(entity).ConfigureAwait(false);
        }
    }

    public async Task<List<Character>> GetAllCharactersAsync()
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        var entities = await connection.Table<CharacterEntity>().ToListAsync().ConfigureAwait(false);
        var characters = new List<Character>();

        foreach (var entity in entities)
        {
            try
            {
                var character = JsonConvert.DeserializeObject<Character>(entity.JsonData, jsonSettings);
                if (character != null)
                {
                    character.CalculateChanges();
                    characters.Add(character);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }
        return characters;
    }

    public async Task DeleteCharacterAsync(string name)
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        var entity = await connection.Table<CharacterEntity>().FirstOrDefaultAsync(c => c.Name == name).ConfigureAwait(false);
        if (entity != null)
        {
            await connection.DeleteAsync(entity).ConfigureAwait(false);
        }
    }
}