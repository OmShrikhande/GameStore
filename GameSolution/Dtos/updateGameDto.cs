namespace GameSolution.Dtos;

public record class UpdateGameDto(
    string Name,
    string Gener,
    decimal Price,
    DateOnly ReleaseDate
);