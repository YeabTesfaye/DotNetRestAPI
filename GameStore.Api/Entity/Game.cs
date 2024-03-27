

namespace GameStore.Api.Entity
{
    public class Game
    {

     public int Id {get; set;} 
     public required string Name {get; set;}

     public required string Genere { get; set; }

     public decimal Price  { get; set; }
     public DateTime RealseDate { get; set; }

     public required string ImageUrl { get; set; }
    }
}