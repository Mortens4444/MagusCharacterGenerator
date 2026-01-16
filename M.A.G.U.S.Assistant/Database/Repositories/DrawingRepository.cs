using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Database.Entities;
using M.A.G.U.S.Assistant.Interfaces;
using Mtf.Maui.Controls.Messages;
using Newtonsoft.Json;

namespace M.A.G.U.S.Assistant.Database.Repositories;

internal class DrawingRepository(DatabaseContext context)
{
    private readonly DatabaseContext context = context;

    private readonly JsonSerializerSettings jsonSettings = new()
    {
        TypeNameHandling = TypeNameHandling.Auto, // Kritikus az interfészek miatt!
#if DEBUG
        Formatting = Formatting.Indented,
#else
        Formatting = Formatting.None,
#endif
        PreserveReferencesHandling = PreserveReferencesHandling.Objects
    };

    public async Task SaveDrawingAsync(string name, List<IDrawableElement> elements)
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        var existing = await connection.Table<DrawingEntity>()
                                       .FirstOrDefaultAsync(d => d.Name == name)
                                       .ConfigureAwait(false);

        var jsonData = JsonConvert.SerializeObject(elements, jsonSettings);

        if (existing == null)
        {
            var entity = new DrawingEntity
            {
                Name = name,
                CreatedAt = DateTime.Now,
                ElementsJson = jsonData
            };
            await connection.InsertAsync(entity).ConfigureAwait(false);
        }
        else
        {
            existing.CreatedAt = DateTime.Now;
            existing.ElementsJson = jsonData;
            await connection.UpdateAsync(existing).ConfigureAwait(false);
        }
    }

    public async Task<List<IDrawableElement>?> GetDrawingByNameAsync(string name)
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        var entity = await connection.Table<DrawingEntity>()
                                     .FirstOrDefaultAsync(d => d.Name == name)
                                     .ConfigureAwait(false);

        if (entity == null) return null;

        try
        {
            return JsonConvert.DeserializeObject<List<IDrawableElement>>(entity.ElementsJson, jsonSettings);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            return null;
        }
    }

    public async Task<List<DrawingEntity>> GetAllDrawingsAsync()
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        var drawings = await connection.Table<DrawingEntity>().ToListAsync().ConfigureAwait(false);
        return [.. drawings];
    }

    public async Task<List<string>> GetAllDrawingNamesAsync()
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        var drawings = await connection.Table<DrawingEntity>().ToListAsync().ConfigureAwait(false);
        return [.. drawings.Select(d => d.Name)];
    }

    public async Task DeleteDrawingAsync(string name)
    {
        var connection = await context.GetConnectionAsync().ConfigureAwait(false);
        var entity = await connection.Table<DrawingEntity>()
                                     .FirstOrDefaultAsync(d => d.Name == name)
                                     .ConfigureAwait(false);
        if (entity != null)
        {
            await connection.DeleteAsync(entity).ConfigureAwait(false);
        }
    }
}