using Newtonsoft.Json;

namespace RecommendationService.Services
{
    public class HealthMetricsServiceClient
    {
        private readonly HttpClient _httpClient;

        public HealthMetricsServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HealthMetrics> GetHealthMetricsAsync(Guid userId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44335/api/UserActivityDetail/{userId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var healthMetrics = JsonConvert.DeserializeObject<HealthMetrics>(json);
            return healthMetrics;
        }

        public class HealthMetrics
        {
            public Guid Id { get; set; }
            public int Steps { get; set; }
            public int ExerciseMinutes { get; set; }
            public int HeartRate { get; set; }
            public int CaloriesBurned { get; set; }
        }
    }
}
