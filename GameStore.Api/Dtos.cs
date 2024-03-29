
using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime RelseDate,
    string ImageUrl

);

public record CreateGameDto(
   [Required][StringLength(50)] string Name,
     [Required][StringLength(50)] string Genre,
   [Required][Range(1, 100)] decimal Price,
    DateTime RelseDate,
   [Url][StringLength(100)] string ImageUrl
);

public record UpdateGameDto(
   [Required][StringLength(50)] string Name,
     [Required][StringLength(50)] string Genre,
   [Required][Range(1, 100)] decimal Price,
    DateTime RelseDate,
   [Url][StringLength(100)] string ImageUrl
);