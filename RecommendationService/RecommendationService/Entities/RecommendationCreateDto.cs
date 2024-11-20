using System.ComponentModel.DataAnnotations;

namespace RecommendationService.Entities
{
    public class RecommendationCreateDto
    {
        [Required(ErrorMessage = "This field is required")]
        public Guid Id { get; set; }
        
    }
}
