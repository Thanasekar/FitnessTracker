namespace RecommendationService.Entities
{
    public class RecommendationResponseDto
    {
        public Guid Id { get; set; }
        public string Recommendation { get; set; }
        public int Steps { get; set; }
        public int ExerciseMinutes { get; set; }
        public int HeartRate { get; set; }
        public int CaloriesBurned { get; set; }
        public DateTime Date { get; set; }
    }
}
