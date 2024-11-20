using UserActivityService.Models;
using Newtonsoft.Json;

namespace UserActivityService.Services
{
    public interface IUserDetailsServiceClient
    {
        Task<UserDetail> GetUserDetailAsync(Guid userId);
    }
    public class UserDetailsServiceClient : IUserDetailsServiceClient
    {
        private readonly HttpClient _httpClient;

        public UserDetailsServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetail> GetUserDetailAsync(Guid userId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:5003/api/UserDetail/{userId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var userDetail = JsonConvert.DeserializeObject<UserDetail>(json);
            return userDetail;
        }
    }
    public class UserDetail
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long Phone { get; set; }
    }
}
