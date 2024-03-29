using GameStore.Api.Dtos;

namespace GameStore.Api.Entity;

public static class EntityExtensions
{
    public static GameDto AsDto(this Game game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.Genere,
            game.Price,
            game.RealseDate,
            game.ImageUrl
        );
    }

}