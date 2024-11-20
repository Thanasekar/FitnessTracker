using System.ComponentModel.DataAnnotations;

namespace HealthMetricsService.Entities
{
    public class HealthMetricsCreateDto
    {
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int HeartRate { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int CaloriesBurned { get; set; }
    }
}
