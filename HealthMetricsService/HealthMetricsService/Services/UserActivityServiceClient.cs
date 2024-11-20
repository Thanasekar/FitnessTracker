using Newtonsoft.Json;

namespace HealthMetricsService.Services
{
    public class UserActivityServiceClient
    {
        private readonly HttpClient _httpClient;

        public UserActivityServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UserActivityDetail> GetUserActivityDetailAsync(Guid userId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44335/api/UserActivityDetail/{userId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var userActivity = JsonConvert.DeserializeObject<UserActivityDetail>(json);
            return userActivity;
        }

        public class UserActivityDetail
        {
            public string FirstName { get; set; } = string.Empty;

            public string LastName { get; set; } = string.Empty;

            public long Phone { get; set; }
            public int Steps { get; set; }

            public int ExerciseMinutes { get; set; }
        }
    }
}
