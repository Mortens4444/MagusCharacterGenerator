using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Database.Entities;
using M.A.G.U.S.GameSystem;
using Mtf.Maui.Controls.Models;
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
        var existing = await GetEntityByNameAsync(character.Name).ConfigureAwait(false);
        if (existing == null)
        {
            await InsertCharacterAsync(character).ConfigureAwait(false);
        }
        else
        {
            await UpdateCharacterAsync(character).ConfigureAwait(false);
        }
    }

    public async Task InsertCharacterAsync(Character character)
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        var exists = (await connection.Table<CharacterEntity>().CountAsync(c => c.Name == character.Name).ConfigureAwait(false)) > 0;
        if (exists)
        {
            throw new InvalidOperationException($"Character with name '{character.Name}' already exists.");
        }

        var entity = new CharacterEntity
        {
            Name = character.Name,
            RaceName = character.Race?.ToString() ?? String.Empty,
            ClassName = character.BaseClass?.ToString() ?? String.Empty,
            LastModified = DateTime.Now,
            JsonData = JsonConvert.SerializeObject(character, jsonSettings)
        };

        await connection.InsertAsync(entity).ConfigureAwait(false);
    }

    public async Task UpdateCharacterAsync(Character character)
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        var entity = await connection.Table<CharacterEntity>().FirstOrDefaultAsync(c => c.Name == character.Name).ConfigureAwait(false) ?? throw new InvalidOperationException($"Character with name '{character.Name}' not found.");
        entity.RaceName = character.Race?.ToString() ?? String.Empty;
        entity.ClassName = character.BaseClass?.ToString() ?? String.Empty;
        entity.LastModified = DateTime.Now;
        entity.JsonData = JsonConvert.SerializeObject(character, jsonSettings);

        await connection.UpdateAsync(entity).ConfigureAwait(false);
    }

    public async Task<Character?> GetByNameAsync(string name)
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        var entity = await connection.Table<CharacterEntity>().FirstOrDefaultAsync(c => c.Name == name).ConfigureAwait(false);
        if (entity == null) return null;

        try
        {
            var character = JsonConvert.DeserializeObject<Character>(entity.JsonData, jsonSettings);
            character?.CalculateChanges();
            return character;
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            return null;
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
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
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

    private async Task<CharacterEntity?> GetEntityByNameAsync(string name)
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        return await connection.Table<CharacterEntity>().FirstOrDefaultAsync(c => c.Name == name).ConfigureAwait(false);
    }
}