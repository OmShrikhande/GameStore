
namespace GameSolution.Dtos;
public record class CreateGameDto(
    string Name,
    string Gener,
    decimal Price,
    DateOnly ReleaseDate
);
