using System.Text.Json;
using EAMS.Domain.DTOs;
using EAMS.Domain.Models;
using Microsoft.Extensions.Logging;

namespace EAMS.Web.Services
{
    public class BffService : IBffService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BffService> _logger;

        public BffService(HttpClient httpClient, ILogger<BffService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.GetAsync("bff/users", cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync(cancellationToken);
                    _logger.LogWarning("Failed to fetch users data. StatusCode: {StatusCode}, Response: {Response}", response.StatusCode, error);

                    response.EnsureSuccessStatusCode();
                }

                var json = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<UserDto>>>(new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }, cancellationToken);

                return json?.Data ?? Enumerable.Empty<UserDto>();
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving users data.");
                throw;
            }
        }
    }
}