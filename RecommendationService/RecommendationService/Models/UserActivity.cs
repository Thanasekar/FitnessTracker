namespace RecommendationService.Models
{
    public class UserActivity : BaseModel
    {
        public int Steps { get; set; }
        public int ExerciseMinutes { get; set; }
    }
}
