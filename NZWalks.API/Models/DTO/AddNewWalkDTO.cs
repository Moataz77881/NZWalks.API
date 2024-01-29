using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class AddNewWalkDTO
    {
        [Required]
        [MaxLength(100 , ErrorMessage ="name has to be maximum 100 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000 , ErrorMessage ="description has to be maximum 1000 characters")]
        public string Description { get; set; }
        [Required]
        [Range(0,50)]
        public double LenghtInKm { get; set; }
        public string? WalkImageUrl { get; set; } // can be null
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
