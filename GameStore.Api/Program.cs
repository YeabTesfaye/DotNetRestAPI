
using GameStore.Api.Entity;

const string GetGameByIdEndPoint = "GetGameById";

List <Game> games = new (){

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


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var group = app.MapGroup("/games");

group.MapGet("/", () => games);
group.MapGet("/{id}", (int id) => {
    Game? game = games.Find(game => game.Id == id);

    if(game is null){
        return Results.NotFound();
    }
    return Results.Ok(game);
}).WithName(GetGameByIdEndPoint);

group.MapPost("/", (Game game) => {
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);
    return Results.CreatedAtRoute(GetGameByIdEndPoint, new {id= game.Id}, game);

});

app.MapPut("/games/{id}", (int id, Game updatedGame) => {
    Game? existingGame = games.Find(game => game.Id == id);
    if (existingGame is null){
        return Results.NotFound();
    }
    existingGame.Genere = updatedGame.Genere;
    existingGame.Name = updatedGame.Name;
    existingGame.Price  = updatedGame.Price;
    existingGame.RealseDate = updatedGame.RealseDate;
    existingGame.ImageUrl = updatedGame.ImageUrl;

    return Results.NoContent();
});

app.MapDelete("/games/{id}", (int id) => {
    Game? existingGame = games.Find(game => game.Id == id);
    if(existingGame is not null){
         games.Remove(existingGame);
        return Results.Ok();
    }

    return Results.NoContent();
});

app.Run(); 