using M.A.G.U.S.Assistant.Database.Repositories;
using M.A.G.U.S.GameSystem;

namespace M.A.G.U.S.Assistant.Services;

internal class CharacterService(CharacterRepository characterRepository)
{
    private readonly CharacterRepository characterRepository = characterRepository;

    public Task<List<Character>> GetAllAsync() => characterRepository.GetAllCharactersAsync();

    public Task<Character?> GetByNameAsync(string name) => characterRepository.GetByNameAsync(name);

    public Task SaveAsync(Character character) => characterRepository.SaveCharacterAsync(character);

    public Task AddAsync(Character character) => characterRepository.InsertCharacterAsync(character);

    public Task UpdateAsync(Character character) => characterRepository.UpdateCharacterAsync(character);

    public Task DeleteAsync(string name) => characterRepository.DeleteCharacterAsync(name);

    public Task DeleteAllAsync() => characterRepository.DeleteAllCharacterAsync();
}
