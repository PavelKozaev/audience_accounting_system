﻿namespace AudienceService.Application.Contracts
{
    public class BuildingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AudienceDto> Audiences { get; set; }
    }
}