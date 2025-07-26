using System.Text.Json;
using AccommodationManagement.Domain.DTOs;
using AccommodationManagement.Domain.Models;

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

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Users", cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync(cancellationToken);
                    _logger.LogWarning("Failed to fetch users. StatusCode: {StatusCode}, Response: {Response}", response.StatusCode, error);

                    response.EnsureSuccessStatusCode();
                }

                var json = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<UserDto>>>(new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }, cancellationToken);

                return json?.Data ?? Enumerable.Empty<UserDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving users from Core API.");
                throw;
            }
        }

    }
}