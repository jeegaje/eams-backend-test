using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using EAMS.API.DTOs;
using EAMS.Domain.Interfaces;
using EAMS.Domain.Entities;
using EAMS.Domain.Entities.Enums;
using AutoMapper;

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
        private readonly IMapper _mapper;

        public AccommodationController(
            IAccommodationRepository accommodationRepository,
            ILogger<AccommodationController> logger,
            IMapper mapper)
        {
            _accommodationRepository = accommodationRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all accommodations
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccommodationDto>>> GetAccommodations(CancellationToken cancellationToken = default)
        {
            try
            {
                var accommodations = await _accommodationRepository.GetAllAsync(cancellationToken);

                var response = _mapper.Map<IEnumerable<AccommodationDto>>(accommodations);
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
        public async Task<ActionResult<AccommodationDto>> GetAccommodation(
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

                var response = _mapper.Map<AccommodationDto>(accommodation);
                return Ok(response);
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
        public async Task<ActionResult<AccommodationDto>> CreateAccommodation(
            AccommodationDto accommodationDto,
            CancellationToken cancellationToken = default)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var accommodation = _mapper.Map<Accommodation>(accommodationDto);
                
                var createdAccommodation = await _accommodationRepository.AddAsync(accommodation, cancellationToken);
                await _accommodationRepository.SaveChangesAsync(cancellationToken);

                var response = _mapper.Map<AccommodationDto>(createdAccommodation);
                return CreatedAtAction(nameof(GetAccommodation), new { id = createdAccommodation.Id }, response);
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
        public async Task<ActionResult<AccommodationDto>> UpdateAccommodation(
            Int64 id,
            AccommodationDto accommodationDto,
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

                var updatedAccommodation = _mapper.Map<Accommodation>(accommodationDto);
                
                var result = await _accommodationRepository.UpdateAsync(updatedAccommodation, cancellationToken);
                await _accommodationRepository.SaveChangesAsync(cancellationToken);

                var response = _mapper.Map<AccommodationDto>(result);
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
    }
}
