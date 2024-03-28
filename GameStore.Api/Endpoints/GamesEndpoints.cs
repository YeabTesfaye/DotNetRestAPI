

using GameStore.Api.Entity;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameByIdEndPoint = "GetGameById";


    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        InMemGamesRepository repository = new();

        var group = routes.MapGroup("/games")
       .WithParameterValidation();

        group.MapGet("/", () => repository.GetAll());
        group.MapGet("/{id}", (int id) =>
        {
            Game? game = repository.Get(id);

            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName(GetGameByIdEndPoint);

        group.MapPost("/", (Game game) =>
        {
            repository.Create(game);

            return Results.CreatedAtRoute(GetGameByIdEndPoint, new { id = game.Id }, game);

        });

        routes.MapPut("/games/{id}", (int id, Game updatedGame) =>
        {

            Game? existingGame = repository.Get(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
            repository.Update(existingGame);
            return Results.NoContent();
        });

        routes.MapDelete("/games/{id}", (int id) =>
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