using GameStore.Api.Entity;

namespace GameStore.Api.Repositories;

public interface IGamesRepository
{
    void Create(Game game);
    void Delete(int id);

    Game? Get(int id);
    IEnumerable<Game> GetAll();
    void Update(Game updatedGame);

}
