namespace AudienceService.Application.Contracts
{
    public class AudienceUpdateDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public string Number { get; set; }
        public int BuildingId { get; set; }
    }
}
