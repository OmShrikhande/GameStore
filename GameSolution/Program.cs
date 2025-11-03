using GameSolution.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


const string GetGameEndpointName = "GetGame";
List<GameDto> games = new()
{
    new GameDto(1, "The Legend of Code", "Adventure", 59.99m, new DateOnly(2023, 11, 15)),
    new GameDto(2, "Bug Hunter", "Action", 49.99m, new DateOnly(2022, 5, 22)),
    new GameDto(3, "Pixel Quest", "RPG", 39.99m, new DateOnly(2021, 8, 30))
};


// GET /games
app.MapGet("/games", () => games);
app.MapGet("/", () => "Hello World!");


//GET /games/{id}
app.MapGet("/games/{id}", (int id) =>
{
    app.MapGet("gmaes/{id}", (int id) => games.Find(x => x.Id == id)).WithName("GetGameEndpointName");
});

// POST /games
app.MapPost("/games",(CreateGameDto NewGame) =>
{
    GameDto newGame = new(games.Count + 1, NewGame.Name, NewGame.Gener, NewGame.Price, NewGame.ReleaseDate);
    games.Add(newGame);
   
    return Results.CreatedAtRoute("GetGameEndpointName", new { id = newGame.Id }, newGame);
});

// PUT /games/{id}
app.MapPut("/games/{id}", (int id, UpdateGameDto updateGame) =>
{
    var index = games.FindIndex(x => x.Id == id);
    games[index] = new GameDto(id, updateGame.Name,updateGame.Gener, updateGame.Price, updateGame.ReleaseDate);
    return Results.NoContent();
}
);


// DELETE /games/{id}
app.MapDelete("/games/{id}", (int id) =>
{
    var index = games.FindIndex(x => x.Id == id);
    if(index != -1)
        games.RemoveAt(index);
}
);

app.Run();
