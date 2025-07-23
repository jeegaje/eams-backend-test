using System.Text.Json;
using AccommodationManagement.Domain.DTOs;

namespace AccommodationManagement.BFF.Services
{
    public class CoreApiService : ICoreApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CoreApiService> _logger;

        public CoreApiService(HttpClient httpClient, ILogger<CoreApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Users");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<UserDto>>(json, new JsonSerializerOptions
                {
                  PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting users from Core API");
                throw;
            }
        }

    }
}