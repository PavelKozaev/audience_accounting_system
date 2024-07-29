using AudienceService.Application.Contracts;
using AudienceService.Application.Services;
using AudienceService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AudienceService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudienceController : ControllerBase
    {
        private readonly IAudienceService _service;

        public AudienceController(IAudienceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<AudienceDto>>> GetAudiences()
        {
            var audiences = await _service.GetAudiencesAsync();
            return Ok(audiences);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AudienceDto>> GetAudience(int id)
        {
            var audience = await _service.GetAudienceByIdAsync(id);
            return Ok(audience);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAudience(AudienceCreateDto audienceCreateDto)
        {
            var audienceId = await _service.AddAudienceAsync(audienceCreateDto);
            return CreatedAtAction(nameof(GetAudience), new { id = audienceId }, audienceCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAudience(int id, AudienceUpdateDto audienceUpdateDto)
        {
            await _service.UpdateAudienceAsync(id, audienceUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAudience(int id)
        {            
            await _service.DeleteAudienceAsync(id);
            return NoContent();
        }

        [HttpGet("building/{buildingId}")]
        public async Task<ActionResult<List<AudienceDto>>> GetAudiencesByBuildingId(int buildingId)
        {
            var audiences = await _service.GetAudiencesByBuildingIdAsync(buildingId);
            return Ok(audiences);
        }
    }
}
