﻿namespace BuildingService.Api.Models
{
    public class BuildingCreateDto
    {        
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Floors { get; set; }
    }
}
