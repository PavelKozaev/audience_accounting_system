﻿using BuildingService.Application.Contracts;
using BuildingService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuildingService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _service;

        public BuildingController(IBuildingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<BuildingDto>>> GetBuildings()
        {
            var buildings = await _service.GetBuildingsAsync();
            return Ok(buildings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingDto>> GetBuilding(int id)
        {
            var building = await _service.GetBuildingByIdAsync(id);            
            return Ok(building);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBuilding(BuildingCreateDto buildingCreateDto)
        {
            var buildingId = await _service.AddBuildingAsync(buildingCreateDto);
            return CreatedAtAction(nameof(GetBuilding), new { id = buildingId }, buildingCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBuilding(int id, BuildingUpdateDto buildingUpdateDto)
        {              
            await _service.UpdateBuildingAsync(id, buildingUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBuilding(int id)
        {                       
            await _service.DeleteBuildingAsync(id);
            return NoContent();
        }
    }
}
