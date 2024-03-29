

using GameStore.Api.Dtos;
using GameStore.Api.Entity;
using GameStore.Api.Repositories;


namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameByIdEndPoint = "GetGameById";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {


        var group = routes.MapGroup("/games")
       .WithParameterValidation();

        group.MapGet("/", (IGamesRepository repository) => repository.GetAll().Select(game => game.AsDto()));
        group.MapGet("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? game = repository.Get(id);

            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
        }).WithName(GetGameByIdEndPoint);

        group.MapPost("/", (IGamesRepository repository,CreateGameDto gameDto ) =>
        {

            Game game = new(){
                Name = gameDto.Name,
                Genere = gameDto.Genre,
                Price = gameDto.Price,
                RealseDate = gameDto.RelseDate,
                ImageUrl = gameDto.ImageUrl
            };
            repository.Create(game);

            return Results.CreatedAtRoute(GetGameByIdEndPoint, new { id = game.Id }, game);

        });

        routes.MapPut("/games/{id}", (IGamesRepository repository, int id, UpdateGameDto updatedGameDto) =>
        {

            Game? existingGame = repository.Get(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
            existingGame.Name =  updatedGameDto.Name;
            existingGame.Genere = updatedGameDto.Genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.RealseDate = updatedGameDto.RelseDate;
            existingGame.ImageUrl = updatedGameDto.ImageUrl;
            
            repository.Update(existingGame);
            return Results.NoContent();
        });

        routes.MapDelete("/games/{id}", (IGamesRepository repository, int id) =>
        {
            Game? existingGame = repository.Get(id);
            if (existingGame is not null)
            {
                repository.Delete(id);
                return Results.Ok();
            }

            return Results.NoContent();
        });
        return group;

    }

}