using System.Text.Json;
using AccommodationManagement.Domain.DTOs;
using AccommodationManagement.Domain.Models;

namespace AccommodationManagement.Web.Services
{
    public class BffService : IBffService
    {
        private readonly HttpClient _httpClient;

        public BffService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BffResponse<IEnumerable<UserDto>>> GetUsersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("bff/users");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<BffResponse<IEnumerable<UserDto>>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return result;
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP errors
                return new BffResponse<IEnumerable<UserDto>>
                {
                    Success = false,
                    Message = $"HTTP Error: {ex.Message}",
                    Data = Enumerable.Empty<UserDto>()
                };
            }
            catch (JsonException ex)
            {
                // Handle JSON deserialization errors
                return new BffResponse<IEnumerable<UserDto>>
                {
                    Success = false,
                    Message = $"JSON Error: {ex.Message}",
                    Data = Enumerable.Empty<UserDto>()
                };
            }
        }
    }
}