namespace AudienceService.Application.Contracts
{
    public class AudienceDto
    {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public string Number { get; set; }
        public int BuildingId { get; set; }
    }
}
