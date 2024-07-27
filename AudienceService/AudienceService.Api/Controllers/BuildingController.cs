using AudienceService.Application.Contracts;
using AudienceService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AudienceService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : Controller
    {
        private readonly IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BuildingDto>>> GetBuildings()
        {
            var buildings = await _buildingService.GetBuildingsAsync();
            return Ok(buildings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingDto>> GetBuilding(int id)
        {
            var building = await _buildingService.GetBuildingByIdAsync(id);
            return Ok(building);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBuilding(BuildingCreateDto buildingCreateDto)
        {
            var buildingId = await _buildingService.AddBuildingAsync(buildingCreateDto);
            return CreatedAtAction(nameof(GetBuilding), new { id = buildingId }, buildingCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBuilding(int id, BuildingUpdateDto buildingUpdateDto)
        {
            await _buildingService.UpdateBuildingAsync(id, buildingUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBuilding(int id)
        {
            await _buildingService.DeleteBuildingAsync(id);
            return NoContent();
        }
    }
}
