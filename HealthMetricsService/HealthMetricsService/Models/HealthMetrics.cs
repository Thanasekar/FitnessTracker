
namespace HealthMetricsService.Models
{
    public class HealthMetrics : BaseModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public long Phone { get; set; }
        public int Steps { get; set; }
        public int ExerciseMinutes { get; set; }
        public int HeartRate { get; set; }
        public int CaloriesBurned { get; set; }
    }
}
