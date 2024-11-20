using System.ComponentModel.DataAnnotations;

namespace RecommendationService.Entities
{
    public class UserActivityDto
    {
        [Required(ErrorMessage = "This field is required")]
        public int Steps { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int ExerciseMinutes { get; set; }
    }
}
