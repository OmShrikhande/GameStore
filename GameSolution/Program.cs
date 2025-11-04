using GameSolution.Endpoints;
using GameSolution.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGamesEndpoints();


app.Run();
