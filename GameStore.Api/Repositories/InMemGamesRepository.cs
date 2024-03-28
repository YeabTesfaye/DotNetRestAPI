using GameStore.Api.Entity;

namespace GameStore.Api.Repositories;

public class InMemGamesRepository
{
    private readonly List<Game> games = new(){

      new Game()
    {
        Id = 1,
        Name = "Street Fight II",
        Price = 19.99M,
        Genere = "Fighting",
        RealseDate = new DateTime(1991,1,1),
        ImageUrl ="https://placehold.co/100",
    },
      new Game()
    {
        Id = 2,
        Name = "Final Fatasy XIV",
        Price = 55.99M,
        Genere = "Roleplaying",
        RealseDate = new DateTime(2011,1,1),
        ImageUrl ="https://placehold.co/100",
    },
        new Game()
    {
        Id = 3,
        Name = "FIFA 23",
        Price = 99.99M,
        Genere = "Sports",
        RealseDate = new DateTime(2022,1,1),
        ImageUrl ="https://placehold.co/100",
    }
};

    public IEnumerable<Game> GetAll()
    {
        return games;
    }
    public Game? Get(int id)
    {
        return games.Find(game => game.Id == id);
    }

    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame)
    {

        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int id)
    {

        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
    }




}