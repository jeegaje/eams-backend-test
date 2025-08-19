using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using EAMS.API.DTOs;
using EAMS.Domain.Interfaces;
using EAMS.Domain.Entities;
using EAMS.Domain.Entities.Enums;

namespace EAMS.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly ILogger<AccommodationController> _logger;

        public AccommodationController(
            IAccommodationRepository accommodationRepository,
            ILogger<AccommodationController> logger)
        {
            _accommodationRepository = accommodationRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get all accommodations
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccommodationResponseDto>>> GetAccommodations(CancellationToken cancellationToken = default)
        {
            try
            {
                var accommodations = await _accommodationRepository.GetAllAsync(cancellationToken);

                var response = accommodations.Select(MapToResponseDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving accommodations");
                return StatusCode(500, "An error occurred while retrieving accommodations");
            }
        }

        /// <summary>
        /// Get accommodation by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<AccommodationResponseDto>> GetAccommodation(
            Int64 id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var accommodation = await _accommodationRepository.GetByIdAsync(id, cancellationToken);

                if (accommodation == null)
                {
                    return NotFound($"Accommodation with ID {id} not found");
                }

                return Ok(MapToResponseDto(accommodation));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving accommodation with ID {Id}", id);
                return StatusCode(500, "An error occurred while retrieving the accommodation");
            }
        }

        /// <summary>
        /// Create a new accommodation
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<AccommodationResponseDto>> CreateAccommodation(
            AccommodationCreateDto createDto,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var accommodation = MapToEntity(createDto);
                
                var createdAccommodation = await _accommodationRepository.AddAsync(accommodation, cancellationToken);
                await _accommodationRepository.SaveChangesAsync(cancellationToken);

                var response = MapToResponseDto(createdAccommodation);
                return CreatedAtAction(nameof(GetAccommodation), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating accommodation");
                return StatusCode(500, "An error occurred while creating the accommodation");
            }
        }

        /// <summary>
        /// Update an existing accommodation
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<AccommodationResponseDto>> UpdateAccommodation(
            Int64 id,
            AccommodationUpdateDto updateDto,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingAccommodation = await _accommodationRepository.GetByIdAsync(id, cancellationToken);
                if (existingAccommodation == null)
                {
                    return NotFound($"Accommodation with ID {id} not found");
                }

                var updatedAccommodation = MapToEntity(updateDto, id);
                
                var result = await _accommodationRepository.UpdateAsync(updatedAccommodation, cancellationToken);
                await _accommodationRepository.SaveChangesAsync(cancellationToken);

                var response = MapToResponseDto(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating accommodation with ID {Id}", id);
                return StatusCode(500, "An error occurred while updating the accommodation");
            }
        }

        /// <summary>
        /// Delete an accommodation
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccommodation(Int64 id, CancellationToken cancellationToken = default)
        {
            try
            {
                var exists = await _accommodationRepository.ExistsAsync(id, cancellationToken);
                if (!exists)
                {
                    return NotFound($"Accommodation with ID {id} not found");
                }

                await _accommodationRepository.DeleteAsync(id, cancellationToken);
                await _accommodationRepository.SaveChangesAsync(cancellationToken);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting accommodation with ID {Id}", id);
                return StatusCode(500, "An error occurred while deleting the accommodation");
            }
        }

        private static AccommodationResponseDto MapToResponseDto(Accommodation accommodation)
        {
            return new AccommodationResponseDto
            {
                Id = accommodation.Id,
                Name = accommodation.Name,
                Street = accommodation.Street,
                Suburb = accommodation.Suburb,
                Postcode = accommodation.Postcode,
                State = accommodation.State,
                Region = accommodation.Region,
                Phone = accommodation.Phone,
                Email = accommodation.Email,
                Website = accommodation.Website,
                AccommodationType = accommodation.AccommodationType,
                Density = accommodation.Density,
                Duration = accommodation.Duration,
                Inactive = accommodation.Inactive,
                CreatedAt = accommodation.CreatedAt,
                UpdatedAt = accommodation.UpdatedAt,
                Amenities = accommodation.Amenities?.Select(a => new AmenityResponseDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    AmenityType = a.AmenityType,
                    HelpText = a.HelpText
                }).ToList() ?? new List<AmenityResponseDto>()
            };
        }

        private static Accommodation MapToEntity(AccommodationCreateDto createDto)
        {
            return new Accommodation
            {
                Name = createDto.Name,
                Street = createDto.Street,
                Suburb = createDto.Suburb,
                Postcode = createDto.Postcode,
                State = createDto.State,
                Region = createDto.Region,
                Phone = createDto.Phone,
                Email = createDto.Email,
                Website = createDto.Website,
                AccommodationType = createDto.AccommodationType,
                Density = createDto.Density,
                Duration = createDto.Duration,
                Inactive = createDto.Inactive,
                Amenities = new List<Amenity>()
            };
        }

        private static Accommodation MapToEntity(AccommodationUpdateDto updateDto, Int64 id)
        {
            return new Accommodation
            {
                Id = id,
                Name = updateDto.Name,
                Street = updateDto.Street,
                Suburb = updateDto.Suburb,
                Postcode = updateDto.Postcode,
                State = updateDto.State,
                Region = updateDto.Region,
                Phone = updateDto.Phone,
                Email = updateDto.Email,
                Website = updateDto.Website,
                AccommodationType = updateDto.AccommodationType,
                Density = updateDto.Density,
                Duration = updateDto.Duration,
                Inactive = updateDto.Inactive,
                Amenities = new List<Amenity>()
            };
        }
    }
}
