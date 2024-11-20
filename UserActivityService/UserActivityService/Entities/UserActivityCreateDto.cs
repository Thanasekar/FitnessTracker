using System.ComponentModel.DataAnnotations;

namespace UserActivityService.Entities
{
    public class UserActivityCreateDto
    {
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Steps { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int ExerciseMinutes { get; set; }
    }
}
