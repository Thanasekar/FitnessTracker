namespace RecommendationService.Models
{
    public class RecommentationDetail : BaseModel
    {
        public string Recommendation { get; set; }
        public int Steps { get; set; }
        public int ExerciseMinutes { get; set; }
        public int HeartRate { get; set; }
        public int CaloriesBurned { get; set; }
    }
}
