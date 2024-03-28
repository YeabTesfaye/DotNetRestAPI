

using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Entity;

    public class Game
    {

     public int Id {get; set;} 
     [Required]
     [StringLength(50)]
     public required string Name {get; set;}
      [Required]
     [StringLength(20)]
     public required string Genere { get; set; }
      [Required]
       [Range(1,100)]
     public decimal Price  { get; set; }
     public DateTime RealseDate { get; set; }
     
     [Url]
     [StringLength(100)]
     public required string ImageUrl { get; set; }
    }
